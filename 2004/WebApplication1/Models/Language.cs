using System.Text.Json.Serialization;

namespace WebApplication1.Models
{
    public class Language
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("label")]
        public string Label { get; set; }
        [JsonPropertyName("category")]
        public string Category { get; set; }
        [JsonPropertyName("priority")]
        public int Priority { get; set; }

    }
}
