using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FixIt.Infrastructure.Migrations
{
    public partial class SeedAppointment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "CarId", "DateAndTime", "ServiceId", "Status", "TechnicianId", "UserId" },
                values: new object[] { 1, 1, new DateTime(2024, 3, 7, 0, 14, 10, 513, DateTimeKind.Local).AddTicks(6481), 1, 0, 1, "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bb087438-5539-4392-a929-668189cb29f8", "AQAAAAEAACcQAAAAEDYW1tX1boDwTgnIXZpT22z7gsh8jb5AzbaFFitbnKkjv7/fixcGjnj2cc+E90iLbA==", "13a2b244-2d44-4e85-bbff-ae9215d2de57" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e4998466-5b65-489a-a903-6242f27714b5", "AQAAAAEAACcQAAAAEFCuhwYmBDh7BCUSMzFw3AZ7zA3oSx3aYkcMrbkx85YftFohwqgue84e+oiXPncSPA==", "53fba295-4448-4162-a3d1-6cb5d2eea467" });

            migrationBuilder.UpdateData(
                table: "ServiceHistories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 12, 5, 0, 0, 0, 0, DateTimeKind.Local));
        }
    }
}
