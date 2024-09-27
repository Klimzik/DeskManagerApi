using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeskManagerApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDeskOccupancyV3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsOccupated",
                table: "DeskOccupancies",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsOccupated",
                table: "DeskOccupancies");
        }
    }
}
