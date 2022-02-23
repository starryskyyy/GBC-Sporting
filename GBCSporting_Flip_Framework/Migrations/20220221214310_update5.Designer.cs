﻿// <auto-generated />
using System;
using GBCSporting_Flip_Framework.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GBCSporting_Flip_Framework.Migrations
{
    [DbContext(typeof(GBCSportingContext))]
    [Migration("20220221214310_update5")]
    partial class update5
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GBCSporting_Flip_Framework.Models.Country", b =>
                {
                    b.Property<int>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CountryId"), 1L, 1);

                    b.Property<string>("CountryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CountryId");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            CountryId = 1,
                            CountryName = "Austria"
                        },
                        new
                        {
                            CountryId = 2,
                            CountryName = "Canada"
                        },
                        new
                        {
                            CountryId = 3,
                            CountryName = "France"
                        },
                        new
                        {
                            CountryId = 4,
                            CountryName = "Germany"
                        },
                        new
                        {
                            CountryId = 5,
                            CountryName = "India"
                        },
                        new
                        {
                            CountryId = 6,
                            CountryName = "Iran"
                        },
                        new
                        {
                            CountryId = 7,
                            CountryName = "Italy"
                        },
                        new
                        {
                            CountryId = 8,
                            CountryName = "Lithuania"
                        },
                        new
                        {
                            CountryId = 9,
                            CountryName = "Mexico"
                        },
                        new
                        {
                            CountryId = 10,
                            CountryName = "New Zealand"
                        },
                        new
                        {
                            CountryId = 11,
                            CountryName = "Russia"
                        },
                        new
                        {
                            CountryId = 12,
                            CountryName = "Singapore"
                        },
                        new
                        {
                            CountryId = 13,
                            CountryName = "Turkey"
                        },
                        new
                        {
                            CountryId = 14,
                            CountryName = "United States"
                        },
                        new
                        {
                            CountryId = 15,
                            CountryName = "Vietnam"
                        });
                });

            modelBuilder.Entity("GBCSporting_Flip_Framework.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("CustEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustPhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerId");

                    b.HasIndex("CountryId");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            CustomerId = 1,
                            Address = "67 Tikhvinskaya street",
                            City = "Moscow",
                            CountryId = 11,
                            CustEmail = "elizaveta.vygovskaia@georgebrown.ca",
                            CustPhone = "+7(943)234-1234",
                            FirstName = "Elizaveta",
                            LastName = "Vygovskaia",
                            PostalCode = "140002",
                            State = "Moskovskaya oblast"
                        },
                        new
                        {
                            CustomerId = 2,
                            Address = "3852 Eglinton Avenue",
                            City = "Toronto",
                            CountryId = 2,
                            CustEmail = "jordon.jensen@georgebrown.ca",
                            CustPhone = "+1(506)312-9547",
                            FirstName = "Jordon",
                            LastName = "Jensen",
                            PostalCode = "M4P 1A6",
                            State = "Ontario"
                        },
                        new
                        {
                            CustomerId = 3,
                            Address = "532 Hoang Hoa Tham",
                            City = "Ha Noi",
                            CountryId = 15,
                            CustEmail = "phuong.hoang2@georgebrown.ca",
                            CustPhone = "+94(564)123-1234",
                            FirstName = "Phuong",
                            LastName = "Hoang",
                            PostalCode = "901011",
                            State = "Hanoi"
                        },
                        new
                        {
                            CustomerId = 4,
                            Address = "3422 Bay Street",
                            City = "Toronto",
                            CountryId = 2,
                            CustEmail = "truongthi.bui@georgebrown.ca",
                            CustPhone = "+1(647)893-3833",
                            FirstName = "Truong",
                            LastName = "Thi Bui",
                            PostalCode = "M5J 2R8",
                            State = "Ontario"
                        });
                });

            modelBuilder.Entity("GBCSporting_Flip_Framework.Models.Incident", b =>
                {
                    b.Property<int>("IncidentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IncidentId"), 1L, 1);

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateClosed")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateOpened")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int?>("TechnicianId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IncidentId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ProductId");

                    b.HasIndex("TechnicianId");

                    b.ToTable("Incidents");

                    b.HasData(
                        new
                        {
                            IncidentId = 1,
                            CustomerId = 2,
                            DateClosed = new DateTime(2022, 2, 21, 16, 43, 9, 982, DateTimeKind.Local).AddTicks(8447),
                            Description = "When trying to install getting error 123",
                            ProductId = 2,
                            TechnicianId = 1,
                            Title = "Could not install"
                        },
                        new
                        {
                            IncidentId = 2,
                            CustomerId = 1,
                            DateClosed = new DateTime(2022, 2, 21, 16, 43, 9, 982, DateTimeKind.Local).AddTicks(8450),
                            Description = "Program crash almost instantly when I open it",
                            ProductId = 1,
                            TechnicianId = 2,
                            Title = "Error launching program"
                        });
                });

            modelBuilder.Entity("GBCSporting_Flip_Framework.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"), 1L, 1);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ReleaseDate")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<double?>("YearlyPrice")
                        .IsRequired()
                        .HasColumnType("float");

                    b.HasKey("ProductId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            Code = "H332K",
                            Name = "Draft Manager 1.0",
                            ReleaseDate = new DateTime(2022, 2, 21, 16, 43, 9, 982, DateTimeKind.Local).AddTicks(8433),
                            YearlyPrice = 6.6500000000000004
                        },
                        new
                        {
                            ProductId = 2,
                            Code = "TVE32",
                            Name = "League Scheduler 1.0",
                            ReleaseDate = new DateTime(2022, 2, 21, 16, 43, 9, 982, DateTimeKind.Local).AddTicks(8436),
                            YearlyPrice = 5.54
                        });
                });

            modelBuilder.Entity("GBCSporting_Flip_Framework.Models.Technician", b =>
                {
                    b.Property<int>("TechnicianId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TechnicianId"), 1L, 1);

                    b.Property<string>("TechEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TechName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TechPhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TechnicianId");

                    b.ToTable("Technicians");

                    b.HasData(
                        new
                        {
                            TechnicianId = 1,
                            TechEmail = "sam.brooks@gmail.com",
                            TechName = "Samuel Brooks",
                            TechPhone = "+1(342)234-4223"
                        },
                        new
                        {
                            TechnicianId = 2,
                            TechEmail = "r.pharo@gmail.com",
                            TechName = "Richard Pharo",
                            TechPhone = "+1(542)112-4367"
                        });
                });

            modelBuilder.Entity("GBCSporting_Flip_Framework.Models.Customer", b =>
                {
                    b.HasOne("GBCSporting_Flip_Framework.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("GBCSporting_Flip_Framework.Models.Incident", b =>
                {
                    b.HasOne("GBCSporting_Flip_Framework.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GBCSporting_Flip_Framework.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GBCSporting_Flip_Framework.Models.Technician", "Technician")
                        .WithMany()
                        .HasForeignKey("TechnicianId");

                    b.Navigation("Customer");

                    b.Navigation("Product");

                    b.Navigation("Technician");
                });
#pragma warning restore 612, 618
        }
    }
}
