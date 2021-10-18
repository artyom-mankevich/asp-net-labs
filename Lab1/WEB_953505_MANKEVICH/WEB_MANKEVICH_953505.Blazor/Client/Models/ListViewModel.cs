using System.Text.Json.Serialization;

namespace WEB_MANKEVICH_953505.Blazor.Client.Models
{
    public class ListViewModel
    {
        [JsonPropertyName("carId")] public int CarId { get; set; }

        [JsonPropertyName("modelName")] public string ModelName { get; set; }

        [JsonPropertyName("manufacturerName")] public string ManufacturerName { get; set; }
    }
}