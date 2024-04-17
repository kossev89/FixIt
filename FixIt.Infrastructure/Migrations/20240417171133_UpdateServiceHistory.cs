using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FixIt.Infrastructure.Migrations
{
    public partial class UpdateServiceHistory : Migration
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
                columns: new[] { "Date", "Price" },
                values: new object[] { new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Local), 2420.00m });
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
                value: new DateTime(2024, 4, 17, 0, 22, 55, 906, DateTimeKind.Local).AddTicks(2405));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3e0f5536-ea82-4817-9d63-861cc93427c6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5da8c938-db1e-49c7-aec8-67ff2016ec76", "AQAAAAEAACcQAAAAEODySK0K/jfg9hTe1tQKNRpBY21YLgwn0wgza8RxaNlABUkgHzefkhwKNiCT6e7bWw==", "8ad2cfcb-a79c-4fbb-bade-5abac906e96b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2c04ccb1-adb6-48a3-93b2-cccaec55df78", "AQAAAAEAACcQAAAAEKQM+GsFyPPpr6UYhtVCXwKKXa9gQzoMJsxWnaldAd3FvQsf3XEC2dECKSas7umP6g==", "ca8de875-b853-4757-acf5-b303eb7ec466" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "99ae7f52-08a1-4c41-98f6-0934ab9eeced",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d066c533-4b6c-4019-bd48-98d3d104e1fe", "AQAAAAEAACcQAAAAEP58v6YvWSXDJbmwi8uG3bcjaj+LnGTjoxTQmfkQamIb73uujam083/ihTrbTESk5Q==", "b7f9c5dc-265d-4054-ae0c-1afdfcef8eba" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b98a765c-94d6-4520-95ae-42503a95445d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ed64586d-1223-43dd-a4eb-9da23a863052", "AQAAAAEAACcQAAAAEG+jHgL4VvFsujZK2FSBRau9YLNpPvXLAnhwYuuPp9HAllhP0FPSrJID8246E+fpCw==", "c0911565-6204-4de2-aaa0-de56cee1d418" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4875014b-b25b-4dc0-8a74-32471a461c4a", "AQAAAAEAACcQAAAAEFu6Z+4MPFTUADpndvgpaV6gwgEIAVKpdMtOzduBNaLVkzeEQ1CTYiYKxjq/3LCgaw==", "8296809f-a3a0-4b4a-bf4e-d3340211846e" });

            migrationBuilder.UpdateData(
                table: "ServiceHistories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Local));
        }
    }
}
