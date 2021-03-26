using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace XYZ.Data.Migrations
{
    public partial class AjusteErrorTipoHabitacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TipoHabitacionViewModelId",
                table: "TipoHabitacion",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TipoHabitacionViewModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Camas = table.Column<int>(type: "int", nullable: false),
                    Capacidad = table.Column<int>(type: "int", nullable: false),
                    Banhio = table.Column<int>(type: "int", nullable: false),
                    Salon = table.Column<bool>(type: "bit", nullable: false),
                    Terraza = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoHabitacionViewModel", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TipoHabitacion_TipoHabitacionViewModelId",
                table: "TipoHabitacion",
                column: "TipoHabitacionViewModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_TipoHabitacion_TipoHabitacionViewModel_TipoHabitacionViewModelId",
                table: "TipoHabitacion",
                column: "TipoHabitacionViewModelId",
                principalTable: "TipoHabitacionViewModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TipoHabitacion_TipoHabitacionViewModel_TipoHabitacionViewModelId",
                table: "TipoHabitacion");

            migrationBuilder.DropTable(
                name: "TipoHabitacionViewModel");

            migrationBuilder.DropIndex(
                name: "IX_TipoHabitacion_TipoHabitacionViewModelId",
                table: "TipoHabitacion");

            migrationBuilder.DropColumn(
                name: "TipoHabitacionViewModelId",
                table: "TipoHabitacion");
        }
    }
}
