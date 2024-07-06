using System.Text.Json;

namespace FhrWasm.RatingsApi;

public class RatingsApiService(IHttpClientFactory httpClientFactory) 
{
    public async Task<IEnumerable<Authority>> GetAuthorities()
    {
        var root = await GetFsaResource<AuthoritiesRoot>("authorities/basic");
        return root.Authorities;
    }

    public async Task<IEnumerable<Establishment>> GetEstablishments(int authorityId)
    {
        var root = await GetFsaResource<EstablishmentsRoot>($"establishments?localauthorityid={authorityId}");

        return root.Establishments;
    }

    private async Task<T> GetFsaResource<T>(string path)
    {
        var client = httpClientFactory.CreateClient("ratings-api");
        using var response = await client.GetAsync(path, HttpCompletionOption.ResponseHeadersRead);
        response.EnsureSuccessStatusCode();
        var stream = await response.Content.ReadAsStreamAsync();
        return await JsonSerializer.DeserializeAsync<T>(stream) ?? throw new InvalidDataException();
    }
}
