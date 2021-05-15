using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyTravel.Data.Migrations
{
    public partial class ChangeContactFormModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_ContactForms_ContactFormId",
                table: "Properties");

            migrationBuilder.DropIndex(
                name: "IX_Properties_ContactFormId",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "ContactFormId",
                table: "Properties");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ContactFormId",
                table: "Properties",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Properties_ContactFormId",
                table: "Properties",
                column: "ContactFormId");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_ContactForms_ContactFormId",
                table: "Properties",
                column: "ContactFormId",
                principalTable: "ContactForms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
