using System;
using System.Text.Json;

namespace JsonExtensions.Writing;

/// <summary>
/// Extensions for <see cref="Utf8JsonWriter"/> that enable conditional writing for nullable types.
/// </summary>
public static class OptionalExtensions
{
    /// <inheritdoc cref="OptionalExtensions" />
    extension(Utf8JsonWriter writer)
    {
        /// <summary>
        /// Writes a <see cref="bool"/> value or null.
        /// </summary>
        public void WriteBooleanValue(bool? value)
        {
            if (value is not null)
                writer.WriteBooleanValue(value.Value);
            else
                writer.WriteNullValue();
        }

        /// <summary>
        /// Writes a <see cref="bool"/> property or null.
        /// </summary>
        public void WriteBoolean(string propertyName, bool? value)
        {
            writer.WritePropertyName(propertyName);
            writer.WriteBooleanValue(value);
        }

        /// <summary>
        /// Writes a <see cref="byte"/> value or null.
        /// </summary>
        public void WriteNumberValue(byte? value)
        {
            if (value is not null)
                writer.WriteNumberValue(value.Value);
            else
                writer.WriteNullValue();
        }

        /// <summary>
        /// Writes a <see cref="byte"/> property or null.
        /// </summary>
        public void WriteNumber(string propertyName, byte? value)
        {
            writer.WritePropertyName(propertyName);
            writer.WriteNumberValue(value);
        }

        /// <summary>
        /// Writes a <see cref="decimal"/> value or null.
        /// </summary>
        public void WriteNumberValue(decimal? value)
        {
            if (value is not null)
                writer.WriteNumberValue(value.Value);
            else
                writer.WriteNullValue();
        }

        /// <summary>
        /// Writes a <see cref="decimal"/> property or null.
        /// </summary>
        public void WriteNumber(string propertyName, decimal? value)
        {
            writer.WritePropertyName(propertyName);
            writer.WriteNumberValue(value);
        }

        /// <summary>
        /// Writes a <see cref="double"/> value or null.
        /// </summary>
        public void WriteNumberValue(double? value)
        {
            if (value is not null)
                writer.WriteNumberValue(value.Value);
            else
                writer.WriteNullValue();
        }

        /// <summary>
        /// Writes a <see cref="double"/> property or null.
        /// </summary>
        public void WriteNumber(string propertyName, double? value)
        {
            writer.WritePropertyName(propertyName);
            writer.WriteNumberValue(value);
        }

        /// <summary>
        /// Writes a <see cref="float"/> value or null.
        /// </summary>
        public void WriteNumberValue(float? value)
        {
            if (value is not null)
                writer.WriteNumberValue(value.Value);
            else
                writer.WriteNullValue();
        }

        /// <summary>
        /// Writes a <see cref="float"/> property or null.
        /// </summary>
        public void WriteNumber(string propertyName, float? value)
        {
            writer.WritePropertyName(propertyName);
            writer.WriteNumberValue(value);
        }

        /// <summary>
        /// Writes a <see cref="short"/> value or null.
        /// </summary>
        public void WriteNumberValue(short? value)
        {
            if (value is not null)
                writer.WriteNumberValue(value.Value);
            else
                writer.WriteNullValue();
        }

        /// <summary>
        /// Writes a <see cref="short"/> property or null.
        /// </summary>
        public void WriteNumber(string propertyName, short? value)
        {
            writer.WritePropertyName(propertyName);
            writer.WriteNumberValue(value);
        }

        /// <summary>
        /// Writes a <see cref="int"/> value or null.
        /// </summary>
        public void WriteNumberValue(int? value)
        {
            if (value is not null)
                writer.WriteNumberValue(value.Value);
            else
                writer.WriteNullValue();
        }

        /// <summary>
        /// Writes a <see cref="int"/> property or null.
        /// </summary>
        public void WriteNumber(string propertyName, int? value)
        {
            writer.WritePropertyName(propertyName);
            writer.WriteNumberValue(value);
        }

        /// <summary>
        /// Writes a <see cref="long"/> value or null.
        /// </summary>
        public void WriteNumberValue(long? value)
        {
            if (value is not null)
                writer.WriteNumberValue(value.Value);
            else
                writer.WriteNullValue();
        }

