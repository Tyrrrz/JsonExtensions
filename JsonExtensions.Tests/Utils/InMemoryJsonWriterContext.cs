using System;
using System.IO;
using System.Text;
using System.Text.Json;

namespace JsonExtensions.Tests.Utils;

internal class InMemoryJsonWriterContext : IDisposable
{
    private readonly MemoryStream _buffer = new();

    public Utf8JsonWriter Writer { get; }

    public InMemoryJsonWriterContext() => Writer = new Utf8JsonWriter(_buffer);

    public byte[] GetBytes()
    {
        Writer.Flush();
        return _buffer.ToArray();
    }

    public string GetString() => Encoding.UTF8.GetString(GetBytes());

    public void Dispose()
    {
        Writer.Dispose();
        _buffer.Dispose();
    }
}
