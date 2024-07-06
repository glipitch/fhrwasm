using System.Text.Json.Serialization;
namespace FhrWasm.RatingsApi;
public record AuthoritiesRoot([property: JsonPropertyName("authorities")] IEnumerable<Authority> Authorities);