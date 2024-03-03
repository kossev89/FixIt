using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FixIt.Infrastructure.Migrations
{
    public partial class RequireConfirmedAccountsFalse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "510d151f-2e89-4483-a02f-ea8d21c59e62", "AQAAAAEAACcQAAAAEIREZxncW0vmzcSA3pVTLyy9tSFeh91pF6LqcvWiPlfHCFc+YRBiWuxmRok9H1dCyw==", "6fcbd745-6206-4277-ae57-9dbd3683d2c3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ce34ba76-1649-414a-9ee4-64d578847b48", "AQAAAAEAACcQAAAAENIs+4dcAxmH9C2bFj9hKkHX58hk7hblCD3oCIOZgEjQe+1aT7Fw/gmW5L5Sm3/7fw==", "a6da7cb3-a375-41d7-a0ec-d9658cd973f2" });

            migrationBuilder.UpdateData(
                table: "ServiceHistories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 11, 29, 0, 0, 0, 0, DateTimeKind.Local));
        }
    }
}
