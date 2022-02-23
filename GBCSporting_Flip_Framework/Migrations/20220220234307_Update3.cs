using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GBCSporting_Flip_Framework.Migrations
{
    public partial class Update3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Incidents",
                keyColumn: "IncidentId",
                keyValue: 1,
                column: "DateClosed",
                value: new DateTime(2022, 2, 20, 18, 43, 7, 634, DateTimeKind.Local).AddTicks(2652));

            migrationBuilder.UpdateData(
                table: "Incidents",
                keyColumn: "IncidentId",
                keyValue: 2,
                column: "DateClosed",
                value: new DateTime(2022, 2, 20, 18, 43, 7, 634, DateTimeKind.Local).AddTicks(2655));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "ReleaseDate",
                value: new DateTime(2022, 2, 20, 18, 43, 7, 634, DateTimeKind.Local).AddTicks(2631));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                column: "ReleaseDate",
                value: new DateTime(2022, 2, 20, 18, 43, 7, 634, DateTimeKind.Local).AddTicks(2635));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Incidents",
                keyColumn: "IncidentId",
                keyValue: 1,
                column: "DateClosed",
                value: new DateTime(2022, 2, 20, 18, 24, 42, 298, DateTimeKind.Local).AddTicks(1792));

            migrationBuilder.UpdateData(
                table: "Incidents",
                keyColumn: "IncidentId",
                keyValue: 2,
                column: "DateClosed",
                value: new DateTime(2022, 2, 20, 18, 24, 42, 298, DateTimeKind.Local).AddTicks(1796));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "ReleaseDate",
                value: new DateTime(2022, 2, 20, 18, 24, 42, 298, DateTimeKind.Local).AddTicks(1770));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                column: "ReleaseDate",
                value: new DateTime(2022, 2, 20, 18, 24, 42, 298, DateTimeKind.Local).AddTicks(1773));
        }
    }
}
