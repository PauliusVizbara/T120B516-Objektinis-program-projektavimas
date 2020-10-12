using Microsoft.EntityFrameworkCore.Migrations;

namespace TowerDefense.Data.Migrations
{
    public partial class addedMapSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Maps",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Miškas" });

            migrationBuilder.InsertData(
                table: "MapPathCoordinates",
                columns: new[] { "Id", "CoordinateIndex", "MapId", "XCoordinate", "YCoordinate" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, 2 },
                    { 16, 16, 1, 13, 5 },
                    { 15, 15, 1, 12, 5 },
                    { 14, 14, 1, 11, 5 },
                    { 13, 13, 1, 10, 5 },
                    { 12, 12, 1, 9, 5 },
                    { 11, 11, 1, 8, 5 },
                    { 10, 10, 1, 8, 4 },
                    { 9, 9, 1, 8, 3 },
                    { 8, 8, 1, 8, 2 },
                    { 7, 7, 1, 7, 2 },
                    { 6, 6, 1, 6, 2 },
                    { 5, 5, 1, 5, 2 },
                    { 4, 4, 1, 4, 2 },
                    { 3, 3, 1, 3, 2 },
                    { 2, 2, 1, 2, 2 },
                    { 17, 17, 1, 14, 5 },
                    { 18, 18, 1, 15, 5 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MapPathCoordinates",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MapPathCoordinates",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MapPathCoordinates",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MapPathCoordinates",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MapPathCoordinates",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MapPathCoordinates",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "MapPathCoordinates",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "MapPathCoordinates",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "MapPathCoordinates",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "MapPathCoordinates",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "MapPathCoordinates",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "MapPathCoordinates",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "MapPathCoordinates",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "MapPathCoordinates",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "MapPathCoordinates",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "MapPathCoordinates",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "MapPathCoordinates",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "MapPathCoordinates",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Maps",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
