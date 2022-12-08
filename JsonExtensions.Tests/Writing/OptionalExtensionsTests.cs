using System;
using FluentAssertions;
using JsonExtensions.Tests.Utils;
using JsonExtensions.Writing;
using Xunit;

namespace JsonExtensions.Tests.Writing;

public class OptionalExtensionsTests
{
    [Fact]
    public void WriteBoolean_Actual_Test()
    {
        // Arrange
        var context = new InMemoryJsonWriterContext();

        // Act
        context.Writer.WriteStartObject();
        context.Writer.WriteBoolean("foo", new bool?(true));
        context.Writer.WriteEndObject();

        // Assert
        context.GetString().Should().Be(
            // language=JSON
            """
            {"foo":true}
            """
        );
    }

    [Fact]
    public void WriteBoolean_Null_Test()
    {
        // Arrange
        var context = new InMemoryJsonWriterContext();

        // Act
        context.Writer.WriteStartObject();
        context.Writer.WriteBoolean("foo", new bool?());
        context.Writer.WriteEndObject();

        // Assert
        context.GetString().Should().Be(
            // language=JSON
            """
            {"foo":null}
            """
        );
    }

    [Fact]
    public void WriteNumber_Byte_Actual_Test()
    {
        // Arrange
        var context = new InMemoryJsonWriterContext();

        // Act
        context.Writer.WriteStartObject();
        context.Writer.WriteNumber("foo", new byte?(13));
        context.Writer.WriteEndObject();

        // Assert
        context.GetString().Should().Be(
            // language=JSON
            """
            {"foo":13}
            """
        );
    }

    [Fact]
    public void WriteNumber_Byte_Null_Test()
    {
        // Arrange
        var context = new InMemoryJsonWriterContext();

        // Act
        context.Writer.WriteStartObject();
        context.Writer.WriteNumber("foo", new byte?());
        context.Writer.WriteEndObject();

        // Assert
        context.GetString().Should().Be(
            // language=JSON
            """
            {"foo":null}
            """
        );
    }

    [Fact]
    public void WriteNumber_Decimal_Actual_Test()
    {
        // Arrange
        var context = new InMemoryJsonWriterContext();

        // Act
        context.Writer.WriteStartObject();
        context.Writer.WriteNumber("foo", new decimal?(13));
        context.Writer.WriteEndObject();

        // Assert
        context.GetString().Should().Be(
            // language=JSON
            """
            {"foo":13}
            """
        );
    }

    [Fact]
    public void WriteNumber_Decimal_Null_Test()
    {
        // Arrange
        var context = new InMemoryJsonWriterContext();

        // Act
        context.Writer.WriteStartObject();
        context.Writer.WriteNumber("foo", new decimal?());
        context.Writer.WriteEndObject();

        // Assert
        context.GetString().Should().Be(
            // language=JSON
            """
            {"foo":null}
            """
        );
    }

    [Fact]
    public void WriteNumber_Double_Actual_Test()
    {
        // Arrange
        var context = new InMemoryJsonWriterContext();

        // Act
        context.Writer.WriteStartObject();
        context.Writer.WriteNumber("foo", new double?(13));
        context.Writer.WriteEndObject();

        // Assert
        context.GetString().Should().Be(
            // language=JSON
            """
            {"foo":13}
            """
        );
    }

    [Fact]
    public void WriteNumber_Double_Null_Test()
    {
        // Arrange
        var context = new InMemoryJsonWriterContext();

        // Act
        context.Writer.WriteStartObject();
        context.Writer.WriteNumber("foo", new double?());
        context.Writer.WriteEndObject();

        // Assert
        context.GetString().Should().Be(
            // language=JSON
            """
            {"foo":null}
            """
        );
    }

    [Fact]
    public void WriteNumber_Float_Actual_Test()
    {
        // Arrange
        var context = new InMemoryJsonWriterContext();

        // Act
        context.Writer.WriteStartObject();
        context.Writer.WriteNumber("foo", new float?(13));
        context.Writer.WriteEndObject();

        // Assert
        context.GetString().Should().Be(
            // language=JSON
            """
            {"foo":13}
            """
        );
    }

    [Fact]
    public void WriteNumber_Float_Null_Test()
    {
        // Arrange
        var context = new InMemoryJsonWriterContext();

        // Act
        context.Writer.WriteStartObject();
        context.Writer.WriteNumber("foo", new float?());
        context.Writer.WriteEndObject();

        // Assert
        context.GetString().Should().Be(
            // language=JSON
            """
            {"foo":null}
            """
        );
    }

