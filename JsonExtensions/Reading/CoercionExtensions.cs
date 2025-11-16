using System;
using System.Globalization;
using System.Text.Json;

namespace JsonExtensions.Reading;

/// <summary>
/// Extensions for reading content from <see cref="JsonElement"/> with coercion.
/// </summary>
public static class CoercionExtensions
{
    /// <inheritdoc cref="CoercionExtensions" />
    extension(JsonElement element)
    {
        /// <summary>
        /// Gets the value of the element as a <see cref="bool"/>,
        /// either by reading it directly or by coercing it from a string.
        ///
        /// Returns null if the element contains a value of any other kind.
        /// </summary>
        public bool? GetBooleanCoercedOrNull() =>
            element.ValueKind switch
            {
                JsonValueKind.String => bool.TryParse(element.GetString(), out var result)
                    ? result
                    : null,
                _ => element.GetBooleanOrNull(),
            };

        /// <summary>
        /// Gets the value of the element as a <see cref="bool"/>,
        /// either by reading it directly or by coercing it from a string.
        /// </summary>
        public bool GetBooleanCoerced() =>
            element.GetBooleanCoercedOrNull()
            ?? throw new InvalidOperationException(
                "Cannot read or coerce the specified JSON element into a boolean value."
            );

        /// <summary>
        /// Gets the value of the element as a <see cref="byte"/>,
        /// either by reading it directly or by coercing it from a string.
        ///
        /// Returns null if the element contains a value of any other kind.
        /// </summary>
        public byte? GetByteCoercedOrNull() =>
            element.ValueKind switch
            {
                JsonValueKind.String => byte.TryParse(
                    element.GetString(),
                    NumberStyles.Integer,
                    CultureInfo.InvariantCulture,
                    out var result
                )
                    ? result
                    : null,

                _ => element.GetByteOrNull(),
            };

        /// <summary>
        /// Gets the value of the element as a <see cref="byte"/>,
        /// either by reading it directly or by coercing it from a string.
        /// </summary>
        public byte GetByteCoerced() =>
            element.GetByteCoercedOrNull()
            ?? throw new InvalidOperationException(
                "Cannot read or coerce the specified JSON element into a byte value."
            );

        /// <summary>
        /// Gets the value of the element as a <see cref="decimal"/>,
        /// either by reading it directly or by coercing it from a string.
        ///
        /// Returns null if the element contains a value of any other kind.
        /// </summary>
        public decimal? GetDecimalCoercedOrNull() =>
            element.ValueKind switch
            {
                JsonValueKind.String => decimal.TryParse(
                    element.GetString(),
                    NumberStyles.Number,
                    CultureInfo.InvariantCulture,
                    out var result
                )
                    ? result
                    : null,

                _ => element.GetDecimalOrNull(),
            };

        /// <summary>
        /// Gets the value of the element as a <see cref="decimal"/>,
        /// either by reading it directly or by coercing it from a string.
        /// </summary>
        public decimal GetDecimalCoerced() =>
            element.GetDecimalCoercedOrNull()
            ?? throw new InvalidOperationException(
                "Cannot read or coerce the specified JSON element into a decimal value."
            );

        /// <summary>
        /// Gets the value of the element as a <see cref="double"/>,
        /// either by reading it directly or by coercing it from a string.
        ///
        /// Returns null if the element contains a value of any other kind.
        /// </summary>
        public double? GetDoubleCoercedOrNull() =>
            element.ValueKind switch
            {
                JsonValueKind.String => double.TryParse(
                    element.GetString(),
                    NumberStyles.Number,
                    CultureInfo.InvariantCulture,
                    out var result
                )
                    ? result
                    : null,

                _ => element.GetDoubleOrNull(),
            };

        /// <summary>
        /// Gets the value of the element as a <see cref="double"/>,
        /// either by reading it directly or by coercing it from a string.
        /// </summary>
        public double GetDoubleCoerced() =>
            element.GetDoubleCoercedOrNull()
            ?? throw new InvalidOperationException(
                "Cannot read or coerce the specified JSON element into a double value."
            );

        /// <summary>
        /// Gets the value of the element as a <see cref="float"/>,
        /// either by reading it directly or by coercing it from a string.
        ///
        /// Returns null if the element contains a value of any other kind.
        /// </summary>
        public float? GetSingleCoercedOrNull() =>
            element.ValueKind switch
            {
                JsonValueKind.String => float.TryParse(
                    element.GetString(),
                    NumberStyles.Number,
                    CultureInfo.InvariantCulture,
                    out var result
                )
                    ? result
                    : null,

                _ => element.GetSingleOrNull(),
            };

        /// <summary>
        /// Gets the value of the element as a <see cref="float"/>,
        /// either by reading it directly or by coercing it from a string.
        /// </summary>
        public float GetSingleCoerced() =>
            element.GetSingleCoercedOrNull()
            ?? throw new InvalidOperationException(
                "Cannot read or coerce the specified JSON element into a float value."
            );

        /// <summary>
        /// Gets the value of the element as a <see cref="short"/>,
        /// either by reading it directly or by coercing it from a string.
        ///
        /// Returns null if the element contains a value of any other kind.
        /// </summary>
        public short? GetInt16CoercedOrNull() =>
            element.ValueKind switch
            {
                JsonValueKind.String => short.TryParse(
                    element.GetString(),
                    NumberStyles.Integer,
                    CultureInfo.InvariantCulture,
                    out var result
                )
                    ? result
                    : null,

                _ => element.GetInt16OrNull(),
            };

        /// <summary>
        /// Gets the value of the element as a <see cref="short"/>,
        /// either by reading it directly or by coercing it from a string.
        /// </summary>
        public short GetInt16Coerced() =>
            element.GetInt16CoercedOrNull()
            ?? throw new InvalidOperationException(
                "Cannot read or coerce the specified JSON element into a short value."
            );

