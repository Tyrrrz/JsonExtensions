using System;
using FluentAssertions;
using JsonExtensions.Reading;
using Xunit;

namespace JsonExtensions.Tests.Reading;

public class CoercionExtensionsTests
{
    [Fact]
    public void GetBooleanCoerced_Positive_Direct_Test()
    {
        // Arrange
        var json = Json.Parse(
            // language=JSON
            "true"
        );

        // Act
        var value = json.GetBooleanCoerced();

        // Assert
        value.Should().BeTrue();
    }

    [Fact]
    public void GetBooleanCoerced_Positive_FromString_Test()
    {
        // Arrange
        var json = Json.Parse(
            // language=JSON
            "\"true\""
        );

        // Act
        var value = json.GetBooleanCoerced();

        // Assert
        value.Should().BeTrue();
    }

    [Fact]
    public void GetBooleanCoerced_Negative_Test()
    {
        // Arrange
        var json = Json.Parse(
            // language=JSON
            "null"
        );

        // Act & assert
        Assert.Throws<InvalidOperationException>(() => json.GetBooleanCoerced());
    }

    [Fact]
    public void GetByteCoerced_Positive_Direct_Test()
    {
        // Arrange
        var json = Json.Parse(
            // language=JSON
            "13"
        );

        // Act
        var value = json.GetByteCoerced();

        // Assert
        value.Should().Be(13);
    }

    [Fact]
    public void GetByteCoerced_Positive_FromString_Test()
    {
        // Arrange
        var json = Json.Parse(
            // language=JSON
            "\"13\""
        );

        // Act
        var value = json.GetByteCoerced();

        // Assert
        value.Should().Be(13);
    }

    [Fact]
    public void GetByteCoerced_Negative_Test()
    {
        // Arrange
        var json = Json.Parse(
            // language=JSON
            "null"
        );

        // Act & assert
        Assert.Throws<InvalidOperationException>(() => json.GetByteCoerced());
    }

    [Fact]
    public void GetDecimalCoerced_Positive_Direct_Test()
    {
        // Arrange
        var json = Json.Parse(
            // language=JSON
            "13"
        );

        // Act
        var value = json.GetDecimalCoerced();

        // Assert
        value.Should().Be(13);
    }

    [Fact]
    public void GetDecimalCoerced_Positive_FromString_Test()
    {
        // Arrange
        var json = Json.Parse(
            // language=JSON
            "\"13\""
        );

        // Act
        var value = json.GetDecimalCoerced();

        // Assert
        value.Should().Be(13);
    }

    [Fact]
    public void GetDecimalCoerced_Negative_Test()
    {
        // Arrange
        var json = Json.Parse(
            // language=JSON
            "null"
        );

        // Act & assert
        Assert.Throws<InvalidOperationException>(() => json.GetDecimalCoerced());
    }

    [Fact]
    public void GetDoubleCoerced_Positive_Direct_Test()
    {
        // Arrange
        var json = Json.Parse(
            // language=JSON
            "13.11"
        );

        // Act
        var value = json.GetDoubleCoerced();

        // Assert
        value.Should().Be(13.11);
    }

    [Fact]
    public void GetDoubleCoerced_Positive_FromString_Test()
    {
        // Arrange
        var json = Json.Parse(
            // language=JSON
            "\"13.11\""
        );

        // Act
        var value = json.GetDoubleCoerced();

        // Assert
        value.Should().Be(13.11);
    }

    [Fact]
    public void GetDoubleCoerced_Negative_Test()
    {
        // Arrange
        var json = Json.Parse(
            // language=JSON
            "null"
        );

        // Act & assert
        Assert.Throws<InvalidOperationException>(() => json.GetDoubleCoerced());
    }

    [Fact]
    public void GetSingleCoerced_Positive_Direct_Test()
    {
        // Arrange
        var json = Json.Parse(
            // language=JSON
            "13.11"
        );

        // Act
        var value = json.GetSingleCoerced();

        // Assert
        value.Should().Be(13.11f);
    }

    [Fact]
    public void GetSingleCoerced_Positive_FromString_Test()
    {
        // Arrange
        var json = Json.Parse(
            // language=JSON
            "\"13.11\""
        );

        // Act
        var value = json.GetSingleCoerced();

        // Assert
        value.Should().Be(13.11f);
    }

    [Fact]
    public void GetSingleCoerced_Negative_Test()
    {
        // Arrange
        var json = Json.Parse(
            // language=JSON
            "null"
        );

        // Act & assert
        Assert.Throws<InvalidOperationException>(() => json.GetSingleCoerced());
    }

    [Fact]
    public void GetInt16Coerced_Positive_Direct_Test()
    {
        // Arrange
        var json = Json.Parse(
            // language=JSON
            "13"
        );

        // Act
        var value = json.GetInt16Coerced();

        // Assert
        value.Should().Be(13);
    }

    [Fact]
    public void GetInt16Coerced_Positive_FromString_Test()
    {
        // Arrange
        var json = Json.Parse(
            // language=JSON
            "\"13\""
        );

        // Act
        var value = json.GetInt16Coerced();

        // Assert
        value.Should().Be(13);
    }

    [Fact]
    public void GetInt16Coerced_Negative_Test()
    {
        // Arrange
        var json = Json.Parse(
            // language=JSON
            "null"
        );

        // Act & assert
        Assert.Throws<InvalidOperationException>(() => json.GetInt16Coerced());
    }

