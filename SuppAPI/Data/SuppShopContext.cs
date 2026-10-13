using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SuppAPI.Models;

namespace SuppAPI.Data;

public partial class SuppShopContext : DbContext
{
    public SuppShopContext()
    {
    }

    public SuppShopContext(DbContextOptions<SuppShopContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Basket> Baskets { get; set; }

    public virtual DbSet<BasketDetail> BasketDetails { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Basket>(entity =>
        {
            entity.ToTable("Basket");
        });

        modelBuilder.Entity<BasketDetail>(entity =>
        {
            entity.HasIndex(e => e.BasketId, "IX_BasketDetails_BasketId");

            entity.HasIndex(e => e.ProductId, "IX_BasketDetails_ProductId");

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.HasOne(d => d.Basket).WithMany(p => p.BasketDetails).HasForeignKey(d => d.BasketId);

            entity.HasOne(d => d.Product).WithMany(p => p.BasketDetails).HasForeignKey(d => d.ProductId);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasIndex(e => e.Email, "IX_Customers_Email").IsUnique();
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasIndex(e => e.BasketId, "IX_Orders_BasketId");

            entity.HasIndex(e => e.CustomerId, "IX_Orders_CustomerId");

            entity.HasOne(d => d.Basket).WithMany(p => p.Orders).HasForeignKey(d => d.BasketId);

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders).HasForeignKey(d => d.CustomerId);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(e => e.Price).HasColumnType("decimal(6, 2)");
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasIndex(e => e.Email, "IX_Staff_Email").IsUnique();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
