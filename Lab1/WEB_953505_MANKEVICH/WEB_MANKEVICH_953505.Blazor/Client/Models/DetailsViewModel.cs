using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WEB_MANKEVICH_953505.Blazor.Client.Models
{
    public class DetailsViewModel
    {
        [JsonPropertyName("modelName")]
        public string ModelName { get; set; } // название блюда
        [JsonPropertyName("manufacturerName")]
        public string ManufacturerName { get; set; } // описание блюда
        [JsonPropertyName("image")]
        public string Image { get; set; } // имя файла изображения
    }
}