    [Fact]
    public void GetInt32Coerced_Positive_Direct_Test()
    {
        // Arrange
        var json = Json.Parse(
            // language=JSON
            "13"
        );

        // Act
        var value = json.GetInt32Coerced();

        // Assert
        value.Should().Be(13);
    }

    [Fact]
    public void GetInt32Coerced_Positive_FromString_Test()
    {
        // Arrange
        var json = Json.Parse(
            // language=JSON
            "\"13\""
        );

        // Act
        var value = json.GetInt32Coerced();

        // Assert
        value.Should().Be(13);
    }

    [Fact]
    public void GetInt32Coerced_Negative_Test()
    {
        // Arrange
        var json = Json.Parse(
            // language=JSON
            "null"
        );

        // Act & assert
        Assert.Throws<InvalidOperationException>(() => json.GetInt32Coerced());
    }

    [Fact]
    public void GetInt64Coerced_Positive_Direct_Test()
    {
        // Arrange
        var json = Json.Parse(
            // language=JSON
            "13"
        );

        // Act
        var value = json.GetInt64Coerced();

        // Assert
        value.Should().Be(13);
    }

    [Fact]
    public void GetInt64Coerced_Positive_FromString_Test()
    {
        // Arrange
        var json = Json.Parse(
            // language=JSON
            "\"13\""
        );

        // Act
        var value = json.GetInt64Coerced();

        // Assert
        value.Should().Be(13);
    }

    [Fact]
    public void GetInt64Coerced_Negative_Test()
    {
        // Arrange
        var json = Json.Parse(
            // language=JSON
            "null"
        );

        // Act & assert
        Assert.Throws<InvalidOperationException>(() => json.GetInt64Coerced());
    }

    [Fact]
    public void GetSByteCoerced_Positive_Direct_Test()
    {
        // Arrange
        var json = Json.Parse(
            // language=JSON
            "13"
        );

        // Act
        var value = json.GetSByteCoerced();

        // Assert
        value.Should().Be(13);
    }

    [Fact]
    public void GetSByteCoerced_Positive_FromString_Test()
    {
        // Arrange
        var json = Json.Parse(
            // language=JSON
            "\"13\""
        );

        // Act
        var value = json.GetSByteCoerced();

        // Assert
        value.Should().Be(13);
    }

    [Fact]
    public void GetSByteCoerced_Negative_Test()
    {
        // Arrange
        var json = Json.Parse(
            // language=JSON
            "null"
        );

        // Act & assert
        Assert.Throws<InvalidOperationException>(() => json.GetSByteCoerced());
    }

    [Fact]
    public void GetUInt16Coerced_Positive_Direct_Test()
    {
        // Arrange
        var json = Json.Parse(
            // language=JSON
            "13"
        );

        // Act
        var value = json.GetUInt16Coerced();

        // Assert
        value.Should().Be(13);
    }

    [Fact]
    public void GetUInt16Coerced_Positive_FromString_Test()
    {
        // Arrange
        var json = Json.Parse(
            // language=JSON
            "\"13\""
        );

        // Act
        var value = json.GetUInt16Coerced();

        // Assert
        value.Should().Be(13);
    }

    [Fact]
    public void GetUInt16Coerced_Negative_Test()
    {
        // Arrange
        var json = Json.Parse(
            // language=JSON
            "null"
        );

        // Act & assert
        Assert.Throws<InvalidOperationException>(() => json.GetUInt16Coerced());
    }

    [Fact]
    public void GetUInt32Coerced_Positive_Direct_Test()
    {
        // Arrange
        var json = Json.Parse(
            // language=JSON
            "13"
        );

        // Act
        var value = json.GetUInt32Coerced();

        // Assert
        value.Should().Be(13);
    }

    [Fact]
    public void GetUInt32Coerced_Positive_FromString_Test()
    {
        // Arrange
        var json = Json.Parse(
            // language=JSON
            "\"13\""
        );

        // Act
        var value = json.GetUInt32Coerced();

        // Assert
        value.Should().Be(13);
    }

    [Fact]
    public void GetUInt32Coerced_Negative_Test()
    {
        // Arrange
        var json = Json.Parse(
            // language=JSON
            "null"
        );

        // Act & assert
        Assert.Throws<InvalidOperationException>(() => json.GetUInt32Coerced());
    }

    [Fact]
    public void GetUInt64Coerced_Positive_Direct_Test()
    {
        // Arrange
        var json = Json.Parse(
            // language=JSON
            "13"
        );

        // Act
        var value = json.GetUInt64Coerced();

        // Assert
        value.Should().Be(13);
    }

    [Fact]
    public void GetUInt64Coerced_Positive_FromString_Test()
    {
        // Arrange
        var json = Json.Parse(
            // language=JSON
            "\"13\""
        );

        // Act
        var value = json.GetUInt64Coerced();

        // Assert
        value.Should().Be(13);
    }

    [Fact]
    public void GetUInt64Coerced_Negative_Test()
    {
        // Arrange
        var json = Json.Parse(
            // language=JSON
            "null"
        );

        // Act & assert
        Assert.Throws<InvalidOperationException>(() => json.GetUInt64Coerced());
    }
}