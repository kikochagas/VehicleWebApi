using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VehicleWebApi.Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("b2dd001b-3c83-4bb3-a9c5-d3a77d55d0bd"), "Alfa Romeo 4C" });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("babaffff-615a-4d7d-a0dd-c3dcd3f3ffd8"), "Alfa Romeo Stelvio" });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("a88bfe7b-af13-48bc-ac04-7e8089b287a0"), "Peugeot 2008 Allure 1.2" });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "RequestId", "DeliveryDate", "ModelId", "Vin" },
                values: new object[] { new Guid("cc97d34d-d5a1-4228-92b5-a7797b21b271"), new DateTime(2022, 5, 13, 18, 18, 57, 367, DateTimeKind.Utc).AddTicks(6386), new Guid("b2dd001b-3c83-4bb3-a9c5-d3a77d55d0bd"), "VN56RFF5656R6F" });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "RequestId", "DeliveryDate", "ModelId", "Vin" },
                values: new object[] { new Guid("f4ca36b9-ee67-4dbc-bed6-010406dda01a"), new DateTime(2022, 5, 13, 18, 18, 57, 367, DateTimeKind.Utc).AddTicks(6944), new Guid("babaffff-615a-4d7d-a0dd-c3dcd3f3ffd8"), "VN677HHTUY6BB" });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "RequestId", "DeliveryDate", "ModelId", "Vin" },
                values: new object[] { new Guid("b4b00d59-0fb8-4fe8-9ecb-1555f58bfb15"), new DateTime(2022, 5, 13, 18, 18, 57, 367, DateTimeKind.Utc).AddTicks(6941), new Guid("a88bfe7b-af13-48bc-ac04-7e8089b287a0"), "VN677BBB6B6BB" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "RequestId",
                keyValue: new Guid("b4b00d59-0fb8-4fe8-9ecb-1555f58bfb15"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "RequestId",
                keyValue: new Guid("cc97d34d-d5a1-4228-92b5-a7797b21b271"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "RequestId",
                keyValue: new Guid("f4ca36b9-ee67-4dbc-bed6-010406dda01a"));

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: new Guid("a88bfe7b-af13-48bc-ac04-7e8089b287a0"));

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: new Guid("b2dd001b-3c83-4bb3-a9c5-d3a77d55d0bd"));

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: new Guid("babaffff-615a-4d7d-a0dd-c3dcd3f3ffd8"));
        }
    }
}
