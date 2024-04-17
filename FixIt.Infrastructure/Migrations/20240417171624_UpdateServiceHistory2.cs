using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FixIt.Infrastructure.Migrations
{
    public partial class UpdateServiceHistory2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                value: new DateTime(2024, 4, 18, 20, 11, 31, 808, DateTimeKind.Local).AddTicks(7449));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3e0f5536-ea82-4817-9d63-861cc93427c6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "51069ae5-71c3-4f3e-8e6e-d814532ef389", "AQAAAAEAACcQAAAAEE4UKyEFD6jn/H8+jGv4ZjCraBa4HfES5EGlkqGKPBZtg84ofw37aRpqXTEmOble+w==", "52b2597a-5190-449c-9277-e548da2104b9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bcfa3ffe-3bed-4ce8-9e1b-e7841b4c33cd", "AQAAAAEAACcQAAAAEB7JUMVRL+cyqWNlXs06XbjCjgS993PU0jzVNDoyXpMsxTR6ZumnyhbnD3Mh3QQ1TA==", "e55d8aff-3080-4b59-a6f0-33ffb1ef7ffb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "99ae7f52-08a1-4c41-98f6-0934ab9eeced",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "28029a3a-7b35-47cc-8a95-b842bd9a3c13", "AQAAAAEAACcQAAAAEAHN78fX5tjU7mz5LW6Wp7kyBqjXRo1CYYrPe36KuriTdOVE+0EJ+GrsPRzyz+4NqQ==", "2a4e63df-29f8-451a-a8b9-82786aeabd63" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b98a765c-94d6-4520-95ae-42503a95445d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "65117358-853a-4dd7-907d-d1727bb207f1", "AQAAAAEAACcQAAAAECp5R1QS793psttVbbzs8iqXmaGM4s2Qr2Dqr7P8epynql7ZTpTEjE4mtPXqMlX/Kw==", "6ba0fe59-2685-490e-a00e-146824178005" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1d729348-b857-4328-ab85-114a6e424135", "AQAAAAEAACcQAAAAEJSbzP36lrzDDCIa8tP3L2nHXp2zVX03Ea4hcDtkh//f/LwOktZwPNR/iZu2C5IBNg==", "e115d9eb-e91b-4bc3-a61f-5e2cf297178d" });

            migrationBuilder.UpdateData(
                table: "ServiceHistories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Price",
                value: 2420.00m);
        }
    }
}
