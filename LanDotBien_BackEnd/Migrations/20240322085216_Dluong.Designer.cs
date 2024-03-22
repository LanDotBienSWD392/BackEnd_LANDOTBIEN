﻿// <auto-generated />
using System;
using LanVar.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LanDotBien_BackEnd.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20240322085216_Dluong")]
    partial class Dluong
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("LanVar.Core.Entity.Auction", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<DateTime>("auctionDay")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("auction_Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("deposit_Money")
                        .HasColumnType("double");

                    b.Property<DateTime>("endDay")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<long>("product_id")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("startDay")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("product_id");

                    b.ToTable("Auction");

                    b.HasData(
                        new
                        {
                            id = 1L,
                            auctionDay = new DateTime(2024, 3, 29, 15, 52, 15, 107, DateTimeKind.Local).AddTicks(1308),
                            auction_Name = "Auction 1",
                            deposit_Money = 50.0,
                            endDay = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            password = "1",
                            product_id = 1L,
                            startDay = new DateTime(2024, 3, 22, 15, 52, 15, 107, DateTimeKind.Local).AddTicks(1307),
                            status = 0
                        });
                });

            modelBuilder.Entity("LanVar.Core.Entity.Bid", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long>("auction_id")
                        .HasColumnType("bigint");

                    b.Property<double>("bid")
                        .HasColumnType("double");

                    b.Property<DateTime>("bid_time")
                        .HasColumnType("datetime(6)");

                    b.Property<long>("user_id")
                        .HasColumnType("bigint");

                    b.HasKey("id");

                    b.HasIndex("auction_id");

                    b.HasIndex("user_id");

                    b.ToTable("Bid");

                    b.HasData(
                        new
                        {
                            id = 1L,
                            auction_id = 1L,
                            bid = 60.0,
                            bid_time = new DateTime(2024, 3, 22, 15, 52, 15, 107, DateTimeKind.Local).AddTicks(1427),
                            user_id = 1L
                        });
                });

            modelBuilder.Entity("LanVar.Core.Entity.Bill", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("orderCode")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("paymentUrl")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("payment_Method")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("status")
                        .HasColumnType("tinyint(1)");

                    b.Property<double>("total_Price")
                        .HasColumnType("double");

                    b.Property<long>("user_id")
                        .HasColumnType("bigint");

                    b.HasKey("id");

                    b.HasIndex("user_id");

                    b.ToTable("Bill");

                    b.HasData(
                        new
                        {
                            id = 1L,
                            orderCode = "SPX00000000001",
                            paymentUrl = "",
                            payment_Method = "Credit Card",
                            status = false,
                            total_Price = 100.0,
                            user_id = 1L
                        });
                });

            modelBuilder.Entity("LanVar.Core.Entity.Order", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("orderCode")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<long>("orderItem_id")
                        .HasColumnType("bigint");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.Property<double>("total_Price")
                        .HasColumnType("double");

                    b.Property<long>("user_id")
                        .HasColumnType("bigint");

                    b.HasKey("id");

                    b.HasIndex("user_id");

                    b.ToTable("Order");

                    b.HasData(
                        new
                        {
                            id = 1L,
                            date = new DateTime(2024, 3, 22, 15, 52, 15, 107, DateTimeKind.Local).AddTicks(1351),
                            orderCode = "SPX00000000001",
                            orderItem_id = 0L,
                            status = 1,
                            total_Price = 100.0,
                            user_id = 1L
                        },
                        new
                        {
                            id = 2L,
                            date = new DateTime(2024, 3, 22, 15, 52, 15, 107, DateTimeKind.Local).AddTicks(1355),
                            orderCode = "SPX00000000002",
                            orderItem_id = 0L,
                            status = 2,
                            total_Price = 100.0,
                            user_id = 1L
                        },
                        new
                        {
                            id = 3L,
                            date = new DateTime(2024, 3, 22, 15, 52, 15, 107, DateTimeKind.Local).AddTicks(1357),
                            orderCode = "SPX00000000003",
                            orderItem_id = 0L,
                            status = 3,
                            total_Price = 100.0,
                            user_id = 1L
                        },
                        new
                        {
                            id = 4L,
                            date = new DateTime(2024, 3, 22, 15, 52, 15, 107, DateTimeKind.Local).AddTicks(1358),
                            orderCode = "SPX00000000004",
                            orderItem_id = 0L,
                            status = 4,
                            total_Price = 100.0,
                            user_id = 1L
                        });
                });

            modelBuilder.Entity("LanVar.Core.Entity.OrderItem", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<bool>("hidden")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("isSelected")
                        .HasColumnType("tinyint(1)");

                    b.Property<long>("product_id")
                        .HasColumnType("bigint");

                    b.Property<long>("user_id")
                        .HasColumnType("bigint");

                    b.HasKey("id");

                    b.HasIndex("product_id");

                    b.HasIndex("user_id");

                    b.ToTable("OrderItem");

                    b.HasData(
                        new
                        {
                            id = 1L,
                            hidden = false,
                            isSelected = false,
                            product_id = 1L,
                            user_id = 1L
                        });
                });

            modelBuilder.Entity("LanVar.Core.Entity.Package", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<DateTime>("endDay")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("packageName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("package_Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("startDay")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("status")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("id");

                    b.ToTable("Package");

                    b.HasData(
                        new
                        {
                            id = 1L,
                            endDay = new DateTime(2024, 4, 21, 15, 52, 15, 107, DateTimeKind.Local).AddTicks(269),
                            packageName = "Basic",
                            package_Description = "Basic package",
                            startDay = new DateTime(2024, 3, 22, 15, 52, 15, 107, DateTimeKind.Local).AddTicks(259),
                            status = true
                        },
                        new
                        {
                            id = 2L,
                            endDay = new DateTime(2024, 4, 21, 15, 52, 15, 107, DateTimeKind.Local).AddTicks(276),
                            packageName = "Premium",
                            package_Description = "Premium package",
                            startDay = new DateTime(2024, 3, 22, 15, 52, 15, 107, DateTimeKind.Local).AddTicks(275),
                            status = true
                        });
                });

            modelBuilder.Entity("LanVar.Core.Entity.Product", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("image")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("product_Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("product_Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("product_Price")
                        .HasColumnType("double");

                    b.Property<bool>("status")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("type")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<long>("user_id")
                        .HasColumnType("bigint");

                    b.HasKey("id");

                    b.HasIndex("user_id");

                    b.ToTable("Product");

                    b.HasData(
                        new
                        {
                            id = 1L,
                            ISBN = "123456789",
                            image = "",
                            product_Description = "Description for Product 1",
                            product_Name = "Product 1",
                            product_Price = 100.0,
                            status = true,
                            type = "Type 1",
                            user_id = 1L
                        });
                });

            modelBuilder.Entity("LanVar.Core.Entity.RoomRegistrations", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long>("auction_id")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("register_time")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.Property<long>("user_id")
                        .HasColumnType("bigint");

                    b.HasKey("id");

                    b.HasIndex("auction_id");

                    b.HasIndex("user_id");

                    b.ToTable("RoomRegistrations");

                    b.HasData(
                        new
                        {
                            id = 1L,
                            auction_id = 1L,
                            register_time = new DateTime(2024, 3, 22, 15, 52, 15, 107, DateTimeKind.Local).AddTicks(1332),
                            status = 2,
                            user_id = 1L
                        });
                });

            modelBuilder.Entity("LanVar.Core.Entity.User", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("dob")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("gender")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("identityCard")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<byte[]>("image")
                        .HasColumnType("longblob");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<long>("package_id")
                        .HasColumnType("bigint");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<long>("permission_id")
                        .HasColumnType("bigint");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("registerDay")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("status")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.HasIndex("package_id");

                    b.HasIndex("permission_id");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            id = 1L,
                            address = "Admin Address",
                            dob = new DateTime(2024, 3, 22, 15, 52, 15, 107, DateTimeKind.Local).AddTicks(1233),
                            email = "admin@example.com",
                            gender = "Male",
                            identityCard = "123456789",
                            name = "Admin",
                            package_id = 1L,
                            password = "c7ad44cbad762a5da0a452f9e854fdc1e0e7a52a38015f23f3eab1d80b931dd472634dfac71cd34ebc35d16ab7fb8a90c81f975113d6c7538dc69dd8de9077ec",
                            permission_id = 1L,
                            phone = "123456789",
                            registerDay = new DateTime(2024, 3, 22, 15, 52, 15, 107, DateTimeKind.Local).AddTicks(1238),
                            status = true,
                            username = "admin"
                        });
                });

            modelBuilder.Entity("LanVar.Core.Entity.UserPermission", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("role")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("UserPermission");

                    b.HasData(
                        new
                        {
                            id = 1L,
                            role = "Admin"
                        },
                        new
                        {
                            id = 2L,
                            role = "Manager"
                        },
                        new
                        {
                            id = 3L,
                            role = "Staff"
                        },
                        new
                        {
                            id = 4L,
                            role = "ProductOwner"
                        },
                        new
                        {
                            id = 5L,
                            role = "Customer"
                        });
                });

            modelBuilder.Entity("LanVar.Core.Entity.Auction", b =>
                {
                    b.HasOne("LanVar.Core.Entity.Product", "product")
                        .WithMany()
                        .HasForeignKey("product_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("product");
                });

            modelBuilder.Entity("LanVar.Core.Entity.Bid", b =>
                {
                    b.HasOne("LanVar.Core.Entity.Auction", "auction")
                        .WithMany()
                        .HasForeignKey("auction_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LanVar.Core.Entity.User", "user")
                        .WithMany()
                        .HasForeignKey("user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("auction");

                    b.Navigation("user");
                });

            modelBuilder.Entity("LanVar.Core.Entity.Bill", b =>
                {
                    b.HasOne("LanVar.Core.Entity.User", "user")
                        .WithMany()
                        .HasForeignKey("user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("LanVar.Core.Entity.Order", b =>
                {
                    b.HasOne("LanVar.Core.Entity.User", "user")
                        .WithMany()
                        .HasForeignKey("user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("LanVar.Core.Entity.OrderItem", b =>
                {
                    b.HasOne("LanVar.Core.Entity.Product", "product")
                        .WithMany()
                        .HasForeignKey("product_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LanVar.Core.Entity.User", "user")
                        .WithMany()
                        .HasForeignKey("user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("product");

                    b.Navigation("user");
                });

            modelBuilder.Entity("LanVar.Core.Entity.Product", b =>
                {
                    b.HasOne("LanVar.Core.Entity.User", "user")
                        .WithMany()
                        .HasForeignKey("user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("LanVar.Core.Entity.RoomRegistrations", b =>
                {
                    b.HasOne("LanVar.Core.Entity.Auction", "auction")
                        .WithMany()
                        .HasForeignKey("auction_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LanVar.Core.Entity.User", "user")
                        .WithMany()
                        .HasForeignKey("user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("auction");

                    b.Navigation("user");
                });

            modelBuilder.Entity("LanVar.Core.Entity.User", b =>
                {
                    b.HasOne("LanVar.Core.Entity.Package", "package")
                        .WithMany()
                        .HasForeignKey("package_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LanVar.Core.Entity.UserPermission", "userPermission")
                        .WithMany()
                        .HasForeignKey("permission_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("package");

                    b.Navigation("userPermission");
                });
#pragma warning restore 612, 618
        }
    }
}
