namespace RickAndMortyIntegration.Business.Services.Interfaces
{
    public interface IHttpRequestService
    {
        Task<TResponse> ExecuteGetRequest<TResponse>(string uri);
    }
}
