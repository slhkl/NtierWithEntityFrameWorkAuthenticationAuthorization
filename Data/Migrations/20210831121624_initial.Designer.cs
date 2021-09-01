﻿// <auto-generated />
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(MasterContext))]
    [Migration("20210831121624_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.9");

            modelBuilder.Entity("Data.Models.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("BookName")
                        .HasColumnType("text");

                    b.Property<string>("BookShelf")
                        .HasColumnType("text");

                    b.Property<int>("WriterId")
                        .HasColumnType("int");

                    b.HasKey("BookId");

                    b.HasIndex("WriterId");

                    b.ToTable("Book");
                });

            modelBuilder.Entity("Data.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.HasKey("UserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Data.Models.Writer", b =>
                {
                    b.Property<int>("WriterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("WriterName")
                        .HasColumnType("text");

                    b.HasKey("WriterId");

                    b.ToTable("Writer");
                });

            modelBuilder.Entity("Data.Models.Book", b =>
                {
                    b.HasOne("Data.Models.Writer", "Writer")
                        .WithMany()
                        .HasForeignKey("WriterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Writer");
                });
#pragma warning restore 612, 618
        }
    }
}
