using System.Text.Json.Serialization;

namespace WEB_MANKEVICH_953505.Blazor.Client.Models
{
    public class DetailsViewModel
    {
        [JsonPropertyName("modelName")] public string ModelName { get; set; }

        [JsonPropertyName("manufacturerName")] public string ManufacturerName { get; set; }

        [JsonPropertyName("image")] public string Image { get; set; }
    }
}