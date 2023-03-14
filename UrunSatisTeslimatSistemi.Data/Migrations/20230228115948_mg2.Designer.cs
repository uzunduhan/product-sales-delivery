﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UrunSatisTeslimatSistemi.Data.DBOperations;

#nullable disable

namespace UrunSatisTeslimatSistemi.Data.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20230228115948_mg2")]
    partial class mg2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("UrunSatisTeslimatSistemi.Data.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "mehmetaslan18@gmail.com",
                            Name = "Mehmet",
                            Surname = "Aslan"
                        },
                        new
                        {
                            Id = 2,
                            Email = "ahmetuzun06@hotmail.com",
                            Name = "Ahmet",
                            Surname = "Uzun"
                        },
                        new
                        {
                            Id = 3,
                            Email = "kadirsert@gmail.com",
                            Name = "Kadir",
                            Surname = "Sert"
                        });
                });

            modelBuilder.Entity("UrunSatisTeslimatSistemi.Data.Models.CustomerProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ProductId");

                    b.ToTable("CustomerProducts");
                });

            modelBuilder.Entity("UrunSatisTeslimatSistemi.Data.Models.Delivery", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Deliveries");
                });

            modelBuilder.Entity("UrunSatisTeslimatSistemi.Data.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Laptop",
                            Price = 26000.0
                        },
                        new
                        {
                            Id = 2,
                            Name = "Telefon",
                            Price = 14350.0
                        },
                        new
                        {
                            Id = 3,
                            Name = "Gözlük",
                            Price = 2500.0
                        });
                });

            modelBuilder.Entity("UrunSatisTeslimatSistemi.Data.Models.CustomerProduct", b =>
                {
                    b.HasOne("UrunSatisTeslimatSistemi.Data.Models.Customer", "Customer")
                        .WithMany("Customer_Products")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UrunSatisTeslimatSistemi.Data.Models.Product", "Product")
                        .WithMany("Customer_Products")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("UrunSatisTeslimatSistemi.Data.Models.Delivery", b =>
                {
                    b.HasOne("UrunSatisTeslimatSistemi.Data.Models.Customer", "customer")
                        .WithMany("Deliveries")
                        .HasForeignKey("CustomerId");

                    b.Navigation("customer");
                });

            modelBuilder.Entity("UrunSatisTeslimatSistemi.Data.Models.Customer", b =>
                {
                    b.Navigation("Customer_Products");

                    b.Navigation("Deliveries");
                });

            modelBuilder.Entity("UrunSatisTeslimatSistemi.Data.Models.Product", b =>
                {
                    b.Navigation("Customer_Products");
                });
#pragma warning restore 612, 618
        }
    }
}