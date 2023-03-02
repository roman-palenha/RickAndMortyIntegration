using AutoMapper;
using RickAndMortyIntegration.Business.Services.Interfaces;
using RickAndMortyIntegration.Business.Validation;
using RickAndMortyIntegration.Domain.Models;
using RickAndMortyIntegration.Domain.Models.DTO;
using RickAndMortyIntegration.Domain.Models.JSON;

namespace RickAndMortyIntegration.Business.Services
{
    public class RickAndMortyService : IRickAndMortyService
    {
        private readonly IHttpRequestService _httpRequestService;
        private readonly IMapper _mapper;

        public RickAndMortyService(IHttpRequestService htpHttpRequestService, IMapper mapper)
        {
            _httpRequestService = htpHttpRequestService ?? throw new ArgumentNullException(nameof(htpHttpRequestService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<bool> CheckPerson(CheckPersonRequestDTO checkPersonDto)
        {
            if(checkPersonDto == null)
                throw new ArgumentNullException(nameof(checkPersonDto));

            var uri = RickAndMorty.Uri + RickAndMorty.Character + RickAndMorty.Name + checkPersonDto.PersonName;
            var persons = await _httpRequestService.ExecuteGetRequest<RootJSON<PersonDTO>>(uri);
            var personDto = persons.Results.FirstOrDefault();
            if (personDto == null)
                throw new RickAndMortyException("Person is null.");

            uri = RickAndMorty.Uri + RickAndMorty.Episode + RickAndMorty.Name + checkPersonDto.EpisodeName;
            var episodes = await _httpRequestService.ExecuteGetRequest<RootJSON<EpisodeDTO>>(uri);
            var episodeDto = episodes.Results.FirstOrDefault();
            if (episodeDto == null)
                throw new RickAndMortyException("Episode is null.");

            return episodeDto.Characters.Contains(personDto.Url);
        }

        public async Task<Person> GetPerson(string name)
        {
            if(string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));

            var uri = RickAndMorty.Uri + RickAndMorty.Character + RickAndMorty.Name + name;
            var persons = await _httpRequestService.ExecuteGetRequest<RootJSON<PersonDTO>>(uri);
            var personDto = persons.Results.FirstOrDefault();
            if (personDto == null)
                throw new RickAndMortyException("Person is null.");

            var locationDto = string.IsNullOrEmpty(personDto.Origin.Url)
                ? new LocationDTO() { Name = personDto.Origin.Name }
                : await _httpRequestService.ExecuteGetRequest<LocationDTO>(personDto.Origin.Url);
            var person = _mapper.Map<Person>((personDto, locationDto));

            return person;
        }
    }
}
