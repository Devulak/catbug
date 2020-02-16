using Microsoft.EntityFrameworkCore.Migrations;

namespace catbug.Data.Migrations
{
    public partial class ChangeCategoriesToCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Categories",
                table: "Entries");

            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "Entries",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Entries");

            migrationBuilder.AddColumn<int>(
                name: "Categories",
                table: "Entries",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
