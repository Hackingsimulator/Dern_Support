﻿// <auto-generated />
using System;
using ErdAndEF.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ErdAndEF.Migrations
{
    [DbContext(typeof(EmployeeDbContext))]
    [Migration("20240908223107_seedingAddingJobs")]
    partial class seedingAddingJobs
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ErdAndEF.Models.ApplicationUser", b =>
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
                });

            modelBuilder.Entity("ErdAndEF.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("employees");

                    b.HasData(
                        new
                        {
                            Id = 6,
                            Email = "Anymail@gmail.com",
                            FirstName = "Ahmad",
                            LastName = "Mohsen",
                            Phone = "022555554"
                        },
                        new
                        {
                            Id = 7,
                            Email = "Anymail@gmail.com",
                            FirstName = "Essa",
                            LastName = "Mohsen",
                            Phone = "022555554"
                        });
                });

            modelBuilder.Entity("ErdAndEF.Models.EmployeeProjects", b =>
                {
                    b.Property<int>("ProjectID")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeID")
                        .HasColumnType("int");

                    b.HasKey("ProjectID", "EmployeeID");

                    b.HasIndex("EmployeeID");

                    b.ToTable("EmployeeProjectsDBset");

                    b.HasData(
                        new
                        {
                            ProjectID = 1,
                            EmployeeID = 6
                        },
                        new
                        {
                            ProjectID = 2,
                            EmployeeID = 6
                        },
                        new
                        {
                            ProjectID = 1,
                            EmployeeID = 7
                        });
                });

            modelBuilder.Entity("ErdAndEF.Models.EmployeeTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("EmployeeTasksDb");
                });

            modelBuilder.Entity("ErdAndEF.Models.ITStocks", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuantityInStock")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ITStocksDb");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Category = "Laptop",
                            Description = "Dell Latitude 5500",
                            Name = "Laptop",
                            QuantityInStock = 5
                        },
                        new
                        {
                            Id = 2,
                            Category = "Battery",
                            Description = "Dell XPS 13 Battery",
                            Name = "Battery",
                            QuantityInStock = 10
                        },
                        new
                        {
                            Id = 3,
                            Category = "Screen",
                            Description = "15.6 inch FHD Screen",
                            Name = "Screen",
                            QuantityInStock = 8
                        },
                        new
                        {
                            Id = 4,
                            Category = "RAM",
                            Description = "8GB DDR4 RAM",
                            Name = "RAM",
                            QuantityInStock = 20
                        },
                        new
                        {
                            Id = 5,
                            Category = "Storage",
                            Description = "1TB SSD",
                            Name = "Hard Drive",
                            QuantityInStock = 15
                        },
                        new
                        {
                            Id = 6,
                            Category = "Keyboard",
                            Description = "Mechanical Keyboard",
                            Name = "Keyboard",
                            QuantityInStock = 12
                        },
                        new
                        {
                            Id = 7,
                            Category = "Charger",
                            Description = "65W USB-C Charger",
                            Name = "Charger",
                            QuantityInStock = 18
                        },
                        new
                        {
                            Id = 8,
                            Category = "Laptop",
                            Description = "Dell Latitude Motherboard",
                            Name = "Motherboard",
                            QuantityInStock = 4
                        });
                });

            modelBuilder.Entity("ErdAndEF.Models.Jobs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Priority")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ScheduledDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("JobsDb");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Fix WiFi connectivity issue in the office.",
                            Priority = "High",
                            ScheduledDate = "",
                            Status = "Pending",
                            Title = "Network Issue Resolution"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Install Visual Studio on employee laptops.",
                            Priority = "High",
                            ScheduledDate = "",
                            Status = "Pending",
                            Title = "Install Software"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Replace faulty RAM in server rack 1.",
                            Priority = "Medium",
                            ScheduledDate = "",
                            Status = "New",
                            Title = "Hardware Upgrade"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Perform routine maintenance on printers in all offices.",
                            Priority = "Low",
                            ScheduledDate = "",
                            Status = "Pending",
                            Title = "Printer Maintenance"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Create new user accounts for incoming employees.",
                            Priority = "Medium",
                            ScheduledDate = "",
                            Status = "Pending",
                            Title = "User Account Setup"
                        });
                });

            modelBuilder.Entity("ErdAndEF.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Budget")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Hours")
                        .HasColumnType("float");

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Projects");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Budget = "8000 JD",
                            Hours = 120.0,
                            ProjectName = "Project A"
                        },
                        new
                        {
                            Id = 2,
                            Budget = "12000 JD",
                            Hours = 180.0,
                            ProjectName = "Project B"
                        },
                        new
                        {
                            Id = 3,
                            Budget = "15000 JD",
                            Hours = 160.0,
                            ProjectName = "Project C"
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
                            Id = "admin",
                            ConcurrencyStamp = "00000000-0000-0000-0000-000000000000",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "user",
                            ConcurrencyStamp = "00000000-0000-0000-0000-000000000000",
                            Name = "User",
                            NormalizedName = "USER"
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

                    b.HasData(
                        new
                        {
                            Id = 413580643,
                            ClaimValue = "CanCreate",
                            RoleId = "admin"
                        },
                        new
                        {
                            Id = -2031013919,
                            ClaimValue = "CanDelete",
                            RoleId = "admin"
                        },
                        new
                        {
                            Id = -313678871,
                            ClaimValue = "CanDelete",
                            RoleId = "user"
                        });
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

            modelBuilder.Entity("ErdAndEF.Models.EmployeeProjects", b =>
                {
                    b.HasOne("ErdAndEF.Models.Employee", "Employee")
                        .WithMany("employeeProjects")
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ErdAndEF.Models.Project", "Project")
                        .WithMany("employeeProjects")
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("ErdAndEF.Models.EmployeeTask", b =>
                {
                    b.HasOne("ErdAndEF.Models.Employee", null)
                        .WithMany("EmployeeTasks")
                        .HasForeignKey("EmployeeId");
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
                    b.HasOne("ErdAndEF.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ErdAndEF.Models.ApplicationUser", null)
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

                    b.HasOne("ErdAndEF.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("ErdAndEF.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ErdAndEF.Models.Employee", b =>
                {
                    b.Navigation("EmployeeTasks");

                    b.Navigation("employeeProjects");
                });

            modelBuilder.Entity("ErdAndEF.Models.Project", b =>
                {
                    b.Navigation("employeeProjects");
                });
#pragma warning restore 612, 618
        }
    }
}