    [Fact]
    public void WriteNumber_Short_Actual_Test()
    {
        // Arrange
        var context = new InMemoryJsonWriterContext();

        // Act
        context.Writer.WriteStartObject();
        context.Writer.WriteNumber("foo", new short?(13));
        context.Writer.WriteEndObject();

        // Assert
        context.GetString().Should().Be(
            // language=JSON
            """
            {"foo":13}
            """
        );
    }

    [Fact]
    public void WriteNumber_Short_Null_Test()
    {
        // Arrange
        var context = new InMemoryJsonWriterContext();

        // Act
        context.Writer.WriteStartObject();
        context.Writer.WriteNumber("foo", new short?());
        context.Writer.WriteEndObject();

        // Assert
        context.GetString().Should().Be(
            // language=JSON
            """
            {"foo":null}
            """
        );
    }

    [Fact]
    public void WriteNumber_Int_Actual_Test()
    {
        // Arrange
        var context = new InMemoryJsonWriterContext();

        // Act
        context.Writer.WriteStartObject();
        context.Writer.WriteNumber("foo", new int?(13));
        context.Writer.WriteEndObject();

        // Assert
        context.GetString().Should().Be(
            // language=JSON
            """
            {"foo":13}
            """
        );
    }

    [Fact]
    public void WriteNumber_Int_Null_Test()
    {
        // Arrange
        var context = new InMemoryJsonWriterContext();

        // Act
        context.Writer.WriteStartObject();
        context.Writer.WriteNumber("foo", new int?());
        context.Writer.WriteEndObject();

        // Assert
        context.GetString().Should().Be(
            // language=JSON
            """
            {"foo":null}
            """
        );
    }

    [Fact]
    public void WriteNumber_Long_Actual_Test()
    {
        // Arrange
        var context = new InMemoryJsonWriterContext();

        // Act
        context.Writer.WriteStartObject();
        context.Writer.WriteNumber("foo", new long?(13));
        context.Writer.WriteEndObject();

        // Assert
        context.GetString().Should().Be(
            // language=JSON
            """
            {"foo":13}
            """
        );
    }

    [Fact]
    public void WriteNumber_Long_Null_Test()
    {
        // Arrange
        var context = new InMemoryJsonWriterContext();

        // Act
        context.Writer.WriteStartObject();
        context.Writer.WriteNumber("foo", new long?());
        context.Writer.WriteEndObject();

        // Assert
        context.GetString().Should().Be(
            // language=JSON
            """
            {"foo":null}
            """
        );
    }

    [Fact]
    public void WriteNumber_SByte_Actual_Test()
    {
        // Arrange
        var context = new InMemoryJsonWriterContext();

        // Act
        context.Writer.WriteStartObject();
        context.Writer.WriteNumber("foo", new sbyte?(13));
        context.Writer.WriteEndObject();

        // Assert
        context.GetString().Should().Be(
            // language=JSON
            """
            {"foo":13}
            """
        );
    }

    [Fact]
    public void WriteNumber_SByte_Null_Test()
    {
        // Arrange
        var context = new InMemoryJsonWriterContext();

        // Act
        context.Writer.WriteStartObject();
        context.Writer.WriteNumber("foo", new sbyte?());
        context.Writer.WriteEndObject();

        // Assert
        context.GetString().Should().Be(
            // language=JSON
            """
            {"foo":null}
            """
        );
    }

    [Fact]
    public void WriteNumber_UShort_Actual_Test()
    {
        // Arrange
        var context = new InMemoryJsonWriterContext();

        // Act
        context.Writer.WriteStartObject();
        context.Writer.WriteNumber("foo", new ushort?(13));
        context.Writer.WriteEndObject();

        // Assert
        context.GetString().Should().Be(
            // language=JSON
            """
            {"foo":13}
            """
        );
    }

    [Fact]
    public void WriteNumber_UShort_Null_Test()
    {
        // Arrange
        var context = new InMemoryJsonWriterContext();

        // Act
        context.Writer.WriteStartObject();
        context.Writer.WriteNumber("foo", new ushort?());
        context.Writer.WriteEndObject();

        // Assert
        context.GetString().Should().Be(
            // language=JSON
            """
            {"foo":null}
            """
        );
    }

