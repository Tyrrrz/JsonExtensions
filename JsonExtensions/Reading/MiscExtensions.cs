using System.Text.Json;

namespace JsonExtensions.Reading
{
    /// <summary>
    /// Miscellaneous extensions for <see cref="JsonElement"/>.
    /// </summary>
    public static class MiscExtensions
    {
        /// <summary>
        /// Deconstructs <see cref="JsonProperty"/> into its name and value.
        /// </summary>
        public static void Deconstruct(this JsonProperty property, out string name, out JsonElement value)
        {
            name = property.Name;
            value = property.Value;
        }
    }
}