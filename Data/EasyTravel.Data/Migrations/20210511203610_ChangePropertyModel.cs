using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyTravel.Data.Migrations
{
    public partial class ChangePropertyModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Capacity",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "SummerPrice",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "WinterPrice",
                table: "Properties");

            migrationBuilder.AddColumn<string>(
                name: "PriceSummerr",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PriceWinter",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PriceSummerr",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "PriceWinter",
                table: "Properties");

            migrationBuilder.AddColumn<int>(
                name: "Capacity",
                table: "Properties",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "SummerPrice",
                table: "Properties",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "WinterPrice",
                table: "Properties",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
