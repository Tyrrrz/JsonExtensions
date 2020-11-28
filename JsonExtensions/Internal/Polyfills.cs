// ReSharper disable CheckNamespace

// Polyfills to bridge the missing APIs in older versions of the framework/standard.

#if NETSTANDARD2_0 || NETCOREAPP3_0
namespace System.Net.Http
{
    using IO;
    using Threading;
    using Threading.Tasks;

    internal static class PolyfillExtensions
    {
        public static async Task<Stream> ReadAsStreamAsync(
            this HttpContent httpContent,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await httpContent.ReadAsStreamAsync();
        }
    }
}
#endif

#if NETSTANDARD2_0
namespace System
{
    internal static class PolyfillExtensions
    {
        public static string[] Split(this string str, char c, StringSplitOptions options = StringSplitOptions.None) =>
            str.Split(new[] {c}, options);
    }
}

namespace System.Collections.Generic
{
    internal static class PolyfillExtensions
    {
        public static void Deconstruct<TKey, TValue>(this KeyValuePair<TKey, TValue> pair, out TKey key, out TValue value)
        {
            key = pair.Key;
            value = pair.Value;
        }
    }
}
#endif