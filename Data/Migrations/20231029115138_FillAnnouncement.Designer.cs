﻿// <auto-generated />
using System;
using AutoDealer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AutoDealer.Data.Migrations
{
    [DbContext(typeof(AutoDbContext))]
    [Migration("20231029115138_FillAnnouncement")]
    partial class FillAnnouncement
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AutoDealer.Entities.Models.Auth.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("AutoDealer.Entities.Models.Auto.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Brands");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Audi"
                        },
                        new
                        {
                            Id = 2,
                            Name = "BMW"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Mercedes"
                        });
                });

            modelBuilder.Entity("AutoDealer.Entities.Models.Auto.Engine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Capacity")
                        .HasColumnType("float");

                    b.Property<int>("FuelType")
                        .HasColumnType("int");

                    b.Property<int>("HorsePower")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Engines");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Capacity = 3.0,
                            FuelType = 0,
                            HorsePower = 333,
                            Name = ""
                        },
                        new
                        {
                            Id = 2,
                            Capacity = 3.0,
                            FuelType = 1,
                            HorsePower = 245,
                            Name = ""
                        },
                        new
                        {
                            Id = 3,
                            Capacity = 2.0,
                            FuelType = 0,
                            HorsePower = 252,
                            Name = ""
                        });
                });

            modelBuilder.Entity("AutoDealer.Entities.Models.Auto.Equipment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Equipments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Premium"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Premium Plus (Quattro)"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Prestige"
                        });
                });

            modelBuilder.Entity("AutoDealer.Entities.Models.Auto.Gearbox", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("GearboxType")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Gearboxes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            GearboxType = 3,
                            Name = "DSG DQ 250"
                        },
                        new
                        {
                            Id = 2,
                            GearboxType = 3,
                            Name = "DSG DQ 500"
                        },
                        new
                        {
                            Id = 3,
                            GearboxType = 3,
                            Name = "DSG DQ 381"
                        },
                        new
                        {
                            Id = 4,
                            GearboxType = 1,
                            Name = "ZF 8HP"
                        });
                });

            modelBuilder.Entity("AutoDealer.Entities.Models.Auto.Generation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("EndYear")
                        .HasColumnType("int");

                    b.Property<int>("ModelId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StartYear")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ModelId");

                    b.ToTable("Generations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EndYear = 2014,
                            ModelId = 7,
                            Name = "C7",
                            StartYear = 2010
                        },
                        new
                        {
                            Id = 2,
                            EndYear = 2018,
                            ModelId = 7,
                            Name = "C7 (FL)",
                            StartYear = 2014
                        },
                        new
                        {
                            Id = 3,
                            ModelId = 7,
                            Name = "C8",
                            StartYear = 2018
                        });
                });

            modelBuilder.Entity("AutoDealer.Entities.Models.Auto.IntermediateModels.EngineGearbox", b =>
                {
                    b.Property<int>("EnginesId")
                        .HasColumnType("int");

                    b.Property<int>("GearboxesId")
                        .HasColumnType("int");

                    b.HasKey("EnginesId", "GearboxesId");

                    b.HasIndex("GearboxesId");

                    b.ToTable("EngineGearbox");

                    b.HasData(
                        new
                        {
                            EnginesId = 1,
                            GearboxesId = 3
                        },
                        new
                        {
                            EnginesId = 2,
                            GearboxesId = 4
                        },
                        new
                        {
                            EnginesId = 3,
                            GearboxesId = 1
                        });
                });

            modelBuilder.Entity("AutoDealer.Entities.Models.Auto.IntermediateModels.EngineModel", b =>
                {
                    b.Property<int>("EnginesId")
                        .HasColumnType("int");

                    b.Property<int>("ModelsId")
                        .HasColumnType("int");

                    b.HasKey("EnginesId", "ModelsId");

                    b.HasIndex("ModelsId");

                    b.ToTable("EngineModel");

                    b.HasData(
                        new
                        {
                            EnginesId = 1,
                            ModelsId = 7
                        },
                        new
                        {
                            EnginesId = 2,
                            ModelsId = 7
                        },
                        new
                        {
                            EnginesId = 3,
                            ModelsId = 7
                        });
                });

            modelBuilder.Entity("AutoDealer.Entities.Models.Auto.IntermediateModels.EquipmentModel", b =>
                {
                    b.Property<int>("EquipmentsId")
                        .HasColumnType("int");

                    b.Property<int>("ModelsId")
                        .HasColumnType("int");

                    b.HasKey("EquipmentsId", "ModelsId");

                    b.HasIndex("ModelsId");

                    b.ToTable("EquipmentModel");

                    b.HasData(
                        new
                        {
                            EquipmentsId = 1,
                            ModelsId = 7
                        },
                        new
                        {
                            EquipmentsId = 2,
                            ModelsId = 7
                        },
                        new
                        {
                            EquipmentsId = 3,
                            ModelsId = 7
                        });
                });

            modelBuilder.Entity("AutoDealer.Entities.Models.Auto.Model", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.ToTable("Models");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BrandId = 1,
                            Name = "A1"
                        },
                        new
                        {
                            Id = 2,
                            BrandId = 1,
                            Name = "A2"
                        },
                        new
                        {
                            Id = 3,
                            BrandId = 1,
                            Name = "A3"
                        },
                        new
                        {
                            Id = 4,
                            BrandId = 1,
                            Name = "A4"
                        },
                        new
                        {
                            Id = 5,
                            BrandId = 1,
                            Name = "A5"
                        },
                        new
                        {
                            Id = 6,
                            BrandId = 1,
                            Name = "A6"
                        },
                        new
                        {
                            Id = 7,
                            BrandId = 1,
                            Name = "A7"
                        },
                        new
                        {
                            Id = 8,
                            BrandId = 1,
                            Name = "A8"
                        });
                });

            modelBuilder.Entity("AutoDealer.Entities.Models.Auto.SaleAnnouncement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EngineId")
                        .HasColumnType("int");

                    b.Property<int>("EquipmentId")
                        .HasColumnType("int");

                    b.Property<int>("GearboxId")
                        .HasColumnType("int");

                    b.Property<int>("GenerationId")
                        .HasColumnType("int");

                    b.Property<int>("MileageThousands")
                        .HasColumnType("int");

                    b.Property<int>("ModelId")
                        .HasColumnType("int");

                    b.Property<int>("OwnersCount")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("WinNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EngineId");

                    b.HasIndex("EquipmentId");

                    b.HasIndex("GearboxId");

                    b.HasIndex("GenerationId");

                    b.HasIndex("ModelId");

                    b.HasIndex("UserId");

                    b.ToTable("SaleAnnouncements");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "Kyiv",
                            Color = "Blue",
                            CreatedAt = new DateTime(2023, 10, 29, 13, 51, 37, 979, DateTimeKind.Local).AddTicks(6343),
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla euismod, nisl vitae aliquam ultricies, nunc nisl ultricies",
                            EngineId = 1,
                            EquipmentId = 3,
                            GearboxId = 3,
                            GenerationId = 2,
                            MileageThousands = 100000,
                            ModelId = 7,
                            OwnersCount = 1,
                            Price = 35000,
                            UserId = "b0d3634c-6328-4814-b095-a0078f357393",
                            WinNumber = "12345678901234567",
                            Year = 2015
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "2301D884-221A-4E7D-B509-0113DCC043E1",
                            Name = "Viewer",
                            NormalizedName = "VIEWER"
                        },
                        new
                        {
                            Id = "7D9B7113-A8F8-4035-99A7-A20DD400F6A3",
                            Name = "Seller",
                            NormalizedName = "SELLER"
                        },
                        new
                        {
                            Id = "78A7570F-3CE5-48BA-9461-80283ED1D94D",
                            Name = "Manager",
                            NormalizedName = "MANAGER"
                        },
                        new
                        {
                            Id = "01B168FE-810B-432D-9010-233BA0B380E9",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("AutoDealer.Entities.Models.Auto.Generation", b =>
                {
                    b.HasOne("AutoDealer.Entities.Models.Auto.Model", "Model")
                        .WithMany("Generations")
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Model");
                });

            modelBuilder.Entity("AutoDealer.Entities.Models.Auto.IntermediateModels.EngineGearbox", b =>
                {
                    b.HasOne("AutoDealer.Entities.Models.Auto.Engine", null)
                        .WithMany()
                        .HasForeignKey("EnginesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AutoDealer.Entities.Models.Auto.Gearbox", null)
                        .WithMany()
                        .HasForeignKey("GearboxesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AutoDealer.Entities.Models.Auto.IntermediateModels.EngineModel", b =>
                {
                    b.HasOne("AutoDealer.Entities.Models.Auto.Engine", null)
                        .WithMany()
                        .HasForeignKey("EnginesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AutoDealer.Entities.Models.Auto.Model", null)
                        .WithMany()
                        .HasForeignKey("ModelsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AutoDealer.Entities.Models.Auto.IntermediateModels.EquipmentModel", b =>
                {
                    b.HasOne("AutoDealer.Entities.Models.Auto.Equipment", null)
                        .WithMany()
                        .HasForeignKey("EquipmentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AutoDealer.Entities.Models.Auto.Model", null)
                        .WithMany()
                        .HasForeignKey("ModelsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AutoDealer.Entities.Models.Auto.Model", b =>
                {
                    b.HasOne("AutoDealer.Entities.Models.Auto.Brand", "Brand")
                        .WithMany("Models")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("AutoDealer.Entities.Models.Auto.SaleAnnouncement", b =>
                {
                    b.HasOne("AutoDealer.Entities.Models.Auto.Engine", "Engine")
                        .WithMany("SaleAnnouncements")
                        .HasForeignKey("EngineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AutoDealer.Entities.Models.Auto.Equipment", "Equipment")
                        .WithMany("SaleAnnouncements")
                        .HasForeignKey("EquipmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AutoDealer.Entities.Models.Auto.Gearbox", "Gearbox")
                        .WithMany()
                        .HasForeignKey("GearboxId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AutoDealer.Entities.Models.Auto.Generation", "Generation")
                        .WithMany("SaleAnnouncements")
                        .HasForeignKey("GenerationId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("AutoDealer.Entities.Models.Auto.Model", "Model")
                        .WithMany("SaleAnnouncements")
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AutoDealer.Entities.Models.Auth.User", "User")
                        .WithMany("SaleAnnouncements")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Engine");

                    b.Navigation("Equipment");

                    b.Navigation("Gearbox");

                    b.Navigation("Generation");

                    b.Navigation("Model");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("AutoDealer.Entities.Models.Auth.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("AutoDealer.Entities.Models.Auth.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AutoDealer.Entities.Models.Auth.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("AutoDealer.Entities.Models.Auth.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AutoDealer.Entities.Models.Auth.User", b =>
                {
                    b.Navigation("SaleAnnouncements");
                });

            modelBuilder.Entity("AutoDealer.Entities.Models.Auto.Brand", b =>
                {
                    b.Navigation("Models");
                });

            modelBuilder.Entity("AutoDealer.Entities.Models.Auto.Engine", b =>
                {
                    b.Navigation("SaleAnnouncements");
                });

            modelBuilder.Entity("AutoDealer.Entities.Models.Auto.Equipment", b =>
                {
                    b.Navigation("SaleAnnouncements");
                });

            modelBuilder.Entity("AutoDealer.Entities.Models.Auto.Generation", b =>
                {
                    b.Navigation("SaleAnnouncements");
                });

            modelBuilder.Entity("AutoDealer.Entities.Models.Auto.Model", b =>
                {
                    b.Navigation("Generations");

                    b.Navigation("SaleAnnouncements");
                });
#pragma warning restore 612, 618
        }
    }
}
