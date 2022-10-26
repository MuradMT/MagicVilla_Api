using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVilla_VillaApi.Migrations
{
    public partial class Occupations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Occupancy" },
                values: new object[] { new DateTime(2022, 10, 24, 12, 19, 33, 684, DateTimeKind.Local).AddTicks(4074), 4 });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Occupancy" },
                values: new object[] { new DateTime(2022, 10, 24, 12, 19, 33, 684, DateTimeKind.Local).AddTicks(4083), 5 });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Occupancy" },
                values: new object[] { new DateTime(2022, 10, 24, 12, 19, 33, 684, DateTimeKind.Local).AddTicks(4084), 6 });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "Occupancy" },
                values: new object[] { new DateTime(2022, 10, 24, 12, 19, 33, 684, DateTimeKind.Local).AddTicks(4085), 7 });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "Occupancy" },
                values: new object[] { new DateTime(2022, 10, 24, 12, 19, 33, 684, DateTimeKind.Local).AddTicks(4086), 8 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Occupancy" },
                values: new object[] { new DateTime(2022, 10, 22, 22, 25, 28, 293, DateTimeKind.Local).AddTicks(3362), 0 });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Occupancy" },
                values: new object[] { new DateTime(2022, 10, 22, 22, 25, 28, 293, DateTimeKind.Local).AddTicks(3373), 0 });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Occupancy" },
                values: new object[] { new DateTime(2022, 10, 22, 22, 25, 28, 293, DateTimeKind.Local).AddTicks(3374), 0 });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "Occupancy" },
                values: new object[] { new DateTime(2022, 10, 22, 22, 25, 28, 293, DateTimeKind.Local).AddTicks(3375), 0 });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "Occupancy" },
                values: new object[] { new DateTime(2022, 10, 22, 22, 25, 28, 293, DateTimeKind.Local).AddTicks(3376), 0 });
        }
    }
}
