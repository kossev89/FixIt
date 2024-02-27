using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FixIt.Infrastructure.Migrations
{
    public partial class DomainTablesCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Car Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Make = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Car Manufacturer Information"),
                    Model = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Car Model Information"),
                    Year = table.Column<int>(type: "int", nullable: false, comment: "Car Year of Manufacture"),
                    PlateNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Car Registration Plate Number"),
                    Vin = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: true, comment: "Car Vehicle Identification Number"),
                    Mileage = table.Column<int>(type: "int", nullable: false, comment: "Car Current Mileage in km"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Car's owner"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Car Image")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Cars Table");

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Service Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false, comment: "Type of the Service"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Detailed description of the service, if needed"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Price for the service")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                },
                comment: "Table for Services");

            migrationBuilder.CreateTable(
                name: "Technicians",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Technician Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Technician Name"),
                    Specialization = table.Column<int>(type: "int", nullable: false, comment: "Technician Specialization")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Technicians", x => x.Id);
                },
                comment: "Technicians Table");

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Appointment Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Customer Identifier"),
                    CarId = table.Column<int>(type: "int", nullable: false, comment: "Car Identifier"),
                    ServiceId = table.Column<int>(type: "int", nullable: false, comment: "Service Identifier"),
                    TechnicianId = table.Column<int>(type: "int", nullable: false, comment: "Technician Identifier"),
                    DateAndTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Appointment Date"),
                    Status = table.Column<int>(type: "int", nullable: false, comment: "Appointment Status")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Appointments_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Technicians_TechnicianId",
                        column: x => x.TechnicianId,
                        principalTable: "Technicians",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Appointments table");

            migrationBuilder.CreateTable(
                name: "ServiceHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "ServiceHistory Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarId = table.Column<int>(type: "int", nullable: false, comment: "Car Identifier"),
                    ServiceId = table.Column<int>(type: "int", nullable: false, comment: "Service Identifier"),
                    TechnicianId = table.Column<int>(type: "int", nullable: false, comment: "Technician Identifier"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date of the service")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceHistories_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceHistories_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceHistories_Technicians_TechnicianId",
                        column: x => x.TechnicianId,
                        principalTable: "Technicians",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Table for the ServiceHistory");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_CarId",
                table: "Appointments",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_ServiceId",
                table: "Appointments",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_TechnicianId",
                table: "Appointments",
                column: "TechnicianId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_UserId",
                table: "Appointments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_UserId",
                table: "Cars",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceHistories_CarId",
                table: "ServiceHistories",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceHistories_ServiceId",
                table: "ServiceHistories",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceHistories_TechnicianId",
                table: "ServiceHistories",
                column: "TechnicianId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "ServiceHistories");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Technicians");
        }
    }
}
