using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WalletApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedingdataintoWalkandRegiontable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("006d4c13-a079-42f8-8603-4abf778b3cf8"), "Easy" },
                    { new Guid("4e080aec-ddba-42c2-bc25-a4da2c72c705"), "Medium" },
                    { new Guid("7c2cc3dd-c3af-473f-9c63-8ecc72bbabc7"), "Hard" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("d8d64eda-f5e9-45cb-8d5a-3c96f991afcb"), "Kad", "Kaduna", "https://momaa.org/wp-content/uploads/2019/10/zazzau-gate-1024x568.png" },
                    { new Guid("edec48ed-f6b3-4cb9-b1c7-f133ea2d6133"), "Kas", "Kastina", "https://freedomradionig.com/wp-content/uploads/2020/07/katsina.jpg" },
                    { new Guid("ff756d93-71fd-4acc-a6d3-d5f5023cd25f"), "Kan", "Kano", "https://www.bellanaija.com/wp-content/uploads/2023/09/IMG-20230909-WA0022.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("006d4c13-a079-42f8-8603-4abf778b3cf8"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("4e080aec-ddba-42c2-bc25-a4da2c72c705"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("7c2cc3dd-c3af-473f-9c63-8ecc72bbabc7"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("d8d64eda-f5e9-45cb-8d5a-3c96f991afcb"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("edec48ed-f6b3-4cb9-b1c7-f133ea2d6133"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("ff756d93-71fd-4acc-a6d3-d5f5023cd25f"));
        }
    }
}
