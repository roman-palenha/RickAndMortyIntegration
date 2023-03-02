using Newtonsoft.Json;

namespace RickAndMortyIntegration.Domain.Models.Responses
{
    public class PersonOrigin
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("dimension")]
        public string Dimension { get; set; }
    }
}
