using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace JsonExtensions;

/// <summary>
/// Extensions for <see cref="HttpClient" />.
/// </summary>
public static class HttpClientExtensions
{
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

        /// <inheritdoc cref="GetJsonAsync(HttpClient, Uri, CancellationToken)" />
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
