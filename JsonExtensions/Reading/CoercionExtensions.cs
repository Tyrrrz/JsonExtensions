using System;
using System.Globalization;
using System.Text.Json;
using PowerKit.Extensions;

namespace JsonExtensions.Reading;

/// <summary>
/// Extensions for reading values from <see cref="JsonElement"/> with transparent string coercion.
/// </summary>
public static class CoercionExtensions
{
    /// <inheritdoc cref="CoercionExtensions" />
    extension(JsonElement element)
    {
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
    }
}
