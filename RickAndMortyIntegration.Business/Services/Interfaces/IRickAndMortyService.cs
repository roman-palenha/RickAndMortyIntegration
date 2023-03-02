using RickAndMortyIntegration.Domain.Models;
using RickAndMortyIntegration.Domain.Models.Requests;

namespace RickAndMortyIntegration.Business.Services.Interfaces
{
    public interface IRickAndMortyService
    {
        bool CheckPerson(CheckPersonRequestDTO checkPersonDto);
        Person GetPerson(string name);
    }
}
