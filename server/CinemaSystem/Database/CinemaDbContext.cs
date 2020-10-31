using System;
using CinemaSystem.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace CinemaSystem.Database
{
    public partial class CinemaDbContext : DbContext
    {
        public CinemaDbContext()
        {
        }

        public CinemaDbContext(DbContextOptions<CinemaDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Hall> Hales { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Reservations> Reservations { get; set; }
        public virtual DbSet<Showing> Showings { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseIdentityColumns();
            modelBuilder.Entity<Hall>(entity =>
            {
                entity.HasKey(e => e.HallId)
                    .HasName("hales_pkey");

                entity.ToTable("hales");

                entity.Property(e => e.HallId)
                    .HasColumnName("hall_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.HallName).HasColumnName("hall_name");
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.HasKey(e => e.MovieId)
                    .HasName("movies_pkey");

                entity.ToTable("movies");

                entity.Property(e => e.MovieId)
                    .HasColumnName("movie_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.MovieDuration)
                    .IsRequired()
                    .HasColumnName("movie_duration");

                entity.Property(e => e.MovieTitle)
                    .IsRequired()
                    .HasColumnName("movie_title");
            });

            modelBuilder.Entity<Reservations>(entity =>
            {
                entity.HasKey(e => e.ReservationId)
                    .HasName("reservations_pkey");

                entity.ToTable("reservations");

                entity.HasIndex(e => e.ReservationShowingId)
                    .HasName("fki_reservations_showing_id");

                entity.Property(e => e.ReservationId)
                    .HasColumnName("reservation_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ReservationSeat).HasColumnName("reservation_seat");

                entity.Property(e => e.ReservationShowingId).HasColumnName("reservation_showing_id");

                entity.Property(e => e.ReservationUserId).HasColumnName("reservation_user_id");

                entity.HasOne(d => d.ReservationShowing)
                    .WithMany(p => p.InverseReservationShowing)
                    .HasForeignKey(d => d.ReservationShowingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_reservations_showing_id");

                entity.HasOne(d => d.ReservationUser)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.ReservationUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_reservations_user_id");
            });

            modelBuilder.Entity<Showing>(entity =>
            {
                entity.HasKey(e => e.ShowingId)
                    .HasName("showings_pkey");

                entity.ToTable("showings");

                entity.HasIndex(e => e.ShowingHallId)
                    .HasName("fki_fk_showings_hall_id");

                entity.HasIndex(e => e.ShowingMovieId)
                    .HasName("fki_fk_showings_movie_id");

                entity.Property(e => e.ShowingId)
                    .HasColumnName("showing_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ShowingDate)
                    .HasColumnName("showing_date")
                    .HasColumnType("timestamp with time zone");

                entity.Property(e => e.ShowingHallId).HasColumnName("showing_hall_id");

                entity.Property(e => e.ShowingMovieId).HasColumnName("showing_movie_id");

                entity.HasOne(d => d.ShowingHall)
                    .WithMany(p => p.Showings)
                    .HasForeignKey(d => d.ShowingHallId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_showings_hall_id");

                entity.HasOne(d => d.ShowingMovie)
                    .WithMany(p => p.Showings)
                    .HasForeignKey(d => d.ShowingMovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_showings_movie_id");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("users_pkey");

                entity.ToTable("users");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.UserLogin)
                    .IsRequired()
                    .HasColumnName("user_login");

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasColumnName("user_password");

                entity.Property(e => e.UserType)
                    .IsRequired()
                    .HasColumnName("user_type");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
