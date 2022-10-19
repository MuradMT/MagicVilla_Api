using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVilla_VillaApi.Migrations
{
    public partial class SeedVillaTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "Amenity", "CreatedDate", "Details", "ImageUrl", "Name", "Occupancy", "Rate", "Sqft", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "", new DateTime(2022, 10, 19, 13, 34, 35, 248, DateTimeKind.Local).AddTicks(799), "this villa is nice", "https://media-cdn.tripadvisor.com/media/vr-splice-j/09/1f/7e/d1.jpg", "Royal Villa", 0, 200.0, 550, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "", new DateTime(2022, 10, 19, 13, 34, 35, 248, DateTimeKind.Local).AddTicks(813), "this villa is very good", "https://images.squarespace-cdn.com/content/v1/585562bcbe659442d503893f/c3b765c0-45e3-46b3-9ff9-b4101fb30674/01.+Exotik+Villas+Bali+-+Aloui.jpg?format=1000w", "Premium Pool Villa", 0, 400.0, 650, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "", new DateTime(2022, 10, 19, 13, 34, 35, 248, DateTimeKind.Local).AddTicks(815), "this villa is very good and also exspensive", "https://cf.bstatic.com/xdata/images/hotel/max1024x768/306027131.jpg?k=9bb7b6bfeab68dafed1919b814c007658b002eb2c94d65b59cc15bec83e04bfe&o=&hp=1", "Luxury Pool Villa", 0, 500.0, 750, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "", new DateTime(2022, 10, 19, 13, 34, 35, 248, DateTimeKind.Local).AddTicks(816), "this villa is very good and also exspensive and  height is big", "https://www.casagrand.co.in/wp-content/uploads/2021/06/1621872930952_florella.jpg", "Diamond  Villa", 0, 600.0, 850, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "", new DateTime(2022, 10, 19, 13, 34, 35, 248, DateTimeKind.Local).AddTicks(817), "this villa is very good and also exspensive and  height&weight is big", "https://storage.googleapis.com/bd-az-01/buildings-v2/2560x1920/1760.jpg", "Diamond Pool Villa", 0, 700.0, 950, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
