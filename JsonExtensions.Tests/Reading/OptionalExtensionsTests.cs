using System;
using System.Globalization;
using System.Linq;
using System.Text;
using FluentAssertions;
using JsonExtensions.Reading;
using Xunit;

namespace JsonExtensions.Tests.Reading;

public class OptionalExtensionsTests
{
    [Fact]
    public void GetPropertyOrNull_Positive_Test()
    {
        // Arrange
        var json = Json.Parse(
            // lang=json
            """
            {"foo":13}
            """
        );

        // Act
        var child = json.GetPropertyOrNull("foo");

        // Assert
        child.Should().NotBeNull();
        child?.GetInt32().Should().Be(13);
    }

    [Fact]
    public void GetPropertyOrNull_Negative_Undefined_Test()
    {
        // Arrange
        var json = Json.Parse(
            // lang=json
            """
            {"foo":13}
            """
        );

        // Act
        var child = json.GetPropertyOrNull("bar");

        // Assert
        child.Should().BeNull();
    }

    [Fact]
    public void GetPropertyOrNull_Negative_Null_Test()
    {
        // Arrange
        var json = Json.Parse(
            // lang=json
            """
            {"foo":null}
            """
        );

        // Act
        var child = json.GetPropertyOrNull("foo");

        // Assert
        child.Should().BeNull();
    }

    [Fact]
    public void GetPropertyOrNull_Negative_NotObject_Test()
    {
        // Arrange
        var json = Json.Parse(
            // lang=json
            "[1,2,3]"
        );

        // Act
        var child = json.GetPropertyOrNull("foo");

        // Assert
        child.Should().BeNull();
    }

    [Fact]
    public void GetByIndexOrNull_Positive_Test()
    {
        // Arrange
        var json = Json.Parse(
            // lang=json
            "[1,2,3]"
        );

        // Act
        var child = json.GetByIndexOrNull(1);

        // Assert
        child.Should().NotBeNull();
        child?.GetInt32().Should().Be(2);
    }

    [Fact]
    public void GetByIndexOrNull_Negative_OutOfBounds_Test()
    {
        // Arrange
        var json = Json.Parse(
            // lang=json
            "[1,2,3]"
        );

        // Act
        var child = json.GetByIndexOrNull(5);

        // Assert
        child.Should().BeNull();
    }

    [Fact]
    public void GetByIndexOrNull_Negative_Null_Test()
    {
        // Arrange
        var json = Json.Parse(
            // lang=json
            "[1,null,3]"
        );

        // Act
        var child = json.GetByIndexOrNull(1);

        // Assert
        child.Should().BeNull();
    }

    [Fact]
    public void GetByIndexOrNull_Negative_NotArray_Test()
    {
        // Arrange
        var json = Json.Parse(
            // lang=json
            """
            {"foo":null}
            """
        );

        // Act
        var child = json.GetByIndexOrNull(1);

        // Assert
        child.Should().BeNull();
    }

    [Fact]
    public void EnumerateArrayOrEmpty_Positive_Test()
    {
        // Arrange
        var json = Json.Parse(
            // lang=json
            "[1,2,3]"
        );

        // Act
        var count = json.EnumerateArrayOrEmpty().Count();

        // Assert
        count.Should().Be(3);
    }

    [Fact]
    public void EnumerateArrayOrEmpty_Negative_NotArray_Test()
    {
        // Arrange
        var json = Json.Parse(
            // lang=json
            """
            {"foo":null}
            """
        );

        // Act
        var count = json.EnumerateArrayOrEmpty().Count();

        // Assert
        count.Should().Be(0);
    }

    [Fact]
    public void EnumerateObjectOrEmpty_Positive_Test()
    {
        // Arrange
        var json = Json.Parse(
            // lang=json
            """
            {"foo":1,"bar":true}
            """
        );

        // Act
        var count = json.EnumerateObjectOrEmpty().Count();

        // Assert
        count.Should().Be(2);
    }

