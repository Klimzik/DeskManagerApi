using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeskManagerApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDeskOccupancyV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DeskNumber",
                table: "DeskOccupancies",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeskNumber",
                table: "DeskOccupancies");
        }
    }
}
