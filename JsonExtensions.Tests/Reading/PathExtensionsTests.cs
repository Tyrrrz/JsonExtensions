using System.Collections.Generic;
using FluentAssertions;
using JsonExtensions.Reading;
using Xunit;

namespace JsonExtensions.Tests.Reading;

public class PathExtensionsTests
{
    [Fact]
    public void GetPropertyByPath_Positive_Test()
    {
        // Arrange
        var json = Json.Parse(
            // lang=json
            """
            {"foo":{"bar":{"baz":13}}}
            """
        );

        // Act
        var child = json.GetPropertyByPath("foo.bar.baz");

        // Assert
        child.GetInt32().Should().Be(13);
    }

    [Fact]
    public void GetPropertyByPath_Negative_Test()
    {
        // Arrange
        var json = Json.Parse(
            // lang=json
            """
            {"foo":{"bar":{"baz":13}}}
            """
        );

        // Act & assert
        Assert.Throws<KeyNotFoundException>(() =>
            json.GetPropertyByPath("foo.bar.baa")
        );
    }
}