﻿// <auto-generated />
using System;
using FixIt.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FixIt.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240409193454_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.28")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FixIt.Infrastructure.Data.Models.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Appointment Identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CarId")
                        .HasColumnType("int")
                        .HasComment("Car Identifier");

                    b.Property<DateTime>("DateAndTime")
                        .HasColumnType("datetime2")
                        .HasComment("Appointment Date");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int")
                        .HasComment("Service Identifier");

                    b.Property<int>("Status")
                        .HasColumnType("int")
                        .HasComment("Appointment Status");

                    b.Property<int?>("TechnicianId")
                        .HasColumnType("int")
                        .HasComment("Technician Identifier");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasComment("Customer Identifier");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("ServiceId");

                    b.HasIndex("TechnicianId");

                    b.HasIndex("UserId");

                    b.ToTable("Appointments");

                    b.HasComment("Appointments table");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CarId = 1,
                            DateAndTime = new DateTime(2024, 4, 10, 22, 34, 53, 701, DateTimeKind.Local).AddTicks(4036),
                            ServiceId = 1,
                            Status = 0,
                            TechnicianId = 1,
                            UserId = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"
                        });
                });

            modelBuilder.Entity("FixIt.Infrastructure.Data.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Car Identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Car Image");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasComment("Soft delete property");

                    b.Property<string>("Make")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasComment("Car Manufacturer Information");

                    b.Property<int>("Mileage")
                        .HasColumnType("int")
                        .HasComment("Car Current Mileage in km");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasComment("Car Model Information");

                    b.Property<string>("PlateNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasComment("Car Registration Plate Number");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasComment("Car's owner");

                    b.Property<string>("Vin")
                        .HasMaxLength(17)
                        .HasColumnType("nvarchar(17)")
                        .HasComment("Car Vehicle Identification Number");

                    b.Property<int>("Year")
                        .HasColumnType("int")
                        .HasComment("Car Year of Manufacture");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Cars");

                    b.HasComment("Cars Table");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ImageUrl = "https://www.google.com/imgres?imgurl=https%3A%2F%2Fimg.autoabc.lv%2FToyota-Avensis%2FToyota-Avensis_2003_Hecbeks_15102250637_3.jpg&tbnid=3pELpEqszmhQ8M&vet=12ahUKEwiHqLvu_s6EAxX74bsIHVDBCw8QMygIegQIARBf..i&imgrefurl=https%3A%2F%2Fwww.auto-abc.eu%2FToyota-Avensis%2Fg275-2003&docid=Hbz18f1fC2wffM&w=1000&h=547&q=avensis%20t25&ved=2ahUKEwiHqLvu_s6EAxX74bsIHVDBCw8QMygIegQIARBf",
                            IsDeleted = false,
                            Make = "Toyota",
                            Mileage = 180000,
                            Model = "Avensis",
                            PlateNumber = "P3366BC",
                            UserId = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                            Year = 2005
                        },
                        new
                        {
                            Id = 2,
                            ImageUrl = "https://www.google.com/imgres?imgurl=https%3A%2F%2Fautomedia.investor.bg%2Fmedia%2Ffiles%2Fresized%2Fuploadedfiles%2F640x0%2F244%2F5afbc0f7c9b507828db312f5101c9244-98.JPG&tbnid=EkO4b49Jvg6aaM&vet=12ahUKEwjr9Zuy_86EAxXSgv0HHawqCAoQMygBegQIARBN..i&imgrefurl=https%3A%2F%2Fautomedia.investor.bg%2Fa%2F2-novini%2F43784-upotrebyavano-renault-clio-iii-struva-li-si&docid=rme63mMTwMi2YM&w=640&h=463&q=renault%20clio%203&ved=2ahUKEwjr9Zuy_86EAxXSgv0HHawqCAoQMygBegQIARBN",
                            IsDeleted = false,
                            Make = "Renault",
                            Mileage = 120000,
                            Model = "Clio",
                            PlateNumber = "P1917BX",
                            UserId = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                            Year = 2008
                        });
                });

            modelBuilder.Entity("FixIt.Infrastructure.Data.Models.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Service Identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Detailed description of the service, if needed");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)")
                        .HasComment("Price for the service");

                    b.Property<int>("Type")
                        .HasColumnType("int")
                        .HasComment("Type of the Service");

                    b.HasKey("Id");

                    b.ToTable("Services");

                    b.HasComment("Table for Services");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Price = 80.00m,
                            Type = 0
                        },
                        new
                        {
                            Id = 2,
                            Price = 150.00m,
                            Type = 1
                        },
                        new
                        {
                            Id = 3,
                            Price = 60.00m,
                            Type = 2
                        },
                        new
                        {
                            Id = 4,
                            Price = 2000.00m,
                            Type = 3
                        },
                        new
                        {
                            Id = 5,
                            Price = 1300.00m,
                            Type = 4
                        },
                        new
                        {
                            Id = 6,
                            Price = 2420.00m,
                            Type = 5
                        });
                });

            modelBuilder.Entity("FixIt.Infrastructure.Data.Models.ServiceHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("ServiceHistory Identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CarId")
                        .HasColumnType("int")
                        .HasComment("Car Identifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2")
                        .HasComment("Date of the service");

                    b.Property<int>("Mileage")
                        .HasColumnType("int")
                        .HasComment("Current car mileage");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int")
                        .HasComment("Service Identifier");

                    b.Property<int>("TechnicianId")
                        .HasColumnType("int")
                        .HasComment("Technician Identifier");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasComment("ServceHistory Customer Identifier");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("ServiceId");

                    b.HasIndex("TechnicianId");

                    b.HasIndex("UserId");

                    b.ToTable("ServiceHistories");

                    b.HasComment("Table for the ServiceHistory");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CarId = 1,
                            Date = new DateTime(2024, 1, 9, 0, 0, 0, 0, DateTimeKind.Local),
                            Mileage = 180000,
                            ServiceId = 6,
                            TechnicianId = 2,
                            UserId = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"
                        });
                });

            modelBuilder.Entity("FixIt.Infrastructure.Data.Models.Technician", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Technician Identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasComment("Technician Soft Delete Property");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Technician Name");

                    b.Property<int>("Specialization")
                        .HasColumnType("int")
                        .HasComment("Technician Specialization");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasComment("Identity User Identification");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Technicians");

                    b.HasComment("Technicians Table");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsDeleted = false,
                            Name = "John Doe",
                            Specialization = 3,
                            UserId = "99ae7f52-08a1-4c41-98f6-0934ab9eeced"
                        },
                        new
                        {
                            Id = 2,
                            IsDeleted = false,
                            Name = "Jane Doe",
                            Specialization = 0,
                            UserId = "3e0f5536-ea82-4817-9d63-861cc93427c6"
                        },
                        new
                        {
                            Id = 3,
                            IsDeleted = false,
                            Name = "Don Johns",
                            Specialization = 4,
                            UserId = "b98a765c-94d6-4520-95ae-42503a95445d"
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
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
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

                    b.HasData(
                        new
                        {
                            Id = "dea12856-c198-4129-b3f3-b893d8395082",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "355a7489-74d3-426b-801f-5e938c7b7b59",
                            Email = "admin@mail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "admin@mail.com",
                            NormalizedUserName = "admin@mail.com",
                            PasswordHash = "AQAAAAEAACcQAAAAEAG0wMH+62weEriO8so+hkJW29f/a3NTVAoZIrbSdJFXBLuKYaZCK+fo9c2xZKsdPw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "81d7567d-650e-4d54-8f3a-9f776d89864c",
                            TwoFactorEnabled = false,
                            UserName = "admin@mail.com"
                        },
                        new
                        {
                            Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "7a9955db-0186-47b4-a0d6-b6be27c2725a",
                            Email = "customer@mail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "customer@mail.com",
                            NormalizedUserName = "customer@mail.com",
                            PasswordHash = "AQAAAAEAACcQAAAAEKGhhH1XGgJrkV2St+vjw3iItx+I+4VtjsvhbNePiNfwmAi5m30hf+FLpmKeX39Hyw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "8332b224-ee28-4db1-9678-2ecc82e7baa9",
                            TwoFactorEnabled = false,
                            UserName = "customer@mail.com"
                        },
                        new
                        {
                            Id = "99ae7f52-08a1-4c41-98f6-0934ab9eeced",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "319bb0af-824f-49dd-a75a-d005c99106ee",
                            Email = "technician1@mail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "technician1@mail.com",
                            NormalizedUserName = "technician1@mail.com",
                            PasswordHash = "AQAAAAEAACcQAAAAEAPyA3K/kE5IG8TFNgSrV4j8lycLyUmSB2mHtD/uVrXu6c6Qtsv9cKNFqAs6oiqskA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "26a76ec6-4bd2-4385-b8be-d75889290c00",
                            TwoFactorEnabled = false,
                            UserName = "technician1@mail.com"
                        },
                        new
                        {
                            Id = "3e0f5536-ea82-4817-9d63-861cc93427c6",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "fdca5ee5-9bb7-4921-a83f-b2307c01430d",
                            Email = "technician2@mail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "technician2@mail.com",
                            NormalizedUserName = "technician2@mail.com",
                            PasswordHash = "AQAAAAEAACcQAAAAEO8W2XAXnTfjvNiHbty44Pk4QYZVb53Inm2OmvN6TnjHVCWlfemFdGhMogcFLmDVRg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "974d8093-d827-4346-9eae-cc358e0e5a1c",
                            TwoFactorEnabled = false,
                            UserName = "technician2@mail.com"
                        },
                        new
                        {
                            Id = "b98a765c-94d6-4520-95ae-42503a95445d",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "b09328d9-0e26-4840-ac47-f6cdc7a8aea6",
                            Email = "technician3@mail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "technician3@mail.com",
                            NormalizedUserName = "technician3@mail.com",
                            PasswordHash = "AQAAAAEAACcQAAAAELx6TvT6WDBpqoTpipCLQ8SqjkzRROA865woy0J2O3tegrUkVUcRgDew7YC1FjXXLA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "e8247c5c-082b-4910-a72e-633df8ca1651",
                            TwoFactorEnabled = false,
                            UserName = "technician3@mail.com"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

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
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

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
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("FixIt.Infrastructure.Data.Models.Appointment", b =>
                {
                    b.HasOne("FixIt.Infrastructure.Data.Models.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FixIt.Infrastructure.Data.Models.Service", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FixIt.Infrastructure.Data.Models.Technician", "Technician")
                        .WithMany()
                        .HasForeignKey("TechnicianId");

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Service");

                    b.Navigation("Technician");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FixIt.Infrastructure.Data.Models.Car", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("FixIt.Infrastructure.Data.Models.ServiceHistory", b =>
                {
                    b.HasOne("FixIt.Infrastructure.Data.Models.Car", "Car")
                        .WithMany("ServiceHistories")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FixIt.Infrastructure.Data.Models.Service", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FixIt.Infrastructure.Data.Models.Technician", "Technician")
                        .WithMany()
                        .HasForeignKey("TechnicianId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Service");

                    b.Navigation("Technician");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FixIt.Infrastructure.Data.Models.Technician", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

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
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
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

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FixIt.Infrastructure.Data.Models.Car", b =>
                {
                    b.Navigation("ServiceHistories");
                });
#pragma warning restore 612, 618
        }
    }
}
