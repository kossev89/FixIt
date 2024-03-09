using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FixIt.Infrastructure.Migrations
{
    public partial class AppointmentTechIdNotRequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAndTime",
                value: new DateTime(2024, 3, 10, 23, 13, 20, 840, DateTimeKind.Local).AddTicks(1370));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e4d5a354-0a4a-474b-90b9-1e8d176ddb3c", "AQAAAAEAACcQAAAAECO0R3igEph0ap5v1KNDDZq52XysOmZtO9gv5NzMNvpJlaKg/y6FF7jw6llPFDjDtg==", "f8267ade-8973-42f6-8af5-1c3d47a34dfc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f7841859-782d-455a-b0c1-8b4810558aab", "AQAAAAEAACcQAAAAEIwfynJBf+2VCgwFbtmLUJPlrrMt9adYdf58r130jyTHy8mRuNV2Tnf5T3iALDv7kQ==", "e2ac17d7-c6a2-4935-9edd-2ccb5f58daae" });

            migrationBuilder.UpdateData(
                table: "ServiceHistories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 12, 9, 0, 0, 0, 0, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAndTime",
                value: new DateTime(2024, 3, 7, 0, 14, 10, 513, DateTimeKind.Local).AddTicks(6481));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1b40a721-ab92-46a4-b359-b4fc9928aead", "AQAAAAEAACcQAAAAEFB6A1DhOJrurtrtGSGPaoXe0odZqaCEJuAclW/zaKBM6xiClwXnk4TGp7g1PBWujQ==", "2f0b3a11-e93a-40cf-a0b8-c8f6d91cf3ee" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ecd8a93f-aeb3-47ba-bdcd-1156d5277921", "AQAAAAEAACcQAAAAEPmHuP9L2pBomZZ/iVL5E45kaby0Var1HFXKjWkk+SUYVo0Ru1dm+gz+hUV82XlGKQ==", "628bbd0b-3364-488f-af3d-f25fb607254d" });

            migrationBuilder.UpdateData(
                table: "ServiceHistories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 12, 6, 0, 0, 0, 0, DateTimeKind.Local));
        }
    }
}
