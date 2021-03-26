using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace XYZ.Data.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastLoginDate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "MustChangePassword",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

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
                name: "TipoHabitacion",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Camas = table.Column<int>(type: "int", nullable: false),
                    Capacidad = table.Column<int>(type: "int", nullable: false),
                    Banhio = table.Column<int>(type: "int", nullable: false),
                    Salon = table.Column<bool>(type: "bit", nullable: false),
                    Terraza = table.Column<bool>(type: "bit", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoHabitacion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoHotel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoHotel", x => x.Id);
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
                    table.ForeignKey(
                        name: "FK_PrecioHabitacion_TipoHabitacion_TipoHabitacionId",
                        column: x => x.TipoHabitacionId,
                        principalTable: "TipoHabitacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hotel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Calificacion = table.Column<int>(type: "int", nullable: false),
                    TipoHotelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hotel_TipoHotel_TipoHotelId",
                        column: x => x.TipoHotelId,
                        principalTable: "TipoHotel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Habitacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Disponibilidad = table.Column<bool>(type: "bit", nullable: false),
                    TipoHabitacionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HotelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Habitacion_TipoHabitacion_TipoHabitacionId",
                        column: x => x.TipoHabitacionId,
                        principalTable: "TipoHabitacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReservaHabitacion",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FechaEntrega = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaSalida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Excedente = table.Column<int>(type: "int", nullable: false),
                    HabitacionId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservaHabitacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReservaHabitacion_AspNetUsers_ClientId",
                        column: x => x.ClientId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReservaHabitacion_Habitacion_HabitacionId",
                        column: x => x.HabitacionId,
                        principalTable: "Habitacion",
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
                name: "IX_Hotel_TipoHotelId",
                table: "Hotel",
                column: "TipoHotelId");

            migrationBuilder.CreateIndex(
                name: "IX_PrecioHabitacion_TemporadaId",
                table: "PrecioHabitacion",
                column: "TemporadaId");

            migrationBuilder.CreateIndex(
                name: "IX_PrecioHabitacion_TipoHabitacionId",
                table: "PrecioHabitacion",
                column: "TipoHabitacionId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservaHabitacion_ClientId",
                table: "ReservaHabitacion",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservaHabitacion_HabitacionId",
                table: "ReservaHabitacion",
                column: "HabitacionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PrecioHabitacion");

            migrationBuilder.DropTable(
                name: "ReservaHabitacion");

            migrationBuilder.DropTable(
                name: "Temporada");

            migrationBuilder.DropTable(
                name: "Habitacion");

            migrationBuilder.DropTable(
                name: "Hotel");

            migrationBuilder.DropTable(
                name: "TipoHabitacion");

            migrationBuilder.DropTable(
                name: "TipoHotel");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastLoginDate",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MustChangePassword",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "AspNetUsers");
        }
    }
}
