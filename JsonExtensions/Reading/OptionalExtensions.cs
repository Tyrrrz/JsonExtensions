using System;
using System.Text.Json;

namespace JsonExtensions.Reading;

/// <summary>
/// Extensions for reading content from <see cref="JsonElement"/> in a fault-tolerant way.
/// </summary>
public static class OptionalExtensions
{
    /// <inheritdoc cref="OptionalExtensions" />
    extension(JsonElement element)
    {
        /// <summary>
        /// Gets a property by its name.
        ///
        /// Returns null if the element is not an object,
        /// or if the property is not defined,
        /// or if the property has a null value.
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
        /// Gets a child element by its array index.
        ///
        /// Returns null if the element is not an array,
        /// or if the index is out of bounds,
        /// or if the index refers to a null value.
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
        /// Enumerates the element as an array.
        ///
        /// Returns null if the element is not an array.
        /// </summary>
        public JsonElement.ArrayEnumerator? EnumerateArrayOrNull()
        {
            if (element.ValueKind != JsonValueKind.Array)
                return null;

            return element.EnumerateArray();
        }

        /// <summary>
        /// Enumerates the element as an array.
        ///
        /// Returns an empty enumerator if the element is not an array.
        /// </summary>
        public JsonElement.ArrayEnumerator EnumerateArrayOrEmpty() =>
            element.EnumerateArrayOrNull() ?? default;

        /// <summary>
        /// Enumerates the element as an object.
        ///
        /// Returns null if the element is not an object.
        /// </summary>
        public JsonElement.ObjectEnumerator? EnumerateObjectOrNull()
        {
            if (element.ValueKind != JsonValueKind.Object)
                return null;

            return element.EnumerateObject();
        }

        /// <summary>
        /// Enumerates the element as an object.
        ///
        /// Returns empty enumerator if the element is not an object.
        /// </summary>
        public JsonElement.ObjectEnumerator EnumerateObjectOrEmpty() =>
            element.EnumerateObjectOrNull() ?? default;

        /// <summary>
        /// Gets the value of the element as a <see cref="bool"/>.
        ///
        /// Returns null if the element contains a value of any other kind.
        /// </summary>
        public bool? GetBooleanOrNull() =>
            element.ValueKind switch
            {
                JsonValueKind.True => true,
                JsonValueKind.False => false,
                _ => null,
            };

        /// <summary>
        /// Gets the value of the element as a <see cref="byte"/>.
        ///
        /// Returns null if the element contains a value of any other kind.
        /// </summary>
        public byte? GetByteOrNull()
        {
            if (element.ValueKind != JsonValueKind.Number)
                return null;

            if (element.TryGetByte(out var result))
                return result;

            return null;
        }

        /// <summary>
        /// Gets the value of the element as a <see cref="decimal"/>.
        ///
        /// Returns null if the element contains a value of any other kind.
        /// </summary>
        public decimal? GetDecimalOrNull()
        {
            if (element.ValueKind != JsonValueKind.Number)
                return null;

            if (element.TryGetDecimal(out var result))
                return result;

            return null;
        }

        /// <summary>
        /// Gets the value of the element as a <see cref="double"/>.
        ///
        /// Returns null if the element contains a value of any other kind.
        /// </summary>
        public double? GetDoubleOrNull()
        {
            if (element.ValueKind != JsonValueKind.Number)
                return null;

            if (element.TryGetDouble(out var result))
                return result;

            return null;
        }

        /// <summary>
        /// Gets the value of the element as a <see cref="float"/>.
        ///
        /// Returns null if the element contains a value of any other kind.
        /// </summary>
        public float? GetSingleOrNull()
        {
            if (element.ValueKind != JsonValueKind.Number)
                return null;

            if (element.TryGetSingle(out var result))
                return result;

            return null;
        }

        /// <summary>
        /// Gets the value of the element as a <see cref="short"/>
        ///
        /// Returns null if the element contains a value of any other kind.
        /// </summary>
        public short? GetInt16OrNull()
        {
            if (element.ValueKind != JsonValueKind.Number)
                return null;

            if (element.TryGetInt16(out var result))
                return result;

            return null;
        }