    [Fact]
    public void EnumerateObjectOrEmpty_Negative_NotObject_Test()
    {
        // Arrange
        var json = Json.Parse(
            // lang=json
            "[1,2,3]"
        );

        // Act
        var count = json.EnumerateObjectOrEmpty().Count();

        // Assert
        count.Should().Be(0);
    }

    [Fact]
    public void GetBooleanOrNull_Positive_True_Test()
    {
        // Arrange
        var json = Json.Parse(
            // lang=json
            "true"
        );

        // Act
        var value = json.GetBooleanOrNull();

        // Assert
        value.Should().BeTrue();
    }

    [Fact]
    public void GetBooleanOrNull_Positive_False_Test()
    {
        // Arrange
        var json = Json.Parse(
            // lang=json
            "false"
        );

        // Act
        var value = json.GetBooleanOrNull();

        // Assert
        value.Should().BeFalse();
    }

    [Fact]
    public void GetBooleanOrNull_Negative_Null_Test()
    {
        // Arrange
        var json = Json.Parse(
            // lang=json
            "null"
        );

        // Act
        var value = json.GetBooleanOrNull();

        // Assert
        value.Should().BeNull();
    }

    [Fact]
    public void GetBooleanOrNull_Negative_NotBoolean_Test()
    {
        // Arrange
        var json = Json.Parse(
            // lang=json
            "13"
        );

        // Act
        var value = json.GetBooleanOrNull();

        // Assert
        value.Should().BeNull();
    }

    [Fact]
    public void GetByteOrNull_Positive_Test()
    {
        // Arrange
        var json = Json.Parse(
            // lang=json
            "13"
        );

        // Act
        var value = json.GetByteOrNull();

        // Assert
        value.Should().Be(13);
    }

    [Fact]
    public void GetByteOrNull_Negative_Null_Test()
    {
        // Arrange
        var json = Json.Parse(
            // lang=json
            "null"
        );

        // Act
        var value = json.GetByteOrNull();

        // Assert
        value.Should().BeNull();
    }

    [Fact]
    public void GetByteOrNull_Negative_NotNumber_Test()
    {
        // Arrange
        var json = Json.Parse(
            // lang=json
            "true"
        );

        // Act
        var value = json.GetByteOrNull();

        // Assert
        value.Should().BeNull();
    }

    [Fact]
    public void GetByteOrNull_Negative_NotConvertible_Test()
    {
        // Arrange
        var json = Json.Parse(
            // lang=json
            "3.14"
        );

        // Act
        var value = json.GetByteOrNull();

        // Assert
        value.Should().BeNull();
    }

    [Fact]
    public void GetDecimalOrNull_Positive_Test()
    {
        // Arrange
        var json = Json.Parse(
            // lang=json
            "13"
        );

        // Act
        var value = json.GetDecimalOrNull();

        // Assert
        value.Should().Be(13);
    }

    [Fact]
    public void GetDecimalOrNull_Negative_Null_Test()
    {
        // Arrange
        var json = Json.Parse(
            // lang=json
            "null"
        );

        // Act
        var value = json.GetDecimalOrNull();

        // Assert
        value.Should().BeNull();
    }

    [Fact]
    public void GetDecimalOrNull_Negative_NotNumber_Test()
    {
        // Arrange
        var json = Json.Parse(
            // lang=json
            "true"
        );

        // Act
        var value = json.GetDecimalOrNull();

        // Assert
        value.Should().BeNull();
    }

    [Fact]
    public void GetDecimalOrNull_Negative_NotConvertible_Test()
    {
        // Arrange
        var json = Json.Parse(
            // lang=json
            "99999999999999999999999999999999999"
        );

        // Act
        var value = json.GetDecimalOrNull();

        // Assert
        value.Should().BeNull();
    }

    [Fact]
    public void GetDoubleOrNull_Positive_Test()
    {
        // Arrange
        var json = Json.Parse(
            // lang=json
            "13.11"
        );

        // Act
        var value = json.GetDoubleOrNull();

        // Assert
        value.Should().Be(13.11);
    }

