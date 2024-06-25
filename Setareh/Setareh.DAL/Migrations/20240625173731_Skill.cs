using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Setareh.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Skill : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Skill",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Percentage = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skill", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AboutMe",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 6, 25, 21, 7, 29, 82, DateTimeKind.Local).AddTicks(4975));

            migrationBuilder.UpdateData(
                table: "ContactUs",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 6, 25, 21, 7, 29, 82, DateTimeKind.Local).AddTicks(4901));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 6, 25, 21, 7, 29, 82, DateTimeKind.Local).AddTicks(4766));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Skill");

            migrationBuilder.UpdateData(
                table: "AboutMe",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 6, 25, 18, 16, 44, 121, DateTimeKind.Local).AddTicks(7534));

            migrationBuilder.UpdateData(
                table: "ContactUs",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 6, 25, 18, 16, 44, 121, DateTimeKind.Local).AddTicks(7500));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 6, 25, 18, 16, 44, 121, DateTimeKind.Local).AddTicks(7350));
        }
    }
}
