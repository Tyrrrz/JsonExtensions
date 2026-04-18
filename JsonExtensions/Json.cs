using System.Text.Json;

namespace JsonExtensions;

/// <summary>
/// Provides helper methods for parsing raw JSON into <see cref="JsonElement"/> values.
/// </summary>
public static class Json
{
    /// <summary>
    /// Parses the UTF-8 encoded JSON byte array and returns its root element.
    /// </summary>
    public static JsonElement Parse(byte[] json, JsonDocumentOptions options = default)
    {
        using var document = JsonDocument.Parse(json, options);
        return document.RootElement.Clone();
    }

    /// <summary>
    /// Parses the JSON string and returns its root element.
    /// </summary>
    public static JsonElement Parse(string json, JsonDocumentOptions options = default)
    {
        using var document = JsonDocument.Parse(json, options);
        return document.RootElement.Clone();
    }

    /// <summary>
    /// Attempts to parse the UTF-8 encoded JSON byte array and returns its root element,
    /// or null if the input is not valid JSON.
    /// </summary>
    public static JsonElement? TryParse(byte[] json, JsonDocumentOptions options = default)
    {
        try
        {
            return Parse(json, options);
        }
        catch (JsonException)
        {
            return null;
        }
    }

    /// <summary>
    /// Attempts to parse the JSON string and returns its root element,
    /// or null if the input is not valid JSON.
    /// </summary>
    public static JsonElement? TryParse(string json, JsonDocumentOptions options = default)
    {
        try
        {
            return Parse(json, options);
        }
        catch (JsonException)
        {
            return null;
        }
    }
}