    [Fact]
    public void GetDoubleOrNull_Negative_Null_Test()
    {
        // Arrange
        var json = Json.Parse(
            // lang=json
            "null"
        );

        // Act
        var value = json.GetDoubleOrNull();

        // Assert
        value.Should().BeNull();
    }

    [Fact]
    public void GetDoubleOrNull_Negative_NotNumber_Test()
    {
        // Arrange
        var json = Json.Parse(
            // lang=json
            "true"
        );

        // Act
        var value = json.GetDoubleOrNull();

        // Assert
        value.Should().BeNull();
    }

    [Fact]
    public void GetSingleOrNull_Positive_Test()
    {
        // Arrange
        var json = Json.Parse(
            // lang=json
            "13.11"
        );

        // Act
        var value = json.GetSingleOrNull();

        // Assert
        value.Should().Be(13.11f);
    }

    [Fact]
    public void GetSingleOrNull_Negative_Null_Test()
    {
        // Arrange
        var json = Json.Parse(
            // lang=json
            "null"
        );

        // Act
        var value = json.GetSingleOrNull();

        // Assert
        value.Should().BeNull();
    }

    [Fact]
    public void GetSingleOrNull_Negative_NotNumber_Test()
    {
        // Arrange
        var json = Json.Parse(
            // lang=json
            "true"
        );

        // Act
        var value = json.GetSingleOrNull();

        // Assert
        value.Should().BeNull();
    }

    [Fact]
    public void GetInt16OrNull_Positive_Test()
    {
        // Arrange
        var json = Json.Parse(
            // lang=json
            "13"
        );

        // Act
        var value = json.GetInt16OrNull();

        // Assert
        value.Should().Be(13);
    }

    [Fact]
    public void GetInt16OrNull_Negative_Null_Test()
    {
        // Arrange
        var json = Json.Parse(
            // lang=json
            "null"
        );

        // Act
        var value = json.GetInt16OrNull();

        // Assert
        value.Should().BeNull();
    }

    [Fact]
    public void GetInt16OrNull_Negative_NotNumber_Test()
    {
        // Arrange
        var json = Json.Parse(
            // lang=json
            "true"
        );

        // Act
        var value = json.GetInt16OrNull();

        // Assert
        value.Should().BeNull();
    }

    [Fact]
    public void GetInt16OrNull_Negative_NotConvertible_Test()
    {
        // Arrange
        var json = Json.Parse(
            // lang=json
            "3.14"
        );

        // Act
        var value = json.GetInt16OrNull();

        // Assert
        value.Should().BeNull();
    }

    [Fact]
    public void GetInt32OrNull_Positive_Test()
    {
        // Arrange
        var json = Json.Parse(
            // lang=json
            "13"
        );

        // Act
        var value = json.GetInt32OrNull();

        // Assert
        value.Should().Be(13);
    }

    [Fact]
    public void GetInt32OrNull_Negative_Null_Test()
    {
        // Arrange
        var json = Json.Parse(
            // lang=json
            "null"
        );

        // Act
        var value = json.GetInt32OrNull();

        // Assert
        value.Should().BeNull();
    }

    [Fact]
    public void GetInt32OrNull_Negative_NotNumber_Test()
    {
        // Arrange
        var json = Json.Parse(
            // lang=json
            "true"
        );

        // Act
        var value = json.GetInt32OrNull();

        // Assert
        value.Should().BeNull();
    }

    [Fact]
    public void GetInt32OrNull_Negative_NotConvertible_Test()
    {
        // Arrange
        var json = Json.Parse(
            // lang=json
            "3.14"
        );

        // Act
        var value = json.GetInt32OrNull();

        // Assert
        value.Should().BeNull();
    }

    [Fact]
    public void GetInt64OrNull_Positive_Test()
    {
        // Arrange
        var json = Json.Parse(
            // lang=json
            "13"
        );

        // Act
        var value = json.GetInt64OrNull();

        // Assert
        value.Should().Be(13);
    }

