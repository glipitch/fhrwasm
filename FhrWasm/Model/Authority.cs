using System.Text.Json.Serialization;

namespace FhrWasm.Model
{
    public record Authority
    {
        [JsonPropertyName("LocalAuthorityId")]
        public int Id { get; set; }
        public string? Name { get; set; }
        public SchemeTypes SchemeType { get; set; }
    }
}
