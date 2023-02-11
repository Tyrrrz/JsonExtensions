using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace JsonExtensions.Http;

/// <summary>
/// Extensions to bridge <see cref="System.Text.Json"/> and <see cref="System.Net.Http"/>.
/// </summary>
public static class HttpExtensions
{
    /// <summary>
    /// Reads the content as JSON.
    /// </summary>
    public static async Task<JsonElement> ReadAsJsonAsync(
        this HttpContent content,
        CancellationToken cancellationToken = default)
    {
        using var stream = await content.ReadAsStreamAsync(cancellationToken);
        using var document = await JsonDocument.ParseAsync(stream, default, cancellationToken);

        return document.RootElement.Clone();
    }

    /// <summary>
    /// Sends a GET request and reads the response content as JSON.
    /// </summary>
    public static async Task<JsonElement> GetJsonAsync(
        this HttpClient http,
        Uri requestUri,
        CancellationToken cancellationToken = default)
    {
        using var response = await http.GetAsync(
            requestUri,
            HttpCompletionOption.ResponseHeadersRead,
            cancellationToken
        );

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadAsJsonAsync(cancellationToken);
    }

    /// <summary>
    /// Sends a GET request and reads the response content as JSON.
    /// </summary>
    public static async Task<JsonElement> GetJsonAsync(
        this HttpClient http,
        string requestUri,
        CancellationToken cancellationToken = default) =>
        await http.GetJsonAsync(new Uri(requestUri, UriKind.RelativeOrAbsolute), cancellationToken);
}