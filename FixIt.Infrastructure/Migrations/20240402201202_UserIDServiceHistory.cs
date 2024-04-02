using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FixIt.Infrastructure.Migrations
{
    public partial class UserIDServiceHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "ServiceHistories",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                comment: "ServceHistory Customer Identifier");

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAndTime",
                value: new DateTime(2024, 4, 3, 23, 12, 0, 366, DateTimeKind.Local).AddTicks(6169));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5302009b-5c97-407e-8dcc-7e13400a7395", "AQAAAAEAACcQAAAAEJZAzaxFOv1Nxrh6H8FOaAAZ++i2/k2kRx+wkkR9U9KSi6cSzYEQjg2taK7TEuS4yw==", "fc0ab2b5-d0c7-45cc-87c1-ab0899cc2060" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "10cd0336-2d55-44b7-8b2c-14afa93be73b", "AQAAAAEAACcQAAAAEJHHxT6wnRlcB8HEq8CnSytn4Un66RNNu95r+dlqcFNAMHIKLR7h+lgkuwghnZzq8A==", "90ea44b5-43aa-4cc4-ac72-744c46a63ac7" });

            migrationBuilder.UpdateData(
                table: "ServiceHistories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "UserId" },
                values: new object[] { new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Local), "" });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceHistories_UserId",
                table: "ServiceHistories",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceHistories_AspNetUsers_UserId",
                table: "ServiceHistories",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceHistories_AspNetUsers_UserId",
                table: "ServiceHistories");

            migrationBuilder.DropIndex(
                name: "IX_ServiceHistories_UserId",
                table: "ServiceHistories");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ServiceHistories");

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAndTime",
                value: new DateTime(2024, 3, 30, 9, 43, 53, 651, DateTimeKind.Local).AddTicks(8557));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "42f87388-fd2a-4b24-9d2d-ce1bb93c25f5", "AQAAAAEAACcQAAAAEKzFY0ae4fUh6SiPp9QCd0XL8Cq23B0kR3TZGPWnKJp37JGq8hCA6Z1TIT8J9Zz58Q==", "2ae109dd-9276-4991-be15-5927e0df1fff" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1948bf8e-2b78-483b-9847-27fcffcab44b", "AQAAAAEAACcQAAAAEBQFt+Hq77kJAuY6/lZ3LVCOrp2CnxlQAvq0rF9gkaDuapUYr86kv0/uOrpz5VZPaQ==", "cf08c216-d6a4-45b4-b723-075edb257c0c" });

            migrationBuilder.UpdateData(
                table: "ServiceHistories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 12, 29, 0, 0, 0, 0, DateTimeKind.Local));
        }
    }
}
