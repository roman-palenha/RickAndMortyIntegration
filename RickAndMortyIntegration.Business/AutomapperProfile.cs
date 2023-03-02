using AutoMapper;
using RickAndMortyIntegration.Domain.Models;
using RickAndMortyIntegration.Domain.Models.DTO;

namespace RickAndMortyIntegration.Business
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<(PersonDTO, LocationDTO), Person>()
                .ForMember(p => p.Name, pl => pl.MapFrom(x => x.Item1.Name))
                .ForMember(p => p.Status, pl => pl.MapFrom(x => x.Item1.Status))
                .ForMember(p => p.Species, pl => pl.MapFrom(x => x.Item1.Species))
                .ForMember(p => p.Type, pl => pl.MapFrom(x => x.Item1.Type))
                .ForMember(p => p.Gender, pl => pl.MapFrom(x => x.Item1.Gender))
                .ForPath(p => p.Origin.Type, pl => pl.MapFrom(x => x.Item2.Type))
                .ForPath(p => p.Origin.Name, pl => pl.MapFrom(x => x.Item2.Name))
                .ForPath(p => p.Origin.Dimension, pl => pl.MapFrom(x => x.Item2.Dimension));
        }
    }
}
