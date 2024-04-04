using System.Text.Json.Serialization;

namespace CompilerVsAsync.Entities;

public record Post(
    [property: JsonPropertyName("id")] int Id,
    [property: JsonPropertyName("title")] string Title,
    [property: JsonPropertyName("body")] string Body);