    [Fact]
    public void GetInt64OrNull_Negative_Null_Test()
    {
        // Arrange
        var json = Json.Parse(
            // lang=json
            "null"
        );

        // Act
        var value = json.GetInt64OrNull();

        // Assert
        value.Should().BeNull();
    }

    [Fact]
    public void GetInt64OrNull_Negative_NotNumber_Test()
    {
        // Arrange
        var json = Json.Parse(
            // lang=json
            "true"
        );

        // Act
        var value = json.GetInt64OrNull();

        // Assert
        value.Should().BeNull();
    }

    [Fact]
    public void GetInt64OrNull_Negative_NotConvertible_Test()
    {
        // Arrange
        var json = Json.Parse(
            // lang=json
            "3.14"
        );

        // Act
        var value = json.GetInt64OrNull();

        // Assert
        value.Should().BeNull();
    }

    [Fact]
    public void GetSByteOrNull_Positive_Test()
    {
        // Arrange
        var json = Json.Parse(
            // lang=json
            "13"
        );

        // Act
        var value = json.GetSByteOrNull();

        // Assert
        value.Should().Be(13);
    }

    [Fact]
    public void GetSByteOrNull_Negative_Null_Test()
    {
        // Arrange
        var json = Json.Parse(
            // lang=json
            "null"
        );

        // Act
        var value = json.GetSByteOrNull();

        // Assert
        value.Should().BeNull();
    }

    [Fact]
    public void GetSByteOrNull_Negative_NotNumber_Test()
    {
        // Arrange
        var json = Json.Parse(
            // lang=json
            "true"
        );

        // Act
        var value = json.GetSByteOrNull();

        // Assert
        value.Should().BeNull();
    }

    [Fact]
    public void GetSByteOrNull_Negative_NotConvertible_Test()
    {
        // Arrange
        var json = Json.Parse(
            // lang=json
            "3.14"
        );

        // Act
        var value = json.GetSByteOrNull();

        // Assert
        value.Should().BeNull();
    }

    [Fact]
    public void GetUInt16OrNull_Positive_Test()
    {
        // Arrange
        var json = Json.Parse(
            // lang=json
            "13"
        );

        // Act
        var value = json.GetUInt16OrNull();

        // Assert
        value.Should().Be(13);
    }

    [Fact]
    public void GetUInt16OrNull_Negative_Null_Test()
    {
        // Arrange
        var json = Json.Parse(
            // lang=json
            "null"
        );

        // Act
        var value = json.GetUInt16OrNull();

        // Assert
        value.Should().BeNull();
    }

    [Fact]
    public void GetUInt16OrNull_Negative_NotNumber_Test()
    {
        // Arrange
        var json = Json.Parse(
            // lang=json
            "true"
        );

        // Act
        var value = json.GetUInt16OrNull();

        // Assert
        value.Should().BeNull();
    }

    [Fact]
    public void GetUInt16OrNull_Negative_NotConvertible_Test()
    {
        // Arrange
        var json = Json.Parse(
            // lang=json
            "3.14"
        );

        // Act
        var value = json.GetUInt16OrNull();

        // Assert
        value.Should().BeNull();
    }

    [Fact]
    public void GetUInt32OrNull_Positive_Test()
    {
        // Arrange
        var json = Json.Parse(
            // lang=json
            "13"
        );

        // Act
        var value = json.GetUInt32OrNull();

        // Assert
        value.Should().Be(13);
    }

    [Fact]
    public void GetUInt32OrNull_Negative_Null_Test()
    {
        // Arrange
        var json = Json.Parse(
            // lang=json
            "null"
        );

        // Act
        var value = json.GetUInt32OrNull();

        // Assert
        value.Should().BeNull();
    }

