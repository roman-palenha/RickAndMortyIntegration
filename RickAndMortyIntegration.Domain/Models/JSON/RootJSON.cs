using Newtonsoft.Json;

namespace RickAndMortyIntegration.Domain.Models.JSON
{
    public class RootJSON<T>
    {
        [JsonProperty("results")]
        public List<T> Results { get; set; }
    }
}
