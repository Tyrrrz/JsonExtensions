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
        this HttpContent httpContent,
        CancellationToken cancellationToken = default)
    {
        using var stream = await httpContent.ReadAsStreamAsync(cancellationToken);
        using var document = await JsonDocument.ParseAsync(stream, default, cancellationToken);

        return document.RootElement.Clone();
    }

    /// <summary>
    /// Sends a GET request and reads the response content as JSON.
    /// </summary>
    public static async Task<JsonElement> GetJsonAsync(
        this HttpClient httpClient,
        Uri requestUri,
        CancellationToken cancellationToken = default)
    {
        using var response = await httpClient.GetAsync(
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
        this HttpClient httpClient,
        string requestUri,
        CancellationToken cancellationToken = default) =>
        await httpClient.GetJsonAsync(new Uri(requestUri, UriKind.RelativeOrAbsolute), cancellationToken);
}