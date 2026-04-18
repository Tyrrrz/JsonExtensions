using System;
using System.Text.Json;

namespace JsonExtensions.Reading;

/// <summary>
/// Extensions for extracting validated string values from <see cref="JsonElement"/>.
/// </summary>
public static class StringExtensions
{
    /// <inheritdoc cref="StringExtensions" />
    extension(JsonElement element)
    {
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
}
