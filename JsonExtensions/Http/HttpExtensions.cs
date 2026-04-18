using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace JsonExtensions.Http;

/// <summary>
/// Extensions for working with JSON over HTTP, bridging <see cref="System.Text.Json"/> and <see cref="System.Net.Http"/>.
/// </summary>
public static class HttpExtensions
{
    /// <inheritdoc cref="HttpExtensions" />
    extension(HttpContent content)
    {
        /// <summary>
        /// Reads the HTTP content body and deserializes it as a <see cref="JsonElement"/>.
        /// </summary>
        public async Task<JsonElement> ReadAsJsonAsync(
            CancellationToken cancellationToken = default
        )
        {
            using var stream = await content
                .ReadAsStreamAsync(cancellationToken)
                .ConfigureAwait(false);

            using var document = await JsonDocument
                .ParseAsync(stream, default, cancellationToken)
                .ConfigureAwait(false);

            return document.RootElement.Clone();
        }
    }

    /// <inheritdoc cref="HttpExtensions" />
    extension(HttpClient http)
    {
        /// <summary>
        /// Sends a GET request to <paramref name="requestUri"/> and deserializes the response body as a <see cref="JsonElement"/>.
        /// </summary>
        public async Task<JsonElement> GetJsonAsync(
            Uri requestUri,
            CancellationToken cancellationToken = default
        )
        {
            using var response = await http.GetAsync(
                    requestUri,
                    HttpCompletionOption.ResponseHeadersRead,
                    cancellationToken
                )
                .ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsJsonAsync(cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Sends a GET request to <paramref name="requestUri"/> and deserializes the response body as a <see cref="JsonElement"/>.
        /// </summary>
        public async Task<JsonElement> GetJsonAsync(
            string requestUri,
            CancellationToken cancellationToken = default
        ) =>
            await http.GetJsonAsync(
                    new Uri(requestUri, UriKind.RelativeOrAbsolute),
                    cancellationToken
                )
                .ConfigureAwait(false);
    }
}
