using System;
using System.Globalization;
using System.Text.Json;

namespace JsonExtensions.Reading
{
    /// <summary>
    /// Extensions for reading content from <see cref="JsonElement"/> with coercion.
    /// </summary>
    public static class CoercionExtensions
    {
        /// <summary>
        /// Gets the value of the element as a <see cref="bool"/>,
        /// either by reading it directly or by coercing it from a string.
        ///
        /// Returns null if the element contains a value of any other kind.
        /// </summary>
        public static bool? GetBooleanCoercedOrNull(this JsonElement element) => element.ValueKind switch
        {
            JsonValueKind.String => bool.TryParse(element.GetString(), out var result) ? result : null,
            _ => element.GetBooleanOrNull()
        };

        /// <summary>
        /// Gets the value of the element as a <see cref="bool"/>,
        /// either by reading it directly or by coercing it from a string.
        /// </summary>
        public static bool GetBooleanCoerced(this JsonElement element) =>
            element.GetBooleanCoercedOrNull() ??
            throw new InvalidOperationException(
                "Cannot read or coerce the specified JSON element into a boolean value."
            );

        /// <summary>
        /// Gets the value of the element as a <see cref="byte"/>,
        /// either by reading it directly or by coercing it from a string.
        ///
        /// Returns null if the element contains a value of any other kind.
        /// </summary>
        public static byte? GetByteCoercedOrNull(this JsonElement element) => element.ValueKind switch
        {
            JsonValueKind.String => byte.TryParse(
                element.GetString(),
                NumberStyles.Integer,
                CultureInfo.InvariantCulture,
                out var result) ? result : null,

            _ => element.GetByteOrNull()
        };

        /// <summary>
        /// Gets the value of the element as a <see cref="byte"/>,
        /// either by reading it directly or by coercing it from a string.
        /// </summary>
        public static byte GetByteCoerced(this JsonElement element) =>
            element.GetByteCoercedOrNull() ??
            throw new InvalidOperationException(
                "Cannot read or coerce the specified JSON element into a byte value."
            );

        /// <summary>
        /// Gets the value of the element as a <see cref="decimal"/>,
        /// either by reading it directly or by coercing it from a string.
        ///
        /// Returns null if the element contains a value of any other kind.
        /// </summary>
        public static decimal? GetDecimalCoercedOrNull(this JsonElement element) => element.ValueKind switch
        {
            JsonValueKind.String => decimal.TryParse(
                element.GetString(),
                NumberStyles.Number,
                CultureInfo.InvariantCulture,
                out var result) ? result : null,

            _ => element.GetDecimalOrNull()
        };

        /// <summary>
        /// Gets the value of the element as a <see cref="decimal"/>,
        /// either by reading it directly or by coercing it from a string.
        /// </summary>
        public static decimal GetDecimalCoerced(this JsonElement element) =>
            element.GetDecimalCoercedOrNull() ??
            throw new InvalidOperationException(
                "Cannot read or coerce the specified JSON element into a decimal value."
            );

        /// <summary>
        /// Gets the value of the element as a <see cref="double"/>,
        /// either by reading it directly or by coercing it from a string.
        ///
        /// Returns null if the element contains a value of any other kind.
        /// </summary>
        public static double? GetDoubleCoercedOrNull(this JsonElement element) => element.ValueKind switch
        {
            JsonValueKind.String => double.TryParse(
                element.GetString(),
                NumberStyles.Number,
                CultureInfo.InvariantCulture,
                out var result) ? result : null,

            _ => element.GetDoubleOrNull()
        };

        /// <summary>
        /// Gets the value of the element as a <see cref="double"/>,
        /// either by reading it directly or by coercing it from a string.
        /// </summary>
        public static double GetDoubleCoerced(this JsonElement element) =>
            element.GetDoubleCoercedOrNull() ??
            throw new InvalidOperationException(
                "Cannot read or coerce the specified JSON element into a double value."
            );

        /// <summary>
        /// Gets the value of the element as a <see cref="float"/>,
        /// either by reading it directly or by coercing it from a string.
        ///
        /// Returns null if the element contains a value of any other kind.
        /// </summary>
        public static float? GetSingleCoercedOrNull(this JsonElement element) => element.ValueKind switch
        {
            JsonValueKind.String => float.TryParse(
                element.GetString(),
                NumberStyles.Number,
                CultureInfo.InvariantCulture,
                out var result) ? result : null,

            _ => element.GetSingleOrNull()
        };

        /// <summary>
        /// Gets the value of the element as a <see cref="float"/>,
        /// either by reading it directly or by coercing it from a string.
        /// </summary>
        public static float GetSingleCoerced(this JsonElement element) =>
            element.GetSingleCoercedOrNull() ??
            throw new InvalidOperationException(
                "Cannot read or coerce the specified JSON element into a float value."
            );

        /// <summary>
        /// Gets the value of the element as a <see cref="short"/>,
        /// either by reading it directly or by coercing it from a string.
        ///
        /// Returns null if the element contains a value of any other kind.
        /// </summary>
        public static short? GetInt16CoercedOrNull(this JsonElement element) => element.ValueKind switch
        {
            JsonValueKind.String => short.TryParse(
                element.GetString(),
                NumberStyles.Integer,
                CultureInfo.InvariantCulture,
                out var result) ? result : null,

            _ => element.GetInt16OrNull()
        };

        /// <summary>
        /// Gets the value of the element as a <see cref="short"/>,
        /// either by reading it directly or by coercing it from a string.
        /// </summary>
        public static short GetInt16Coerced(this JsonElement element) =>
            element.GetInt16CoercedOrNull() ??
            throw new InvalidOperationException(
                "Cannot read or coerce the specified JSON element into a short value."
            );

