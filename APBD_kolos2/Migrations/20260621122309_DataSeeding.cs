using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace APBD_kolos2.Migrations
{
    /// <inheritdoc />
    public partial class DataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Client",
                columns: new[] { "ClientId", "DateOfBirth", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jan", "Kowalski" },
                    { 2, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dawid", "Zygzak" }
                });

            migrationBuilder.InsertData(
                table: "Mechanic",
                columns: new[] { "MechanicId", "FirstName", "LastName", "LicenseNumber" },
                values: new object[,]
                {
                    { 1, "Jan", "Kowalski", "123456789" },
                    { 2, "Dawid", "Zygzak", "987654321" }
                });

            migrationBuilder.InsertData(
                table: "Service",
                columns: new[] { "ServiceId", "BaseFee", "Name" },
                values: new object[,]
                {
                    { 1, 200m, "Zmiana oleju" },
                    { 2, 100m, "Przeglad" }
                });

            migrationBuilder.InsertData(
                table: "Visit",
                columns: new[] { "VisitId", "ClientId", "Date", "MechanicId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, 2, new DateTime(2022, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 }
                });

            migrationBuilder.InsertData(
                table: "Visit_Service",
                columns: new[] { "ServiceId", "VisitId", "ServiceFee" },
                values: new object[,]
                {
                    { 1, 1, 200m },
                    { 2, 1, 100m },
                    { 1, 2, 200m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Visit_Service",
                keyColumns: new[] { "ServiceId", "VisitId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Visit_Service",
                keyColumns: new[] { "ServiceId", "VisitId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "Visit_Service",
                keyColumns: new[] { "ServiceId", "VisitId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "ServiceId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "ServiceId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Visit",
                keyColumn: "VisitId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Visit",
                keyColumn: "VisitId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Client",
                keyColumn: "ClientId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Client",
                keyColumn: "ClientId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Mechanic",
                keyColumn: "MechanicId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Mechanic",
                keyColumn: "MechanicId",
                keyValue: 2);
        }
    }
}
