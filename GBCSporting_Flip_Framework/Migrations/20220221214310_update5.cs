using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GBCSporting_Flip_Framework.Migrations
{
    public partial class update5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Incidents",
                keyColumn: "IncidentId",
                keyValue: 1,
                column: "DateClosed",
                value: new DateTime(2022, 2, 21, 16, 43, 9, 982, DateTimeKind.Local).AddTicks(8447));

            migrationBuilder.UpdateData(
                table: "Incidents",
                keyColumn: "IncidentId",
                keyValue: 2,
                column: "DateClosed",
                value: new DateTime(2022, 2, 21, 16, 43, 9, 982, DateTimeKind.Local).AddTicks(8450));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "ReleaseDate",
                value: new DateTime(2022, 2, 21, 16, 43, 9, 982, DateTimeKind.Local).AddTicks(8433));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                column: "ReleaseDate",
                value: new DateTime(2022, 2, 21, 16, 43, 9, 982, DateTimeKind.Local).AddTicks(8436));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Incidents",
                keyColumn: "IncidentId",
                keyValue: 1,
                column: "DateClosed",
                value: new DateTime(2022, 2, 21, 16, 41, 29, 28, DateTimeKind.Local).AddTicks(6595));

            migrationBuilder.UpdateData(
                table: "Incidents",
                keyColumn: "IncidentId",
                keyValue: 2,
                column: "DateClosed",
                value: new DateTime(2022, 2, 21, 16, 41, 29, 28, DateTimeKind.Local).AddTicks(6598));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "ReleaseDate",
                value: new DateTime(2022, 2, 21, 16, 41, 29, 28, DateTimeKind.Local).AddTicks(6575));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                column: "ReleaseDate",
                value: new DateTime(2022, 2, 21, 16, 41, 29, 28, DateTimeKind.Local).AddTicks(6578));
        }
    }
}
