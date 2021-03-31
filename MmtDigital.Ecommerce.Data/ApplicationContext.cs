using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using MmtDigital.Ecommerce.Entities;

#nullable disable

namespace MmtDigital.Ecommerce.Data
{
    public partial class ApplicationContext : DbContext, IApplicationContext
    {
        private readonly IConfiguration Configuration;

        public ApplicationContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderItem> Orderitems { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration["ApiCode"]
                    , options => options.EnableRetryOnFailure(6));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("ORDERS");

                entity.Property(e => e.OrderId).HasColumnName("ORDERID");

                entity.Property(e => e.ContainsGift).HasColumnName("CONTAINSGIFT");

                entity.Property(e => e.CustomerId)
                    .HasMaxLength(10)
                    .HasColumnName("CUSTOMERID");

                entity.Property(e => e.DeliveryExpected)
                    .HasColumnType("date")
                    .HasColumnName("DELIVERYEXPECTED");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("date")
                    .HasColumnName("ORDERDATE");

                entity.Property(e => e.OrderSource)
                    .HasMaxLength(30)
                    .HasColumnName("ORDERSOURCE");

                entity.Property(e => e.ShippingMode)
                    .HasMaxLength(30)
                    .HasColumnName("SHIPPINGMODE");
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.ToTable("ORDERITEMS");

                entity.Property(e => e.OrderItemId).HasColumnName("ORDERITEMID");

                entity.Property(e => e.OrderId).HasColumnName("ORDERID");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(9, 2)")
                    .HasColumnName("PRICE");

                entity.Property(e => e.ProductId).HasColumnName("PRODUCTID");

                entity.Property(e => e.Quantity).HasColumnName("QUANTITY");

                entity.Property(e => e.Returnable).HasColumnName("RETURNABLE");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__ORDERITEM__ORDER__60A75C0F");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__ORDERITEM__PRODU__619B8048");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("PRODUCTS");

                entity.Property(e => e.ProductId).HasColumnName("PRODUCTID");

                entity.Property(e => e.Colour)
                    .HasMaxLength(20)
                    .HasColumnName("COLOUR");

                entity.Property(e => e.PackHeight)
                    .HasColumnType("decimal(9, 2)")
                    .HasColumnName("PACKHEIGHT");

                entity.Property(e => e.PackWeight)
                    .HasColumnType("decimal(8, 3)")
                    .HasColumnName("PACKWEIGHT");

                entity.Property(e => e.PackWidth)
                    .HasColumnType("decimal(9, 2)")
                    .HasColumnName("PACKWIDTH");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(50)
                    .HasColumnName("PRODUCTNAME");

                entity.Property(e => e.Size)
                    .HasMaxLength(20)
                    .HasColumnName("SIZE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
