using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FixIt.Infrastructure.Migrations
{
    public partial class UpdateServiceHistory3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "ServiceHistories",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                comment: "Price of the service performed");

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAndTime",
                value: new DateTime(2024, 4, 18, 20, 19, 25, 792, DateTimeKind.Local).AddTicks(7742));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3e0f5536-ea82-4817-9d63-861cc93427c6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "46b79ec5-513b-4562-8e5f-d65611391f7d", "AQAAAAEAACcQAAAAEO731PrxnS2m6ZC6p8O/n2hLwCAwXaPzY7OkGEeDOvLzDDyKAExdk7h+0/gdb0pgEg==", "de158e3b-3d72-4bf8-be6d-c053b6fc64fb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c46a8e84-51ad-468a-9404-c633501d6260", "AQAAAAEAACcQAAAAEAARZfP7HtMOjvFNCG4fs5+KIx0EZs+DjBMuUP9H8LGkYGGDjYbR04L17aJtsPf7rQ==", "e36871da-e580-42d2-a0ad-49e0f02a76d7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "99ae7f52-08a1-4c41-98f6-0934ab9eeced",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b0f4afd4-eb4b-4e8e-a23b-2d290669a697", "AQAAAAEAACcQAAAAEJkEMjdISGKcXZk0KWDQDiKuwFELa4KuSSY5tpoEpLJmRZnisnSQuUEhpwJ/CHkzEg==", "ba998f67-6d8a-421d-8336-b8efdedfe875" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b98a765c-94d6-4520-95ae-42503a95445d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1d850e26-9ff2-4bf2-ab43-5757886d688a", "AQAAAAEAACcQAAAAEHI3ki3vYZQnlddaoa5xk1FnRDH57m3ZYDeIErXJ1AuUnihOmcayTe1Z6Ee4Nnj+EQ==", "0e8bdab1-9ef0-443f-a242-ac18ef99f445" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fa4914a1-5e2b-43ff-a3c6-a82a702e315c", "AQAAAAEAACcQAAAAEC6H/5MddbGsQrMc3oF6E+vs425igyhHtPELuk6drNaqnCZvQ7glC0+wkSmhh97Sbw==", "e76b9f33-a703-4df7-acf8-8babb09ba88a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "ServiceHistories");

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAndTime",
                value: new DateTime(2024, 4, 18, 20, 16, 22, 681, DateTimeKind.Local).AddTicks(4356));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3e0f5536-ea82-4817-9d63-861cc93427c6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b460ca27-d197-46fd-8171-db1df9f2ce8e", "AQAAAAEAACcQAAAAEP9wXYhIP4asmbg0AQwwjzE1uLovoE6XaSnSCUcINszNJzrjxxFSyIjoD7WqFoENfg==", "d1a54ec5-925e-4caf-b409-b43b204e0222" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d4c22ca9-0354-48c1-b646-32d9b57c7ef9", "AQAAAAEAACcQAAAAEMUywMUtwNR9xfca4tcrryW1etxL1gzHKJO6CHarDpi8nlCHRXwFONh7tISznTJtzg==", "69f90279-4b6d-4552-8690-c2f25013d6ed" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "99ae7f52-08a1-4c41-98f6-0934ab9eeced",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "52ea4451-ecff-41b9-bacb-71785e4c66a1", "AQAAAAEAACcQAAAAENrOFOnQ0s5MR9F/eG9+p6/VVpII98Zbb7XmWlEoNGlw+7WblOtWWZgm8QRDSc6jlQ==", "65d553b0-0678-4beb-9d92-3a3a5fb81740" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b98a765c-94d6-4520-95ae-42503a95445d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "255ce8d5-9df5-4048-b6d0-c4e2089030ba", "AQAAAAEAACcQAAAAEGOhTRRy3qddm/paYkCZYC24R1YgZXQ83vqkuX69Jky7+SsltFKVu6271hgbC4nCew==", "2c20fb03-750d-4ecb-ac18-de2a2e4cfabd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "27592397-4340-4328-9adc-99fb818171b2", "AQAAAAEAACcQAAAAEHmnS1/tHn6ZGjrR1GUo0cUIogjkEqGtwV63lQPyno9GisYT0ZQ4SKOomyeAHRy2yg==", "e9a68c35-b6d1-49af-afea-41ef21b9cf19" });
        }
    }
}
