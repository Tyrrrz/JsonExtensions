using System.Text.Json;

namespace JsonExtensions.Reading;

/// <summary>
/// General-purpose extensions for JSON types.
/// </summary>
public static class MiscExtensions
{
    /// <inheritdoc cref="MiscExtensions" />
    extension(JsonProperty property)
    {
        /// <summary>
        /// Deconstructs the property into its <paramref name="name"/> and <paramref name="value"/> components.
        /// </summary>
        public void Deconstruct(out string name, out JsonElement value)
        {
            name = property.Name;
            value = property.Value;
        }
    }
}
