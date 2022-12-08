using System;
using FluentAssertions;
using JsonExtensions.Reading;
using Xunit;

namespace JsonExtensions.Tests.Reading;

public class StringExtensionsTests
{
    [Fact]
    public void GetNonNullString_Positive_Test()
    {
        // Arrange
        var json = Json.Parse(
            // language=JSON
            "\"foo\""
        );
            
        // Act
        var value = json.GetNonNullString();
            
        // Assert
        value.Should().Be("foo");
    }

    [Fact]
    public void GetNonNullString_Negative_Null_Test()
    {
        // Arrange
        var json = Json.Parse(
            // language=JSON
            "null"
        );
            
        // Act & assert
        Assert.Throws<InvalidOperationException>(() => json.GetNonNullString());
    }
        
    [Fact]
    public void GetNonNullString_Negative_NotString_Test()
    {
        // Arrange
        var json = Json.Parse(
            // language=JSON
            "true"
        );
            
        // Act & assert
        Assert.Throws<InvalidOperationException>(() => json.GetNonNullString());
    }
        
    [Fact]
    public void GetNonEmptyString_Positive_Test()
    {
        // Arrange
        var json = Json.Parse(
            // language=JSON
            "\"foo\""
        );
            
        // Act
        var value = json.GetNonEmptyString();
            
        // Assert
        value.Should().Be("foo");
    }

    [Fact]
    public void GetNonEmptyString_Negative_Null_Test()
    {
        // Arrange
        var json = Json.Parse(
            // language=JSON
            "null"
        );
            
        // Act & assert
        Assert.Throws<InvalidOperationException>(() => json.GetNonEmptyString());
    }
        
    [Fact]
    public void GetNonEmptyString_Negative_NotString_Test()
    {
        // Arrange
        var json = Json.Parse(
            // language=JSON
            "true"
        );
            
        // Act & assert
        Assert.Throws<InvalidOperationException>(() => json.GetNonEmptyString());
    }
        
    [Fact]
    public void GetNonEmptyString_Negative_EmptyString_Test()
    {
        // Arrange
        var json = Json.Parse(
            // language=JSON
            "\"\""
        );
            
        // Act & assert
        Assert.Throws<InvalidOperationException>(() => json.GetNonEmptyString());
    }
        
    [Fact]
    public void GetNonWhiteSpaceString_Positive_Test()
    {
        // Arrange
        var json = Json.Parse(
            // language=JSON
            "\"foo\""
        );
            
        // Act
        var value = json.GetNonWhiteSpaceString();
            
        // Assert
        value.Should().Be("foo");
    }

    [Fact]
    public void GetNonWhiteSpaceString_Negative_Null_Test()
    {
        // Arrange
        var json = Json.Parse(
            // language=JSON
            "null"
        );
            
        // Act & assert
        Assert.Throws<InvalidOperationException>(() => json.GetNonWhiteSpaceString());
    }
        
    [Fact]
    public void GetNonWhiteSpaceString_Negative_NotString_Test()
    {
        // Arrange
        var json = Json.Parse(
            // language=JSON
            "true"
        );
            
        // Act & assert
        Assert.Throws<InvalidOperationException>(() => json.GetNonWhiteSpaceString());
    }
        
    [Fact]
    public void GetNonWhiteSpaceString_Negative_EmptyString_Test()
    {
        // Arrange
        var json = Json.Parse(
            // language=JSON
            "\"\""
        );
            
        // Act & assert
        Assert.Throws<InvalidOperationException>(() => json.GetNonWhiteSpaceString());
    }
        
    [Fact]
    public void GetNonWhiteSpaceString_Negative_WhiteSpaceString_Test()
    {
        // Arrange
        var json = Json.Parse(
            // language=JSON
            "\"  \""
        );
            
        // Act & assert
        Assert.Throws<InvalidOperationException>(() => json.GetNonWhiteSpaceString());
    }
}