        /// <summary>
        /// Gets the value of the element as an <see cref="int"/>,
        /// either by reading it directly or by coercing it from a string.
        ///
        /// Returns null if the element contains a value of any other kind.
        /// </summary>
        public static int? GetInt32CoercedOrNull(this JsonElement element) => element.ValueKind switch
        {
            JsonValueKind.String => int.TryParse(
                element.GetString(),
                NumberStyles.Integer,
                CultureInfo.InvariantCulture,
                out var result) ? result : null,

            _ => element.GetInt32OrNull()
        };

        /// <summary>
        /// Gets the value of the element as an <see cref="int"/>,
        /// either by reading it directly or by coercing it from a string.
        /// </summary>
        public static int GetInt32Coerced(this JsonElement element) =>
            element.GetInt32CoercedOrNull() ??
            throw new InvalidOperationException(
                "Cannot read or coerce the specified JSON element into an int value."
            );

        /// <summary>
        /// Gets the value of the element as a <see cref="long"/>,
        /// either by reading it directly or by coercing it from a string.
        ///
        /// Returns null if the element contains a value of any other kind.
        /// </summary>
        public static long? GetInt64CoercedOrNull(this JsonElement element) => element.ValueKind switch
        {
            JsonValueKind.String => long.TryParse(
                element.GetString(),
                NumberStyles.Integer,
                CultureInfo.InvariantCulture,
                out var result) ? result : null,

            _ => element.GetInt64OrNull()
        };

        /// <summary>
        /// Gets the value of the element as a <see cref="long"/>,
        /// either by reading it directly or by coercing it from a string.
        /// </summary>
        public static long GetInt64Coerced(this JsonElement element) =>
            element.GetInt64CoercedOrNull() ??
            throw new InvalidOperationException(
                "Cannot read or coerce the specified JSON element into a long value."
            );

        /// <summary>
        /// Gets the value of the element as an <see cref="sbyte"/>,
        /// either by reading it directly or by coercing it from a string.
        ///
        /// Returns null if the element contains a value of any other kind.
        /// </summary>
        public static sbyte? GetSByteCoercedOrNull(this JsonElement element) => element.ValueKind switch
        {
            JsonValueKind.String => sbyte.TryParse(
                element.GetString(),
                NumberStyles.Integer,
                CultureInfo.InvariantCulture,
                out var result) ? result : null,

            _ => element.GetSByteOrNull()
        };

        /// <summary>
        /// Gets the value of the element as an <see cref="sbyte"/>,
        /// either by reading it directly or by coercing it from a string.
        /// </summary>
        public static sbyte GetSByteCoerced(this JsonElement element) =>
            element.GetSByteCoercedOrNull() ??
            throw new InvalidOperationException(
                "Cannot read or coerce the specified JSON element into an sbyte value."
            );

        /// <summary>
        /// Gets the value of the element as a <see cref="ushort"/>,
        /// either by reading it directly or by coercing it from a string.
        ///
        /// Returns null if the element contains a value of any other kind.
        /// </summary>
        public static ushort? GetUInt16CoercedOrNull(this JsonElement element) => element.ValueKind switch
        {
            JsonValueKind.String => ushort.TryParse(
                element.GetString(),
                NumberStyles.Integer,
                CultureInfo.InvariantCulture,
                out var result) ? result : null,

            _ => element.GetUInt16OrNull()
        };

        /// <summary>
        /// Gets the value of the element as a <see cref="ushort"/>,
        /// either by reading it directly or by coercing it from a string.
        /// </summary>
        public static ushort GetUInt16Coerced(this JsonElement element) =>
            element.GetUInt16CoercedOrNull() ??
            throw new InvalidOperationException(
                "Cannot read or coerce the specified JSON element into a ushort value."
            );

        /// <summary>
        /// Gets the value of the element as a <see cref="uint"/>,
        /// either by reading it directly or by coercing it from a string.
        ///
        /// Returns null if the element contains a value of any other kind.
        /// </summary>
        public static uint? GetUInt32CoercedOrNull(this JsonElement element) => element.ValueKind switch
        {
            JsonValueKind.String => uint.TryParse(
                element.GetString(),
                NumberStyles.Integer,
                CultureInfo.InvariantCulture,
                out var result) ? result : null,

            _ => element.GetUInt32OrNull()
        };

        /// <summary>
        /// Gets the value of the element as a <see cref="uint"/>,
        /// either by reading it directly or by coercing it from a string.
        /// </summary>
        public static uint GetUInt32Coerced(this JsonElement element) =>
            element.GetUInt32CoercedOrNull() ??
            throw new InvalidOperationException(
                "Cannot read or coerce the specified JSON element into a uint value."
            );

        /// <summary>
        /// Gets the value of the element as a <see cref="ulong"/>,
        /// either by reading it directly or by coercing it from a string.
        ///
        /// Returns null if the element contains a value of any other kind.
        /// </summary>
        public static ulong? GetUInt64CoercedOrNull(this JsonElement element) => element.ValueKind switch
        {
            JsonValueKind.String => ulong.TryParse(
                element.GetString(),
                NumberStyles.Integer,
                CultureInfo.InvariantCulture,
                out var result) ? result : null,

            _ => element.GetUInt64OrNull()
        };

        /// <summary>
        /// Gets the value of the element as a <see cref="ulong"/>,
        /// either by reading it directly or by coercing it from a string.
        /// </summary>
        public static ulong GetUInt64Coerced(this JsonElement element) =>
            element.GetUInt64CoercedOrNull() ??
            throw new InvalidOperationException(
                "Cannot read or coerce the specified JSON element into a ulong value."
            );
    }
}