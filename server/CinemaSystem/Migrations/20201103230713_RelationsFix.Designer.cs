﻿// <auto-generated />
using System;
using CinemaSystem.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace CinemaSystem.Migrations
{
    [DbContext(typeof(CinemaDbContext))]
    [Migration("20201103230713_RelationsFix")]
    partial class RelationsFix
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("CinemaSystem.Database.Models.Hall", b =>
                {
                    b.Property<int>("HallId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("hall_id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("HallName")
                        .HasColumnName("hall_name")
                        .HasColumnType("text");

                    b.HasKey("HallId")
                        .HasName("hales_pkey");

                    b.ToTable("hales");
                });

            modelBuilder.Entity("CinemaSystem.Database.Models.Movie", b =>
                {
                    b.Property<int>("MovieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("movie_id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("MovieDuration")
                        .HasColumnName("movie_duration")
                        .HasColumnType("integer");

                    b.Property<string>("MovieTitle")
                        .IsRequired()
                        .HasColumnName("movie_title")
                        .HasColumnType("text");

                    b.HasKey("MovieId")
                        .HasName("movies_pkey");

                    b.ToTable("movies");

                    b.HasData(
                        new
                        {
                            MovieId = 1,
                            MovieDuration = 120,
                            MovieTitle = "Avatar"
                        },
                        new
                        {
                            MovieId = 2,
                            MovieDuration = 200,
                            MovieTitle = "Transformers"
                        },
                        new
                        {
                            MovieId = 3,
                            MovieDuration = 220,
                            MovieTitle = "Spiderman: Homecoming"
                        },
                        new
                        {
                            MovieId = 4,
                            MovieDuration = 280,
                            MovieTitle = "Once upon a time in Hollywood"
                        },
                        new
                        {
                            MovieId = 5,
                            MovieDuration = 200,
                            MovieTitle = "Django"
                        },
                        new
                        {
                            MovieId = 6,
                            MovieDuration = 90,
                            MovieTitle = "El camino"
                        },
                        new
                        {
                            MovieId = 7,
                            MovieDuration = 120,
                            MovieTitle = "Joker"
                        });
                });

            modelBuilder.Entity("CinemaSystem.Database.Models.Reservations", b =>
                {
                    b.Property<int>("ReservationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("reservation_id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("ReservationSeat")
                        .HasColumnName("reservation_seat")
                        .HasColumnType("integer");

                    b.Property<int>("ReservationShowingId")
                        .HasColumnName("reservation_showing_id")
                        .HasColumnType("integer");

                    b.Property<int>("ReservationUserId")
                        .HasColumnName("reservation_user_id")
                        .HasColumnType("integer");

                    b.HasKey("ReservationId")
                        .HasName("reservations_pkey");

                    b.HasIndex("ReservationShowingId")
                        .HasName("fki_reservations_showing_id");

                    b.HasIndex("ReservationUserId");

                    b.ToTable("reservations");
                });

            modelBuilder.Entity("CinemaSystem.Database.Models.Showing", b =>
                {
                    b.Property<int>("ShowingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("showing_id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("ShowingDate")
                        .HasColumnName("showing_date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("ShowingHallId")
                        .HasColumnName("showing_hall_id")
                        .HasColumnType("integer");

                    b.Property<int>("ShowingMovieId")
                        .HasColumnName("showing_movie_id")
                        .HasColumnType("integer");

                    b.HasKey("ShowingId")
                        .HasName("showings_pkey");

                    b.HasIndex("ShowingHallId")
                        .HasName("fki_fk_showings_hall_id");

                    b.HasIndex("ShowingMovieId")
                        .HasName("fki_fk_showings_movie_id");

                    b.ToTable("showings");
                });

            modelBuilder.Entity("CinemaSystem.Database.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("user_id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("UserLogin")
                        .IsRequired()
                        .HasColumnName("user_login")
                        .HasColumnType("text");

                    b.Property<string>("UserPassword")
                        .IsRequired()
                        .HasColumnName("user_password")
                        .HasColumnType("text");

                    b.Property<string>("UserType")
                        .IsRequired()
                        .HasColumnName("user_type")
                        .HasColumnType("text");

                    b.HasKey("UserId")
                        .HasName("users_pkey");

                    b.ToTable("users");
                });

            modelBuilder.Entity("CinemaSystem.Database.Models.Reservations", b =>
                {
                    b.HasOne("CinemaSystem.Database.Models.Showing", "ReservationShowing")
                        .WithMany("ShowingReservations")
                        .HasForeignKey("ReservationShowingId")
                        .HasConstraintName("fk_reservations_showing_id")
                        .IsRequired();

                    b.HasOne("CinemaSystem.Database.Models.User", "ReservationUser")
                        .WithMany("Reservations")
                        .HasForeignKey("ReservationUserId")
                        .HasConstraintName("fk_reservations_user_id")
                        .IsRequired();
                });

            modelBuilder.Entity("CinemaSystem.Database.Models.Showing", b =>
                {
                    b.HasOne("CinemaSystem.Database.Models.Hall", "ShowingHall")
                        .WithMany("Showings")
                        .HasForeignKey("ShowingHallId")
                        .HasConstraintName("fk_showings_hall_id")
                        .IsRequired();

                    b.HasOne("CinemaSystem.Database.Models.Movie", "ShowingMovie")
                        .WithMany("Showings")
                        .HasForeignKey("ShowingMovieId")
                        .HasConstraintName("fk_showings_movie_id")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