    [Fact]
    public void GetUInt32OrNull_Negative_NotNumber_Test()
    {
        // Arrange
        var json = Json.Parse(
            // lang=json
            "true"
        );

        // Act
        var value = json.GetUInt32OrNull();

        // Assert
        value.Should().BeNull();
    }

    [Fact]
    public void GetUInt32OrNull_Negative_NotConvertible_Test()
    {
        // Arrange
        var json = Json.Parse(
            // lang=json
            "3.14"
        );

        // Act
        var value = json.GetUInt32OrNull();

        // Assert
        value.Should().BeNull();
    }

    [Fact]
    public void GetUInt64OrNull_Positive_Test()
    {
        // Arrange
        var json = Json.Parse(
            // lang=json
            "13"
        );

        // Act
        var value = json.GetUInt64OrNull();

        // Assert
        value.Should().Be(13);
    }

    [Fact]
    public void GetUInt64OrNull_Negative_Null_Test()
    {
        // Arrange
        var json = Json.Parse(
            // lang=json
            "null"
        );

        // Act
        var value = json.GetUInt64OrNull();

        // Assert
        value.Should().BeNull();
    }

    [Fact]
    public void GetUInt64OrNull_Negative_NotNumber_Test()
    {
        // Arrange
        var json = Json.Parse(
            // lang=json
            "true"
        );

        // Act
        var value = json.GetUInt64OrNull();

        // Assert
        value.Should().BeNull();
    }

    [Fact]
    public void GetUInt64OrNull_Negative_NotConvertible_Test()
    {
        // Arrange
        var json = Json.Parse(
            // lang=json
            "3.14"
        );

        // Act
        var value = json.GetUInt64OrNull();

        // Assert
        value.Should().BeNull();
    }

    [Fact]
    public void GetStringOrNull_Positive_Test()
    {
        // Arrange
        var json = Json.Parse(
            // lang=json
            "\"foo\""
        );

        // Act
        var value = json.GetStringOrNull();

        // Assert
        value.Should().Be("foo");
    }

    [Fact]
    public void GetStringOrNull_Negative_Null_Test()
    {
        // Arrange
        var json = Json.Parse(
            // lang=json
            "null"
        );

        // Act
        var value = json.GetStringOrNull();

        // Assert
        value.Should().BeNull();
    }

    [Fact]
    public void GetStringOrNull_Negative_NotString_Test()
    {
        // Arrange
        var json = Json.Parse(
            // lang=json
            "true"
        );

        // Act
        var value = json.GetStringOrNull();

        // Assert
        value.Should().BeNull();
    }

    [Fact]
    public void GetGuidOrNull_Positive_Test()
    {
        // Arrange
        var json = Json.Parse(
            // lang=json
            "\"b2567a71-6966-49b1-8976-ad3f4e397b05\""
        );

        // Act
        var value = json.GetGuidOrNull();

        // Assert
        value.Should().Be(Guid.Parse("b2567a71-6966-49b1-8976-ad3f4e397b05"));
    }

    [Fact]
    public void GetGuidOrNull_Negative_Null_Test()
    {
        // Arrange
        var json = Json.Parse(
            // lang=json
            "null"
        );

        // Act
        var value = json.GetGuidOrNull();

        // Assert
        value.Should().BeNull();
    }

    [Fact]
    public void GetGuidOrNull_Negative_NotString_Test()
    {
        // Arrange
        var json = Json.Parse(
            // lang=json
            "true"
        );

        // Act
        var value = json.GetGuidOrNull();

        // Assert
        value.Should().BeNull();
    }

    [Fact]
    public void GetGuidOrNull_Negative_NotConvertible_Test()
    {
        // Arrange
        var json = Json.Parse(
            // lang=json
            "\"foo\""
        );

        // Act
        var value = json.GetGuidOrNull();

        // Assert
        value.Should().BeNull();
    }

