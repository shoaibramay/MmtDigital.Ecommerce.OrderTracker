using Microsoft.EntityFrameworkCore;
using MmtDigital.Ecommerce.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MmtDigital.Ecommerce.Data
{
    public interface IApplicationContext
    {
        DbSet<Order> Orders { get; set; }
        DbSet<OrderItem> Orderitems { get; set; }
        DbSet<Product> Products { get; set; }
    }
}
