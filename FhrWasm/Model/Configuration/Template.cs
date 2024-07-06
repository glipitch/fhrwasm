namespace FhrWasm.Model.Configuration;

public class Template
{
    public string? SchemeName { get; set; }

    public Dictionary<string, Rating>? Ratings { get; set; }
}