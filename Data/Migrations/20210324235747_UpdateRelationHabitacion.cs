using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace XYZ.Data.Migrations
{
    public partial class UpdateRelationHabitacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReservaHabitacion_AspNetUsers_ApplicationUserId",
                table: "ReservaHabitacion");

            migrationBuilder.DropIndex(
                name: "IX_ReservaHabitacion_ApplicationUserId",
                table: "ReservaHabitacion");

            migrationBuilder.AlterColumn<Guid>(
                name: "ApplicationUserId",
                table: "ReservaHabitacion",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "ReservaHabitacion",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HabitacionId",
                table: "ReservaHabitacion",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ReservaHabitacionId",
                table: "Habitacion",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ReservaHabitacion_ApplicationUserId1",
                table: "ReservaHabitacion",
                column: "ApplicationUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_ReservaHabitacion_HabitacionId",
                table: "ReservaHabitacion",
                column: "HabitacionId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReservaHabitacion_AspNetUsers_ApplicationUserId1",
                table: "ReservaHabitacion",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReservaHabitacion_Habitacion_HabitacionId",
                table: "ReservaHabitacion",
                column: "HabitacionId",
                principalTable: "Habitacion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReservaHabitacion_AspNetUsers_ApplicationUserId1",
                table: "ReservaHabitacion");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservaHabitacion_Habitacion_HabitacionId",
                table: "ReservaHabitacion");

            migrationBuilder.DropIndex(
                name: "IX_ReservaHabitacion_ApplicationUserId1",
                table: "ReservaHabitacion");

            migrationBuilder.DropIndex(
                name: "IX_ReservaHabitacion_HabitacionId",
                table: "ReservaHabitacion");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "ReservaHabitacion");

            migrationBuilder.DropColumn(
                name: "HabitacionId",
                table: "ReservaHabitacion");

            migrationBuilder.DropColumn(
                name: "ReservaHabitacionId",
                table: "Habitacion");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "ReservaHabitacion",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReservaHabitacion_ApplicationUserId",
                table: "ReservaHabitacion",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReservaHabitacion_AspNetUsers_ApplicationUserId",
                table: "ReservaHabitacion",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
