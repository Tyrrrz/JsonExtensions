using System;
using System.Text.Json;

namespace JsonExtensions.Reading;

/// <summary>
/// Extensions for reading strings from <see cref="JsonElement"/>.
/// </summary>
public static class StringExtensions
{
    /// <inheritdoc cref="StringExtensions" />
    extension(JsonElement element)
    {
        /// <summary>
        /// Gets the value of the element as a non-null <see cref="string"/>.
        /// </summary>
        public string GetNonNullString() =>
            element.GetStringOrNull()
            ?? throw new InvalidOperationException(
                "Cannot read the specified JSON element as a non-null string value."
            );

        /// <summary>
        /// Gets the value of the element as a non-empty <see cref="string"/>.
        ///
        /// Returns null if the element contains an empty string or a value of any other kind.
        /// </summary>
        public string? GetNonEmptyStringOrNull()
        {
            var result = element.GetStringOrNull();
            return !string.IsNullOrEmpty(result) ? result : null;
        }

        /// <summary>
        /// Gets the value of the element as a non-empty <see cref="string"/>.
        /// </summary>
        public string GetNonEmptyString() =>
            element.GetNonEmptyStringOrNull()
            ?? throw new InvalidOperationException(
                "Cannot read the specified JSON element as a non-empty string value."
            );

        /// <summary>
        /// Gets the value of the element as a non-empty and non-whitespace <see cref="string"/>.
        ///
        /// Returns null if the element contains an empty string, a whitespace string, or a value of any other kind.
        /// </summary>
        public string? GetNonWhiteSpaceStringOrNull()
        {
            var result = element.GetStringOrNull();
            return !string.IsNullOrWhiteSpace(result) ? result : null;
        }

        /// <summary>
        /// Gets the value of the element as a non-empty and non-whitespace <see cref="string"/>.
        /// </summary>
        public string GetNonWhiteSpaceString() =>
            element.GetNonWhiteSpaceStringOrNull()
            ?? throw new InvalidOperationException(
                "Cannot read the specified JSON element as a non-empty and non-whitespace string value."
            );
    }
}