    [Fact]
    public void WriteNumber_UInt_Actual_Test()
    {
        // Arrange
        var context = new InMemoryJsonWriterContext();

        // Act
        context.Writer.WriteStartObject();
        context.Writer.WriteNumber("foo", new uint?(13));
        context.Writer.WriteEndObject();

        // Assert
        context.GetString().Should().Be(
            // language=JSON
            """
            {"foo":13}
            """
        );
    }

    [Fact]
    public void WriteNumber_UInt_Null_Test()
    {
        // Arrange
        var context = new InMemoryJsonWriterContext();

        // Act
        context.Writer.WriteStartObject();
        context.Writer.WriteNumber("foo", new uint?());
        context.Writer.WriteEndObject();

        // Assert
        context.GetString().Should().Be(
            // language=JSON
            """
            {"foo":null}
            """
        );
    }

    [Fact]
    public void WriteNumber_ULong_Actual_Test()
    {
        // Arrange
        var context = new InMemoryJsonWriterContext();

        // Act
        context.Writer.WriteStartObject();
        context.Writer.WriteNumber("foo", new ulong?(13));
        context.Writer.WriteEndObject();

        // Assert
        context.GetString().Should().Be(
            // language=JSON
            """
            {"foo":13}
            """
        );
    }

    [Fact]
    public void WriteNumber_ULong_Null_Test()
    {
        // Arrange
        var context = new InMemoryJsonWriterContext();

        // Act
        context.Writer.WriteStartObject();
        context.Writer.WriteNumber("foo", new ulong?());
        context.Writer.WriteEndObject();

        // Assert
        context.GetString().Should().Be(
            // language=JSON
            """
            {"foo":null}
            """
        );
    }

    [Fact]
    public void WriteString_Guid_Actual_Test()
    {
        // Arrange
        var context = new InMemoryJsonWriterContext();

        // Act
        context.Writer.WriteStartObject();
        context.Writer.WriteString("foo", new Guid?(Guid.Empty));
        context.Writer.WriteEndObject();

        // Assert
        context.GetString().Should().Be(
            // language=JSON
            """
            {"foo":"00000000-0000-0000-0000-000000000000"}
            """
        );
    }

    [Fact]
    public void WriteString_Guid_Null_Test()
    {
        // Arrange
        var context = new InMemoryJsonWriterContext();

        // Act
        context.Writer.WriteStartObject();
        context.Writer.WriteString("foo", new Guid?());
        context.Writer.WriteEndObject();

        // Assert
        context.GetString().Should().Be(
            // language=JSON
            """
            {"foo":null}
            """
        );
    }

    [Fact]
    public void WriteString_DateTime_Actual_Test()
    {
        // Arrange
        var context = new InMemoryJsonWriterContext();

        // Act
        context.Writer.WriteStartObject();
        context.Writer.WriteString("foo", new DateTime?(DateTime.UnixEpoch));
        context.Writer.WriteEndObject();

        // Assert
        context.GetString().Should().Be(
            // language=JSON
            """
            {"foo":"1970-01-01T00:00:00Z"}
            """
        );
    }

    [Fact]
    public void WriteString_DateTime_Null_Test()
    {
        // Arrange
        var context = new InMemoryJsonWriterContext();

        // Act
        context.Writer.WriteStartObject();
        context.Writer.WriteString("foo", new DateTime?());
        context.Writer.WriteEndObject();

        // Assert
        context.GetString().Should().Be(
            // language=JSON
            """
            {"foo":null}
            """
        );
    }

    [Fact]
    public void WriteString_DateTimeOffset_Actual_Test()
    {
        // Arrange
        var context = new InMemoryJsonWriterContext();

        // Act
        context.Writer.WriteStartObject();
        context.Writer.WriteString("foo", new DateTimeOffset?(DateTimeOffset.UnixEpoch));
        context.Writer.WriteEndObject();

        // Assert
        context.GetString().Should().Be(
            // language=JSON
            """
            {"foo":"1970-01-01T00:00:00+00:00"}
            """
        );
    }

    [Fact]
    public void WriteString_DateTimeOffset_Null_Test()
    {
        // Arrange
        var context = new InMemoryJsonWriterContext();

        // Act
        context.Writer.WriteStartObject();
        context.Writer.WriteString("foo", new DateTimeOffset?());
        context.Writer.WriteEndObject();

        // Assert
        context.GetString().Should().Be(
            // language=JSON
            """
            {"foo":null}
            """
        );
    }
}