    [Fact]
    public void GetDateTimeOrNull_Positive_Test()
    {
        // Arrange
        var json = Json.Parse(
            // lang=json
            "\"2014-01-01T23:28:56.782Z\""
        );

        // Act
        var value = json.GetDateTimeOrNull();

        // Assert
        value.Should().Be(
            DateTime.Parse(
                "2014-01-01T23:28:56.782Z",
                CultureInfo.InvariantCulture,
                DateTimeStyles.AdjustToUniversal)
        );
    }

    [Fact]
    public void GetDateTimeOrNull_Negative_Null_Test()
    {
        // Arrange
        var json = Json.Parse(
            // lang=json
            "null"
        );

        // Act
        var value = json.GetDateTimeOrNull();

        // Assert
        value.Should().BeNull();
    }

    [Fact]
    public void GetDateTimeOrNull_Negative_NotString_Test()
    {
        // Arrange
        var json = Json.Parse(
            // lang=json
            "true"
        );

        // Act
        var value = json.GetDateTimeOrNull();

        // Assert
        value.Should().BeNull();
    }

    [Fact]
    public void GetDateTimeOrNull_Negative_NotConvertible_Test()
    {
        // Arrange
        var json = Json.Parse(
            // lang=json
            "\"foo\""
        );

        // Act
        var value = json.GetDateTimeOrNull();

        // Assert
        value.Should().BeNull();
    }

    [Fact]
    public void GetDateTimeOffsetOrNull_Positive_Test()
    {
        // Arrange
        var json = Json.Parse(
            // lang=json
            "\"2014-01-01T23:28:56.782Z\""
        );

        // Act
        var value = json.GetDateTimeOffsetOrNull();

        // Assert
        value.Should().Be(
            DateTimeOffset.Parse(
                "2014-01-01T23:28:56.782Z",
                CultureInfo.InvariantCulture)
        );
    }

    [Fact]
    public void GetDateTimeOffsetOrNull_Negative_Null_Test()
    {
        // Arrange
        var json = Json.Parse(
            // lang=json
            "null"
        );

        // Act
        var value = json.GetDateTimeOffsetOrNull();

        // Assert
        value.Should().BeNull();
    }

    [Fact]
    public void GetDateTimeOffsetOrNull_Negative_NotString_Test()
    {
        // Arrange
        var json = Json.Parse(
            // lang=json
            "true"
        );

        // Act
        var value = json.GetDateTimeOffsetOrNull();

        // Assert
        value.Should().BeNull();
    }

    [Fact]
    public void GetDateTimeOffsetOrNull_Negative_NotConvertible_Test()
    {
        // Arrange
        var json = Json.Parse(
            // lang=json
            "\"foo\""
        );

        // Act
        var value = json.GetDateTimeOffsetOrNull();

        // Assert
        value.Should().BeNull();
    }

    [Fact]
    public void GetBytesFromBase64OrNull_Positive_Test()
    {
        // Arrange
        var json = Json.Parse(
            // lang=json
            "\"Zm9v\""
        );

        // Act
        var value = json.GetBytesFromBase64OrNull();

        // Assert
        value.Should().Equal(Encoding.UTF8.GetBytes("foo"));
    }

    [Fact]
    public void GetBytesFromBase64OrNull_Negative_Null_Test()
    {
        // Arrange
        var json = Json.Parse(
            // lang=json
            "null"
        );

        // Act
        var value = json.GetBytesFromBase64OrNull();

        // Assert
        value.Should().BeNull();
    }

    [Fact]
    public void GetBytesFromBase64OrNull_Negative_NotString_Test()
    {
        // Arrange
        var json = Json.Parse(
            // lang=json
            "true"
        );

        // Act
        var value = json.GetBytesFromBase64OrNull();

        // Assert
        value.Should().BeNull();
    }

    [Fact]
    public void GetBytesFromBase64OrNull_Negative_NotConvertible_Test()
    {
        // Arrange
        var json = Json.Parse(
            // lang=json
            "\"foo\""
        );

        // Act
        var value = json.GetBytesFromBase64OrNull();

        // Assert
        value.Should().BeNull();
    }
}