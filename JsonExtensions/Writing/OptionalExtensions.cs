using System;
using System.Text.Json;

namespace JsonExtensions.Writing;

/// <summary>
/// Nullable-aware extensions for <see cref="Utf8JsonWriter"/> that emit a JSON null token
/// in place of absent values.
/// </summary>
public static class OptionalExtensions
{
    /// <inheritdoc cref="OptionalExtensions" />
    extension(Utf8JsonWriter writer)
    {
        /// <summary>
        /// Writes <paramref name="value"/> as a JSON boolean, or a JSON null if <paramref name="value"/> is null.
        /// </summary>
        public void WriteBooleanValue(bool? value)
        {
            if (value is not null)
                writer.WriteBooleanValue(value.Value);
            else
                writer.WriteNullValue();
        }

        /// <summary>
        /// Writes a property named <paramref name="propertyName"/> with a boolean value,
        /// or a JSON null if <paramref name="value"/> is null.
        /// </summary>
        public void WriteBoolean(string propertyName, bool? value)
        {
            writer.WritePropertyName(propertyName);
            writer.WriteBooleanValue(value);
        }

        /// <summary>
        /// Writes <paramref name="value"/> as a JSON number, or a JSON null if <paramref name="value"/> is null.
        /// </summary>
        public void WriteNumberValue(byte? value)
        {
            if (value is not null)
                writer.WriteNumberValue(value.Value);
            else
                writer.WriteNullValue();
        }

        /// <inheritdoc cref="WriteNumberValue(Utf8JsonWriter, byte?)" />
        public void WriteNumberValue(decimal? value)
        {
            if (value is not null)
                writer.WriteNumberValue(value.Value);
            else
                writer.WriteNullValue();
        }

        /// <inheritdoc cref="WriteNumberValue(Utf8JsonWriter, byte?)"/>
        public void WriteNumberValue(double? value)
        {
            if (value is not null)
                writer.WriteNumberValue(value.Value);
            else
                writer.WriteNullValue();
        }

        /// <inheritdoc cref="WriteNumberValue(Utf8JsonWriter, byte?)"/>
        public void WriteNumberValue(float? value)
        {
            if (value is not null)
                writer.WriteNumberValue(value.Value);
            else
                writer.WriteNullValue();
        }

        /// <inheritdoc cref="WriteNumberValue(Utf8JsonWriter, byte?)"/>
        public void WriteNumberValue(int? value)
        {
            if (value is not null)
                writer.WriteNumberValue(value.Value);
            else
                writer.WriteNullValue();
        }

        /// <inheritdoc cref="WriteNumberValue(Utf8JsonWriter, byte?)"/>
        public void WriteNumberValue(long? value)
        {
            if (value is not null)
                writer.WriteNumberValue(value.Value);
            else
                writer.WriteNullValue();
        }

        /// <inheritdoc cref="WriteNumberValue(Utf8JsonWriter, byte?)"/>
        public void WriteNumberValue(sbyte? value)
        {
            if (value is not null)
                writer.WriteNumberValue(value.Value);
            else
                writer.WriteNullValue();
        }

        /// <inheritdoc cref="WriteNumberValue(Utf8JsonWriter, byte?)"/>
        public void WriteNumberValue(short? value)
        {
            if (value is not null)
                writer.WriteNumberValue(value.Value);
            else
                writer.WriteNullValue();
        }

        /// <inheritdoc cref="WriteNumberValue(Utf8JsonWriter, byte?)"/>
        public void WriteNumberValue(uint? value)
        {
            if (value is not null)
                writer.WriteNumberValue(value.Value);
            else
                writer.WriteNullValue();
        }

        /// <inheritdoc cref="WriteNumberValue(Utf8JsonWriter, byte?)"/>
        public void WriteNumberValue(ulong? value)
        {
            if (value is not null)
                writer.WriteNumberValue(value.Value);
            else
                writer.WriteNullValue();
        }

        /// <inheritdoc cref="WriteNumberValue(Utf8JsonWriter, byte?)"/>
        public void WriteNumberValue(ushort? value)
        {
            if (value is not null)
                writer.WriteNumberValue(value.Value);
            else
                writer.WriteNullValue();
        }

        /// <summary>
        /// Writes a property named <paramref name="propertyName"/> with a numeric value,
        /// or a JSON null if <paramref name="value"/> is null.
        /// </summary>
        public void WriteNumber(string propertyName, byte? value)
        {
            writer.WritePropertyName(propertyName);
            writer.WriteNumberValue(value);
        }

