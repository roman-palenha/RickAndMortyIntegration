using Newtonsoft.Json;

namespace RickAndMortyIntegration.Domain.Models.DTO
{
    public class PersonOriginDTO
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
