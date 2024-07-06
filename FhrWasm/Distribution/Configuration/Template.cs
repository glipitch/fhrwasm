namespace FhrWasm.Distribution.Configuration;

public class Template
{
    public string? SchemeName { get; set; }
    public string? ImageRoot { get; set; }
    public Dictionary<string, Rating>? Ratings { get; set; }
}
