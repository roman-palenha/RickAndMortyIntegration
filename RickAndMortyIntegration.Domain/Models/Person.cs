using Newtonsoft.Json;

namespace RickAndMortyIntegration.Domain.Models
{
    public class Person
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("species")]
        public string Species { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("origin")]
        public PersonOrigin Origin { get; set; }
    }
}
