using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WalletApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedingdataintotheWalktable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Walks",
                columns: new[] { "Id", "Description", "DifficultyId", "LengthInKm", "Name", "RegionId", "WalkImageUrl" },
                values: new object[,]
                {
                    { new Guid("1f99db48-e3d6-4146-82d0-8e7de5369e09"), "A walk at the city center", new Guid("4e080aec-ddba-42c2-bc25-a4da2c72c705"), 5.0, "Ring road walk", new Guid("00000000-0000-0000-0000-000000000003"), null },
                    { new Guid("2ab992ae-22af-43e4-acfd-294a346e1ef3"), "Take a visit to the largest carnival", new Guid("4e080aec-ddba-42c2-bc25-a4da2c72c705"), 15.0, "Visit Calabar Festival", new Guid("1d5716e5-fbcb-4210-8b02-b74e6926d13c"), null },
                    { new Guid("9bc757d4-52dd-4496-9f93-dc5929ae2d18"), "Study in the south and north of Kaduna", new Guid("7c2cc3dd-c3af-473f-9c63-8ecc72bbabc7"), 20.0, "Kaduna Education Institute", new Guid("d8d64eda-f5e9-45cb-8d5a-3c96f991afcb"), null },
                    { new Guid("b3537d64-47e3-4916-b92e-8fa3722c3572"), "Take a visit to the largest carnival", new Guid("4e080aec-ddba-42c2-bc25-a4da2c72c705"), 15.0, "Kano Commerce Center", new Guid("ff756d93-71fd-4acc-a6d3-d5f5023cd25f"), null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Walks",
                keyColumn: "Id",
                keyValue: new Guid("1f99db48-e3d6-4146-82d0-8e7de5369e09"));

            migrationBuilder.DeleteData(
                table: "Walks",
                keyColumn: "Id",
                keyValue: new Guid("2ab992ae-22af-43e4-acfd-294a346e1ef3"));

            migrationBuilder.DeleteData(
                table: "Walks",
                keyColumn: "Id",
                keyValue: new Guid("9bc757d4-52dd-4496-9f93-dc5929ae2d18"));

            migrationBuilder.DeleteData(
                table: "Walks",
                keyColumn: "Id",
                keyValue: new Guid("b3537d64-47e3-4916-b92e-8fa3722c3572"));
        }
    }
}
