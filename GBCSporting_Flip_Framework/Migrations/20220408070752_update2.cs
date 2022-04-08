using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GBCSporting_Flip_Framework.Migrations
{
    public partial class update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Incidents",
                keyColumn: "IncidentId",
                keyValue: 1,
                columns: new[] { "DateClosed", "DateOpened" },
                values: new object[] { new DateTime(2022, 4, 8, 3, 7, 52, 163, DateTimeKind.Local).AddTicks(680), new DateTime(2022, 4, 8, 3, 7, 52, 163, DateTimeKind.Local).AddTicks(677) });

            migrationBuilder.UpdateData(
                table: "Incidents",
                keyColumn: "IncidentId",
                keyValue: 2,
                columns: new[] { "DateClosed", "DateOpened" },
                values: new object[] { new DateTime(2022, 4, 8, 3, 7, 52, 163, DateTimeKind.Local).AddTicks(683), new DateTime(2022, 4, 8, 3, 7, 52, 163, DateTimeKind.Local).AddTicks(681) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "ReleaseDate",
                value: new DateTime(2022, 4, 8, 3, 7, 52, 163, DateTimeKind.Local).AddTicks(653));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                column: "ReleaseDate",
                value: new DateTime(2022, 4, 8, 3, 7, 52, 163, DateTimeKind.Local).AddTicks(658));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Incidents",
                keyColumn: "IncidentId",
                keyValue: 1,
                columns: new[] { "DateClosed", "DateOpened" },
                values: new object[] { new DateTime(2022, 4, 8, 2, 52, 51, 86, DateTimeKind.Local).AddTicks(6108), new DateTime(2022, 4, 8, 2, 52, 51, 86, DateTimeKind.Local).AddTicks(6105) });

            migrationBuilder.UpdateData(
                table: "Incidents",
                keyColumn: "IncidentId",
                keyValue: 2,
                columns: new[] { "DateClosed", "DateOpened" },
                values: new object[] { new DateTime(2022, 4, 8, 2, 52, 51, 86, DateTimeKind.Local).AddTicks(6111), new DateTime(2022, 4, 8, 2, 52, 51, 86, DateTimeKind.Local).AddTicks(6109) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "ReleaseDate",
                value: new DateTime(2022, 4, 8, 2, 52, 51, 86, DateTimeKind.Local).AddTicks(6091));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                column: "ReleaseDate",
                value: new DateTime(2022, 4, 8, 2, 52, 51, 86, DateTimeKind.Local).AddTicks(6093));
        }
    }
}
