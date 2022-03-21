﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using hotel.Models;

namespace hotel.Migrations
{
    [DbContext(typeof(HotelPrContext))]
    [Migration("20220318013821_v116")]
    partial class v116
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("hotel.Models.Gost", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .UseIdentityColumn();

                    b.Property<int?>("HotelID")
                        .HasColumnType("int");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)")
                        .HasColumnName("Ime");

                    b.Property<int>("LicnaKarta")
                        .HasColumnType("int")
                        .HasColumnName("LicnaKarta");

                    b.Property<string>("Prezime")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("Prezime");

                    b.HasKey("ID");

                    b.HasIndex("HotelID");

                    b.ToTable("Gost");
                });

            modelBuilder.Entity("hotel.Models.GostuSobi", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .UseIdentityColumn();

                    b.Property<string>("DatumPrijaljivanja")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("DatumPrijaljivanja");

                    b.Property<int?>("GostID")
                        .HasColumnType("int");

                    b.Property<int?>("SobaID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("GostID");

                    b.HasIndex("SobaID");

                    b.ToTable("GostuSobi");
                });

            modelBuilder.Entity("hotel.Models.Hotel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .UseIdentityColumn();

                    b.Property<string>("Adresa")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("Adresa");

                    b.Property<int>("BrojSoba")
                        .HasMaxLength(255)
                        .HasColumnType("int")
                        .HasColumnName("BrojSoba");

                    b.Property<string>("Grad")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("Grad");

                    b.Property<string>("Naziv")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("Naziv");

                    b.HasKey("ID");

                    b.ToTable("Hotel");
                });

            modelBuilder.Entity("hotel.Models.Racun", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .UseIdentityColumn();

                    b.Property<int?>("HotelID")
                        .HasColumnType("int");

                    b.Property<int>("KonacnaCena")
                        .HasColumnType("int")
                        .HasColumnName("KonacnaCena");

                    b.Property<int?>("sobaID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("HotelID");

                    b.HasIndex("sobaID");

                    b.ToTable("Racun");
                });

            modelBuilder.Entity("hotel.Models.Soba", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .UseIdentityColumn();

                    b.Property<int>("BrojDana")
                        .HasColumnType("int")
                        .HasColumnName("BrojDana");

                    b.Property<int>("BrojSobe")
                        .HasColumnType("int")
                        .HasColumnName("BrojSobe");

                    b.Property<int?>("HotelID")
                        .HasColumnType("int");

                    b.Property<bool>("Zauzeta")
                        .HasColumnType("bit")
                        .HasColumnName("Zauzeta");

                    b.Property<string>("tip")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("TipSobe");

                    b.HasKey("ID");

                    b.HasIndex("HotelID");

                    b.ToTable("Soba");
                });

            modelBuilder.Entity("hotel.Models.Gost", b =>
                {
                    b.HasOne("hotel.Models.Hotel", "Hotel")
                        .WithMany("Gosti")
                        .HasForeignKey("HotelID");

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("hotel.Models.GostuSobi", b =>
                {
                    b.HasOne("hotel.Models.Gost", "Gost")
                        .WithMany()
                        .HasForeignKey("GostID");

                    b.HasOne("hotel.Models.Soba", "Soba")
                        .WithMany()
                        .HasForeignKey("SobaID");

                    b.Navigation("Gost");

                    b.Navigation("Soba");
                });

            modelBuilder.Entity("hotel.Models.Racun", b =>
                {
                    b.HasOne("hotel.Models.Hotel", "Hotel")
                        .WithMany("Racuni")
                        .HasForeignKey("HotelID");

                    b.HasOne("hotel.Models.Soba", "soba")
                        .WithMany()
                        .HasForeignKey("sobaID");

                    b.Navigation("Hotel");

                    b.Navigation("soba");
                });

            modelBuilder.Entity("hotel.Models.Soba", b =>
                {
                    b.HasOne("hotel.Models.Hotel", "Hotel")
                        .WithMany("Sobe")
                        .HasForeignKey("HotelID");

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("hotel.Models.Hotel", b =>
                {
                    b.Navigation("Gosti");

                    b.Navigation("Racuni");

                    b.Navigation("Sobe");
                });
#pragma warning restore 612, 618
        }
    }
}
