using System;
using System.Text.Json;

namespace JsonExtensions.Writing
{
    /// <summary>
    /// Extensions for <see cref="Utf8JsonWriter"/> that enable conditional writing for nullable types.
    /// </summary>
    public static class OptionalExtensions
    {
        /// <summary>
        /// Writes a <see cref="bool"/> value or null.
        /// </summary>
        public static void WriteBooleanValue(this Utf8JsonWriter writer, bool? value)
        {
            if (value is not null)
                writer.WriteBooleanValue(value.Value);
            else
                writer.WriteNullValue();
        }

        /// <summary>
        /// Writes a <see cref="bool"/> property or null.
        /// </summary>
        public static void WriteBoolean(this Utf8JsonWriter writer, string propertyName, bool? value)
        {
            writer.WritePropertyName(propertyName);
            writer.WriteBooleanValue(value);
        }

        /// <summary>
        /// Writes a <see cref="byte"/> value or null.
        /// </summary>
        public static void WriteNumberValue(this Utf8JsonWriter writer, byte? value)
        {
            if (value is not null)
                writer.WriteNumberValue(value.Value);
            else
                writer.WriteNullValue();
        }

        /// <summary>
        /// Writes a <see cref="byte"/> property or null.
        /// </summary>
        public static void WriteNumber(this Utf8JsonWriter writer, string propertyName, byte? value)
        {
            writer.WritePropertyName(propertyName);
            writer.WriteNumberValue(value);
        }

        /// <summary>
        /// Writes a <see cref="decimal"/> value or null.
        /// </summary>
        public static void WriteNumberValue(this Utf8JsonWriter writer, decimal? value)
        {
            if (value is not null)
                writer.WriteNumberValue(value.Value);
            else
                writer.WriteNullValue();
        }

        /// <summary>
        /// Writes a <see cref="decimal"/> property or null.
        /// </summary>
        public static void WriteNumber(this Utf8JsonWriter writer, string propertyName, decimal? value)
        {
            writer.WritePropertyName(propertyName);
            writer.WriteNumberValue(value);
        }

        /// <summary>
        /// Writes a <see cref="double"/> value or null.
        /// </summary>
        public static void WriteNumberValue(this Utf8JsonWriter writer, double? value)
        {
            if (value is not null)
                writer.WriteNumberValue(value.Value);
            else
                writer.WriteNullValue();
        }

        /// <summary>
        /// Writes a <see cref="double"/> property or null.
        /// </summary>
        public static void WriteNumber(this Utf8JsonWriter writer, string propertyName, double? value)
        {
            writer.WritePropertyName(propertyName);
            writer.WriteNumberValue(value);
        }

        /// <summary>
        /// Writes a <see cref="float"/> value or null.
        /// </summary>
        public static void WriteNumberValue(this Utf8JsonWriter writer, float? value)
        {
            if (value is not null)
                writer.WriteNumberValue(value.Value);
            else
                writer.WriteNullValue();
        }

        /// <summary>
        /// Writes a <see cref="float"/> property or null.
        /// </summary>
        public static void WriteNumber(this Utf8JsonWriter writer, string propertyName, float? value)
        {
            writer.WritePropertyName(propertyName);
            writer.WriteNumberValue(value);
        }

        /// <summary>
        /// Writes a <see cref="short"/> value or null.
        /// </summary>
        public static void WriteNumberValue(this Utf8JsonWriter writer, short? value)
        {
            if (value is not null)
                writer.WriteNumberValue(value.Value);
            else
                writer.WriteNullValue();
        }

        /// <summary>
        /// Writes a <see cref="short"/> property or null.
        /// </summary>
        public static void WriteNumber(this Utf8JsonWriter writer, string propertyName, short? value)
        {
            writer.WritePropertyName(propertyName);
            writer.WriteNumberValue(value);
        }

        /// <summary>
        /// Writes a <see cref="int"/> value or null.
        /// </summary>
        public static void WriteNumberValue(this Utf8JsonWriter writer, int? value)
        {
            if (value is not null)
                writer.WriteNumberValue(value.Value);
            else
                writer.WriteNullValue();
        }

        /// <summary>
        /// Writes a <see cref="int"/> property or null.
        /// </summary>
        public static void WriteNumber(this Utf8JsonWriter writer, string propertyName, int? value)
        {
            writer.WritePropertyName(propertyName);
            writer.WriteNumberValue(value);
        }

        /// <summary>
        /// Writes a <see cref="long"/> value or null.
        /// </summary>
        public static void WriteNumberValue(this Utf8JsonWriter writer, long? value)
        {
            if (value is not null)
                writer.WriteNumberValue(value.Value);
            else
                writer.WriteNullValue();
        }

