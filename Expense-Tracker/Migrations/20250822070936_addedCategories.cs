using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Expense_Tracker.Migrations
{
    /// <inheritdoc />
    public partial class addedCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Data_Entered_On = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Data_Entered_By = table.Column<int>(type: "int", nullable: false),
                    Data_Modified_On = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Data_Modified_By = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 8, 22, 7, 9, 34, 774, DateTimeKind.Utc).AddTicks(1219), "$2b$10$WEwqAUGnMBujN96pKTWLDuPlnGWkJDPFftRu.z9fY694lSbTZMCCC" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 8, 21, 9, 1, 2, 85, DateTimeKind.Utc).AddTicks(8390), "$2b$10$Csfm.dYXdyffA7yrbP48ve16v46jBl0SvAlo3zRbhcXl13ArOyRja" });
        }
    }
}
