﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SwiftMartAPI.Persistance.Contexts;

#nullable disable

namespace SwiftMartAPI.Persistance.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CategoryProduct", b =>
                {
                    b.Property<int>("CategoriesId")
                        .HasColumnType("int");

                    b.Property<int>("ProductsId")
                        .HasColumnType("int");

                    b.HasKey("CategoriesId", "ProductsId");

                    b.HasIndex("ProductsId");

                    b.ToTable("CategoryProduct");
                });

            modelBuilder.Entity("SwiftMartAPI.Domain.Entities.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.ToTable("Brands");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2024, 12, 22, 11, 29, 18, 268, DateTimeKind.Local).AddTicks(2800),
                            IsDeleted = false,
                            Name = "Beauty"
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2024, 12, 22, 11, 29, 18, 268, DateTimeKind.Local).AddTicks(2806),
                            IsDeleted = false,
                            Name = "Movies"
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(2024, 12, 22, 11, 29, 18, 268, DateTimeKind.Local).AddTicks(2811),
                            IsDeleted = true,
                            Name = "Kids"
                        });
                });

            modelBuilder.Entity("SwiftMartAPI.Domain.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ParentId")
                        .HasColumnType("int");

                    b.Property<int>("Priorty")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2024, 12, 22, 11, 29, 18, 268, DateTimeKind.Local).AddTicks(4589),
                            IsDeleted = false,
                            Name = "Electric",
                            ParentId = 0,
                            Priorty = 1
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2024, 12, 22, 11, 29, 18, 268, DateTimeKind.Local).AddTicks(4591),
                            IsDeleted = false,
                            Name = "Fashion",
                            ParentId = 0,
                            Priorty = 1
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(2024, 12, 22, 11, 29, 18, 268, DateTimeKind.Local).AddTicks(4592),
                            IsDeleted = false,
                            Name = "Computer",
                            ParentId = 1,
                            Priorty = 2
                        },
                        new
                        {
                            Id = 4,
                            CreatedDate = new DateTime(2024, 12, 22, 11, 29, 18, 268, DateTimeKind.Local).AddTicks(4593),
                            IsDeleted = false,
                            Name = "Women",
                            ParentId = 2,
                            Priorty = 2
                        });
                });

            modelBuilder.Entity("SwiftMartAPI.Domain.Entities.Detail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Details");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            CreatedDate = new DateTime(2024, 12, 22, 11, 29, 18, 270, DateTimeKind.Local).AddTicks(557),
                            Description = "Reprehenderit ea commodi delectus rerum.",
                            IsDeleted = false,
                            Title = "Exercitationem."
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 3,
                            CreatedDate = new DateTime(2024, 12, 22, 11, 29, 18, 270, DateTimeKind.Local).AddTicks(584),
                            Description = "Non consequatur sed perspiciatis harum.",
                            IsDeleted = true,
                            Title = "Recusandae aliquid."
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 4,
                            CreatedDate = new DateTime(2024, 12, 22, 11, 29, 18, 270, DateTimeKind.Local).AddTicks(602),
                            Description = "Deserunt omnis sed corrupti itaque.",
                            IsDeleted = false,
                            Title = "Officia."
                        });
                });

            modelBuilder.Entity("SwiftMartAPI.Domain.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Discount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BrandId = 1,
                            CreatedDate = new DateTime(2024, 12, 22, 11, 29, 18, 271, DateTimeKind.Local).AddTicks(5300),
                            Description = "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support",
                            Discount = 0.5043300229608190m,
                            IsDeleted = false,
                            Price = 346.06m,
                            Title = "Refined Rubber Chair"
                        },
                        new
                        {
                            Id = 2,
                            BrandId = 3,
                            CreatedDate = new DateTime(2024, 12, 22, 11, 29, 18, 271, DateTimeKind.Local).AddTicks(5319),
                            Description = "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive",
                            Discount = 2.657389824196960m,
                            IsDeleted = false,
                            Price = 193.46m,
                            Title = "Practical Fresh Chair"
                        });
                });

            modelBuilder.Entity("CategoryProduct", b =>
                {
                    b.HasOne("SwiftMartAPI.Domain.Entities.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SwiftMartAPI.Domain.Entities.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SwiftMartAPI.Domain.Entities.Detail", b =>
                {
                    b.HasOne("SwiftMartAPI.Domain.Entities.Category", "Category")
                        .WithMany("Details")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("SwiftMartAPI.Domain.Entities.Product", b =>
                {
                    b.HasOne("SwiftMartAPI.Domain.Entities.Brand", "Brand")
                        .WithMany()
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("SwiftMartAPI.Domain.Entities.Category", b =>
                {
                    b.Navigation("Details");
                });
#pragma warning restore 612, 618
        }
    }
}
