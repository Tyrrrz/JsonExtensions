using System.Text.Json;

namespace JsonExtensions.Reading;

/// <summary>
/// Miscellaneous extensions for <see cref="JsonElement"/>.
/// </summary>
public static class MiscExtensions
{
    /// <inheritdoc cref="MiscExtensions" />
    extension(JsonProperty property)
    {
        /// <summary>
        /// Deconstructs <see cref="JsonProperty"/> into its name and value components.
        /// </summary>
        public void Deconstruct(out string name, out JsonElement value)
        {
            name = property.Name;
            value = property.Value;
        }
    }
}
