using System;
using System.Collections.Generic;

#nullable disable

namespace MmtDigital.Ecommerce.Entities
{
    public partial class Product
    {
        public Product()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal? PackHeight { get; set; }
        public decimal? PackWidth { get; set; }
        public decimal? PackWeight { get; set; }
        public string Colour { get; set; }
        public string Size { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
