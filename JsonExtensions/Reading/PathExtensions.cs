using System;
using System.Collections.Generic;
using System.Text.Json;

namespace JsonExtensions.Reading;

/// <summary>
/// Extensions for navigating <see cref="JsonElement"/> structures using dot-separated property paths.
/// </summary>
public static class PathExtensions
{
    /// <inheritdoc cref="PathExtensions" />
    extension(JsonElement element)
    {
        /// <summary>
        /// Traverses the element along the dot-separated <paramref name="propertyPath"/> and returns
        /// the matching descendant, or null if any segment is missing.
        /// </summary>
        /// <remarks>Supports simple dot-notation paths only, e.g. <c>"foo.bar.baz"</c>.</remarks>
        public JsonElement? GetPropertyByPathOrNull(string propertyPath)
        {
            var propertyNames = propertyPath.Split('.', StringSplitOptions.RemoveEmptyEntries);

            var currentElement = new JsonElement?(element);
            foreach (var propertyName in propertyNames)
            {
                currentElement = currentElement.Value.GetPropertyOrNull(propertyName);

                if (currentElement is null)
                    break;
            }

            return currentElement;
        }

        /// <summary>
        /// Traverses the element along the dot-separated <paramref name="propertyPath"/> and returns
        /// the matching descendant. Throws <see cref="KeyNotFoundException"/> if any segment is missing.
        /// </summary>
        public JsonElement GetPropertyByPath(string propertyPath) =>
            element.GetPropertyByPathOrNull(propertyPath)
            ?? throw new KeyNotFoundException(
                $"Cannot find JSON property matching path '{propertyPath}'."
            );
    }
}
