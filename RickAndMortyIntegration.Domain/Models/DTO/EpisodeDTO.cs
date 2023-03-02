using Newtonsoft.Json;

namespace RickAndMortyIntegration.Domain.Models.DTO
{
    public class EpisodeDTO
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("air_date")]
        public string AirDate { get; set; }

        [JsonProperty("episode")]
        public string Episode { get; set; }

        [JsonProperty("characters")]
        public List<string> Characters { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("created")]
        public DateTime Created { get; set; }
    }
}
