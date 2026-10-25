using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace JsonExtensions;

/// <summary>
/// Extensions for <see cref="HttpContent" />.
/// </summary>
public static class HttpContentExtensions
{
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
}
