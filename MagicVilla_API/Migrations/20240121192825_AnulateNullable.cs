using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MagicVilla_API.Migrations
{
    /// <inheritdoc />
    public partial class AnulateNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: new Guid("032a560a-1565-467b-a241-3c7c8ca392d5"));

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: new Guid("73e40870-bfc0-41bd-9354-712791c579f3"));

            migrationBuilder.AlterColumn<string>(
                name: "DetalleEspecial",
                table: "NumeroVillas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "Amenidad", "Detalle", "FechaActualizacion", "FechaCreacion", "ImagenUrl", "MetrosCuadrados", "Nombre", "Ocupantes", "Tarifa" },
                values: new object[,]
                {
                    { new Guid("11bc30d0-3e22-486c-82f7-a85bafd4bd31"), "", "Detalle de la villa", new DateTime(2024, 1, 21, 16, 28, 25, 513, DateTimeKind.Local).AddTicks(7698), new DateTime(2024, 1, 21, 16, 28, 25, 513, DateTimeKind.Local).AddTicks(7697), "", 10, "Villa real", 5, 200.0 },
                    { new Guid("8af02c92-f161-4285-ab91-dc68427ab1a0"), "", "Detalle de la villa", new DateTime(2024, 1, 21, 16, 28, 25, 513, DateTimeKind.Local).AddTicks(7704), new DateTime(2024, 1, 21, 16, 28, 25, 513, DateTimeKind.Local).AddTicks(7703), "", 40, "Premium vista a la piscina", 4, 250.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: new Guid("11bc30d0-3e22-486c-82f7-a85bafd4bd31"));

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: new Guid("8af02c92-f161-4285-ab91-dc68427ab1a0"));

            migrationBuilder.AlterColumn<string>(
                name: "DetalleEspecial",
                table: "NumeroVillas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "Amenidad", "Detalle", "FechaActualizacion", "FechaCreacion", "ImagenUrl", "MetrosCuadrados", "Nombre", "Ocupantes", "Tarifa" },
                values: new object[,]
                {
                    { new Guid("032a560a-1565-467b-a241-3c7c8ca392d5"), "", "Detalle de la villa", new DateTime(2024, 1, 19, 23, 17, 26, 676, DateTimeKind.Local).AddTicks(889), new DateTime(2024, 1, 19, 23, 17, 26, 676, DateTimeKind.Local).AddTicks(889), "", 40, "Premium vista a la piscina", 4, 250.0 },
                    { new Guid("73e40870-bfc0-41bd-9354-712791c579f3"), "", "Detalle de la villa", new DateTime(2024, 1, 19, 23, 17, 26, 676, DateTimeKind.Local).AddTicks(883), new DateTime(2024, 1, 19, 23, 17, 26, 676, DateTimeKind.Local).AddTicks(882), "", 10, "Villa real", 5, 200.0 }
                });
        }
    }
}
