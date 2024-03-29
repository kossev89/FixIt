using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FixIt.Infrastructure.Migrations
{
    public partial class TechnicianIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Technicians",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                comment: "Identity User Identification");

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

            migrationBuilder.UpdateData(
                table: "Technicians",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: "99ae7f52-08a1-4c41-98f6-0934ab9eeced");

            migrationBuilder.UpdateData(
                table: "Technicians",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId",
                value: "3e0f5536-ea82-4817-9d63-861cc93427c6");

            migrationBuilder.UpdateData(
                table: "Technicians",
                keyColumn: "Id",
                keyValue: 3,
                column: "UserId",
                value: "b98a765c-94d6-4520-95ae-42503a95445d");

            migrationBuilder.CreateIndex(
                name: "IX_Technicians_UserId",
                table: "Technicians",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Technicians_AspNetUsers_UserId",
                table: "Technicians",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Technicians_AspNetUsers_UserId",
                table: "Technicians");

            migrationBuilder.DropIndex(
                name: "IX_Technicians_UserId",
                table: "Technicians");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Technicians");

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAndTime",
                value: new DateTime(2024, 3, 11, 0, 50, 6, 699, DateTimeKind.Local).AddTicks(162));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6064d0d3-5fe3-4c7a-9d3c-6215a515ace4", "AQAAAAEAACcQAAAAEDwTUFLt4B06eXu2puV1RLolq/bPBfYDMo1hafVvwGf13kRu6aY7ZKhKKEY6EhfBtA==", "721a0964-78c0-491b-9144-017abce28889" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ae1a9b29-2137-4910-87f8-82569bedc029", "AQAAAAEAACcQAAAAEB84qcMkMm8I/S0riLj8tNJXRo2IrOZKRmtsI5f56AmsQDcK1CokXElORqnGfEyjXw==", "d185435b-f81f-473c-872d-2ede3f0bda59" });

            migrationBuilder.UpdateData(
                table: "ServiceHistories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 12, 10, 0, 0, 0, 0, DateTimeKind.Local));
        }
    }
}
