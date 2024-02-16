﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TheHealtood.Data;

#nullable disable

namespace TheHealtood.Migrations
{
    [DbContext(typeof(TheHealtoodContext))]
    [Migration("20240215210227_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.14");

            modelBuilder.Entity("ProductsWithIngredients", b =>
                {
                    b.Property<int>("IngredientsId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ListProductsId")
                        .HasColumnType("INTEGER");

                    b.HasKey("IngredientsId", "ListProductsId");

                    b.HasIndex("ListProductsId");

                    b.ToTable("ProductsWithIngredients");
                });

            modelBuilder.Entity("TheHealtood.Models.Gallery", b =>
                {
                    b.Property<int>("GalleryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<byte[]>("Datos")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.Property<string>("Extension")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("GalleryId");

                    b.ToTable("Gallery");
                });

            modelBuilder.Entity("TheHealtood.Models.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FoodGroups")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("TheHealtood.Models.Products", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("GalleryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("GalleryId")
                        .IsUnique();

                    b.ToTable("Products");
                });

            modelBuilder.Entity("ProductsWithIngredients", b =>
                {
                    b.HasOne("TheHealtood.Models.Ingredient", null)
                        .WithMany()
                        .HasForeignKey("IngredientsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TheHealtood.Models.Products", null)
                        .WithMany()
                        .HasForeignKey("ListProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TheHealtood.Models.Products", b =>
                {
                    b.HasOne("TheHealtood.Models.Gallery", "gallery")
                        .WithOne("Product")
                        .HasForeignKey("TheHealtood.Models.Products", "GalleryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("gallery");
                });

            modelBuilder.Entity("TheHealtood.Models.Gallery", b =>
                {
                    b.Navigation("Product")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}