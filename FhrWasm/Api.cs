

using FhrWasm.Model;

using System.Text.Json;

namespace FhrWasm;

public class Api(IHttpClientFactory httpClientFactory)
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
    public async Task<Dictionary<string, decimal>> GetRatings(int authorityId)
    {
        var establishments = await GetEstablishments(authorityId);
        var totalCount = establishments.Count();
        var groupedByRating = establishments.GroupBy(establishment => establishment.RatingValue);

        return groupedByRating
            .ToDictionary(group => group.Key, group => ((decimal)group.Count()).AsFractionOf(totalCount));
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
