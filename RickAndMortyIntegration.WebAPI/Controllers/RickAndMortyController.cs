using Microsoft.AspNetCore.Mvc;
using RickAndMortyIntegration.Business.Services.Interfaces;
using RickAndMortyIntegration.Domain.Models.DTO;

namespace RickAndMortyIntegration.WebAPI.Controllers
{
    [Route("api/v1")]
    [ApiController]
    public class RickAndMortyController : ControllerBase
    {
        private readonly IRickAndMortyService _rickAndMortyService;
        public RickAndMortyController(IRickAndMortyService rickAndMortyService)
        {
            _rickAndMortyService = rickAndMortyService ?? throw new ArgumentNullException(nameof(rickAndMortyService));
        }

        [ResponseCache(Duration = 300, Location = ResponseCacheLocation.Any)]
        [HttpPost("/check-person")]
        public async Task<IActionResult> CheckPerson([FromBody] CheckPersonRequestDTO checkPersonRequestDto)
        {
           var result = await _rickAndMortyService.CheckPerson(checkPersonRequestDto);
           return Ok(result);
        }

        [ResponseCache(Duration = 300, Location = ResponseCacheLocation.Any)]
        [HttpGet("/person")]
        public async Task<IActionResult> GetPerson(string name)
        {
            var result = await _rickAndMortyService.GetPerson(name);
            return Ok(result);
        }
    }
}
