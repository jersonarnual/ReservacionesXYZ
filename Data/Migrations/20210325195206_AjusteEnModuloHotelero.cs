using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace XYZ.Data.Migrations
{
    public partial class AjusteEnModuloHotelero : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Habitacion_Hotel_HotelId",
                table: "Habitacion");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservaHabitacion_AspNetUsers_ApplicationUserId1",
                table: "ReservaHabitacion");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservaHabitacion_Habitacion_HabitacionId",
                table: "ReservaHabitacion");

            migrationBuilder.DropIndex(
                name: "IX_ReservaHabitacion_ApplicationUserId1",
                table: "ReservaHabitacion");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "ReservaHabitacion");

            migrationBuilder.DropColumn(
                name: "ReservaHabitacionId",
                table: "Habitacion");

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

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "TipoHabitacion",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "HabitacionId",
                table: "ReservaHabitacion",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ApplicationUserId",
                table: "ReservaHabitacion",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "HotelId",
                table: "Habitacion",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "applicationUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastLoginDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MustChangePassword = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_applicationUsers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReservaHabitacion_ApplicationUserId",
                table: "ReservaHabitacion",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Habitacion_Hotel_HotelId",
                table: "Habitacion",
                column: "HotelId",
                principalTable: "Hotel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReservaHabitacion_applicationUsers_ApplicationUserId",
                table: "ReservaHabitacion",
                column: "ApplicationUserId",
                principalTable: "applicationUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReservaHabitacion_Habitacion_HabitacionId",
                table: "ReservaHabitacion",
                column: "HabitacionId",
                principalTable: "Habitacion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Habitacion_Hotel_HotelId",
                table: "Habitacion");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservaHabitacion_applicationUsers_ApplicationUserId",
                table: "ReservaHabitacion");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservaHabitacion_Habitacion_HabitacionId",
                table: "ReservaHabitacion");

            migrationBuilder.DropTable(
                name: "applicationUsers");

            migrationBuilder.DropIndex(
                name: "IX_ReservaHabitacion_ApplicationUserId",
                table: "ReservaHabitacion");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "TipoHabitacion");

            migrationBuilder.AlterColumn<int>(
                name: "HabitacionId",
                table: "ReservaHabitacion",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<Guid>(
                name: "ApplicationUserId",
                table: "ReservaHabitacion",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "ReservaHabitacion",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "HotelId",
                table: "Habitacion",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "ReservaHabitacionId",
                table: "Habitacion",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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

            migrationBuilder.CreateIndex(
                name: "IX_ReservaHabitacion_ApplicationUserId1",
                table: "ReservaHabitacion",
                column: "ApplicationUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Habitacion_Hotel_HotelId",
                table: "Habitacion",
                column: "HotelId",
                principalTable: "Hotel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
    }
}
