﻿// <auto-generated />
using Lab3.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Lab3.Infra.Migrations
{
    [DbContext(typeof(Lab3Prn231Context))]
    [Migration("20240531053354_SeedData")]
    partial class SeedData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Lab3.Infra.Models.Account", b =>
                {
                    b.Property<int>("Accountid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("accountid");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Accountid"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("password");

                    b.Property<int>("Role")
                        .HasColumnType("integer")
                        .HasColumnName("role");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)")
                        .HasColumnName("username");

                    b.HasKey("Accountid")
                        .HasName("account_pkey");

                    b.ToTable("account", (string)null);
                });

            modelBuilder.Entity("Lab3.Infra.Models.Category", b =>
                {
                    b.Property<int>("Categoryid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("categoryid");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Categoryid"));

                    b.Property<string>("Categoryname")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)")
                        .HasColumnName("categoryname");

                    b.HasKey("Categoryid")
                        .HasName("category_pkey");

                    b.ToTable("category", (string)null);

                    b.HasData(
                        new
                        {
                            Categoryid = 1,
                            Categoryname = "Beverages"
                        },
                        new
                        {
                            Categoryid = 2,
                            Categoryname = "Condiments"
                        },
                        new
                        {
                            Categoryid = 3,
                            Categoryname = "Confections"
                        },
                        new
                        {
                            Categoryid = 4,
                            Categoryname = "Dairy Products"
                        },
                        new
                        {
                            Categoryid = 5,
                            Categoryname = "Grains/Cereals"
                        },
                        new
                        {
                            Categoryid = 6,
                            Categoryname = "Meat/Poultry"
                        },
                        new
                        {
                            Categoryid = 7,
                            Categoryname = "Produce"
                        },
                        new
                        {
                            Categoryid = 8,
                            Categoryname = "Seafood"
                        });
                });

            modelBuilder.Entity("Lab3.Infra.Models.Product", b =>
                {
                    b.Property<int>("Productid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("productid");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Productid"));

                    b.Property<int>("Categoryid")
                        .HasColumnType("integer")
                        .HasColumnName("categoryid");

                    b.Property<string>("Productname")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)")
                        .HasColumnName("productname");

                    b.Property<decimal>("Unitprice")
                        .HasPrecision(18, 2)
                        .HasColumnType("numeric(18,2)")
                        .HasColumnName("unitprice");

                    b.Property<int>("Unitsinstock")
                        .HasColumnType("integer")
                        .HasColumnName("unitsinstock");

                    b.HasKey("Productid")
                        .HasName("product_pkey");

                    b.HasIndex("Categoryid");

                    b.ToTable("product", (string)null);

                    b.HasData(
                        new
                        {
                            Productid = 1,
                            Categoryid = 1,
                            Productname = "Chai",
                            Unitprice = 18.00m,
                            Unitsinstock = 39
                        },
                        new
                        {
                            Productid = 2,
                            Categoryid = 1,
                            Productname = "Chang",
                            Unitprice = 19.00m,
                            Unitsinstock = 17
                        },
                        new
                        {
                            Productid = 3,
                            Categoryid = 2,
                            Productname = "Aniseed Syrup",
                            Unitprice = 10.00m,
                            Unitsinstock = 13
                        },
                        new
                        {
                            Productid = 4,
                            Categoryid = 2,
                            Productname = "Chef Anton's Cajun Seasoning",
                            Unitprice = 22.00m,
                            Unitsinstock = 53
                        },
                        new
                        {
                            Productid = 5,
                            Categoryid = 2,
                            Productname = "Chef Anton's Gumbo Mix",
                            Unitprice = 21.35m,
                            Unitsinstock = 0
                        },
                        new
                        {
                            Productid = 6,
                            Categoryid = 2,
                            Productname = "Grandma's Boysenberry Spread",
                            Unitprice = 25.00m,
                            Unitsinstock = 120
                        },
                        new
                        {
                            Productid = 7,
                            Categoryid = 7,
                            Productname = "Uncle Bob's Organic Dried Pears",
                            Unitprice = 30.00m,
                            Unitsinstock = 15
                        },
                        new
                        {
                            Productid = 8,
                            Categoryid = 2,
                            Productname = "Northwoods Cranberry Sauce",
                            Unitprice = 40.00m,
                            Unitsinstock = 6
                        },
                        new
                        {
                            Productid = 9,
                            Categoryid = 6,
                            Productname = "Mishi Kobe Niku",
                            Unitprice = 97.00m,
                            Unitsinstock = 29
                        },
                        new
                        {
                            Productid = 10,
                            Categoryid = 8,
                            Productname = "Ikura",
                            Unitprice = 31.00m,
                            Unitsinstock = 31
                        },
                        new
                        {
                            Productid = 11,
                            Categoryid = 4,
                            Productname = "Queso Cabrales",
                            Unitprice = 21.00m,
                            Unitsinstock = 22
                        },
                        new
                        {
                            Productid = 12,
                            Categoryid = 4,
                            Productname = "Queso Manchego La Pastora",
                            Unitprice = 38.00m,
                            Unitsinstock = 86
                        },
                        new
                        {
                            Productid = 13,
                            Categoryid = 8,
                            Productname = "Konbu",
                            Unitprice = 6.00m,
                            Unitsinstock = 24
                        },
                        new
                        {
                            Productid = 14,
                            Categoryid = 7,
                            Productname = "Tofu",
                            Unitprice = 23.25m,
                            Unitsinstock = 35
                        },
                        new
                        {
                            Productid = 15,
                            Categoryid = 2,
                            Productname = "Genen Shouyu",
                            Unitprice = 15.50m,
                            Unitsinstock = 39
                        },
                        new
                        {
                            Productid = 16,
                            Categoryid = 3,
                            Productname = "Pavlova",
                            Unitprice = 17.45m,
                            Unitsinstock = 29
                        },
                        new
                        {
                            Productid = 17,
                            Categoryid = 6,
                            Productname = "Alice Mutton",
                            Unitprice = 39.00m,
                            Unitsinstock = 0
                        },
                        new
                        {
                            Productid = 18,
                            Categoryid = 8,
                            Productname = "Carnarvon Tigers",
                            Unitprice = 62.50m,
                            Unitsinstock = 2
                        });
                });

            modelBuilder.Entity("Lab3.Infra.Models.Product", b =>
                {
                    b.HasOne("Lab3.Infra.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("Categoryid")
                        .IsRequired()
                        .HasConstraintName("fk_product_category");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Lab3.Infra.Models.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
