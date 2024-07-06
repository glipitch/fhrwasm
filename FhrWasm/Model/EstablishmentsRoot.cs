using System.Text.Json.Serialization;

namespace FhrWasm.Model;

public record EstablishmentsRoot([property: JsonPropertyName("establishments")] IEnumerable<Establishment> Establishments);