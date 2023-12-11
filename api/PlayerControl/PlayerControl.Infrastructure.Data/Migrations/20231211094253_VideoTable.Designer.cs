﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PlayerControl.Infrastructure.Data.EntityFramework.Context;

#nullable disable

namespace PlayerControl.Infrastructure.Data.Migrations
{
    [DbContext(typeof(EntityFrameworkDbContext))]
    [Migration("20231211094253_VideoTable")]
    partial class VideoTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PlayerControl.Domain.Entities.Categories.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id_category");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean")
                        .HasColumnName("is_active");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("category", (string)null);
                });

            modelBuilder.Entity("PlayerControl.Domain.Entities.Genres.Genre", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id_genre");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_at");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean")
                        .HasColumnName("is_active");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("genre", (string)null);
                });

            modelBuilder.Entity("PlayerControl.Domain.Entities.Genres.GenreCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id_genre_category");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uuid")
                        .HasColumnName("id_category");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_at");

                    b.Property<Guid>("GenreId")
                        .HasColumnType("uuid")
                        .HasColumnName("id_genre");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("GenreId");

                    b.ToTable("genre_category", (string)null);
                });

            modelBuilder.Entity("PlayerControl.Domain.Entities.Videos.Video", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id_video");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("character varying(2000)")
                        .HasColumnName("is_active");

                    b.Property<int>("Duration")
                        .HasColumnType("integer")
                        .HasColumnName("duration");

                    b.Property<int>("Rating")
                        .HasColumnType("integer")
                        .HasColumnName("rating");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("title");

                    b.Property<int>("Year")
                        .HasColumnType("integer")
                        .HasColumnName("year");

                    b.HasKey("Id");

                    b.ToTable("video", (string)null);
                });

            modelBuilder.Entity("PlayerControl.Domain.Entities.Videos.VideoCategories", b =>
                {
                    b.Property<Guid>("VideoId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uuid");

                    b.HasKey("VideoId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("VideoCategories");
                });

            modelBuilder.Entity("PlayerControl.Domain.Entities.Videos.VideoGenres", b =>
                {
                    b.Property<Guid>("VideoId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("GenreId")
                        .HasColumnType("uuid");

                    b.HasKey("VideoId", "GenreId");

                    b.HasIndex("GenreId");

                    b.ToTable("VideoGenres");
                });

            modelBuilder.Entity("PlayerControl.Domain.Entities.Genres.GenreCategory", b =>
                {
                    b.HasOne("PlayerControl.Domain.Entities.Categories.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PlayerControl.Domain.Entities.Genres.Genre", "Genre")
                        .WithMany("GenreCategories")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("PlayerControl.Domain.Entities.Videos.Video", b =>
                {
                    b.OwnsOne("PlayerControl.Domain.Entities.Videos.Media", "Media", b1 =>
                        {
                            b1.Property<Guid>("VideoId")
                                .HasColumnType("uuid");

                            b1.Property<string>("EncodedPath")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("encoded_path");

                            b1.Property<string>("FilePath")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("file_path");

                            b1.Property<int>("Status")
                                .HasColumnType("integer");

                            b1.HasKey("VideoId");

                            b1.ToTable("video");

                            b1.WithOwner()
                                .HasForeignKey("VideoId");
                        });

                    b.OwnsOne("PlayerControl.Domain.Entities.Videos.ValueObjects.Image", "Image", b1 =>
                        {
                            b1.Property<Guid>("VideoId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Path")
                                .HasColumnType("text")
                                .HasColumnName("image_path");

                            b1.HasKey("VideoId");

                            b1.ToTable("video");

                            b1.WithOwner()
                                .HasForeignKey("VideoId");
                        });

                    b.Navigation("Image");

                    b.Navigation("Media");
                });

            modelBuilder.Entity("PlayerControl.Domain.Entities.Videos.VideoCategories", b =>
                {
                    b.HasOne("PlayerControl.Domain.Entities.Categories.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PlayerControl.Domain.Entities.Videos.Video", "Video")
                        .WithMany()
                        .HasForeignKey("VideoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Video");
                });

            modelBuilder.Entity("PlayerControl.Domain.Entities.Videos.VideoGenres", b =>
                {
                    b.HasOne("PlayerControl.Domain.Entities.Genres.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PlayerControl.Domain.Entities.Videos.Video", "Video")
                        .WithMany()
                        .HasForeignKey("VideoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");

                    b.Navigation("Video");
                });

            modelBuilder.Entity("PlayerControl.Domain.Entities.Genres.Genre", b =>
                {
                    b.Navigation("GenreCategories");
                });
#pragma warning restore 612, 618
        }
    }
}
