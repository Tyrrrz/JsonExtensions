using System;
using System.Globalization;
using System.Text.Json;
using PowerKit.Extensions;

namespace JsonExtensions;

/// <summary>
/// Extensions for <see cref="JsonElement" />.
/// </summary>
public static class JsonElementExtensions
{
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
        /// Reads the element's value as a <see cref="bool"/>, accepting both a native boolean
        /// and a string-encoded representation. Returns null if neither form is recognized.
        /// </summary>
        public bool? GetBooleanCoercedOrNull() =>
            element.ValueKind switch
            {
                JsonValueKind.String => bool.ParseOrNull(element.GetString()),
                _ => element.GetBooleanOrNull(),
            };

        /// <summary>
        /// Reads the element's value as a <see cref="bool"/>, accepting both a native boolean
        /// and a string-encoded representation. Throws <see cref="InvalidOperationException"/> if
        /// neither form is recognized.
        /// </summary>
        public bool GetBooleanCoerced() =>
            element.GetBooleanCoercedOrNull()
            ?? throw new InvalidOperationException(
                "Cannot read or coerce the specified JSON element into a boolean value."
            );

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
        /// Reads the element's value as a <see cref="byte"/>, accepting both a native number
        /// and a string-encoded representation. Returns null if neither form is recognized.
        /// </summary>
        public byte? GetByteCoercedOrNull() =>
            element.ValueKind switch
            {
                JsonValueKind.String => byte.ParseOrNull(
                    element.GetString(),
                    CultureInfo.InvariantCulture
                ),
                _ => element.GetByteOrNull(),
            };

        /// <summary>
        /// Reads the element's value as a <see cref="byte"/>, accepting both a native number
        /// and a string-encoded representation. Throws <see cref="InvalidOperationException"/> if
        /// neither form is recognized.
        /// </summary>
        public byte GetByteCoerced() =>
            element.GetByteCoercedOrNull()
            ?? throw new InvalidOperationException(
                "Cannot read or coerce the specified JSON element into a byte value."
            );

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
        /// Reads the element's value as a <see cref="decimal"/>, accepting both a native number
        /// and a string-encoded representation. Returns null if neither form is recognized.
        /// </summary>
        public decimal? GetDecimalCoercedOrNull() =>
            element.ValueKind switch
            {
                JsonValueKind.String => decimal.ParseOrNull(
                    element.GetString(),
                    CultureInfo.InvariantCulture
                ),
                _ => element.GetDecimalOrNull(),
            };

        /// <summary>
        /// Reads the element's value as a <see cref="decimal"/>, accepting both a native number
        /// and a string-encoded representation. Throws <see cref="InvalidOperationException"/> if
        /// neither form is recognized.
        /// </summary>
        public decimal GetDecimalCoerced() =>
            element.GetDecimalCoercedOrNull()
            ?? throw new InvalidOperationException(
                "Cannot read or coerce the specified JSON element into a decimal value."
            );

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
        /// Reads the element's value as a <see cref="double"/>, accepting both a native number
        /// and a string-encoded representation. Returns null if neither form is recognized.
        /// </summary>
        public double? GetDoubleCoercedOrNull() =>
            element.ValueKind switch
            {
                JsonValueKind.String => double.ParseOrNull(
                    element.GetString(),
                    CultureInfo.InvariantCulture
                ),
                _ => element.GetDoubleOrNull(),
            };

        /// <summary>
        /// Reads the element's value as a <see cref="double"/>, accepting both a native number
        /// and a string-encoded representation. Throws <see cref="InvalidOperationException"/> if
        /// neither form is recognized.
        /// </summary>
        public double GetDoubleCoerced() =>
            element.GetDoubleCoercedOrNull()
            ?? throw new InvalidOperationException(
                "Cannot read or coerce the specified JSON element into a double value."
            );

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
        /// Reads the element's value as a <see cref="short"/>, accepting both a native number
        /// and a string-encoded representation. Returns null if neither form is recognized.
        /// </summary>
        public short? GetInt16CoercedOrNull() =>
            element.ValueKind switch
            {
                JsonValueKind.String => short.ParseOrNull(
                    element.GetString(),
                    CultureInfo.InvariantCulture
                ),
                _ => element.GetInt16OrNull(),
            };

        /// <summary>
        /// Reads the element's value as a <see cref="short"/>, accepting both a native number
        /// and a string-encoded representation. Throws <see cref="InvalidOperationException"/> if
        /// neither form is recognized.
        /// </summary>
        public short GetInt16Coerced() =>
            element.GetInt16CoercedOrNull()
            ?? throw new InvalidOperationException(
                "Cannot read or coerce the specified JSON element into a short value."
            );

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
        /// Reads the element's value as an <see cref="int"/>, accepting both a native number
        /// and a string-encoded representation. Returns null if neither form is recognized.
        /// </summary>
        public int? GetInt32CoercedOrNull() =>
            element.ValueKind switch
            {
                JsonValueKind.String => int.ParseOrNull(
                    element.GetString(),
                    CultureInfo.InvariantCulture
                ),
                _ => element.GetInt32OrNull(),
            };