        /// <summary>
        /// Gets the value of the element as an <see cref="int"/>,
        /// either by reading it directly or by coercing it from a string.
        ///
        /// Returns null if the element contains a value of any other kind.
        /// </summary>
        public int? GetInt32CoercedOrNull() =>
            element.ValueKind switch
            {
                JsonValueKind.String => int.TryParse(
                    element.GetString(),
                    NumberStyles.Integer,
                    CultureInfo.InvariantCulture,
                    out var result
                )
                    ? result
                    : null,

                _ => element.GetInt32OrNull(),
            };

        /// <summary>
        /// Gets the value of the element as an <see cref="int"/>,
        /// either by reading it directly or by coercing it from a string.
        /// </summary>
        public int GetInt32Coerced() =>
            element.GetInt32CoercedOrNull()
            ?? throw new InvalidOperationException(
                "Cannot read or coerce the specified JSON element into an int value."
            );

        /// <summary>
        /// Gets the value of the element as a <see cref="long"/>,
        /// either by reading it directly or by coercing it from a string.
        ///
        /// Returns null if the element contains a value of any other kind.
        /// </summary>
        public long? GetInt64CoercedOrNull() =>
            element.ValueKind switch
            {
                JsonValueKind.String => long.TryParse(
                    element.GetString(),
                    NumberStyles.Integer,
                    CultureInfo.InvariantCulture,
                    out var result
                )
                    ? result
                    : null,

                _ => element.GetInt64OrNull(),
            };

        /// <summary>
        /// Gets the value of the element as a <see cref="long"/>,
        /// either by reading it directly or by coercing it from a string.
        /// </summary>
        public long GetInt64Coerced() =>
            element.GetInt64CoercedOrNull()
            ?? throw new InvalidOperationException(
                "Cannot read or coerce the specified JSON element into a long value."
            );

        /// <summary>
        /// Gets the value of the element as an <see cref="sbyte"/>,
        /// either by reading it directly or by coercing it from a string.
        ///
        /// Returns null if the element contains a value of any other kind.
        /// </summary>
        public sbyte? GetSByteCoercedOrNull() =>
            element.ValueKind switch
            {
                JsonValueKind.String => sbyte.TryParse(
                    element.GetString(),
                    NumberStyles.Integer,
                    CultureInfo.InvariantCulture,
                    out var result
                )
                    ? result
                    : null,

                _ => element.GetSByteOrNull(),
            };

        /// <summary>
        /// Gets the value of the element as an <see cref="sbyte"/>,
        /// either by reading it directly or by coercing it from a string.
        /// </summary>
        public sbyte GetSByteCoerced() =>
            element.GetSByteCoercedOrNull()
            ?? throw new InvalidOperationException(
                "Cannot read or coerce the specified JSON element into an sbyte value."
            );

        /// <summary>
        /// Gets the value of the element as a <see cref="ushort"/>,
        /// either by reading it directly or by coercing it from a string.
        ///
        /// Returns null if the element contains a value of any other kind.
        /// </summary>
        public ushort? GetUInt16CoercedOrNull() =>
            element.ValueKind switch
            {
                JsonValueKind.String => ushort.TryParse(
                    element.GetString(),
                    NumberStyles.Integer,
                    CultureInfo.InvariantCulture,
                    out var result
                )
                    ? result
                    : null,

                _ => element.GetUInt16OrNull(),
            };

        /// <summary>
        /// Gets the value of the element as a <see cref="ushort"/>,
        /// either by reading it directly or by coercing it from a string.
        /// </summary>
        public ushort GetUInt16Coerced() =>
            element.GetUInt16CoercedOrNull()
            ?? throw new InvalidOperationException(
                "Cannot read or coerce the specified JSON element into a ushort value."
            );

        /// <summary>
        /// Gets the value of the element as a <see cref="uint"/>,
        /// either by reading it directly or by coercing it from a string.
        ///
        /// Returns null if the element contains a value of any other kind.
        /// </summary>
        public uint? GetUInt32CoercedOrNull() =>
            element.ValueKind switch
            {
                JsonValueKind.String => uint.TryParse(
                    element.GetString(),
                    NumberStyles.Integer,
                    CultureInfo.InvariantCulture,
                    out var result
                )
                    ? result
                    : null,

                _ => element.GetUInt32OrNull(),
            };

        /// <summary>
        /// Gets the value of the element as a <see cref="uint"/>,
        /// either by reading it directly or by coercing it from a string.
        /// </summary>
        public uint GetUInt32Coerced() =>
            element.GetUInt32CoercedOrNull()
            ?? throw new InvalidOperationException(
                "Cannot read or coerce the specified JSON element into a uint value."
            );

        /// <summary>
        /// Gets the value of the element as a <see cref="ulong"/>,
        /// either by reading it directly or by coercing it from a string.
        ///
        /// Returns null if the element contains a value of any other kind.
        /// </summary>
        public ulong? GetUInt64CoercedOrNull() =>
            element.ValueKind switch
            {
                JsonValueKind.String => ulong.TryParse(
                    element.GetString(),
                    NumberStyles.Integer,
                    CultureInfo.InvariantCulture,
                    out var result
                )
                    ? result
                    : null,

                _ => element.GetUInt64OrNull(),
            };

        /// <summary>
        /// Gets the value of the element as a <see cref="ulong"/>,
        /// either by reading it directly or by coercing it from a string.
        /// </summary>
        public ulong GetUInt64Coerced() =>
            element.GetUInt64CoercedOrNull()
            ?? throw new InvalidOperationException(
                "Cannot read or coerce the specified JSON element into a ulong value."
            );
    }
}
