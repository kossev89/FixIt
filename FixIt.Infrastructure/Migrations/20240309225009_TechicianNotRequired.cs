using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FixIt.Infrastructure.Migrations
{
    public partial class TechicianNotRequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Technicians_TechnicianId",
                table: "Appointments");

            migrationBuilder.AlterColumn<int>(
                name: "TechnicianId",
                table: "Appointments",
                type: "int",
                nullable: true,
                comment: "Technician Identifier",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Technician Identifier");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Technicians_TechnicianId",
                table: "Appointments",
                column: "TechnicianId",
                principalTable: "Technicians",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Technicians_TechnicianId",
                table: "Appointments");

            migrationBuilder.AlterColumn<int>(
                name: "TechnicianId",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Technician Identifier",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldComment: "Technician Identifier");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Technicians_TechnicianId",
                table: "Appointments",
                column: "TechnicianId",
                principalTable: "Technicians",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
