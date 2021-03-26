using Microsoft.EntityFrameworkCore.Migrations;

namespace XYZ.Data.Migrations
{
    public partial class AddRelationApplicationUserV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReservaHabitacion_ApplicationUser_UserId",
                table: "ReservaHabitacion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUser",
                table: "ApplicationUser");

            migrationBuilder.RenameTable(
                name: "ApplicationUser",
                newName: "applicationUsers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_applicationUsers",
                table: "applicationUsers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReservaHabitacion_applicationUsers_UserId",
                table: "ReservaHabitacion",
                column: "UserId",
                principalTable: "applicationUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReservaHabitacion_applicationUsers_UserId",
                table: "ReservaHabitacion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_applicationUsers",
                table: "applicationUsers");

            migrationBuilder.RenameTable(
                name: "applicationUsers",
                newName: "ApplicationUser");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUser",
                table: "ApplicationUser",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReservaHabitacion_ApplicationUser_UserId",
                table: "ReservaHabitacion",
                column: "UserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
