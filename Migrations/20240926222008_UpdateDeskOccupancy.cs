using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeskManagerApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDeskOccupancy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeskNumber",
                table: "DeskOccupancies");

            migrationBuilder.RenameColumn(
                name: "OccupiedAt",
                table: "DeskOccupancies",
                newName: "ReservationDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReservationDate",
                table: "DeskOccupancies",
                newName: "OccupiedAt");

            migrationBuilder.AddColumn<string>(
                name: "DeskNumber",
                table: "DeskOccupancies",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
