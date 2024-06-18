using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Setareh.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddAboutMeSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AboutMe",
                columns: new[] { "Id", "CreateDate", "Description", "Email", "FirstName", "LastName", "Location", "Mobile", "Position", "birthDate" },
                values: new object[] { 1, new DateTime(2024, 6, 17, 20, 34, 19, 221, DateTimeKind.Local).AddTicks(6162), "", "", "", "", "", "", "", new DateOnly(2024, 6, 17) });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AboutMe",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "ContactUs",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 6, 17, 20, 28, 24, 856, DateTimeKind.Local).AddTicks(8508));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 6, 17, 20, 28, 24, 856, DateTimeKind.Local).AddTicks(8374));
        }
    }
}
