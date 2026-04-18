using System;
using System.Text.Json;

namespace JsonExtensions.Reading;

/// <summary>
/// Null-returning extensions for reading values out of <see cref="JsonElement"/> without throwing exceptions.
/// </summary>
public static class OptionalExtensions
{
    /// <inheritdoc cref="OptionalExtensions" />
    extension(JsonElement element)
    {
        /// <summary>
        /// Returns an enumerator over the element's array items,
        /// or null if the element is not a JSON array.
        /// </summary>
        public JsonElement.ArrayEnumerator? EnumerateArrayOrNull() =>
            element.ValueKind == JsonValueKind.Array ? element.EnumerateArray() : null;

        /// <summary>
        /// Returns an enumerator over the element's array items,
        /// or an empty enumerator if the element is not a JSON array.
        /// </summary>
        public JsonElement.ArrayEnumerator EnumerateArrayOrEmpty() =>
            element.EnumerateArrayOrNull() ?? default;

        /// <summary>
        /// Returns an enumerator over the element's properties,
        /// or null if the element is not a JSON object.
        /// </summary>
        public JsonElement.ObjectEnumerator? EnumerateObjectOrNull() =>
            element.ValueKind == JsonValueKind.Object ? element.EnumerateObject() : null;

        /// <summary>
        /// Returns an enumerator over the element's properties,
        /// or an empty enumerator if the element is not a JSON object.
        /// </summary>
        public JsonElement.ObjectEnumerator EnumerateObjectOrEmpty() =>
            element.EnumerateObjectOrNull() ?? default;

        /// <summary>
        /// Returns the element's value as a <see cref="bool"/>,
        /// or null if the element is not a boolean.
        /// </summary>
        public bool? GetBooleanOrNull() =>
            element.ValueKind switch
            {
                JsonValueKind.True => true,
                JsonValueKind.False => false,
                _ => null,
            };

        /// <summary>
        /// Returns the child element at position <paramref name="index"/> within the array,
        /// or null if the element is not an array, the index is out of range, or the indexed value is null.
        /// </summary>
        public JsonElement? GetByIndexOrNull(int index)
        {
            if (
                element.ValueKind != JsonValueKind.Array
                || index < 0
                || index >= element.GetArrayLength()
            )
            {
                return null;
            }

            var child = element[index];

            if (child.ValueKind is JsonValueKind.Null or JsonValueKind.Undefined)
            {
                return null;
            }

            return child;
        }

        /// <summary>
        /// Returns the element's value as a <see cref="byte"/>,
        /// or null if the element is not a number or the value is out of range.
        /// </summary>
        public byte? GetByteOrNull() =>
            element.ValueKind == JsonValueKind.Number
                ? element.TryGetByte(out var result)
                    ? result
                    : null
                : null;

        /// <summary>
        /// Decodes the element's base-64 encoded string value and returns the resulting byte array,
        /// or null if the element is not a string or decoding fails.
        /// </summary>
        public byte[]? GetBytesFromBase64OrNull() =>
            element.ValueKind == JsonValueKind.String
                ? element.TryGetBytesFromBase64(out var result)
                    ? result
                    : null
                : null;

        /// <summary>
        /// Returns the element's value as a <see cref="DateTimeOffset"/>,
        /// or null if the element is not a string or the value cannot be parsed.
        /// </summary>
        public DateTimeOffset? GetDateTimeOffsetOrNull() =>
            element.ValueKind == JsonValueKind.String
                ? element.TryGetDateTimeOffset(out var result)
                    ? result
                    : null
                : null;

        /// <summary>
        /// Returns the element's value as a <see cref="DateTime"/>,
        /// or null if the element is not a string or the value cannot be parsed.
        /// </summary>
        public DateTime? GetDateTimeOrNull() =>
            element.ValueKind == JsonValueKind.String
                ? element.TryGetDateTime(out var result)
                    ? result
                    : null
                : null;

        /// <summary>
        /// Returns the element's value as a <see cref="decimal"/>,
        /// or null if the element is not a number or the value is out of range.
        /// </summary>
        public decimal? GetDecimalOrNull() =>
            element.ValueKind == JsonValueKind.Number
                ? element.TryGetDecimal(out var result)
                    ? result
                    : null
                : null;

