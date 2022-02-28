using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GBCSporting_Flip_Framework.Migrations
{
    public partial class update6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOpened",
                table: "Incidents",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Incidents",
                keyColumn: "IncidentId",
                keyValue: 1,
                columns: new[] { "DateClosed", "DateOpened" },
                values: new object[] { new DateTime(2022, 2, 27, 23, 11, 24, 173, DateTimeKind.Local).AddTicks(1548), new DateTime(2022, 2, 27, 23, 11, 24, 173, DateTimeKind.Local).AddTicks(1546) });

            migrationBuilder.UpdateData(
                table: "Incidents",
                keyColumn: "IncidentId",
                keyValue: 2,
                columns: new[] { "DateClosed", "DateOpened" },
                values: new object[] { new DateTime(2022, 2, 27, 23, 11, 24, 173, DateTimeKind.Local).AddTicks(1551), new DateTime(2022, 2, 27, 23, 11, 24, 173, DateTimeKind.Local).AddTicks(1550) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "ReleaseDate",
                value: new DateTime(2022, 2, 27, 23, 11, 24, 173, DateTimeKind.Local).AddTicks(1504));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                column: "ReleaseDate",
                value: new DateTime(2022, 2, 27, 23, 11, 24, 173, DateTimeKind.Local).AddTicks(1509));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOpened",
                table: "Incidents",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "Incidents",
                keyColumn: "IncidentId",
                keyValue: 1,
                columns: new[] { "DateClosed", "DateOpened" },
                values: new object[] { new DateTime(2022, 2, 21, 16, 43, 9, 982, DateTimeKind.Local).AddTicks(8447), null });

            migrationBuilder.UpdateData(
                table: "Incidents",
                keyColumn: "IncidentId",
                keyValue: 2,
                columns: new[] { "DateClosed", "DateOpened" },
                values: new object[] { new DateTime(2022, 2, 21, 16, 43, 9, 982, DateTimeKind.Local).AddTicks(8450), null });

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
    }
}
