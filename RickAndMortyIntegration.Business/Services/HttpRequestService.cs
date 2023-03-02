using Newtonsoft.Json;
using RickAndMortyIntegration.Business.Services.Interfaces;

namespace RickAndMortyIntegration.Business.Services
{
    public class HttpRequestService : IHttpRequestService
    {
        public async Task<TResponse> ExecuteGetRequest<TResponse>(string uri)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(uri),
            };

            using var client = new HttpClient();
            using var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var body = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TResponse>(body) ?? throw new InvalidOperationException("Response body could not be converted.");
        }
    }
}
