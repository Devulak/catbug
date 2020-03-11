using Microsoft.EntityFrameworkCore.Migrations;

namespace catbug.Data.Migrations
{
    public partial class NewWording : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tools",
                table: "LearningObjectives");

            migrationBuilder.AddColumn<string>(
                name: "Completed",
                table: "LearningObjectives",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Techniques",
                table: "LearningObjectives",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Completed",
                table: "LearningObjectives");

            migrationBuilder.DropColumn(
                name: "Techniques",
                table: "LearningObjectives");

            migrationBuilder.AddColumn<string>(
                name: "Tools",
                table: "LearningObjectives",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
