using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace XYZ.Data.Migrations
{
    public partial class AjusteRelacionModuloHotelero : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TipoHabitacion_PrecioHabitacion_PrecioHabitacionId",
                table: "TipoHabitacion");

            migrationBuilder.DropIndex(
                name: "IX_TipoHabitacion_PrecioHabitacionId",
                table: "TipoHabitacion");

            migrationBuilder.DropColumn(
                name: "PrecioHabitacionId",
                table: "TipoHabitacion");

            migrationBuilder.CreateIndex(
                name: "IX_PrecioHabitacion_TipoHabitacionId",
                table: "PrecioHabitacion",
                column: "TipoHabitacionId");

            migrationBuilder.AddForeignKey(
                name: "FK_PrecioHabitacion_TipoHabitacion_TipoHabitacionId",
                table: "PrecioHabitacion",
                column: "TipoHabitacionId",
                principalTable: "TipoHabitacion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PrecioHabitacion_TipoHabitacion_TipoHabitacionId",
                table: "PrecioHabitacion");

            migrationBuilder.DropIndex(
                name: "IX_PrecioHabitacion_TipoHabitacionId",
                table: "PrecioHabitacion");

            migrationBuilder.AddColumn<Guid>(
                name: "PrecioHabitacionId",
                table: "TipoHabitacion",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TipoHabitacion_PrecioHabitacionId",
                table: "TipoHabitacion",
                column: "PrecioHabitacionId");

            migrationBuilder.AddForeignKey(
                name: "FK_TipoHabitacion_PrecioHabitacion_PrecioHabitacionId",
                table: "TipoHabitacion",
                column: "PrecioHabitacionId",
                principalTable: "PrecioHabitacion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