        /// <summary>
        /// Returns the element's value as a <see cref="double"/>,
        /// or null if the element is not a number.
        /// </summary>
        public double? GetDoubleOrNull() =>
            element.ValueKind == JsonValueKind.Number
                ? element.TryGetDouble(out var result)
                    ? result
                    : null
                : null;

        /// <summary>
        /// Returns the element's value as a <see cref="Guid"/>,
        /// or null if the element is not a string or the value cannot be parsed.
        /// </summary>
        public Guid? GetGuidOrNull() =>
            element.ValueKind == JsonValueKind.String
                ? element.TryGetGuid(out var result)
                    ? result
                    : null
                : null;

        /// <summary>
        /// Returns the element's value as a <see cref="short"/>,
        /// or null if the element is not a number or the value is out of range.
        /// </summary>
        public short? GetInt16OrNull() =>
            element.ValueKind == JsonValueKind.Number
                ? element.TryGetInt16(out var result)
                    ? result
                    : null
                : null;

        /// <summary>
        /// Returns the element's value as an <see cref="int"/>,
        /// or null if the element is not a number or the value is out of range.
        /// </summary>
        public int? GetInt32OrNull() =>
            element.ValueKind == JsonValueKind.Number
                ? element.TryGetInt32(out var result)
                    ? result
                    : null
                : null;

        /// <summary>
        /// Returns the element's value as a <see cref="long"/>,
        /// or null if the element is not a number or the value is out of range.
        /// </summary>
        public long? GetInt64OrNull() =>
            element.ValueKind == JsonValueKind.Number
                ? element.TryGetInt64(out var result)
                    ? result
                    : null
                : null;

        /// <summary>
        /// Returns the child property named <paramref name="propertyName"/>,
        /// or null if the element is not an object, the property does not exist, or its value is null.
        /// </summary>
        public JsonElement? GetPropertyOrNull(string propertyName)
        {
            if (element.ValueKind != JsonValueKind.Object)
            {
                return null;
            }

            if (
                element.TryGetProperty(propertyName, out var result)
                && result.ValueKind is not JsonValueKind.Null and not JsonValueKind.Undefined
            )
            {
                return result;
            }

            return null;
        }

        /// <summary>
        /// Returns the element's value as an <see cref="sbyte"/>,
        /// or null if the element is not a number or the value is out of range.
        /// </summary>
        public sbyte? GetSByteOrNull() =>
            element.ValueKind == JsonValueKind.Number
                ? element.TryGetSByte(out var result)
                    ? result
                    : null
                : null;

        /// <summary>
        /// Returns the element's value as a <see cref="float"/>,
        /// or null if the element is not a number.
        /// </summary>
        public float? GetSingleOrNull() =>
            element.ValueKind == JsonValueKind.Number
                ? element.TryGetSingle(out var result)
                    ? result
                    : null
                : null;

        /// <summary>
        /// Returns the element's value as a <see cref="string"/>,
        /// or null if the element is not a string.
        /// </summary>
        public string? GetStringOrNull() =>
            element.ValueKind == JsonValueKind.String ? element.GetString() : null;

        /// <summary>
        /// Returns the element's value as a <see cref="ushort"/>,
        /// or null if the element is not a number or the value is out of range.
        /// </summary>
        public ushort? GetUInt16OrNull() =>
            element.ValueKind == JsonValueKind.Number
                ? element.TryGetUInt16(out var result)
                    ? result
                    : null
                : null;

        /// <summary>
        /// Returns the element's value as a <see cref="uint"/>,
        /// or null if the element is not a number or the value is out of range.
        /// </summary>
        public uint? GetUInt32OrNull() =>
            element.ValueKind == JsonValueKind.Number
                ? element.TryGetUInt32(out var result)
                    ? result
                    : null
                : null;

        /// <summary>
        /// Returns the element's value as a <see cref="ulong"/>,
        /// or null if the element is not a number or the value is out of range.
        /// </summary>
        public ulong? GetUInt64OrNull() =>
            element.ValueKind == JsonValueKind.Number
                ? element.TryGetUInt64(out var result)
                    ? result
                    : null
                : null;
    }
}
