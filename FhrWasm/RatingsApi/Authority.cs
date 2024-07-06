using System.Text.Json.Serialization;

namespace FhrWasm.RatingsApi
{
    public record Authority
    {
        [JsonPropertyName("LocalAuthorityId")]
        public int Id { get; set; }
        public string? Name { get; set; }
        public SchemeTypes SchemeType { get; set; }
    }
}