        /// <summary>
        /// Writes a <see cref="long"/> property or null.
        /// </summary>
        public static void WriteNumber(this Utf8JsonWriter writer, string propertyName, long? value)
        {
            writer.WritePropertyName(propertyName);
            writer.WriteNumberValue(value);
        }

        /// <summary>
        /// Writes a <see cref="sbyte"/> value or null.
        /// </summary>
        public static void WriteNumberValue(this Utf8JsonWriter writer, sbyte? value)
        {
            if (value is not null)
                writer.WriteNumberValue(value.Value);
            else
                writer.WriteNullValue();
        }

        /// <summary>
        /// Writes a <see cref="sbyte"/> property or null.
        /// </summary>
        public static void WriteNumber(this Utf8JsonWriter writer, string propertyName, sbyte? value)
        {
            writer.WritePropertyName(propertyName);
            writer.WriteNumberValue(value);
        }

        /// <summary>
        /// Writes a <see cref="ushort"/> value or null.
        /// </summary>
        public static void WriteNumberValue(this Utf8JsonWriter writer, ushort? value)
        {
            if (value is not null)
                writer.WriteNumberValue(value.Value);
            else
                writer.WriteNullValue();
        }

        /// <summary>
        /// Writes a <see cref="ushort"/> property or null.
        /// </summary>
        public static void WriteNumber(this Utf8JsonWriter writer, string propertyName, ushort? value)
        {
            writer.WritePropertyName(propertyName);
            writer.WriteNumberValue(value);
        }

        /// <summary>
        /// Writes a <see cref="uint"/> value or null.
        /// </summary>
        public static void WriteNumberValue(this Utf8JsonWriter writer, uint? value)
        {
            if (value is not null)
                writer.WriteNumberValue(value.Value);
            else
                writer.WriteNullValue();
        }

        /// <summary>
        /// Writes a <see cref="uint"/> property or null.
        /// </summary>
        public static void WriteNumber(this Utf8JsonWriter writer, string propertyName, uint? value)
        {
            writer.WritePropertyName(propertyName);
            writer.WriteNumberValue(value);
        }

        /// <summary>
        /// Writes a <see cref="ulong"/> value or null.
        /// </summary>
        public static void WriteNumberValue(this Utf8JsonWriter writer, ulong? value)
        {
            if (value is not null)
                writer.WriteNumberValue(value.Value);
            else
                writer.WriteNullValue();
        }

        /// <summary>
        /// Writes a <see cref="ulong"/> property or null.
        /// </summary>
        public static void WriteNumber(this Utf8JsonWriter writer, string propertyName, ulong? value)
        {
            writer.WritePropertyName(propertyName);
            writer.WriteNumberValue(value);
        }

        /// <summary>
        /// Writes a <see cref="Guid"/> value or null.
        /// </summary>
        public static void WriteStringValue(this Utf8JsonWriter writer, Guid? value)
        {
            if (value is not null)
                writer.WriteStringValue(value.Value);
            else
                writer.WriteNullValue();
        }

        /// <summary>
        /// Writes a <see cref="Guid"/> property or null.
        /// </summary>
        public static void WriteString(this Utf8JsonWriter writer, string propertyName, Guid? value)
        {
            writer.WritePropertyName(propertyName);
            writer.WriteStringValue(value);
        }

        /// <summary>
        /// Writes a <see cref="DateTime"/> value or null.
        /// </summary>
        public static void WriteStringValue(this Utf8JsonWriter writer, DateTime? value)
        {
            if (value is not null)
                writer.WriteStringValue(value.Value);
            else
                writer.WriteNullValue();
        }

        /// <summary>
        /// Writes a <see cref="DateTime"/> property or null.
        /// </summary>
        public static void WriteString(this Utf8JsonWriter writer, string propertyName, DateTime? value)
        {
            writer.WritePropertyName(propertyName);
            writer.WriteStringValue(value);
        }

        /// <summary>
        /// Writes a <see cref="DateTimeOffset"/> value or null.
        /// </summary>
        public static void WriteStringValue(this Utf8JsonWriter writer, DateTimeOffset? value)
        {
            if (value is not null)
                writer.WriteStringValue(value.Value);
            else
                writer.WriteNullValue();
        }

        /// <summary>
        /// Writes a <see cref="DateTimeOffset"/> property or null.
        /// </summary>
        public static void WriteString(this Utf8JsonWriter writer, string propertyName, DateTimeOffset? value)
        {
            writer.WritePropertyName(propertyName);
            writer.WriteStringValue(value);
        }
    }
}