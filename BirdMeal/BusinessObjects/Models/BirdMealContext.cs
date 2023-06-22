using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace BusinessObjects.Models
{
    public partial class BirdMealContext : DbContext
    {
        public BirdMealContext()
        {
        }

        public BirdMealContext(DbContextOptions<BirdMealContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Meal> Meals { get; set; } = null!;
        public virtual DbSet<MealProduct> MealProducts { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderDetail> OrderDetails { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Wallet> Wallets { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var builder = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.json", true, true);
                IConfigurationRoot configuration = builder.Build();
                string _connectionString = configuration.GetConnectionString("MyCnn");
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Meal>(entity =>
            {
                entity.Property(e => e.MealId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("mealID");

                entity.Property(e => e.Description)
                    .HasMaxLength(4000)
                    .HasColumnName("description");

                entity.Property(e => e.RoutingTime)
                    .HasMaxLength(255)
                    .HasColumnName("routingTime");

                entity.Property(e => e.TotalCost).HasColumnName("totalCost");
            });

            modelBuilder.Entity<MealProduct>(entity =>
            {
                entity.ToTable("Meal_Product");

                entity.Property(e => e.MealProductId).HasColumnName("meal_product_ID");

                entity.Property(e => e.MealId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("mealID");

                entity.Property(e => e.ProductId).HasColumnName("productID");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Meal)
                    .WithMany(p => p.MealProducts)
                    .HasForeignKey(d => d.MealId)
                    .HasConstraintName("FK__Meal_Prod__mealI__20C1E124");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.MealProducts)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__Meal_Prod__produ__21B6055D");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderId).HasColumnName("orderID");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("datetime")
                    .HasColumnName("orderDate");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .HasColumnName("status");

                entity.Property(e => e.TotalPrice).HasColumnName("totalPrice");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Orders__userID__239E4DCF");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.ToTable("Order_Details");

                entity.Property(e => e.OrderDetailId).HasColumnName("orderDetailID");

                entity.Property(e => e.MealId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("mealID");

                entity.Property(e => e.OrderId).HasColumnName("orderID");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.UnitPrice).HasColumnName("unitPrice");

                entity.HasOne(d => d.Meal)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.MealId)
                    .HasConstraintName("FK_Order_Details_Meals");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__Order_Det__order__22AA2996");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductId).HasColumnName("productID");

                entity.Property(e => e.Description)
                    .HasMaxLength(4000)
                    .HasColumnName("description");

                entity.Property(e => e.Image)
                    .IsUnicode(false)
                    .HasColumnName("image");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(255)
                    .HasColumnName("productName");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Weight).HasColumnName("weight");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.WalletId, "UQ__Users__3785C871EE5A8E15")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .HasColumnName("address");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("email");

                entity.Property(e => e.FullName)
                    .HasMaxLength(255)
                    .HasColumnName("fullName");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .HasColumnName("password");

                entity.Property(e => e.Phone)
                    .HasMaxLength(255)
                    .HasColumnName("phone");

                entity.Property(e => e.Role)
                    .HasMaxLength(255)
                    .HasColumnName("role");

                entity.Property(e => e.WalletId).HasColumnName("walletId");

                entity.HasOne(d => d.Wallet)
                    .WithOne(p => p.User)
                    .HasForeignKey<User>(d => d.WalletId)
                    .HasConstraintName("FK__Users__walletId__24927208");
            });

            modelBuilder.Entity<Wallet>(entity =>
            {
                entity.Property(e => e.WalletId).HasColumnName("walletId");

                entity.Property(e => e.Balance).HasColumnName("balance");

                entity.Property(e => e.TransactionDate)
                    .HasColumnType("datetime")
                    .HasColumnName("transactionDate");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
