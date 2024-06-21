using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Setareh.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddAboutMeImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "AboutMe",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AboutMe",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "ImageName", "birthDate" },
                values: new object[] { new DateTime(2024, 6, 18, 23, 23, 22, 482, DateTimeKind.Local).AddTicks(9540), "", new DateOnly(2024, 6, 18) });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "AboutMe");

            migrationBuilder.UpdateData(
                table: "AboutMe",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "birthDate" },
                values: new object[] { new DateTime(2024, 6, 17, 20, 34, 19, 221, DateTimeKind.Local).AddTicks(6162), new DateOnly(2024, 6, 17) });

            migrationBuilder.UpdateData(
                table: "ContactUs",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 6, 17, 20, 34, 19, 221, DateTimeKind.Local).AddTicks(6083));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 6, 17, 20, 34, 19, 221, DateTimeKind.Local).AddTicks(5946));
        }
    }
}
