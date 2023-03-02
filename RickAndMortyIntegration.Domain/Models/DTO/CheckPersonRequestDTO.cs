using Newtonsoft.Json;

namespace RickAndMortyIntegration.Domain.Models.DTO
{
    public class CheckPersonRequestDTO
    {
        [JsonProperty("personName")]
        public string PersonName { get; set; }

        [JsonProperty("episodeName")]
        public string EpisodeName { get; set; }
    }
}
