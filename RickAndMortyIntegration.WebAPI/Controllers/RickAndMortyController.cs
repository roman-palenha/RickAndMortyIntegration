using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using RickAndMortyIntegration.Business.Services.Interfaces;
using RickAndMortyIntegration.Domain.Models;
using RickAndMortyIntegration.Domain.Models.DTO;

namespace RickAndMortyIntegration.WebAPI.Controllers
{
    [Route("api/v1")]
    [ApiController]
    public class RickAndMortyController : ControllerBase
    {
        private readonly IRickAndMortyService _rickAndMortyService;
        private readonly MemoryCacheEntryOptions _memoryCacheEntryOptions;
        private IMemoryCache _cache;
        public RickAndMortyController(IRickAndMortyService rickAndMortyService, IMemoryCache cache)
        {
            _rickAndMortyService = rickAndMortyService ?? throw new ArgumentNullException(nameof(rickAndMortyService));
            _cache = cache ?? throw new ArgumentNullException(nameof(cache));

            _memoryCacheEntryOptions =  new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromSeconds(60))
                .SetAbsoluteExpiration(TimeSpan.FromSeconds(3600))
                .SetPriority(CacheItemPriority.Normal)
                .SetSize(1024);
        }

        [HttpPost("/check-person")]
        public async Task<IActionResult> CheckPerson([FromBody] CheckPersonRequestDTO checkPersonRequestDto)
        {
            var foundInCache = _cache.TryGetValue(checkPersonRequestDto.ToString(), out bool result);
            if (!foundInCache)
            {
                result = await _rickAndMortyService.CheckPerson(checkPersonRequestDto);
                _cache.Set(checkPersonRequestDto.ToString(), result, _memoryCacheEntryOptions);
            }
            
           return Ok(result);
        }

        [HttpGet("/person")]
        public async Task<IActionResult> GetPerson(string name)
        {
            var foundInCache = _cache.TryGetValue(name, out Person result);
            if (!foundInCache)
            {
                result = await _rickAndMortyService.GetPerson(name);
                _cache.Set(name, result, _memoryCacheEntryOptions);
            }

            return Ok(result);
        }
    }
}
