using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaSystem.Migrations
{
    public partial class ReservationsUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "reservation_completed",
                table: "reservations",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "reservation_completed",
                table: "reservations");
        }
    }
}
