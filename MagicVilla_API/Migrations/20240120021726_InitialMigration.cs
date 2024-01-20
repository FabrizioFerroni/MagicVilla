using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MagicVilla_API.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Villas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Detalle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Tarifa = table.Column<double>(type: "float", nullable: false),
                    Ocupantes = table.Column<int>(type: "int", nullable: false),
                    MetrosCuadrados = table.Column<int>(type: "int", nullable: false),
                    ImagenUrl = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Amenidad = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Villas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NumeroVillas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VillaNro = table.Column<int>(type: "int", nullable: false),
                    VillaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DetalleEspecial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NumeroVillas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NumeroVillas_Villas_VillaId",
                        column: x => x.VillaId,
                        principalTable: "Villas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "Amenidad", "Detalle", "FechaActualizacion", "FechaCreacion", "ImagenUrl", "MetrosCuadrados", "Nombre", "Ocupantes", "Tarifa" },
                values: new object[,]
                {
                    { new Guid("032a560a-1565-467b-a241-3c7c8ca392d5"), "", "Detalle de la villa", new DateTime(2024, 1, 19, 23, 17, 26, 676, DateTimeKind.Local).AddTicks(889), new DateTime(2024, 1, 19, 23, 17, 26, 676, DateTimeKind.Local).AddTicks(889), "", 40, "Premium vista a la piscina", 4, 250.0 },
                    { new Guid("73e40870-bfc0-41bd-9354-712791c579f3"), "", "Detalle de la villa", new DateTime(2024, 1, 19, 23, 17, 26, 676, DateTimeKind.Local).AddTicks(883), new DateTime(2024, 1, 19, 23, 17, 26, 676, DateTimeKind.Local).AddTicks(882), "", 10, "Villa real", 5, 200.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_NumeroVillas_VillaId",
                table: "NumeroVillas",
                column: "VillaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NumeroVillas");

            migrationBuilder.DropTable(
                name: "Villas");
        }
    }
}
