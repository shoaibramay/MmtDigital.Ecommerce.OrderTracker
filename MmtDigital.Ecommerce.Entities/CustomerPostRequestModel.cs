using System;
using System.Text.Json.Serialization;

namespace MmtDigital.Ecommerce.Entities
{
    public class CustomerPostRequestModel
    {
        [JsonPropertyName("user")]
        public string User { get; set; }

        [JsonPropertyName("customerId")]
        public string CustomerId { get; set; }
    }
}
