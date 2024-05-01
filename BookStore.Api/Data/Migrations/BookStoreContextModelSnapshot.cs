﻿// <auto-generated />
using System;
using BookStore.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookStore.Api.Data.Migrations
{
    [DbContext(typeof(BookStoreContext))]
    partial class BookStoreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("BookStore.Api.Entities.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("MiddleName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Prefix")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Orson",
                            LastName = "Card",
                            MiddleName = "Scott"
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "John",
                            LastName = "Tolkien",
                            MiddleName = "Ronald Reuei"
                        },
                        new
                        {
                            Id = 3,
                            FirstName = "Herman",
                            LastName = "Melville"
                        },
                        new
                        {
                            Id = 4,
                            FirstName = "Frank",
                            LastName = "Herbert"
                        },
                        new
                        {
                            Id = 5,
                            LastName = "Seuss",
                            Prefix = "Dr."
                        },
                        new
                        {
                            Id = 6,
                            FirstName = "J.",
                            LastName = "Rowling",
                            MiddleName = "K."
                        },
                        new
                        {
                            Id = 7,
                            FirstName = "Stephen",
                            LastName = "King"
                        },
                        new
                        {
                            Id = 8,
                            FirstName = "John",
                            LastName = "Green"
                        },
                        new
                        {
                            Id = 9,
                            FirstName = "R.",
                            LastName = "Stine",
                            MiddleName = "L."
                        },
                        new
                        {
                            Id = 10,
                            FirstName = "Jane",
                            LastName = "Austen"
                        });
                });

            modelBuilder.Entity("BookStore.Api.Entities.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AuthorId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GenreId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateOnly>("PublishDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("GenreId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorId = 1,
                            GenreId = 10,
                            Name = "Ender's Game",
                            PublishDate = new DateOnly(1985, 1, 15)
                        },
                        new
                        {
                            Id = 2,
                            AuthorId = 2,
                            GenreId = 8,
                            Name = "The Hobbit",
                            PublishDate = new DateOnly(1937, 9, 21)
                        },
                        new
                        {
                            Id = 3,
                            AuthorId = 3,
                            GenreId = 7,
                            Name = "Moby-Dick",
                            PublishDate = new DateOnly(1851, 10, 18)
                        },
                        new
                        {
                            Id = 4,
                            AuthorId = 4,
                            GenreId = 10,
                            Name = "Dune",
                            PublishDate = new DateOnly(1965, 8, 17)
                        });
                });

            modelBuilder.Entity("BookStore.Api.Entities.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Fiction"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Non-Fiction"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Biography"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Autobiography"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Children's Literature"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Mystery"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Adventure Fiction"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Fantasy Fiction"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Historical Fiction"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Science Fiction"
                        });
                });

            modelBuilder.Entity("BookStore.Api.Entities.Book", b =>
                {
                    b.HasOne("BookStore.Api.Entities.Author", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookStore.Api.Entities.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Genre");
                });
#pragma warning restore 612, 618
        }
    }
}
