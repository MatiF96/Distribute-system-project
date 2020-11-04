using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaSystem.Migrations
{
    public partial class RelationsFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_reservations_showing_id",
                table: "reservations");

            migrationBuilder.AddForeignKey(
                name: "fk_reservations_showing_id",
                table: "reservations",
                column: "reservation_showing_id",
                principalTable: "showings",
                principalColumn: "showing_id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_reservations_showing_id",
                table: "reservations");

            migrationBuilder.AddForeignKey(
                name: "fk_reservations_showing_id",
                table: "reservations",
                column: "reservation_showing_id",
                principalTable: "reservations",
                principalColumn: "reservation_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
