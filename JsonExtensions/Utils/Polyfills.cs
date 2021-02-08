// ReSharper disable CheckNamespace

// Polyfills to bridge the missing APIs in older versions of the framework/standard.

using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

#if NETSTANDARD2_0 || NETCOREAPP3_0
internal static partial class PolyfillExtensions
{
    public static async Task<Stream> ReadAsStreamAsync(
        this HttpContent httpContent,
        CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        return await httpContent.ReadAsStreamAsync();
    }
}
#endif

#if NETSTANDARD2_0
internal static partial class PolyfillExtensions
{
    public static string[] Split(this string str, char c, StringSplitOptions options = StringSplitOptions.None) =>
        str.Split(new[] {c}, options);

    public static void Deconstruct<TKey, TValue>(this KeyValuePair<TKey, TValue> pair, out TKey key, out TValue value)
    {
        key = pair.Key;
        value = pair.Value;
    }
}
#endif