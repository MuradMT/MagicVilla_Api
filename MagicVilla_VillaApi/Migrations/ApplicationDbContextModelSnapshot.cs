﻿// <auto-generated />
using System;
using MagicVilla_VillaApi.Models.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MagicVilla_VillaApi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MagicVilla_VillaApi.Models.Villa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Amenity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Occupancy")
                        .HasColumnType("int");

                    b.Property<double>("Rate")
                        .HasColumnType("float");

                    b.Property<int>("Sqft")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Villas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amenity = "",
                            CreatedDate = new DateTime(2022, 10, 19, 13, 34, 35, 248, DateTimeKind.Local).AddTicks(799),
                            Details = "this villa is nice",
                            ImageUrl = "https://media-cdn.tripadvisor.com/media/vr-splice-j/09/1f/7e/d1.jpg",
                            Name = "Royal Villa",
                            Occupancy = 0,
                            Rate = 200.0,
                            Sqft = 550,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            Amenity = "",
                            CreatedDate = new DateTime(2022, 10, 19, 13, 34, 35, 248, DateTimeKind.Local).AddTicks(813),
                            Details = "this villa is very good",
                            ImageUrl = "https://images.squarespace-cdn.com/content/v1/585562bcbe659442d503893f/c3b765c0-45e3-46b3-9ff9-b4101fb30674/01.+Exotik+Villas+Bali+-+Aloui.jpg?format=1000w",
                            Name = "Premium Pool Villa",
                            Occupancy = 0,
                            Rate = 400.0,
                            Sqft = 650,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            Amenity = "",
                            CreatedDate = new DateTime(2022, 10, 19, 13, 34, 35, 248, DateTimeKind.Local).AddTicks(815),
                            Details = "this villa is very good and also exspensive",
                            ImageUrl = "https://cf.bstatic.com/xdata/images/hotel/max1024x768/306027131.jpg?k=9bb7b6bfeab68dafed1919b814c007658b002eb2c94d65b59cc15bec83e04bfe&o=&hp=1",
                            Name = "Luxury Pool Villa",
                            Occupancy = 0,
                            Rate = 500.0,
                            Sqft = 750,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 4,
                            Amenity = "",
                            CreatedDate = new DateTime(2022, 10, 19, 13, 34, 35, 248, DateTimeKind.Local).AddTicks(816),
                            Details = "this villa is very good and also exspensive and  height is big",
                            ImageUrl = "https://www.casagrand.co.in/wp-content/uploads/2021/06/1621872930952_florella.jpg",
                            Name = "Diamond  Villa",
                            Occupancy = 0,
                            Rate = 600.0,
                            Sqft = 850,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 5,
                            Amenity = "",
                            CreatedDate = new DateTime(2022, 10, 19, 13, 34, 35, 248, DateTimeKind.Local).AddTicks(817),
                            Details = "this villa is very good and also exspensive and  height&weight is big",
                            ImageUrl = "https://storage.googleapis.com/bd-az-01/buildings-v2/2560x1920/1760.jpg",
                            Name = "Diamond Pool Villa",
                            Occupancy = 0,
                            Rate = 700.0,
                            Sqft = 950,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
