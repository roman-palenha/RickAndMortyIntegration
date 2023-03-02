using RickAndMortyIntegration.Domain.Models;
using RickAndMortyIntegration.Domain.Models.DTO;

namespace RickAndMortyIntegration.Business.Services.Interfaces
{
    public interface IRickAndMortyService
    {
        Task<bool> CheckPerson(CheckPersonRequestDTO checkPersonDto);
        Task<Person> GetPerson(string name);
    }
}
