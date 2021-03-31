﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MmtDigital.Ecommerce.Entities
{
    public class OrderViewModel
    {
        [JsonPropertyName("orderNumber")]
        public int OrderNumber { get; set; }

        [JsonPropertyName("orderDate")]
        public string OrderDate { get; set; }

        [JsonPropertyName("deliveryAddress")]
        public string DeliveryAddress { get; set; }

        [JsonPropertyName("orderItems")]
        public List<OrderItemsViewModel> OrderItems { get; set; }

        [JsonPropertyName("deliveryExpected")]
        public string DeliveryExpected { get; set; }
    }

    public class OrderItemsViewModel
    {
        [JsonPropertyName("product")]
        public string Product { get; set; }

        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }

        [JsonPropertyName("priceEach")]
        public double PriceEach { get; set; }
    }

    public class OrderTrackerViewModel
    {
        [JsonPropertyName("customer")]
        public Customer Customer { get; set; }

        [JsonPropertyName("order")]
        public OrderViewModel Order { get; set; }
    }
}