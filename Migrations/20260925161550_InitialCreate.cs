using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Momentum.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Goals",
                columns: table => new
                {
                    GoalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Category = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TargetDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goals", x => x.GoalId);
                });

            migrationBuilder.InsertData(
                table: "Goals",
                columns: new[] { "GoalId", "Category", "Description", "TargetDate", "Title" },
                values: new object[,]
                {
                    { 1, "Money", "Build a starter emergency fund.", new DateTime(2027, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Save $1,000" },
                    { 2, "Health", "Build a regular weekly exercise routine.", new DateTime(2027, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Exercise Consistently" },
                    { 3, "Learning", "Practice a new skill through small, manageable steps.", new DateTime(2027, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Learn a New Skill" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Goals");
        }
    }
}
