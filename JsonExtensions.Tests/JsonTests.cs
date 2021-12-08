using FluentAssertions;
using Xunit;

namespace JsonExtensions.Tests;

public class JsonTests
{
    [Fact]
    public void Parse_Test()
    {
        // Arrange
        const string jsonRaw = "{\"foo\":\"bar\"}";

        // Act
        var json = Json.Parse(jsonRaw);

        // Assert
        json.GetProperty("foo").GetString().Should().Be("bar");
    }

    [Fact]
    public void TryParse_Positive_Test()
    {
        // Arrange
        const string jsonRaw = "{\"foo\":\"bar\"}";

        // Act
        var json = Json.TryParse(jsonRaw);

        // Assert
        json.Should().NotBeNull();
        json?.GetProperty("foo").GetString().Should().Be("bar");
    }

    [Fact]
    public void TryParse_Negative_Test()
    {
        // Arrange
        const string jsonRaw = "{\"foo\":bar}";

        // Act
        var json = Json.TryParse(jsonRaw);

        // Assert
        json.Should().BeNull();
    }
}