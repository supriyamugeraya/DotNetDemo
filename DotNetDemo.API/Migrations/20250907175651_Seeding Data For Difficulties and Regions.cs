using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DotNetDemo.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDataForDifficultiesandRegions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("3b5f62f5-1c41-4393-9a8a-bd559cbc188d"), "Medium" },
                    { new Guid("4143d42d-7be9-4363-8069-a123470ca381"), "Easy" },
                    { new Guid("d9154729-7057-421f-9eb6-0ff2159d3dd7"), "Hard" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("65a5490a-d2ff-4163-ae3c-c34cc42350c0"), "AKL", "Auckland", "https://cdn.holidayguru.ch/wp-content/uploads/2017/03/skyline-von-auckland-istock_49893056_large-2.jpg" },
                    { new Guid("a0a5c0ae-9a84-4110-a925-0c44e74ed31c"), "WGN", "Wellington", "https://datacom.com/content/dam/images/admin/insights/experience/ai-attitudes-research-report/nz/WellingtonCity.jpg" },
                    { new Guid("b8ccb03b-7c2a-4335-9735-2b13be4aa34b"), "BOP", "Bay of Plenty", null },
                    { new Guid("bd4b05e3-0e09-4d7e-bb74-6c684aca998e"), "STL", "Southland", null },
                    { new Guid("cb7682a7-76b3-43b1-900a-c7f6f33ea915"), "NTL", "Northland", null },
                    { new Guid("fba177f6-df80-4918-9a16-1a0f55a2a020"), "NSN", "Nelson", "https://i.natgeofe.com/n/6784d56f-a792-4d57-9a05-f6a9500dd2f2/68382.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("3b5f62f5-1c41-4393-9a8a-bd559cbc188d"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("4143d42d-7be9-4363-8069-a123470ca381"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("d9154729-7057-421f-9eb6-0ff2159d3dd7"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("65a5490a-d2ff-4163-ae3c-c34cc42350c0"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("a0a5c0ae-9a84-4110-a925-0c44e74ed31c"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("b8ccb03b-7c2a-4335-9735-2b13be4aa34b"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("bd4b05e3-0e09-4d7e-bb74-6c684aca998e"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("cb7682a7-76b3-43b1-900a-c7f6f33ea915"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("fba177f6-df80-4918-9a16-1a0f55a2a020"));
        }
    }
}
