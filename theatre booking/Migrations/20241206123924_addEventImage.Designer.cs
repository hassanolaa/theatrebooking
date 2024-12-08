﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using theatre_booking.DataAccess;

#nullable disable

namespace theatre_booking.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241206123924_addEventImage")]
    partial class addEventImage
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("theatre_booking.DataAccess.models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EventName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LatLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LongLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TheatreId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("theatre_booking.DataAccess.models.Seat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsBooked")
                        .HasColumnType("bit");

                    b.Property<int?>("Seat")
                        .HasColumnType("int");

                    b.Property<string>("Seat_number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TheatreId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Seat");

                    b.HasIndex("TheatreId");

                    b.HasIndex("UserId");

                    b.ToTable("Seats");
                });

            modelBuilder.Entity("theatre_booking.DataAccess.models.Theatre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<int?>("EventId")
                        .HasColumnType("int");

                    b.Property<string>("TheatreName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EventId")
                        .IsUnique()
                        .HasFilter("[EventId] IS NOT NULL");

                    b.ToTable("Theatres");
                });

            modelBuilder.Entity("theatre_booking.DataAccess.models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fullname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsMan")
                        .HasColumnType("bit");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("theatre_booking.DataAccess.models.Seat", b =>
                {
                    b.HasOne("theatre_booking.DataAccess.models.User", null)
                        .WithMany("Seats")
                        .HasForeignKey("Seat");

                    b.HasOne("theatre_booking.DataAccess.models.Theatre", "theatre")
                        .WithMany("Seats")
                        .HasForeignKey("TheatreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("theatre_booking.DataAccess.models.User", "user")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("theatre");

                    b.Navigation("user");
                });

            modelBuilder.Entity("theatre_booking.DataAccess.models.Theatre", b =>
                {
                    b.HasOne("theatre_booking.DataAccess.models.Event", "Event")
                        .WithOne("Theatre")
                        .HasForeignKey("theatre_booking.DataAccess.models.Theatre", "EventId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Event");
                });

            modelBuilder.Entity("theatre_booking.DataAccess.models.Event", b =>
                {
                    b.Navigation("Theatre");
                });

            modelBuilder.Entity("theatre_booking.DataAccess.models.Theatre", b =>
                {
                    b.Navigation("Seats");
                });

            modelBuilder.Entity("theatre_booking.DataAccess.models.User", b =>
                {
                    b.Navigation("Seats");
                });
#pragma warning restore 612, 618
        }
    }
}
