using System.Text.Json.Serialization;

namespace FhrWasm.RatingsApi;

public record EstablishmentsRoot([property: JsonPropertyName("establishments")] IEnumerable<Establishment> Establishments);
