using System.Text.Json.Serialization;
namespace FhrWasm.Model;
public record AuthoritiesRoot([property: JsonPropertyName("authorities")] IEnumerable<Authority> Authorities);