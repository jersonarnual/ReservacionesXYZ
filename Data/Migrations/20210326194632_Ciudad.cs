using Microsoft.EntityFrameworkCore.Migrations;

namespace XYZ.Data.Migrations
{
    public partial class Ciudad : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CiudadId",
                table: "Hotel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Ciudad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ciudad", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hotel_CiudadId",
                table: "Hotel",
                column: "CiudadId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hotel_Ciudad_CiudadId",
                table: "Hotel",
                column: "CiudadId",
                principalTable: "Ciudad",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hotel_Ciudad_CiudadId",
                table: "Hotel");

            migrationBuilder.DropTable(
                name: "Ciudad");

            migrationBuilder.DropIndex(
                name: "IX_Hotel_CiudadId",
                table: "Hotel");

            migrationBuilder.DropColumn(
                name: "CiudadId",
                table: "Hotel");
        }
    }
}
