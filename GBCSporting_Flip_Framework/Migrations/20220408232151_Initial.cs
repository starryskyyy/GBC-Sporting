using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GBCSporting_Flip_Framework.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YearlyPrice = table.Column<double>(type: "float", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "Technicians",
                columns: table => new
                {
                    TechnicianId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TechName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TechEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TechPhone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Technicians", x => x.TechnicianId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(51)", maxLength: 51, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(51)", maxLength: 51, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(51)", maxLength: 51, nullable: false),
                    City = table.Column<string>(type: "nvarchar(51)", maxLength: 51, nullable: false),
                    State = table.Column<string>(type: "nvarchar(51)", maxLength: 51, nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    CustEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustPhone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_Customers_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Incidents",
                columns: table => new
                {
                    IncidentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TechnicianId = table.Column<int>(type: "int", nullable: true),
                    DateOpened = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateClosed = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incidents", x => x.IncidentId);
                    table.ForeignKey(
                        name: "FK_Incidents_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Incidents_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Incidents_Technicians_TechnicianId",
                        column: x => x.TechnicianId,
                        principalTable: "Technicians",
                        principalColumn: "TechnicianId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Registrations",
                columns: table => new
                {
                    RegistrationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registrations", x => x.RegistrationId);
                    table.ForeignKey(
                        name: "FK_Registrations_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Registrations_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryId", "CountryName" },
                values: new object[,]
                {
                    { 1, "Austria" },
                    { 2, "Canada" },
                    { 3, "France" },
                    { 4, "Germany" },
                    { 5, "India" },
                    { 6, "Iran" },
                    { 7, "Italy" },
                    { 8, "Lithuania" },
                    { 9, "Mexico" },
                    { 10, "New Zealand" },
                    { 11, "Russia" },
                    { 12, "Singapore" },
                    { 13, "Turkey" },
                    { 14, "United States" },
                    { 15, "Vietnam" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Code", "Name", "ReleaseDate", "YearlyPrice" },
                values: new object[,]
                {
                    { 1, "H332K", "Draft Manager 1.0", new DateTime(2022, 4, 8, 19, 21, 50, 973, DateTimeKind.Local).AddTicks(205), 6.6500000000000004 },
                    { 2, "TVE32", "League Scheduler 1.0", new DateTime(2022, 4, 8, 19, 21, 50, 973, DateTimeKind.Local).AddTicks(208), 5.54 }
                });

            migrationBuilder.InsertData(
                table: "Technicians",
                columns: new[] { "TechnicianId", "TechEmail", "TechName", "TechPhone" },
                values: new object[,]
                {
                    { 1, "sam.brooks@gmail.com", "Samuel Brooks", "342 234-4223" },
                    { 2, "r.pharo@gmail.com", "Richard Pharo", "542 112-4367" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Address", "City", "CountryId", "CustEmail", "CustPhone", "FirstName", "LastName", "PostalCode", "State" },
                values: new object[,]
                {
                    { 1, "67 Tikhvinskaya street", "Moscow", 11, "elizaveta.vygovskaia@georgebrown.ca", "943 234-1234", "Elizaveta", "Vygovskaia", "140002", "Moskovskaya oblast" },
                    { 2, "3852 Eglinton Avenue", "Toronto", 2, "jordon.jensen@georgebrown.ca", "506 312-9547", "Jordon", "Jensen", "M4P 1A6", "Ontario" },
                    { 3, "532 Hoang Hoa Tham", "Ha Noi", 15, "phuong.hoang2@georgebrown.ca", " 564 123-1234", "Phuong", "Hoang", "901011", "Hanoi" },
                    { 4, "3422 Bay Street", "Toronto", 2, "truongthi.bui@georgebrown.ca", "647 893-3833", "Truong", "Thi Bui", "M5J 2R8", "Ontario" }
                });

            migrationBuilder.InsertData(
                table: "Incidents",
                columns: new[] { "IncidentId", "CustomerId", "DateClosed", "DateOpened", "Description", "ProductId", "TechnicianId", "Title" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(2022, 4, 8, 19, 21, 50, 973, DateTimeKind.Local).AddTicks(224), new DateTime(2022, 4, 8, 19, 21, 50, 973, DateTimeKind.Local).AddTicks(222), "When trying to install getting error 123", 2, 1, "Could not install" },
                    { 2, 1, new DateTime(2022, 4, 8, 19, 21, 50, 973, DateTimeKind.Local).AddTicks(227), new DateTime(2022, 4, 8, 19, 21, 50, 973, DateTimeKind.Local).AddTicks(225), "Program crash almost instantly when I open it", 1, 2, "Error launching program" }
                });

            migrationBuilder.InsertData(
                table: "Registrations",
                columns: new[] { "RegistrationId", "CustomerId", "ProductId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CountryId",
                table: "Customers",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_CustomerId",
                table: "Incidents",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_ProductId",
                table: "Incidents",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_TechnicianId",
                table: "Incidents",
                column: "TechnicianId");

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_CustomerId",
                table: "Registrations",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_ProductId",
                table: "Registrations",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Incidents");

            migrationBuilder.DropTable(
                name: "Registrations");

            migrationBuilder.DropTable(
                name: "Technicians");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
