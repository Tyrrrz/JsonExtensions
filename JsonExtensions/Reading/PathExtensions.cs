using System;
using System.Collections.Generic;
using System.Text.Json;

namespace JsonExtensions.Reading;

/// <summary>
/// Extensions for <see cref="JsonElement"/> for dealing with paths.
/// </summary>
public static class PathExtensions
{
    /// <inheritdoc cref="PathExtensions" />
    extension(JsonElement element)
    {
        /// <summary>
        /// Gets the <see cref="JsonElement"/> that represents a property that matches the specified path.
        ///
        /// Returns null if no matching property is found.
        /// </summary>
        /// <remarks>This currently supports only simple paths, e.g. 'prop1.prop2.prop3'.</remarks>
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
        /// Gets the <see cref="JsonElement"/> that represents a property that matches the specified path.
        /// </summary>
        public JsonElement GetPropertyByPath(string propertyPath) =>
            element.GetPropertyByPathOrNull(propertyPath)
            ?? throw new KeyNotFoundException(
                $"Cannot find JSON property matching path '{propertyPath}'."
            );
    }
}
