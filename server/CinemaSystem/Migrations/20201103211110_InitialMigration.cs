using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace CinemaSystem.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "hales",
                columns: table => new {
                    hall_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    hall_name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("hales_pkey", x => x.hall_id);
                });

            migrationBuilder.CreateTable(
                name: "movies",
                columns: table => new {
                    movie_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    movie_title = table.Column<string>(nullable: false),
                    movie_duration = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("movies_pkey", x => x.movie_id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new {
                    user_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_login = table.Column<string>(nullable: false),
                    user_password = table.Column<string>(nullable: false),
                    user_type = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("users_pkey", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "showings",
                columns: table => new {
                    showing_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    showing_movie_id = table.Column<int>(nullable: false),
                    showing_hall_id = table.Column<int>(nullable: false),
                    showing_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("showings_pkey", x => x.showing_id);
                    table.ForeignKey(
                        name: "fk_showings_hall_id",
                        column: x => x.showing_hall_id,
                        principalTable: "hales",
                        principalColumn: "hall_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_showings_movie_id",
                        column: x => x.showing_movie_id,
                        principalTable: "movies",
                        principalColumn: "movie_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "reservations",
                columns: table => new {
                    reservation_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    reservation_showing_id = table.Column<int>(nullable: false),
                    reservation_user_id = table.Column<int>(nullable: false),
                    reservation_seat = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("reservations_pkey", x => x.reservation_id);
                    table.ForeignKey(
                        name: "fk_reservations_showing_id",
                        column: x => x.reservation_showing_id,
                        principalTable: "reservations",
                        principalColumn: "reservation_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_reservations_user_id",
                        column: x => x.reservation_user_id,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "movies",
                columns: new[] { "movie_id", "movie_duration", "movie_title" },
                values: new object[,]
                {
                    { 1, 120, "Avatar" },
                    { 2, 200, "Transformers" },
                    { 3, 220, "Spiderman: Homecoming" },
                    { 4, 280, "Once upon a time in Hollywood" },
                    { 5, 200, "Django" },
                    { 6, 90, "El camino" },
                    { 7, 120, "Joker" }
                });

            migrationBuilder.CreateIndex(
                name: "fki_reservations_showing_id",
                table: "reservations",
                column: "reservation_showing_id");

            migrationBuilder.CreateIndex(
                name: "IX_reservations_reservation_user_id",
                table: "reservations",
                column: "reservation_user_id");

            migrationBuilder.CreateIndex(
                name: "fki_fk_showings_hall_id",
                table: "showings",
                column: "showing_hall_id");

            migrationBuilder.CreateIndex(
                name: "fki_fk_showings_movie_id",
                table: "showings",
                column: "showing_movie_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "reservations");

            migrationBuilder.DropTable(
                name: "showings");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "hales");

            migrationBuilder.DropTable(
                name: "movies");
        }
    }
}
