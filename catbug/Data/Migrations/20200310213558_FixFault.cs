using Microsoft.EntityFrameworkCore.Migrations;

namespace catbug.Data.Migrations
{
    public partial class FixFault : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LearningCycles_LearningCycles_LearningCycleId",
                table: "LearningCycles");

            migrationBuilder.DropIndex(
                name: "IX_LearningCycles_LearningCycleId",
                table: "LearningCycles");

            migrationBuilder.DropColumn(
                name: "LearningCycleId",
                table: "LearningCycles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LearningCycleId",
                table: "LearningCycles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LearningCycles_LearningCycleId",
                table: "LearningCycles",
                column: "LearningCycleId");

            migrationBuilder.AddForeignKey(
                name: "FK_LearningCycles_LearningCycles_LearningCycleId",
                table: "LearningCycles",
                column: "LearningCycleId",
                principalTable: "LearningCycles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
