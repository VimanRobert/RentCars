﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RentCars.Data;

#nullable disable

namespace RentCars.Migrations
{
    [DbContext(typeof(LibraryContext))]
    partial class LibraryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RentCars.Data.Store", b =>
                {
                    b.Property<int>("itemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("itemId"));

                    b.Property<string>("carBrand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("carId")
                        .HasColumnType("int");

                    b.Property<string>("carModel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isRented")
                        .HasColumnType("bit");

                    b.HasKey("itemId");

                    b.HasIndex("carId");

                    b.ToTable("Store", (string)null);
                });

            modelBuilder.Entity("RentCars.Models.Car", b =>
                {
                    b.Property<int>("carId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("carId"));

                    b.Property<string>("carBrand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("carPrice")
                        .HasColumnType("float");

                    b.HasKey("carId");

                    b.ToTable("Car", (string)null);
                });

            modelBuilder.Entity("RentCars.Models.Customer", b =>
                {
                    b.Property<int>("customerDrivingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("customerDrivingId"));

                    b.Property<string>("customerAdress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("customerBirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("customerCounty")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("customerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("customerDrivingId");

                    b.ToTable("Customer", (string)null);
                });

            modelBuilder.Entity("RentCars.Models.Made", b =>
                {
                    b.Property<int>("carId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("carId"));

                    b.Property<string>("carBrand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("carEngine")
                        .HasColumnType("float");

                    b.Property<string>("carFuelType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("carMadeYear")
                        .HasColumnType("float");

                    b.Property<string>("carModel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("carId");

                    b.ToTable("Made", (string)null);
                });

            modelBuilder.Entity("RentCars.Models.Order", b =>
                {
                    b.Property<int>("orderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("orderId"));

                    b.Property<int>("carId")
                        .HasColumnType("int");

                    b.Property<int>("customerDrivingId")
                        .HasColumnType("int");

                    b.Property<int>("customerDrivingId1")
                        .HasColumnType("int");

                    b.HasKey("orderId");

                    b.HasIndex("carId");

                    b.HasIndex("customerDrivingId1");

                    b.ToTable("Order", (string)null);
                });

            modelBuilder.Entity("RentCars.Data.Store", b =>
                {
                    b.HasOne("RentCars.Models.Car", "car")
                        .WithMany()
                        .HasForeignKey("carId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("car");
                });

            modelBuilder.Entity("RentCars.Models.Order", b =>
                {
                    b.HasOne("RentCars.Models.Car", "car")
                        .WithMany("Orders")
                        .HasForeignKey("carId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RentCars.Models.Customer", "customer")
                        .WithMany("Orders")
                        .HasForeignKey("customerDrivingId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("car");

                    b.Navigation("customer");
                });

            modelBuilder.Entity("RentCars.Models.Car", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("RentCars.Models.Customer", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}