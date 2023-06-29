using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Insights.BigPurpleBank.Models
{
    public class ResponseBankingProduct
    {
        [Required]
        [JsonPropertyName("productId")]
        public string ProductId { get; set; }
        
        [Required]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [Required]
        [JsonPropertyName("description")]
        public string Description { get; set; }

        [Required]
        [JsonPropertyName("brand")]
        public string Brand { get; set; }

        [JsonPropertyName("brandName")]
        public string BrandName { get; set; }
    }
}