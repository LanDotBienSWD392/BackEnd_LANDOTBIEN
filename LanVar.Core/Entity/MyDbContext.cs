﻿using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace LanVar.Core.Entity
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
            
        }

        
        public DbSet<Auction> Auctions { get; set; }
        public DbSet<Bid> Bids { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> Items { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<RoomRegistrations> RoomRegistrations { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserPermission> UsersPermission { get; set; }
        public DbSet<User_Package> UserPackages { get; set; }
        private string HashPassword(string password)
        {
            using (SHA512 sha512 = SHA512.Create())
            {
                byte[] hashBytes = sha512.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    builder.Append(hashBytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data for UserPermissions
            modelBuilder.Entity<UserPermission>().HasData(
                new UserPermission { id = 1, role = "Admin" },
                new UserPermission { id = 2, role = "Manager" },
                new UserPermission { id = 3, role = "Staff" },
                new UserPermission { id = 4, role = "ProductOwner" },
                new UserPermission { id = 5, role = "Customer" }
            );

            // Seed data for Packages
            modelBuilder.Entity<Package>().HasData(
                new Package { id = 1, packageName = "Basic", package_Description = "Basic package",price = 0, status = true },
                new Package { id = 2, packageName = "Premium", package_Description = "Premium package",price = 100000, status = true }
            );
            modelBuilder.Entity<User_Package>().HasData(
                new User_Package
                {
                    id = 1, package_id = 2, user_id = 1, startDay = DateTime.Now, endDay = DateTime.Now.AddDays(30),
                    status = PackageStatus.Active, price = 100000
                }

            );

            // Seed data for User
            string plaintextPassword = "admin"; // Mật khẩu gốc
            string hashedPassword = HashPassword(plaintextPassword); // Mã hóa mật khẩu bằng SHA-512

            modelBuilder.Entity<User>().HasData(
                new User { id = 1, permission_id = 1, identityCard = "123456789", name = "Admin", email = "admin@example.com", username = "admin", password = hashedPassword, phone = "123456789", dob = DateTime.Now, address = "Admin Address", gender = "Male", registerDay = DateTime.Now, status = true }
            );

            // Seed data for Products
            modelBuilder.Entity<Product>().HasData(
                new Product { id = 1, ISBN = "123456789", user_id = 1, product_Name = "Product 1", product_Description = "Description for Product 1", image = "", product_Price = 100.00, type = "Type 1", status = true }
            );

            // Seed data for Auctions
            modelBuilder.Entity<Auction>().HasData(
                new Auction { id = 1, product_id = 1, password = "1" ,startDay = DateTime.Now, auctionDay = DateTime.Now.AddDays(7), auction_Name = "Auction 1", deposit_Money = 50.00, status = AuctionStatus.ACTIVE }
            );

            // Seed data for RoomRegistrations
            modelBuilder.Entity<RoomRegistrations>().HasData(
                new RoomRegistrations { id = 1, user_id = 1, auction_id = 1, status = RegisterStatus.WAITING, register_time = DateTime.Now }
            );

            // Seed data for Orders
            modelBuilder.Entity<Order>().HasData(
                new Order { id = 1, user_id = 1, date = DateTime.Now, total_Price = 100.00, status = OrderStatus.Confirmed, orderCode = "SPX00000000001"},
                new Order { id = 2, user_id = 1, date = DateTime.Now, total_Price = 100.00, status = OrderStatus.InTransit, orderCode = "SPX00000000002" },
                new Order { id = 3, user_id = 1, date = DateTime.Now, total_Price = 100.00, status = OrderStatus.Delivered, orderCode = "SPX00000000003" },
                new Order { id = 4, user_id = 1, date = DateTime.Now, total_Price = 100.00, status = OrderStatus.Canceled, orderCode = "SPX00000000004" }
            );

            // Seed data for OrderItems
            modelBuilder.Entity<OrderItem>().HasData(
                new OrderItem { id = 1,user_id = 1, product_id = 1, hidden = false}
            );

            // Seed data for Bills
            modelBuilder.Entity<Bill>().HasData(
                new Bill { id = 1,user_id = 1,payment_Method = "Credit Card", total_Price = 100.00, status = false, paymentUrl = "", orderCode = "SPX00000000001", }
            );

            // Seed data for Bids
            modelBuilder.Entity<Bid>().HasData(
                new Bid { id = 1, auction_id = 1, user_id = 1, bid = 60.00, bid_time = DateTime.Now }
            );
        }
    }
}
