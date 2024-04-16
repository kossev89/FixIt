using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FixIt.Infrastructure.Migrations
{
    public partial class SoftDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Services",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Soft delete property");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Services");

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAndTime",
                value: new DateTime(2024, 4, 10, 22, 34, 53, 701, DateTimeKind.Local).AddTicks(4036));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3e0f5536-ea82-4817-9d63-861cc93427c6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fdca5ee5-9bb7-4921-a83f-b2307c01430d", "AQAAAAEAACcQAAAAEO8W2XAXnTfjvNiHbty44Pk4QYZVb53Inm2OmvN6TnjHVCWlfemFdGhMogcFLmDVRg==", "974d8093-d827-4346-9eae-cc358e0e5a1c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7a9955db-0186-47b4-a0d6-b6be27c2725a", "AQAAAAEAACcQAAAAEKGhhH1XGgJrkV2St+vjw3iItx+I+4VtjsvhbNePiNfwmAi5m30hf+FLpmKeX39Hyw==", "8332b224-ee28-4db1-9678-2ecc82e7baa9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "99ae7f52-08a1-4c41-98f6-0934ab9eeced",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "319bb0af-824f-49dd-a75a-d005c99106ee", "AQAAAAEAACcQAAAAEAPyA3K/kE5IG8TFNgSrV4j8lycLyUmSB2mHtD/uVrXu6c6Qtsv9cKNFqAs6oiqskA==", "26a76ec6-4bd2-4385-b8be-d75889290c00" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b98a765c-94d6-4520-95ae-42503a95445d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b09328d9-0e26-4840-ac47-f6cdc7a8aea6", "AQAAAAEAACcQAAAAELx6TvT6WDBpqoTpipCLQ8SqjkzRROA865woy0J2O3tegrUkVUcRgDew7YC1FjXXLA==", "e8247c5c-082b-4910-a72e-633df8ca1651" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "355a7489-74d3-426b-801f-5e938c7b7b59", "AQAAAAEAACcQAAAAEAG0wMH+62weEriO8so+hkJW29f/a3NTVAoZIrbSdJFXBLuKYaZCK+fo9c2xZKsdPw==", "81d7567d-650e-4d54-8f3a-9f776d89864c" });

            migrationBuilder.UpdateData(
                table: "ServiceHistories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 1, 9, 0, 0, 0, 0, DateTimeKind.Local));
        }
    }
}