        /// <summary>
        /// Reads the element's value as an <see cref="int"/>, accepting both a native number
        /// and a string-encoded representation. Throws <see cref="InvalidOperationException"/> if
        /// neither form is recognized.
        /// </summary>
        public int GetInt32Coerced() =>
            element.GetInt32CoercedOrNull()
            ?? throw new InvalidOperationException(
                "Cannot read or coerce the specified JSON element into an int value."
            );

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
        /// Reads the element's value as a <see cref="long"/>, accepting both a native number
        /// and a string-encoded representation. Returns null if neither form is recognized.
        /// </summary>
        public long? GetInt64CoercedOrNull() =>
            element.ValueKind switch
            {
                JsonValueKind.String => long.ParseOrNull(
                    element.GetString(),
                    CultureInfo.InvariantCulture
                ),
                _ => element.GetInt64OrNull(),
            };

        /// <summary>
        /// Reads the element's value as a <see cref="long"/>, accepting both a native number
        /// and a string-encoded representation. Throws <see cref="InvalidOperationException"/> if
        /// neither form is recognized.
        /// </summary>
        public long GetInt64Coerced() =>
            element.GetInt64CoercedOrNull()
            ?? throw new InvalidOperationException(
                "Cannot read or coerce the specified JSON element into a long value."
            );

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
        /// Reads the element's value as an <see cref="sbyte"/>, accepting both a native number
        /// and a string-encoded representation. Returns null if neither form is recognized.
        /// </summary>
        public sbyte? GetSByteCoercedOrNull() =>
            element.ValueKind switch
            {
                JsonValueKind.String => sbyte.ParseOrNull(
                    element.GetString(),
                    CultureInfo.InvariantCulture
                ),
                _ => element.GetSByteOrNull(),
            };

        /// <summary>
        /// Reads the element's value as an <see cref="sbyte"/>, accepting both a native number
        /// and a string-encoded representation. Throws <see cref="InvalidOperationException"/> if
        /// neither form is recognized.
        /// </summary>
        public sbyte GetSByteCoerced() =>
            element.GetSByteCoercedOrNull()
            ?? throw new InvalidOperationException(
                "Cannot read or coerce the specified JSON element into an sbyte value."
            );

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
        /// Reads the element's value as a <see cref="float"/>, accepting both a native number
        /// and a string-encoded representation. Returns null if neither form is recognized.
        /// </summary>
        public float? GetSingleCoercedOrNull() =>
            element.ValueKind switch
            {
                JsonValueKind.String => float.ParseOrNull(
                    element.GetString(),
                    CultureInfo.InvariantCulture
                ),
                _ => element.GetSingleOrNull(),
            };

        /// <summary>
        /// Reads the element's value as a <see cref="float"/>, accepting both a native number
        /// and a string-encoded representation. Throws <see cref="InvalidOperationException"/> if
        /// neither form is recognized.
        /// </summary>
        public float GetSingleCoerced() =>
            element.GetSingleCoercedOrNull()
            ?? throw new InvalidOperationException(
                "Cannot read or coerce the specified JSON element into a float value."
            );

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
        /// Reads the element's value as a <see cref="ushort"/>, accepting both a native number
        /// and a string-encoded representation. Returns null if neither form is recognized.
        /// </summary>
        public ushort? GetUInt16CoercedOrNull() =>
            element.ValueKind switch
            {
                JsonValueKind.String => ushort.ParseOrNull(
                    element.GetString(),
                    CultureInfo.InvariantCulture
                ),
                _ => element.GetUInt16OrNull(),
            };

        /// <summary>
        /// Reads the element's value as a <see cref="ushort"/>, accepting both a native number
        /// and a string-encoded representation. Throws <see cref="InvalidOperationException"/> if
        /// neither form is recognized.
        /// </summary>
        public ushort GetUInt16Coerced() =>
            element.GetUInt16CoercedOrNull()
            ?? throw new InvalidOperationException(
                "Cannot read or coerce the specified JSON element into a ushort value."
            );

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
        /// Reads the element's value as a <see cref="uint"/>, accepting both a native number
        /// and a string-encoded representation. Returns null if neither form is recognized.
        /// </summary>
        public uint? GetUInt32CoercedOrNull() =>
            element.ValueKind switch
            {
                JsonValueKind.String => uint.ParseOrNull(
                    element.GetString(),
                    CultureInfo.InvariantCulture
                ),
                _ => element.GetUInt32OrNull(),
            };

