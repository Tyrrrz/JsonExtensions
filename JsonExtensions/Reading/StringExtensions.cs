using System;
using System.Text.Json;

namespace JsonExtensions.Reading;

/// <summary>
/// Extensions for reading strings from <see cref="JsonElement"/>.
/// </summary>
public static class StringExtensions
{
    /// <summary>
    /// Gets the value of the element as a non-null <see cref="string"/>.
    /// </summary>
    public static string GetNonNullString(this JsonElement element) =>
        element.GetStringOrNull() ??
        throw new InvalidOperationException(
            "Cannot read the specified JSON element as a non-null string value."
        );

    /// <summary>
    /// Gets the value of the element as a non-empty <see cref="string"/>.
    ///
    /// Returns null if the element contains an empty string or a value of any other kind.
    /// </summary>
    public static string? GetNonEmptyStringOrNull(this JsonElement element)
    {
        var result = element.GetStringOrNull();
        return !string.IsNullOrEmpty(result) ? result : null;
    }

    /// <summary>
    /// Gets the value of the element as a non-empty <see cref="string"/>.
    /// </summary>
    public static string GetNonEmptyString(this JsonElement element) =>
        element.GetNonEmptyStringOrNull() ??
        throw new InvalidOperationException(
            "Cannot read the specified JSON element as a non-empty string value."
        );
        
    /// <summary>
    /// Gets the value of the element as a non-empty and non-whitespace <see cref="string"/>.
    ///
    /// Returns null if the element contains an empty string, a whitespace string, or a value of any other kind.
    /// </summary>
    public static string? GetNonWhiteSpaceStringOrNull(this JsonElement element)
    {
        var result = element.GetStringOrNull();
        return !string.IsNullOrWhiteSpace(result) ? result : null;
    }

    /// <summary>
    /// Gets the value of the element as a non-empty and non-whitespace <see cref="string"/>.
    /// </summary>
    public static string GetNonWhiteSpaceString(this JsonElement element) =>
        element.GetNonWhiteSpaceStringOrNull() ??
        throw new InvalidOperationException(
            "Cannot read the specified JSON element as a non-empty and non-whitespace string value."
        );
}