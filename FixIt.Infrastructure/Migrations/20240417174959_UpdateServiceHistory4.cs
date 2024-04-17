using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FixIt.Infrastructure.Migrations
{
    public partial class UpdateServiceHistory4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAndTime",
                value: new DateTime(2024, 4, 18, 20, 49, 56, 535, DateTimeKind.Local).AddTicks(4409));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3e0f5536-ea82-4817-9d63-861cc93427c6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "561055d1-6a7f-42d6-a6b9-d96de65b952a", "AQAAAAEAACcQAAAAEPnBKq9MfuizitXlxnwoveGtqj/6ubzNtXt6Pt8eVEsqu7fCtFPExu/avNz5UTvDAw==", "8f229407-6a35-43ea-ad01-7bb2941c70fe" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b9d5c864-444a-4197-9d25-148c8c84d56a", "AQAAAAEAACcQAAAAEJaaVaunu25GsPXToiAfvTjpri0vp1cQnUSMkEpHWIldGUZJLuCloFLSGLyYHedOjw==", "e2c0672d-04bd-4aea-8b18-7fac72673627" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "99ae7f52-08a1-4c41-98f6-0934ab9eeced",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "60ce5133-b801-419f-a066-18e61c21eb10", "AQAAAAEAACcQAAAAEPvNcS0Zb21jARfOGcrERz/sxubqrA55PSt6vqfYmjJlq0izL30DODCF3Tn5PY+DRA==", "750da9a4-7bf2-4a8c-af9f-23a4ed73d866" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b98a765c-94d6-4520-95ae-42503a95445d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3e8f5c3b-e43f-4344-b541-bbb571caad69", "AQAAAAEAACcQAAAAEMiQly9LS58JvWibniZpGTCCCryc9iLcSTWvEgpWMMoq7GxplqGlJPnLWy2/8c3arQ==", "7fd72d1a-459a-42cf-8e18-f12d916f8e42" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c7c63112-99b6-4dd0-aa98-68ef9fffc829", "AQAAAAEAACcQAAAAEHKINayhZq/+dWUEd+UQRh+X0Dd5kIcIY229pTdUkh4PK/BkRixqOP10i0my4LW8xg==", "801d213c-e97b-4993-90a4-2ed6eac9ce8c" });

            migrationBuilder.UpdateData(
                table: "ServiceHistories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Price",
                value: 2420m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "ServiceHistories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Price",
                value: 0m);
        }
    }
}
