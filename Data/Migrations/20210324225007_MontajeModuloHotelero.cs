using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace XYZ.Data.Migrations
{
    public partial class MontajeModuloHotelero : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hotel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Calificacion = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReservaHabitacion",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FechaEntrega = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaSalida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Excedente = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservaHabitacion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Temporada",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFinal = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Temporada", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PrecioHabitacion",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Precio = table.Column<int>(type: "int", nullable: false),
                    TemporadaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipoHabitacionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrecioHabitacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrecioHabitacion_Temporada_TemporadaId",
                        column: x => x.TemporadaId,
                        principalTable: "Temporada",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TipoHabitacion",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Camas = table.Column<int>(type: "int", nullable: false),
                    Capacidad = table.Column<int>(type: "int", nullable: false),
                    Banhio = table.Column<int>(type: "int", nullable: false),
                    Salon = table.Column<bool>(type: "bit", nullable: false),
                    Terraza = table.Column<bool>(type: "bit", nullable: false),
                    PrecioHabitacionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoHabitacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TipoHabitacion_PrecioHabitacion_PrecioHabitacionId",
                        column: x => x.PrecioHabitacionId,
                        principalTable: "PrecioHabitacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Habitacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoHabitacionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HotelId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habitacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Habitacion_Hotel_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Habitacion_TipoHabitacion_TipoHabitacionId",
                        column: x => x.TipoHabitacionId,
                        principalTable: "TipoHabitacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Habitacion_HotelId",
                table: "Habitacion",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_Habitacion_TipoHabitacionId",
                table: "Habitacion",
                column: "TipoHabitacionId");

            migrationBuilder.CreateIndex(
                name: "IX_PrecioHabitacion_TemporadaId",
                table: "PrecioHabitacion",
                column: "TemporadaId");

            migrationBuilder.CreateIndex(
                name: "IX_TipoHabitacion_PrecioHabitacionId",
                table: "TipoHabitacion",
                column: "PrecioHabitacionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Habitacion");

            migrationBuilder.DropTable(
                name: "ReservaHabitacion");

            migrationBuilder.DropTable(
                name: "Hotel");

            migrationBuilder.DropTable(
                name: "TipoHabitacion");

            migrationBuilder.DropTable(
                name: "PrecioHabitacion");

            migrationBuilder.DropTable(
                name: "Temporada");
        }
    }
}