        /// <summary>
        /// Gets the value of the element as a <see cref="int"/>.
        ///
        /// Returns null if the element contains a value of any other kind.
        /// </summary>
        public int? GetInt32OrNull()
        {
            if (element.ValueKind != JsonValueKind.Number)
                return null;

            if (element.TryGetInt32(out var result))
                return result;

            return null;
        }

        /// <summary>
        /// Gets the value of the element as a <see cref="long"/>.
        ///
        /// Returns null if the element contains a value of any other kind.
        /// </summary>
        public long? GetInt64OrNull()
        {
            if (element.ValueKind != JsonValueKind.Number)
                return null;

            if (element.TryGetInt64(out var result))
                return result;

            return null;
        }

        /// <summary>
        /// Gets the value of the element as a <see cref="sbyte"/>.
        ///
        /// Returns null if the element contains a value of any other kind.
        /// </summary>
        public sbyte? GetSByteOrNull()
        {
            if (element.ValueKind != JsonValueKind.Number)
                return null;

            if (element.TryGetSByte(out var result))
                return result;

            return null;
        }

        /// <summary>
        /// Gets the value of the element as a <see cref="ushort"/>.
        ///
        /// Returns null if the element contains a value of any other kind.
        /// </summary>
        public ushort? GetUInt16OrNull()
        {
            if (element.ValueKind != JsonValueKind.Number)
                return null;

            if (element.TryGetUInt16(out var result))
                return result;

            return null;
        }

        /// <summary>
        /// Gets the value of the element as a <see cref="uint"/>.
        ///
        /// Returns null if the element contains a value of any other kind.
        /// </summary>
        public uint? GetUInt32OrNull()
        {
            if (element.ValueKind != JsonValueKind.Number)
                return null;

            if (element.TryGetUInt32(out var result))
                return result;

            return null;
        }

        /// <summary>
        /// Gets the value of the element as a <see cref="ulong"/>.
        ///
        /// Returns null if the element contains a value of any other kind.
        /// </summary>
        public ulong? GetUInt64OrNull()
        {
            if (element.ValueKind != JsonValueKind.Number)
                return null;

            if (element.TryGetUInt64(out var result))
                return result;

            return null;
        }

        /// <summary>
        /// Gets the value of the element as a <see cref="string"/>.
        ///
        /// Returns null if the element contains a value of any other kind.
        /// </summary>
        public string? GetStringOrNull() =>
            element.ValueKind == JsonValueKind.String ? element.GetString() : null;

        /// <summary>
        /// Gets the value of the element as a <see cref="Guid"/>.
        ///
        /// Returns null if the element contains a value of any other kind.
        /// </summary>
        public Guid? GetGuidOrNull()
        {
            if (element.ValueKind != JsonValueKind.String)
                return null;

            if (element.TryGetGuid(out var result))
                return result;

            return null;
        }

        /// <summary>
        /// Gets the value of the element as a <see cref="DateTime"/>.
        ///
        /// Returns null if the element contains a value of any other kind.
        /// </summary>
        public DateTime? GetDateTimeOrNull()
        {
            if (element.ValueKind != JsonValueKind.String)
                return null;

            if (element.TryGetDateTime(out var result))
                return result;

            return null;
        }

        /// <summary>
        /// Gets the value of the element as a <see cref="DateTimeOffset"/>.
        ///
        /// Returns null if the element contains a value of any other kind.
        /// </summary>
        public DateTimeOffset? GetDateTimeOffsetOrNull()
        {
            if (element.ValueKind != JsonValueKind.String)
                return null;

            if (element.TryGetDateTimeOffset(out var result))
                return result;

            return null;
        }

        /// <summary>
        /// Gets the value of the element as a base64-encoded byte array.
        ///
        /// Returns null if the element contains a value of any other kind.
        /// </summary>
        public byte[]? GetBytesFromBase64OrNull()
        {
            if (element.ValueKind != JsonValueKind.String)
                return null;

            if (element.TryGetBytesFromBase64(out var result))
                return result;

            return null;
        }
    }
}