        /// <inheritdoc cref="WriteNumber(Utf8JsonWriter, string, byte?)"/>
        public void WriteNumber(string propertyName, decimal? value)
        {
            writer.WritePropertyName(propertyName);
            writer.WriteNumberValue(value);
        }

        /// <inheritdoc cref="WriteNumber(Utf8JsonWriter, string, byte?)"/>
        public void WriteNumber(string propertyName, double? value)
        {
            writer.WritePropertyName(propertyName);
            writer.WriteNumberValue(value);
        }

        /// <inheritdoc cref="WriteNumber(Utf8JsonWriter, string, byte?)"/>
        public void WriteNumber(string propertyName, float? value)
        {
            writer.WritePropertyName(propertyName);
            writer.WriteNumberValue(value);
        }

        /// <inheritdoc cref="WriteNumber(Utf8JsonWriter, string, byte?)"/>
        public void WriteNumber(string propertyName, int? value)
        {
            writer.WritePropertyName(propertyName);
            writer.WriteNumberValue(value);
        }

        /// <inheritdoc cref="WriteNumber(Utf8JsonWriter, string, byte?)"/>
        public void WriteNumber(string propertyName, long? value)
        {
            writer.WritePropertyName(propertyName);
            writer.WriteNumberValue(value);
        }

        /// <inheritdoc cref="WriteNumber(Utf8JsonWriter, string, byte?)"/>
        public void WriteNumber(string propertyName, sbyte? value)
        {
            writer.WritePropertyName(propertyName);
            writer.WriteNumberValue(value);
        }

        /// <inheritdoc cref="WriteNumber(Utf8JsonWriter, string, byte?)"/>
        public void WriteNumber(string propertyName, short? value)
        {
            writer.WritePropertyName(propertyName);
            writer.WriteNumberValue(value);
        }

        /// <inheritdoc cref="WriteNumber(Utf8JsonWriter, string, byte?)"/>
        public void WriteNumber(string propertyName, uint? value)
        {
            writer.WritePropertyName(propertyName);
            writer.WriteNumberValue(value);
        }

        /// <inheritdoc cref="WriteNumber(Utf8JsonWriter, string, byte?)"/>
        public void WriteNumber(string propertyName, ulong? value)
        {
            writer.WritePropertyName(propertyName);
            writer.WriteNumberValue(value);
        }

        /// <inheritdoc cref="WriteNumber(Utf8JsonWriter, string, byte?)"/>
        public void WriteNumber(string propertyName, ushort? value)
        {
            writer.WritePropertyName(propertyName);
            writer.WriteNumberValue(value);
        }

        /// <summary>
        /// Writes <paramref name="value"/> as a JSON string, or a JSON null if <paramref name="value"/> is null.
        /// </summary>
        public void WriteStringValue(DateTime? value)
        {
            if (value is not null)
                writer.WriteStringValue(value.Value);
            else
                writer.WriteNullValue();
        }

        /// <inheritdoc cref="WriteStringValue(Utf8JsonWriter, DateTime?)"/>
        public void WriteStringValue(DateTimeOffset? value)
        {
            if (value is not null)
                writer.WriteStringValue(value.Value);
            else
                writer.WriteNullValue();
        }

        /// <inheritdoc cref="WriteStringValue(Utf8JsonWriter, DateTime?)"/>
        public void WriteStringValue(Guid? value)
        {
            if (value is not null)
                writer.WriteStringValue(value.Value);
            else
                writer.WriteNullValue();
        }

        /// <summary>
        /// Writes a property named <paramref name="propertyName"/> with a string value,
        /// or a JSON null if <paramref name="value"/> is null.
        /// </summary>
        public void WriteString(string propertyName, DateTime? value)
        {
            writer.WritePropertyName(propertyName);
            writer.WriteStringValue(value);
        }

        /// <inheritdoc cref="WriteString(Utf8JsonWriter, string, DateTime?)"/>
        public void WriteString(string propertyName, DateTimeOffset? value)
        {
            writer.WritePropertyName(propertyName);
            writer.WriteStringValue(value);
        }

        /// <inheritdoc cref="WriteString(Utf8JsonWriter, string, DateTime?)"/>
        public void WriteString(string propertyName, Guid? value)
        {
            writer.WritePropertyName(propertyName);
            writer.WriteStringValue(value);
        }
    }
}
