using System.Text.Json;

namespace JsonExtensions;

/// <summary>
/// Extensions for <see cref="JsonProperty" />.
/// </summary>
public static class JsonPropertyExtensions
{
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
