using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace XYZ.Data.Migrations
{
    public partial class AddRelationApplicationUserV3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReservaHabitacion_applicationUsers_UserId",
                table: "ReservaHabitacion");

            migrationBuilder.DropTable(
                name: "applicationUsers");

            migrationBuilder.DropIndex(
                name: "IX_ReservaHabitacion_UserId",
                table: "ReservaHabitacion");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ReservaHabitacion");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "ReservaHabitacion",
                type: "nvarchar(450)",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReservaHabitacion_AspNetUsers_ApplicationUserId",
                table: "ReservaHabitacion");

            migrationBuilder.DropIndex(
                name: "IX_ReservaHabitacion_ApplicationUserId",
                table: "ReservaHabitacion");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "ReservaHabitacion");

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

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "ReservaHabitacion",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "applicationUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    LastLoginDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    MustChangePassword = table.Column<bool>(type: "bit", nullable: false),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_applicationUsers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReservaHabitacion_UserId",
                table: "ReservaHabitacion",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReservaHabitacion_applicationUsers_UserId",
                table: "ReservaHabitacion",
                column: "UserId",
                principalTable: "applicationUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
