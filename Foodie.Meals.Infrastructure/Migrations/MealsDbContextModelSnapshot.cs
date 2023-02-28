﻿// <auto-generated />
using System;
using Foodie.Meals.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Foodie.Meals.Infrastructure.Migrations
{
    [DbContext(typeof(MealsDbContext))]
    partial class MealsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CategoryRestaurant", b =>
                {
                    b.Property<int>("CategoriesId")
                        .HasColumnType("int");

                    b.Property<int>("RestaurantsId")
                        .HasColumnType("int");

                    b.HasKey("CategoriesId", "RestaurantsId");

                    b.HasIndex("RestaurantsId");

                    b.ToTable("CategoryRestaurant");
                });

            modelBuilder.Entity("Foodie.Meals.Domain.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("LastModifiedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedBy = "Seed",
                            CreatedDate = new DateTimeOffset(new DateTime(2023, 2, 27, 22, 30, 52, 314, DateTimeKind.Unspecified).AddTicks(5890), new TimeSpan(0, 1, 0, 0, 0)),
                            Name = "Pasta"
                        },
                        new
                        {
                            Id = 2,
                            CreatedBy = "Seed",
                            CreatedDate = new DateTimeOffset(new DateTime(2023, 2, 27, 22, 30, 52, 316, DateTimeKind.Unspecified).AddTicks(7101), new TimeSpan(0, 1, 0, 0, 0)),
                            Name = "Burger"
                        },
                        new
                        {
                            Id = 3,
                            CreatedBy = "Seed",
                            CreatedDate = new DateTimeOffset(new DateTime(2023, 2, 27, 22, 30, 52, 316, DateTimeKind.Unspecified).AddTicks(7138), new TimeSpan(0, 1, 0, 0, 0)),
                            Name = "Pizza"
                        },
                        new
                        {
                            Id = 4,
                            CreatedBy = "Seed",
                            CreatedDate = new DateTimeOffset(new DateTime(2023, 2, 27, 22, 30, 52, 316, DateTimeKind.Unspecified).AddTicks(7144), new TimeSpan(0, 1, 0, 0, 0)),
                            Name = "Salad"
                        });
                });

            modelBuilder.Entity("Foodie.Meals.Domain.Entities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("LastModifiedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Country = "USA",
                            CreatedBy = "Seed",
                            CreatedDate = new DateTimeOffset(new DateTime(2023, 2, 27, 22, 30, 52, 318, DateTimeKind.Unspecified).AddTicks(8172), new TimeSpan(0, 1, 0, 0, 0)),
                            Name = "Las Vegas"
                        },
                        new
                        {
                            Id = 2,
                            Country = "USA",
                            CreatedBy = "Seed",
                            CreatedDate = new DateTimeOffset(new DateTime(2023, 2, 27, 22, 30, 52, 318, DateTimeKind.Unspecified).AddTicks(8245), new TimeSpan(0, 1, 0, 0, 0)),
                            Name = "Los Angeles"
                        },
                        new
                        {
                            Id = 3,
                            Country = "USA",
                            CreatedBy = "Seed",
                            CreatedDate = new DateTimeOffset(new DateTime(2023, 2, 27, 22, 30, 52, 318, DateTimeKind.Unspecified).AddTicks(8253), new TimeSpan(0, 1, 0, 0, 0)),
                            Name = "New York"
                        });
                });

            modelBuilder.Entity("Foodie.Meals.Domain.Entities.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("LastModifiedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Locations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Kfc Las Vegas",
                            CityId = 1,
                            CreatedBy = "Seed",
                            CreatedDate = new DateTimeOffset(new DateTime(2023, 2, 27, 22, 30, 52, 319, DateTimeKind.Unspecified).AddTicks(6351), new TimeSpan(0, 1, 0, 0, 0)),
                            Email = "kfc.lasvegas@email.com",
                            PhoneNumber = "123-123-213",
                            RestaurantId = 1
                        },
                        new
                        {
                            Id = 2,
                            Address = "Kfc Los Angeles",
                            CityId = 2,
                            CreatedBy = "Seed",
                            CreatedDate = new DateTimeOffset(new DateTime(2023, 2, 27, 22, 30, 52, 319, DateTimeKind.Unspecified).AddTicks(6402), new TimeSpan(0, 1, 0, 0, 0)),
                            Email = "kfc.losangeles@email.com",
                            PhoneNumber = "123-123-213",
                            RestaurantId = 1
                        },
                        new
                        {
                            Id = 3,
                            Address = "Kfc New York",
                            CityId = 3,
                            CreatedBy = "Seed",
                            CreatedDate = new DateTimeOffset(new DateTime(2023, 2, 27, 22, 30, 52, 319, DateTimeKind.Unspecified).AddTicks(6408), new TimeSpan(0, 1, 0, 0, 0)),
                            Email = "kfc.newyork@email.com",
                            PhoneNumber = "123-123-213",
                            RestaurantId = 1
                        },
                        new
                        {
                            Id = 4,
                            Address = "Pizza Hut Las Vegas",
                            CityId = 1,
                            CreatedBy = "Seed",
                            CreatedDate = new DateTimeOffset(new DateTime(2023, 2, 27, 22, 30, 52, 319, DateTimeKind.Unspecified).AddTicks(6413), new TimeSpan(0, 1, 0, 0, 0)),
                            Email = "pizzahut.lasvegas@email.com",
                            PhoneNumber = "123-123-213",
                            RestaurantId = 2
                        },
                        new
                        {
                            Id = 5,
                            Address = "Pizza Hut Los Angeles",
                            CityId = 2,
                            CreatedBy = "Seed",
                            CreatedDate = new DateTimeOffset(new DateTime(2023, 2, 27, 22, 30, 52, 319, DateTimeKind.Unspecified).AddTicks(6417), new TimeSpan(0, 1, 0, 0, 0)),
                            Email = "pizzahut.losangeles@email.com",
                            PhoneNumber = "123-123-213",
                            RestaurantId = 2
                        },
                        new
                        {
                            Id = 6,
                            Address = "McDonald's Las Vegas",
                            CityId = 1,
                            CreatedBy = "Seed",
                            CreatedDate = new DateTimeOffset(new DateTime(2023, 2, 27, 22, 30, 52, 319, DateTimeKind.Unspecified).AddTicks(6431), new TimeSpan(0, 1, 0, 0, 0)),
                            Email = "mcdonalds.lasvegas@email.com",
                            PhoneNumber = "123-123-213",
                            RestaurantId = 3
                        });
                });

            modelBuilder.Entity("Foodie.Meals.Domain.Entities.Meal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("LastModifiedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Meals");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedBy = "Seed",
                            CreatedDate = new DateTimeOffset(new DateTime(2023, 2, 27, 22, 30, 52, 320, DateTimeKind.Unspecified).AddTicks(4549), new TimeSpan(0, 1, 0, 0, 0)),
                            Description = "Longer",
                            Name = "Longer",
                            Price = 12m,
                            RestaurantId = 1
                        },
                        new
                        {
                            Id = 2,
                            CreatedBy = "Seed",
                            CreatedDate = new DateTimeOffset(new DateTime(2023, 2, 27, 22, 30, 52, 320, DateTimeKind.Unspecified).AddTicks(4603), new TimeSpan(0, 1, 0, 0, 0)),
                            Description = "Zinger",
                            Name = "Zinger",
                            Price = 10m,
                            RestaurantId = 1
                        },
                        new
                        {
                            Id = 3,
                            CreatedBy = "Seed",
                            CreatedDate = new DateTimeOffset(new DateTime(2023, 2, 27, 22, 30, 52, 320, DateTimeKind.Unspecified).AddTicks(4611), new TimeSpan(0, 1, 0, 0, 0)),
                            Description = "Pizza Texas",
                            Name = "Pizza Texas",
                            Price = 12m,
                            RestaurantId = 2
                        },
                        new
                        {
                            Id = 4,
                            CreatedBy = "Seed",
                            CreatedDate = new DateTimeOffset(new DateTime(2023, 2, 27, 22, 30, 52, 320, DateTimeKind.Unspecified).AddTicks(4616), new TimeSpan(0, 1, 0, 0, 0)),
                            Description = "Pizza Carbonara",
                            Name = "Pizza Carbonara",
                            Price = 12m,
                            RestaurantId = 2
                        },
                        new
                        {
                            Id = 5,
                            CreatedBy = "Seed",
                            CreatedDate = new DateTimeOffset(new DateTime(2023, 2, 27, 22, 30, 52, 320, DateTimeKind.Unspecified).AddTicks(4621), new TimeSpan(0, 1, 0, 0, 0)),
                            Description = "Big Mac",
                            Name = "Big Mac",
                            Price = 15m,
                            RestaurantId = 3
                        },
                        new
                        {
                            Id = 6,
                            CreatedBy = "Seed",
                            CreatedDate = new DateTimeOffset(new DateTime(2023, 2, 27, 22, 30, 52, 320, DateTimeKind.Unspecified).AddTicks(4630), new TimeSpan(0, 1, 0, 0, 0)),
                            Description = "McRoyal",
                            Name = "McRoyal",
                            Price = 10m,
                            RestaurantId = 3
                        });
                });

            modelBuilder.Entity("Foodie.Meals.Domain.Entities.Restaurant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("LastModifiedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Restaurants");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedBy = "Seed",
                            CreatedDate = new DateTimeOffset(new DateTime(2023, 2, 27, 22, 30, 52, 320, DateTimeKind.Unspecified).AddTicks(8562), new TimeSpan(0, 1, 0, 0, 0)),
                            Name = "KFC"
                        },
                        new
                        {
                            Id = 2,
                            CreatedBy = "Seed",
                            CreatedDate = new DateTimeOffset(new DateTime(2023, 2, 27, 22, 30, 52, 320, DateTimeKind.Unspecified).AddTicks(8616), new TimeSpan(0, 1, 0, 0, 0)),
                            Name = "Pizza Hut"
                        },
                        new
                        {
                            Id = 3,
                            CreatedBy = "Seed",
                            CreatedDate = new DateTimeOffset(new DateTime(2023, 2, 27, 22, 30, 52, 320, DateTimeKind.Unspecified).AddTicks(8623), new TimeSpan(0, 1, 0, 0, 0)),
                            Name = "McDonald's"
                        });
                });

            modelBuilder.Entity("CategoryRestaurant", b =>
                {
                    b.HasOne("Foodie.Meals.Domain.Entities.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Foodie.Meals.Domain.Entities.Restaurant", null)
                        .WithMany()
                        .HasForeignKey("RestaurantsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Foodie.Meals.Domain.Entities.Location", b =>
                {
                    b.HasOne("Foodie.Meals.Domain.Entities.City", "City")
                        .WithMany("Locations")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Foodie.Meals.Domain.Entities.Restaurant", "Restaurant")
                        .WithMany("Locations")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("Foodie.Meals.Domain.Entities.Meal", b =>
                {
                    b.HasOne("Foodie.Meals.Domain.Entities.Restaurant", "Restaurant")
                        .WithMany("Meals")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("Foodie.Meals.Domain.Entities.City", b =>
                {
                    b.Navigation("Locations");
                });

            modelBuilder.Entity("Foodie.Meals.Domain.Entities.Restaurant", b =>
                {
                    b.Navigation("Locations");

                    b.Navigation("Meals");
                });
#pragma warning restore 612, 618
        }
    }
}
