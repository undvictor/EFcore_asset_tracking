﻿// <auto-generated />
using System;
using EFassets.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFassets.Data.Migrations
{
    [DbContext(typeof(AssetContext))]
    [Migration("20201215103621_what")]
    partial class what
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("EFassets.Domains.Asset", b =>
                {
                    b.Property<int>("AssetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("AssetModel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AssetName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CategoryObjectId")
                        .HasColumnType("int");

                    b.Property<int?>("OfficesOfficeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("expirationDate")
                        .HasColumnType("datetime2");

                    b.Property<float>("price")
                        .HasColumnType("real");

                    b.Property<DateTime>("purchaseDate")
                        .HasColumnType("datetime2");

                    b.HasKey("AssetId");

                    b.HasIndex("CategoryObjectId");

                    b.HasIndex("OfficesOfficeId");

                    b.ToTable("Assets");
                });

            modelBuilder.Entity("EFassets.Domains.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("EFassets.Domains.Office", b =>
                {
                    b.Property<int>("OfficeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("OfficeCountry")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OfficeId");

                    b.ToTable("Offices");
                });

            modelBuilder.Entity("EFassets.Domains.Asset", b =>
                {
                    b.HasOne("EFassets.Domains.Category", "CategoryObject")
                        .WithMany()
                        .HasForeignKey("CategoryObjectId");

                    b.HasOne("EFassets.Domains.Office", "Offices")
                        .WithMany()
                        .HasForeignKey("OfficesOfficeId");

                    b.Navigation("CategoryObject");

                    b.Navigation("Offices");
                });
#pragma warning restore 612, 618
        }
    }
}