        /// <summary>
        /// Writes a <see cref="long"/> property or null.
        /// </summary>
        public void WriteNumber(string propertyName, long? value)
        {
            writer.WritePropertyName(propertyName);
            writer.WriteNumberValue(value);
        }

        /// <summary>
        /// Writes a <see cref="sbyte"/> value or null.
        /// </summary>
        public void WriteNumberValue(sbyte? value)
        {
            if (value is not null)
                writer.WriteNumberValue(value.Value);
            else
                writer.WriteNullValue();
        }

        /// <summary>
        /// Writes a <see cref="sbyte"/> property or null.
        /// </summary>
        public void WriteNumber(string propertyName, sbyte? value)
        {
            writer.WritePropertyName(propertyName);
            writer.WriteNumberValue(value);
        }

        /// <summary>
        /// Writes a <see cref="ushort"/> value or null.
        /// </summary>
        public void WriteNumberValue(ushort? value)
        {
            if (value is not null)
                writer.WriteNumberValue(value.Value);
            else
                writer.WriteNullValue();
        }

        /// <summary>
        /// Writes a <see cref="ushort"/> property or null.
        /// </summary>
        public void WriteNumber(string propertyName, ushort? value)
        {
            writer.WritePropertyName(propertyName);
            writer.WriteNumberValue(value);
        }

        /// <summary>
        /// Writes a <see cref="uint"/> value or null.
        /// </summary>
        public void WriteNumberValue(uint? value)
        {
            if (value is not null)
                writer.WriteNumberValue(value.Value);
            else
                writer.WriteNullValue();
        }

        /// <summary>
        /// Writes a <see cref="uint"/> property or null.
        /// </summary>
        public void WriteNumber(string propertyName, uint? value)
        {
            writer.WritePropertyName(propertyName);
            writer.WriteNumberValue(value);
        }

        /// <summary>
        /// Writes a <see cref="ulong"/> value or null.
        /// </summary>
        public void WriteNumberValue(ulong? value)
        {
            if (value is not null)
                writer.WriteNumberValue(value.Value);
            else
                writer.WriteNullValue();
        }

        /// <summary>
        /// Writes a <see cref="ulong"/> property or null.
        /// </summary>
        public void WriteNumber(string propertyName, ulong? value)
        {
            writer.WritePropertyName(propertyName);
            writer.WriteNumberValue(value);
        }

        /// <summary>
        /// Writes a <see cref="Guid"/> value or null.
        /// </summary>
        public void WriteStringValue(Guid? value)
        {
            if (value is not null)
                writer.WriteStringValue(value.Value);
            else
                writer.WriteNullValue();
        }

        /// <summary>
        /// Writes a <see cref="Guid"/> property or null.
        /// </summary>
        public void WriteString(string propertyName, Guid? value)
        {
            writer.WritePropertyName(propertyName);
            writer.WriteStringValue(value);
        }

        /// <summary>
        /// Writes a <see cref="DateTime"/> value or null.
        /// </summary>
        public void WriteStringValue(DateTime? value)
        {
            if (value is not null)
                writer.WriteStringValue(value.Value);
            else
                writer.WriteNullValue();
        }

        /// <summary>
        /// Writes a <see cref="DateTime"/> property or null.
        /// </summary>
        public void WriteString(string propertyName, DateTime? value)
        {
            writer.WritePropertyName(propertyName);
            writer.WriteStringValue(value);
        }

        /// <summary>
        /// Writes a <see cref="DateTimeOffset"/> value or null.
        /// </summary>
        public void WriteStringValue(DateTimeOffset? value)
        {
            if (value is not null)
                writer.WriteStringValue(value.Value);
            else
                writer.WriteNullValue();
        }

        /// <summary>
        /// Writes a <see cref="DateTimeOffset"/> property or null.
        /// </summary>
        public void WriteString(string propertyName, DateTimeOffset? value)
        {
            writer.WritePropertyName(propertyName);
            writer.WriteStringValue(value);
        }
    }
}
