using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MagicVilla_API.Migrations
{
    /// <inheritdoc />
    public partial class UserMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: new Guid("11bc30d0-3e22-486c-82f7-a85bafd4bd31"));

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: new Guid("8af02c92-f161-4285-ab91-dc68427ab1a0"));

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rol = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "Amenidad", "Detalle", "FechaActualizacion", "FechaCreacion", "ImagenUrl", "MetrosCuadrados", "Nombre", "Ocupantes", "Tarifa" },
                values: new object[,]
                {
                    { new Guid("85157e58-33a7-4825-9fa9-ee2328dd119b"), "", "Detalle de la villa", new DateTime(2024, 1, 29, 18, 0, 38, 807, DateTimeKind.Local).AddTicks(8551), new DateTime(2024, 1, 29, 18, 0, 38, 807, DateTimeKind.Local).AddTicks(8550), "", 10, "Villa real", 5, 200.0 },
                    { new Guid("e9eb8f88-d937-4177-97a6-8bea2d88a06c"), "", "Detalle de la villa", new DateTime(2024, 1, 29, 18, 0, 38, 807, DateTimeKind.Local).AddTicks(8557), new DateTime(2024, 1, 29, 18, 0, 38, 807, DateTimeKind.Local).AddTicks(8556), "", 40, "Premium vista a la piscina", 4, 250.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: new Guid("85157e58-33a7-4825-9fa9-ee2328dd119b"));

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: new Guid("e9eb8f88-d937-4177-97a6-8bea2d88a06c"));

            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "Amenidad", "Detalle", "FechaActualizacion", "FechaCreacion", "ImagenUrl", "MetrosCuadrados", "Nombre", "Ocupantes", "Tarifa" },
                values: new object[,]
                {
                    { new Guid("11bc30d0-3e22-486c-82f7-a85bafd4bd31"), "", "Detalle de la villa", new DateTime(2024, 1, 21, 16, 28, 25, 513, DateTimeKind.Local).AddTicks(7698), new DateTime(2024, 1, 21, 16, 28, 25, 513, DateTimeKind.Local).AddTicks(7697), "", 10, "Villa real", 5, 200.0 },
                    { new Guid("8af02c92-f161-4285-ab91-dc68427ab1a0"), "", "Detalle de la villa", new DateTime(2024, 1, 21, 16, 28, 25, 513, DateTimeKind.Local).AddTicks(7704), new DateTime(2024, 1, 21, 16, 28, 25, 513, DateTimeKind.Local).AddTicks(7703), "", 40, "Premium vista a la piscina", 4, 250.0 }
                });
        }
    }
}
