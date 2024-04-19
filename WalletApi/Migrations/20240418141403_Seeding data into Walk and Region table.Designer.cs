﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WalletApi.Data;

#nullable disable

namespace WalletApi.Migrations
{
    [DbContext(typeof(WalletDbContext))]
    [Migration("20240418141403_Seeding data into Walk and Region table")]
    partial class SeedingdataintoWalkandRegiontable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WalletApi.Models.Domains.Difficulty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Difficulties");

                    b.HasData(
                        new
                        {
                            Id = new Guid("006d4c13-a079-42f8-8603-4abf778b3cf8"),
                            Name = "Easy"
                        },
                        new
                        {
                            Id = new Guid("4e080aec-ddba-42c2-bc25-a4da2c72c705"),
                            Name = "Medium"
                        },
                        new
                        {
                            Id = new Guid("7c2cc3dd-c3af-473f-9c63-8ecc72bbabc7"),
                            Name = "Hard"
                        });
                });

            modelBuilder.Entity("WalletApi.Models.Domains.Region", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegionImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Regions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ff756d93-71fd-4acc-a6d3-d5f5023cd25f"),
                            Code = "Kan",
                            Name = "Kano",
                            RegionImageUrl = "https://www.bellanaija.com/wp-content/uploads/2023/09/IMG-20230909-WA0022.jpg"
                        },
                        new
                        {
                            Id = new Guid("d8d64eda-f5e9-45cb-8d5a-3c96f991afcb"),
                            Code = "Kad",
                            Name = "Kaduna",
                            RegionImageUrl = "https://momaa.org/wp-content/uploads/2019/10/zazzau-gate-1024x568.png"
                        },
                        new
                        {
                            Id = new Guid("edec48ed-f6b3-4cb9-b1c7-f133ea2d6133"),
                            Code = "Kas",
                            Name = "Kastina",
                            RegionImageUrl = "https://freedomradionig.com/wp-content/uploads/2020/07/katsina.jpg"
                        });
                });

            modelBuilder.Entity("WalletApi.Models.Domains.Walk", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("DifficultyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("LengthInKm")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RegionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("WalkImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DifficultyId");

                    b.HasIndex("RegionId");

                    b.ToTable("Walks");
                });

            modelBuilder.Entity("WalletApi.Models.Domains.Walk", b =>
                {
                    b.HasOne("WalletApi.Models.Domains.Difficulty", "Difficulty")
                        .WithMany()
                        .HasForeignKey("DifficultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WalletApi.Models.Domains.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Difficulty");

                    b.Navigation("Region");
                });
#pragma warning restore 612, 618
        }
    }
}
