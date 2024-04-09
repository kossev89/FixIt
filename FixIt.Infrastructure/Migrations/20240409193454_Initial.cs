using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FixIt.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

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
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Car Image"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Soft delete property")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                },
                comment: "Cars Table");

            migrationBuilder.CreateTable(
                name: "Technicians",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Technician Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Identity User Identification"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Technician Name"),
                    Specialization = table.Column<int>(type: "int", nullable: false, comment: "Technician Specialization"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Technician Soft Delete Property")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Technicians", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Technicians_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
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
                    TechnicianId = table.Column<int>(type: "int", nullable: true, comment: "Technician Identifier"),
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
                        onDelete: ReferentialAction.NoAction);
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
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Appointments_Technicians_TechnicianId",
                        column: x => x.TechnicianId,
                        principalTable: "Technicians",
                        principalColumn: "Id");
                },
                comment: "Appointments table");

            migrationBuilder.CreateTable(
                name: "ServiceHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "ServiceHistory Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "ServceHistory Customer Identifier"),
                    CarId = table.Column<int>(type: "int", nullable: false, comment: "Car Identifier"),
                    ServiceId = table.Column<int>(type: "int", nullable: false, comment: "Service Identifier"),
                    TechnicianId = table.Column<int>(type: "int", nullable: false, comment: "Technician Identifier"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date of the service"),
                    Mileage = table.Column<int>(type: "int", nullable: false, comment: "Current car mileage")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceHistories_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ServiceHistories_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ServiceHistories_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ServiceHistories_Technicians_TechnicianId",
                        column: x => x.TechnicianId,
                        principalTable: "Technicians",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                },
                comment: "Table for the ServiceHistory");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "3e0f5536-ea82-4817-9d63-861cc93427c6", 0, "fdca5ee5-9bb7-4921-a83f-b2307c01430d", "technician2@mail.com", false, false, null, "technician2@mail.com", "technician2@mail.com", "AQAAAAEAACcQAAAAEO8W2XAXnTfjvNiHbty44Pk4QYZVb53Inm2OmvN6TnjHVCWlfemFdGhMogcFLmDVRg==", null, false, "974d8093-d827-4346-9eae-cc358e0e5a1c", false, "technician2@mail.com" },
                    { "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", 0, "7a9955db-0186-47b4-a0d6-b6be27c2725a", "customer@mail.com", false, false, null, "customer@mail.com", "customer@mail.com", "AQAAAAEAACcQAAAAEKGhhH1XGgJrkV2St+vjw3iItx+I+4VtjsvhbNePiNfwmAi5m30hf+FLpmKeX39Hyw==", null, false, "8332b224-ee28-4db1-9678-2ecc82e7baa9", false, "customer@mail.com" },
                    { "99ae7f52-08a1-4c41-98f6-0934ab9eeced", 0, "319bb0af-824f-49dd-a75a-d005c99106ee", "technician1@mail.com", false, false, null, "technician1@mail.com", "technician1@mail.com", "AQAAAAEAACcQAAAAEAPyA3K/kE5IG8TFNgSrV4j8lycLyUmSB2mHtD/uVrXu6c6Qtsv9cKNFqAs6oiqskA==", null, false, "26a76ec6-4bd2-4385-b8be-d75889290c00", false, "technician1@mail.com" },
                    { "b98a765c-94d6-4520-95ae-42503a95445d", 0, "b09328d9-0e26-4840-ac47-f6cdc7a8aea6", "technician3@mail.com", false, false, null, "technician3@mail.com", "technician3@mail.com", "AQAAAAEAACcQAAAAELx6TvT6WDBpqoTpipCLQ8SqjkzRROA865woy0J2O3tegrUkVUcRgDew7YC1FjXXLA==", null, false, "e8247c5c-082b-4910-a72e-633df8ca1651", false, "technician3@mail.com" },
                    { "dea12856-c198-4129-b3f3-b893d8395082", 0, "355a7489-74d3-426b-801f-5e938c7b7b59", "admin@mail.com", false, false, null, "admin@mail.com", "admin@mail.com", "AQAAAAEAACcQAAAAEAG0wMH+62weEriO8so+hkJW29f/a3NTVAoZIrbSdJFXBLuKYaZCK+fo9c2xZKsdPw==", null, false, "81d7567d-650e-4d54-8f3a-9f776d89864c", false, "admin@mail.com" }
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
                table: "Cars",
                columns: new[] { "Id", "ImageUrl", "IsDeleted", "Make", "Mileage", "Model", "PlateNumber", "UserId", "Vin", "Year" },
                values: new object[,]
                {
                    { 1, "https://www.google.com/imgres?imgurl=https%3A%2F%2Fimg.autoabc.lv%2FToyota-Avensis%2FToyota-Avensis_2003_Hecbeks_15102250637_3.jpg&tbnid=3pELpEqszmhQ8M&vet=12ahUKEwiHqLvu_s6EAxX74bsIHVDBCw8QMygIegQIARBf..i&imgrefurl=https%3A%2F%2Fwww.auto-abc.eu%2FToyota-Avensis%2Fg275-2003&docid=Hbz18f1fC2wffM&w=1000&h=547&q=avensis%20t25&ved=2ahUKEwiHqLvu_s6EAxX74bsIHVDBCw8QMygIegQIARBf", false, "Toyota", 180000, "Avensis", "P3366BC", "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", null, 2005 },
                    { 2, "https://www.google.com/imgres?imgurl=https%3A%2F%2Fautomedia.investor.bg%2Fmedia%2Ffiles%2Fresized%2Fuploadedfiles%2F640x0%2F244%2F5afbc0f7c9b507828db312f5101c9244-98.JPG&tbnid=EkO4b49Jvg6aaM&vet=12ahUKEwjr9Zuy_86EAxXSgv0HHawqCAoQMygBegQIARBN..i&imgrefurl=https%3A%2F%2Fautomedia.investor.bg%2Fa%2F2-novini%2F43784-upotrebyavano-renault-clio-iii-struva-li-si&docid=rme63mMTwMi2YM&w=640&h=463&q=renault%20clio%203&ved=2ahUKEwjr9Zuy_86EAxXSgv0HHawqCAoQMygBegQIARBN", false, "Renault", 120000, "Clio", "P1917BX", "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", null, 2008 }
                });

            migrationBuilder.InsertData(
                table: "Technicians",
                columns: new[] { "Id", "IsDeleted", "Name", "Specialization", "UserId" },
                values: new object[,]
                {
                    { 1, false, "John Doe", 3, "99ae7f52-08a1-4c41-98f6-0934ab9eeced" },
                    { 2, false, "Jane Doe", 0, "3e0f5536-ea82-4817-9d63-861cc93427c6" },
                    { 3, false, "Don Johns", 4, "b98a765c-94d6-4520-95ae-42503a95445d" }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "CarId", "DateAndTime", "ServiceId", "Status", "TechnicianId", "UserId" },
                values: new object[] { 1, 1, new DateTime(2024, 4, 10, 22, 34, 53, 701, DateTimeKind.Local).AddTicks(4036), 1, 0, 1, "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e" });

            migrationBuilder.InsertData(
                table: "ServiceHistories",
                columns: new[] { "Id", "CarId", "Date", "Mileage", "ServiceId", "TechnicianId", "UserId" },
                values: new object[] { 1, 1, new DateTime(2024, 1, 9, 0, 0, 0, 0, DateTimeKind.Local), 180000, 6, 2, "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e" });

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
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

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

            migrationBuilder.CreateIndex(
                name: "IX_ServiceHistories_UserId",
                table: "ServiceHistories",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Technicians_UserId",
                table: "Technicians",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ServiceHistories");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Technicians");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
