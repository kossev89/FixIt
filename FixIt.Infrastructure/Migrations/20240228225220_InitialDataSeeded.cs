using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FixIt.Infrastructure.Migrations
{
    public partial class InitialDataSeeded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", 0, "510d151f-2e89-4483-a02f-ea8d21c59e62", "customer@mail.com", false, false, null, "customer@mail.com", "customer@mail.com", "AQAAAAEAACcQAAAAEIREZxncW0vmzcSA3pVTLyy9tSFeh91pF6LqcvWiPlfHCFc+YRBiWuxmRok9H1dCyw==", null, false, "6fcbd745-6206-4277-ae57-9dbd3683d2c3", false, "customer@mail.com" },
                    { "dea12856-c198-4129-b3f3-b893d8395082", 0, "ce34ba76-1649-414a-9ee4-64d578847b48", "admin@mail.com", false, false, null, "admin@mail.com", "admin@mail.com", "AQAAAAEAACcQAAAAENIs+4dcAxmH9C2bFj9hKkHX58hk7hblCD3oCIOZgEjQe+1aT7Fw/gmW5L5Sm3/7fw==", null, false, "a6da7cb3-a375-41d7-a0ec-d9658cd973f2", false, "admin@mail.com" }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "Description", "Price", "Type" },
                values: new object[,]
                {
                    { 1, null, 80.00m, 0 },
                    { 2, null, 150.00m, 1 },
                    { 3, null, 60.00m, 2 },
                    { 4, null, 2000.00m, 3 },
                    { 5, null, 1300.00m, 4 },
                    { 6, null, 2420.00m, 5 }
                });

            migrationBuilder.InsertData(
                table: "Technicians",
                columns: new[] { "Id", "Name", "Specialization" },
                values: new object[,]
                {
                    { 1, "John Doe", 3 },
                    { 2, "Jane Doe", 0 },
                    { 3, "Don Johns", 4 }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "ImageUrl", "Make", "Mileage", "Model", "PlateNumber", "UserId", "Vin", "Year" },
                values: new object[] { 1, "https://www.google.com/imgres?imgurl=https%3A%2F%2Fimg.autoabc.lv%2FToyota-Avensis%2FToyota-Avensis_2003_Hecbeks_15102250637_3.jpg&tbnid=3pELpEqszmhQ8M&vet=12ahUKEwiHqLvu_s6EAxX74bsIHVDBCw8QMygIegQIARBf..i&imgrefurl=https%3A%2F%2Fwww.auto-abc.eu%2FToyota-Avensis%2Fg275-2003&docid=Hbz18f1fC2wffM&w=1000&h=547&q=avensis%20t25&ved=2ahUKEwiHqLvu_s6EAxX74bsIHVDBCw8QMygIegQIARBf", "Toyota", 180000, "Avensis", "P3366BC", "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", null, 2005 });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "ImageUrl", "Make", "Mileage", "Model", "PlateNumber", "UserId", "Vin", "Year" },
                values: new object[] { 2, "https://www.google.com/imgres?imgurl=https%3A%2F%2Fautomedia.investor.bg%2Fmedia%2Ffiles%2Fresized%2Fuploadedfiles%2F640x0%2F244%2F5afbc0f7c9b507828db312f5101c9244-98.JPG&tbnid=EkO4b49Jvg6aaM&vet=12ahUKEwjr9Zuy_86EAxXSgv0HHawqCAoQMygBegQIARBN..i&imgrefurl=https%3A%2F%2Fautomedia.investor.bg%2Fa%2F2-novini%2F43784-upotrebyavano-renault-clio-iii-struva-li-si&docid=rme63mMTwMi2YM&w=640&h=463&q=renault%20clio%203&ved=2ahUKEwjr9Zuy_86EAxXSgv0HHawqCAoQMygBegQIARBN", "Renault", 120000, "Clio", "P1917BX", "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", null, 2008 });

            migrationBuilder.InsertData(
                table: "ServiceHistories",
                columns: new[] { "Id", "CarId", "Date", "Mileage", "ServiceId", "TechnicianId" },
                values: new object[] { 1, 1, new DateTime(2023, 11, 29, 0, 0, 0, 0, DateTimeKind.Local), 180000, 6, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082");

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ServiceHistories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Technicians",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Technicians",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Technicians",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e");
        }
    }
}
