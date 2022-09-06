﻿// <auto-generated />
using System;
using HireManagment.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HireManagment.Persistence.Migrations
{
    [DbContext(typeof(HireManagmentDbContext))]
    [Migration("20220905190843_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("HireManagment.Domain.AdminApi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Admins");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Age = 32,
                            Email = "rodrigovalladares1@gmail.com",
                            FirstName = "Robert",
                            LastName = "Wade"
                        },
                        new
                        {
                            Id = 2,
                            Age = 32,
                            Email = "rodrigovalladares1@gmail.com",
                            FirstName = "Felix",
                            LastName = "Feliz"
                        });
                });

            modelBuilder.Entity("HireManagment.Domain.Candidate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Candidates");
                });

            modelBuilder.Entity("HireManagment.Domain.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AdminId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.ToTable("Companies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "address",
                            AdminId = 1,
                            Description = "company 1",
                            Name = "Naughty Dog"
                        },
                        new
                        {
                            Id = 2,
                            Address = "address",
                            AdminId = 1,
                            Description = "company 2",
                            Name = "Riot Games"
                        },
                        new
                        {
                            Id = 3,
                            Address = "address",
                            AdminId = 2,
                            Description = "company 3",
                            Name = "Miami Heat"
                        });
                });

            modelBuilder.Entity("HireManagment.Domain.CompanyEmployee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmployeeType")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("CompanyEmployees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Age = 32,
                            CompanyId = 1,
                            Email = "rodrigovalladares1@gmail.com",
                            EmployeeType = 1,
                            FirstName = "Henry",
                            LastName = "Walas"
                        },
                        new
                        {
                            Id = 2,
                            Age = 32,
                            CompanyId = 1,
                            Email = "rodrigovalladares1@gmail.com",
                            EmployeeType = 2,
                            FirstName = "Brook",
                            LastName = "Bane"
                        },
                        new
                        {
                            Id = 3,
                            Age = 32,
                            CompanyId = 2,
                            Email = "rodrigovalladares1@gmail.com",
                            EmployeeType = 1,
                            FirstName = "Harry",
                            LastName = "Stevens"
                        },
                        new
                        {
                            Id = 4,
                            Age = 32,
                            CompanyId = 3,
                            Email = "rodrigovalladares1@gmail.com",
                            EmployeeType = 1,
                            FirstName = "Alfonse",
                            LastName = "Elric"
                        });
                });

            modelBuilder.Entity("HireManagment.Domain.Opening", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CompanyEmployeeId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateExpiration")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OpeningType")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyEmployeeId");

                    b.ToTable("Openings");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CompanyEmployeeId = 1,
                            DateCreated = new DateTime(2022, 9, 5, 13, 8, 43, 212, DateTimeKind.Local).AddTicks(4332),
                            DateExpiration = new DateTime(2022, 9, 15, 13, 8, 43, 212, DateTimeKind.Local).AddTicks(4344),
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam.",
                            OpeningType = 1,
                            Title = "New Vancancy"
                        },
                        new
                        {
                            Id = 2,
                            CompanyEmployeeId = 3,
                            DateCreated = new DateTime(2022, 9, 5, 13, 8, 43, 212, DateTimeKind.Local).AddTicks(4352),
                            DateExpiration = new DateTime(2022, 9, 30, 13, 8, 43, 212, DateTimeKind.Local).AddTicks(4352),
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam.",
                            OpeningType = 1,
                            Title = "New Vancancy 2"
                        });
                });

            modelBuilder.Entity("HireManagment.Domain.OpeningApplication", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CandidateId")
                        .HasColumnType("int");

                    b.Property<int>("CompanyEmployeeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateApplication")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CandidateId");

                    b.HasIndex("CompanyEmployeeId");

                    b.ToTable("OpeningApplications");
                });

            modelBuilder.Entity("HireManagment.Domain.Company", b =>
                {
                    b.HasOne("HireManagment.Domain.AdminApi", "Admin")
                        .WithMany()
                        .HasForeignKey("AdminId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Admin");
                });

            modelBuilder.Entity("HireManagment.Domain.CompanyEmployee", b =>
                {
                    b.HasOne("HireManagment.Domain.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("HireManagment.Domain.Opening", b =>
                {
                    b.HasOne("HireManagment.Domain.CompanyEmployee", "CompanyEmployee")
                        .WithMany()
                        .HasForeignKey("CompanyEmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CompanyEmployee");
                });

            modelBuilder.Entity("HireManagment.Domain.OpeningApplication", b =>
                {
                    b.HasOne("HireManagment.Domain.Candidate", "Candidate")
                        .WithMany()
                        .HasForeignKey("CandidateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HireManagment.Domain.CompanyEmployee", "CompanyEmployee")
                        .WithMany()
                        .HasForeignKey("CompanyEmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Candidate");

                    b.Navigation("CompanyEmployee");
                });
#pragma warning restore 612, 618
        }
    }
}
