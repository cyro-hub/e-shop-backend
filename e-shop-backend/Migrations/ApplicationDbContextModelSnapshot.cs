﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using e_shop_backend.Config;

#nullable disable

namespace eshopbackend.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("e_shop_backend.Models.ProductModel.Product", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("category")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("expiryDate")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("isActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("price")
                        .HasColumnType("decimal(65,30)");

                    b.Property<DateTime>("productionDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.Property<string>("storageLocation")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("Products");
                });
#pragma warning restore 612, 618
        }
    }
}