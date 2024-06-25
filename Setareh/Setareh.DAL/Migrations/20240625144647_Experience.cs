using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Setareh.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Experience : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Experience",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Start = table.Column<DateOnly>(type: "date", nullable: false),
                    End = table.Column<DateOnly>(type: "date", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experience", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AboutMe",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "birthDate" },
                values: new object[] { new DateTime(2024, 6, 25, 18, 16, 44, 121, DateTimeKind.Local).AddTicks(7534), new DateOnly(2024, 6, 25) });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Experience");

            migrationBuilder.UpdateData(
                table: "AboutMe",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "birthDate" },
                values: new object[] { new DateTime(2024, 6, 21, 12, 44, 47, 167, DateTimeKind.Local).AddTicks(4064), new DateOnly(2024, 6, 21) });

            migrationBuilder.UpdateData(
                table: "ContactUs",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 6, 21, 12, 44, 47, 167, DateTimeKind.Local).AddTicks(4015));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 6, 21, 12, 44, 47, 167, DateTimeKind.Local).AddTicks(3616));
        }
    }
}
