using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FixIt.Infrastructure.Migrations
{
    public partial class SoftDeletePropertiesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Technicians",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Technician Soft Delete Property");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Cars",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Soft delete property");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c810056b-5b4d-4c6c-8340-57746f588e4c", "AQAAAAEAACcQAAAAEN0woIsgUqSD3XEiWH8/dzIP2rHBcANuSsDzTKJB1klItfsxyawXU8IXdgegfHNTOw==", "253f7aad-e685-4491-ac4a-0a619b120845" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "89c621a5-d62b-4af3-82d4-87098efaef56", "AQAAAAEAACcQAAAAEBRCowXq5NuO+hbEgijVuo6gJceJfIVX8LscnB5oiUaI4NToK0ET9lgUIa4+yezf5Q==", "62ec2a0f-8314-4511-a32a-d2e93e5aa994" });

            migrationBuilder.UpdateData(
                table: "ServiceHistories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 12, 5, 0, 0, 0, 0, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Technicians");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Cars");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0c1469db-b44b-4117-a8ff-7ac0583bb12a", "AQAAAAEAACcQAAAAECrycsRrTdm+4KTHhq5R3KBUBQIxdqkT/F8VEmIyD5pFxtRDym1exe+LsjOVh2QPbg==", "481cdadb-b917-4314-a489-712d6233b366" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "453a8cdd-8dbb-4198-a1ea-b7efb48dd58d", "AQAAAAEAACcQAAAAEE8YdSz16VBtsFizCjJ91G4DWOKnCRS3EhLEvzq+daX9SJiE27GBsj6Krk17CdlLeg==", "eee6d657-12da-44d6-b282-3bae9daaed3d" });

            migrationBuilder.UpdateData(
                table: "ServiceHistories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 12, 3, 0, 0, 0, 0, DateTimeKind.Local));
        }
    }
}
