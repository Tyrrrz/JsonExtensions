using FluentAssertions;
using Xunit;

namespace JsonExtensions.Tests;

public class JsonTests
{
    [Fact]
    public void Parse_Test()
    {
        // Act
        var json = Json.Parse(
            // lang=json
            """
            {"foo":"bar"}
            """
        );

        // Assert
        json.GetProperty("foo").GetString().Should().Be("bar");
    }

    [Fact]
    public void TryParse_Positive_Test()
    {
        // Act
        var json = Json.TryParse(
            // lang=json
            """
            {"foo":"bar"}
            """
        );

        // Assert
        json.Should().NotBeNull();
        json?.GetProperty("foo").GetString().Should().Be("bar");
    }

    [Fact]
    public void TryParse_Negative_Test()
    {
        // Act
        var json = Json.TryParse(
            """
            {"foo":bar}
            """
        );

        // Assert
        json.Should().BeNull();
    }
}
