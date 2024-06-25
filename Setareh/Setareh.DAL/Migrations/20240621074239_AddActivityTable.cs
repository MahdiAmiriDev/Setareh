using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Setareh.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddActivityTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activity", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AboutMe",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "birthDate" },
                values: new object[] { new DateTime(2024, 6, 21, 11, 12, 36, 458, DateTimeKind.Local).AddTicks(9076), new DateOnly(2024, 6, 21) });

            migrationBuilder.UpdateData(
                table: "ContactUs",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 6, 21, 11, 12, 36, 458, DateTimeKind.Local).AddTicks(9032));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 6, 21, 11, 12, 36, 458, DateTimeKind.Local).AddTicks(8855));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activity");

            migrationBuilder.UpdateData(
                table: "AboutMe",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "birthDate" },
                values: new object[] { new DateTime(2024, 6, 18, 23, 23, 22, 482, DateTimeKind.Local).AddTicks(9540), new DateOnly(2024, 6, 18) });

            migrationBuilder.UpdateData(
                table: "ContactUs",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 6, 18, 23, 23, 22, 482, DateTimeKind.Local).AddTicks(9503));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 6, 18, 23, 23, 22, 482, DateTimeKind.Local).AddTicks(9367));
        }
    }
}
