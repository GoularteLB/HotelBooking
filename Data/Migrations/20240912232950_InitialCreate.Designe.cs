using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateDesigne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price_Currency",
                table: "Rooms",
                newName: "Price_currency");

            migrationBuilder.RenameColumn(
                name: "PlaceAt",
                table: "Bookings",
                newName: "PlaceAt");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price_Value",
                table: "Rooms",
                type: "decimal(18,5)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price_currency",
                table: "Rooms",
                newName: "Price_Currency");

            migrationBuilder.RenameColumn(
                name: "PlaceAt",
                table: "Bookings",
                newName: "PlaceAt");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price_Value",
                table: "Rooms",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,5)");
        }
    }
}
