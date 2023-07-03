﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Demeter.Infrastracture.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230520183100_Added many to many relationship")]
    partial class Addedmanytomanyrelationship
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Demeter.Domain.FoodDomain.GroceryProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Badges")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nutrients")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("GroceryProducts", (string)null);
                });

            modelBuilder.Entity("Demeter.Domain.FoodDomain.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Amount")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Consistency")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nutrients")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Ingredients", (string)null);
                });

            modelBuilder.Entity("Demeter.Domain.FoodRecordDomain.FoodRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<DateTime>("DateRegistered")
                        .HasColumnType("datetime2");

                    b.Property<string>("FoodType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FoodRecord");

                    b.HasDiscriminator<string>("FoodType").HasValue("FoodRecord");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("GroceryProductGroceryProductRecord", b =>
                {
                    b.Property<int>("GroceryProductRecordsId")
                        .HasColumnType("int");

                    b.Property<int>("GroceryProductsId")
                        .HasColumnType("int");

                    b.HasKey("GroceryProductRecordsId", "GroceryProductsId");

                    b.HasIndex("GroceryProductsId");

                    b.ToTable("GroceryProductGroceryProductRecord");
                });

            modelBuilder.Entity("IngredientIngredientRecord", b =>
                {
                    b.Property<int>("IngredientRecordsId")
                        .HasColumnType("int");

                    b.Property<int>("IngredientsId")
                        .HasColumnType("int");

                    b.HasKey("IngredientRecordsId", "IngredientsId");

                    b.HasIndex("IngredientsId");

                    b.ToTable("IngredientIngredientRecord");
                });

            modelBuilder.Entity("Demeter.Domain.FoodRecordDomain.GroceryProductRecord", b =>
                {
                    b.HasBaseType("Demeter.Domain.FoodRecordDomain.FoodRecord");

                    b.Property<int>("GroceryProductId")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("GroceryProductRecord");
                });

            modelBuilder.Entity("Demeter.Domain.FoodRecordDomain.IngredientRecord", b =>
                {
                    b.HasBaseType("Demeter.Domain.FoodRecordDomain.FoodRecord");

                    b.Property<int>("IngredientId")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("IngredientRecord");
                });

            modelBuilder.Entity("GroceryProductGroceryProductRecord", b =>
                {
                    b.HasOne("Demeter.Domain.FoodRecordDomain.GroceryProductRecord", null)
                        .WithMany()
                        .HasForeignKey("GroceryProductRecordsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Demeter.Domain.FoodDomain.GroceryProduct", null)
                        .WithMany()
                        .HasForeignKey("GroceryProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IngredientIngredientRecord", b =>
                {
                    b.HasOne("Demeter.Domain.FoodRecordDomain.IngredientRecord", null)
                        .WithMany()
                        .HasForeignKey("IngredientRecordsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Demeter.Domain.FoodDomain.Ingredient", null)
                        .WithMany()
                        .HasForeignKey("IngredientsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
