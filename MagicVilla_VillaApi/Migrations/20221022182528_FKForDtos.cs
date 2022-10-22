using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVilla_VillaApi.Migrations
{
    public partial class FKForDtos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 22, 22, 25, 28, 293, DateTimeKind.Local).AddTicks(3362));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 22, 22, 25, 28, 293, DateTimeKind.Local).AddTicks(3373));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 22, 22, 25, 28, 293, DateTimeKind.Local).AddTicks(3374));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 22, 22, 25, 28, 293, DateTimeKind.Local).AddTicks(3375));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 22, 22, 25, 28, 293, DateTimeKind.Local).AddTicks(3376));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 22, 22, 20, 16, 975, DateTimeKind.Local).AddTicks(5302));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 22, 22, 20, 16, 975, DateTimeKind.Local).AddTicks(5316));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 22, 22, 20, 16, 975, DateTimeKind.Local).AddTicks(5318));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 22, 22, 20, 16, 975, DateTimeKind.Local).AddTicks(5319));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 22, 22, 20, 16, 975, DateTimeKind.Local).AddTicks(5321));
        }
    }
}
