﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProductApi.Models.Entites;

#nullable disable

namespace WebApplication6.Migrations
{
    [DbContext(typeof(DesignDistrictContext))]
    [Migration("20240507110346_UpdateCatStyle")]
    partial class UpdateCatStyle
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApplication6.Model.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            Name = "Living Room"
                        },
                        new
                        {
                            CategoryId = 2,
                            Name = "Bedroom"
                        },
                        new
                        {
                            CategoryId = 3,
                            Name = "Office"
                        },
                        new
                        {
                            CategoryId = 4,
                            Name = "Bathroom"
                        },
                        new
                        {
                            CategoryId = 5,
                            Name = "Outdoor"
                        });
                });

            modelBuilder.Entity("WebApplication6.Model.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CommentId"));

                    b.Property<string>("CommentText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("DesignId")
                        .HasColumnType("int");

                    b.HasKey("CommentId");

                    b.HasIndex("DesignId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("WebApplication6.Model.DesignPost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DesignCatagoryCategoryId")
                        .HasColumnType("int");

                    b.Property<int>("ItemType")
                        .HasColumnType("int");

                    b.Property<string>("PostDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UserAccountId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DesignCatagoryCategoryId");

                    b.HasIndex("UserAccountId");

                    b.ToTable("DesignPosts");
                });

            modelBuilder.Entity("WebApplication6.Model.Item", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ItemId"));

                    b.Property<string>("ItemDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ItemName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ItemTypeId")
                        .HasColumnType("int");

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Source")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StoreId")
                        .HasColumnType("int");

                    b.Property<int>("StyleId")
                        .HasColumnType("int");

                    b.HasKey("ItemId");

                    b.HasIndex("ItemTypeId");

                    b.HasIndex("PostId");

                    b.HasIndex("StoreId");

                    b.HasIndex("StyleId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("WebApplication6.Model.ItemType", b =>
                {
                    b.Property<int>("ItemTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ItemTypeId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ItemTypeId");

                    b.ToTable("ItemTypes");

                    b.HasData(
                        new
                        {
                            ItemTypeId = 1,
                            Name = "Chair"
                        },
                        new
                        {
                            ItemTypeId = 2,
                            Name = "Table"
                        },
                        new
                        {
                            ItemTypeId = 3,
                            Name = "Closet"
                        },
                        new
                        {
                            ItemTypeId = 4,
                            Name = "Sofa/Couch"
                        },
                        new
                        {
                            ItemTypeId = 5,
                            Name = "Carpet"
                        },
                        new
                        {
                            ItemTypeId = 6,
                            Name = "Curtain"
                        },
                        new
                        {
                            ItemTypeId = 7,
                            Name = "Cabinet"
                        },
                        new
                        {
                            ItemTypeId = 8,
                            Name = "Shelves"
                        },
                        new
                        {
                            ItemTypeId = 9,
                            Name = "Shoe Closet"
                        });
                });

            modelBuilder.Entity("WebApplication6.Model.Store", b =>
                {
                    b.Property<int>("StoreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StoreId"));

                    b.Property<string>("StoreDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StoreName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StoreWebsite")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StoreId");

                    b.ToTable("Stores");
                });

            modelBuilder.Entity("WebApplication6.Model.Style", b =>
                {
                    b.Property<int>("StyleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StyleId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StyleId");

                    b.ToTable("Styles");

                    b.HasData(
                        new
                        {
                            StyleId = 1,
                            Name = "Modern"
                        },
                        new
                        {
                            StyleId = 2,
                            Name = "Rustic"
                        },
                        new
                        {
                            StyleId = 3,
                            Name = "Classic"
                        },
                        new
                        {
                            StyleId = 4,
                            Name = "Cosy"
                        });
                });

            modelBuilder.Entity("WebApplication6.Model.UserAccount", b =>
                {
                    b.Property<int>("UserAccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserAccountId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserAccountId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("PhoneNumber")
                        .IsUnique();

                    b.ToTable("UserAccounts");
                });

            modelBuilder.Entity("WebApplication6.Model.Comment", b =>
                {
                    b.HasOne("WebApplication6.Model.DesignPost", "Design")
                        .WithMany("Comments")
                        .HasForeignKey("DesignId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Design");
                });

            modelBuilder.Entity("WebApplication6.Model.DesignPost", b =>
                {
                    b.HasOne("WebApplication6.Model.Category", "DesignCatagory")
                        .WithMany()
                        .HasForeignKey("DesignCatagoryCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication6.Model.UserAccount", "User")
                        .WithMany()
                        .HasForeignKey("UserAccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DesignCatagory");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WebApplication6.Model.Item", b =>
                {
                    b.HasOne("WebApplication6.Model.ItemType", "ItemType")
                        .WithMany()
                        .HasForeignKey("ItemTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication6.Model.DesignPost", "Post")
                        .WithMany("Item")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication6.Model.Store", "Store")
                        .WithMany("Items")
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication6.Model.Style", "Style")
                        .WithMany()
                        .HasForeignKey("StyleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ItemType");

                    b.Navigation("Post");

                    b.Navigation("Store");

                    b.Navigation("Style");
                });

            modelBuilder.Entity("WebApplication6.Model.DesignPost", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("WebApplication6.Model.Store", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
