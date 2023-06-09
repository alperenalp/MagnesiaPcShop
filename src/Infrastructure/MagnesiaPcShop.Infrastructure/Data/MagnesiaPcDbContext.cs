using MagnesiaPcShop.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace MagnesiaPcShop.Infrastructure.Data
{
    public class MagnesiaPcDbContext : DbContext 
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
        public DbSet<Category> Categories { get; set; }

        public MagnesiaPcDbContext(DbContextOptions<MagnesiaPcDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Property(p => p.Name).IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.Name).HasMaxLength(50);
            modelBuilder.Entity<Product>().Property(p => p.Price).IsRequired();

            modelBuilder.Entity<Product>().HasOne(p => p.Category)
                                          .WithMany(c => c.Products)
                                          .HasForeignKey(p => p.CategoryId);
           
            modelBuilder.Entity<Product>().HasMany(p => p.Reviews)
                                          .WithOne(upr => upr.Product)
                                          .HasForeignKey(upr => upr.ProductId)
                                          .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Product>().HasMany(p => p.Orders)
                                          .WithOne(od => od.Product)
                                          .HasForeignKey(od => od.ProductId);

            modelBuilder.Entity<OrderDetails>().HasKey("ProductId", "OrderId");

            modelBuilder.Entity<User>().Property(u => u.Name).IsRequired();
            modelBuilder.Entity<User>().Property(u => u.Name).HasMaxLength(50);

            modelBuilder.Entity<User>().Property(u => u.LastName).IsRequired();
            modelBuilder.Entity<User>().Property(u => u.LastName).HasMaxLength(50);

            modelBuilder.Entity<User>().Property(u => u.Username).IsRequired();
            modelBuilder.Entity<User>().Property(u => u.Username).HasMaxLength(50);

            modelBuilder.Entity<User>().Property(u => u.Password).IsRequired();
            modelBuilder.Entity<User>().Property(u => u.Password).HasMaxLength(50);

            modelBuilder.Entity<User>().Property(u => u.Role).IsRequired();
            modelBuilder.Entity<User>().Property(u => u.Role).HasMaxLength(50);

            modelBuilder.Entity<User>().HasMany(u => u.Orders)
                                       .WithOne(o => o.User)
                                       .HasForeignKey(u => u.UserId);

            modelBuilder.Entity<User>().HasMany(u => u.Reviews)
                                       .WithOne(upr => upr.User)
                                       .HasForeignKey(upr => upr.UserId);

            modelBuilder.Entity<UserProductReviews>().HasKey("UserId", "ProductId");

            modelBuilder.Entity<Order>().HasOne(o => o.Shipper)
                                        .WithMany(s => s.Orders)
                                        .HasForeignKey(o => o.ShipperId);

            modelBuilder.Entity<Order>().HasOne(o => o.User)
                                       .WithMany(u => u.Orders)
                                       .HasForeignKey(o => o.UserId);

            modelBuilder.Entity<Order>().HasMany(o => o.Products)
                                        .WithOne(od => od.Order)
                                        .HasForeignKey(od => od.OrderId);

            modelBuilder.Entity<Shipper>().HasMany(s => s.Orders)
                                          .WithOne(o => o.Shipper)
                                          .HasForeignKey(o => o.ShipperId);

            modelBuilder.Entity<Category>().Property(c => c.Name).IsRequired();
            modelBuilder.Entity<Category>().Property(c => c.Name).HasMaxLength(25);

            modelBuilder.Entity<Category>().HasMany(c => c.Products)
                                          .WithOne(p => p.Category)
                                          .HasForeignKey(p => p.CategoryId)
                                          .OnDelete(DeleteBehavior.SetNull);
        }

    }
}
