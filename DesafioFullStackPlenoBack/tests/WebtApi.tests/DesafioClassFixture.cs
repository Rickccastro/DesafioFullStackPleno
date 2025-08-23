using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace WebtApi.tests;
public class DesafioClassFixture : IClassFixture<CustomWebApplicationFactory>
{
    private readonly HttpClient _httpClient;

    public DesafioClassFixture(CustomWebApplicationFactory webApplicationFactory)
    {
        _httpClient = webApplicationFactory.CreateClient();
    }

    protected async Task<HttpResponseMessage> RequestPost(
        string requestUri,
        object request,
        string token = ""
       )
    {
        AuthorizeRequest(token);

        return await _httpClient.PostAsJsonAsync(requestUri, request);
    }

    protected async Task<HttpResponseMessage> RequestPut(
        string requestUri,
        object request,
        string token
        )
    {
        AuthorizeRequest(token);

        return await _httpClient.PutAsJsonAsync(requestUri, request);
    }

    protected async Task<HttpResponseMessage> RequestGet(
        string requestUri,
        string token
        )
    {
        AuthorizeRequest(token);

        return await _httpClient.GetAsync(requestUri);
    }

    protected async Task<HttpResponseMessage> RequestDelete(
        string requestUri,
        string token
        )
    {
        AuthorizeRequest(token);

        return await _httpClient.DeleteAsync(requestUri);
    }

    private void AuthorizeRequest(string token)
    {
        if (string.IsNullOrWhiteSpace(token))
        {
            return;
        }

        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
    }
}