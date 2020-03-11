using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace catbug.Data.Migrations
{
    public partial class AddLearning : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LearningCycles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(nullable: false),
                    Duration = table.Column<TimeSpan>(nullable: false),
                    LearningCycleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LearningCycles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LearningCycles_LearningCycles_LearningCycleId",
                        column: x => x.LearningCycleId,
                        principalTable: "LearningCycles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LearningObjectives",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Goal = table.Column<string>(nullable: true),
                    Tools = table.Column<string>(nullable: true),
                    Criteria = table.Column<string>(nullable: true),
                    Evaulation = table.Column<string>(nullable: true),
                    LearningCycleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LearningObjectives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LearningObjectives_LearningCycles_LearningCycleId",
                        column: x => x.LearningCycleId,
                        principalTable: "LearningCycles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LearningCycles_LearningCycleId",
                table: "LearningCycles",
                column: "LearningCycleId");

            migrationBuilder.CreateIndex(
                name: "IX_LearningObjectives_LearningCycleId",
                table: "LearningObjectives",
                column: "LearningCycleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LearningObjectives");

            migrationBuilder.DropTable(
                name: "LearningCycles");
        }
    }
}