        /// <summary>
        /// Reads the element's value as a <see cref="uint"/>, accepting both a native number
        /// and a string-encoded representation. Throws <see cref="InvalidOperationException"/> if
        /// neither form is recognized.
        /// </summary>
        public uint GetUInt32Coerced() =>
            element.GetUInt32CoercedOrNull()
            ?? throw new InvalidOperationException(
                "Cannot read or coerce the specified JSON element into a uint value."
            );

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

        /// <summary>
        /// Reads the element's value as a <see cref="ulong"/>, accepting both a native number
        /// and a string-encoded representation. Returns null if neither form is recognized.
        /// </summary>
        public ulong? GetUInt64CoercedOrNull() =>
            element.ValueKind switch
            {
                JsonValueKind.String => ulong.ParseOrNull(
                    element.GetString(),
                    CultureInfo.InvariantCulture
                ),
                _ => element.GetUInt64OrNull(),
            };

        /// <summary>
        /// Reads the element's value as a <see cref="ulong"/>, accepting both a native number
        /// and a string-encoded representation. Throws <see cref="InvalidOperationException"/> if
        /// neither form is recognized.
        /// </summary>
        public ulong GetUInt64Coerced() =>
            element.GetUInt64CoercedOrNull()
            ?? throw new InvalidOperationException(
                "Cannot read or coerce the specified JSON element into a ulong value."
            );

        /// <summary>
        /// Returns the element's value as a <see cref="string"/>,
        /// or null if the element is not a string.
        /// </summary>
        public string? GetStringOrNull() =>
            element.ValueKind == JsonValueKind.String ? element.GetString() : null;

        /// <summary>
        /// Returns the element's string value stripped to a non-empty result,
        /// or null if the element is not a string or its value is empty.
        /// </summary>
        public string? GetNonEmptyStringOrNull()
        {
            var result = element.GetStringOrNull();
            return !string.IsNullOrEmpty(result) ? result : null;
        }

        /// <summary>
        /// Returns the element's string value, requiring it to be non-empty.
        /// Throws <see cref="InvalidOperationException"/> if the element is not a string or its value is empty.
        /// </summary>
        public string GetNonEmptyString() =>
            element.GetNonEmptyStringOrNull()
            ?? throw new InvalidOperationException(
                "Cannot read the specified JSON element as a non-empty string value."
            );

        /// <summary>
        /// Returns the element's string value.
        /// Throws <see cref="InvalidOperationException"/> if the element is not a string.
        /// </summary>
        public string GetNonNullString() =>
            element.GetStringOrNull()
            ?? throw new InvalidOperationException(
                "Cannot read the specified JSON element as a non-null string value."
            );

        /// <summary>
        /// Returns the element's string value stripped to a non-whitespace result,
        /// or null if the element is not a string or its value is blank.
        /// </summary>
        public string? GetNonWhiteSpaceStringOrNull()
        {
            var result = element.GetStringOrNull();
            return !string.IsNullOrWhiteSpace(result) ? result : null;
        }

        /// <summary>
        /// Returns the element's string value, requiring it to be non-whitespace.
        /// Throws <see cref="InvalidOperationException"/> if the element is not a string or its value is blank.
        /// </summary>
        public string GetNonWhiteSpaceString() =>
            element.GetNonWhiteSpaceStringOrNull()
            ?? throw new InvalidOperationException(
                "Cannot read the specified JSON element as a non-empty and non-whitespace string value."
            );
    }

    extension(JsonElement)
    {
        /// <summary>
        /// Parses the UTF-8 encoded JSON byte array and returns its root element.
        /// </summary>
        public static JsonElement Parse(byte[] json, JsonDocumentOptions options = default)
        {
            using var document = JsonDocument.Parse(json, options);
            return document.RootElement.Clone();
        }

        /// <summary>
        /// Parses the JSON string and returns its root element.
        /// </summary>
        public static JsonElement Parse(string json, JsonDocumentOptions options = default)
        {
            using var document = JsonDocument.Parse(json, options);
            return document.RootElement.Clone();
        }

        /// <summary>
        /// Attempts to parse the UTF-8 encoded JSON byte array and returns its root element,
        /// or null if the input is not valid JSON.
        /// </summary>
        public static JsonElement? TryParse(byte[] json, JsonDocumentOptions options = default)
        {
            try
            {
                return Parse(json, options);
            }
            catch (JsonException)
            {
                return null;
            }
        }

        /// <summary>
        /// Attempts to parse the JSON string and returns its root element,
        /// or null if the input is not valid JSON.
        /// </summary>
        public static JsonElement? TryParse(string json, JsonDocumentOptions options = default)
        {
            try
            {
                return Parse(json, options);
            }
            catch (JsonException)
            {
                return null;
            }
        }
    }
}
