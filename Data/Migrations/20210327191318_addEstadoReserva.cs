using Microsoft.EntityFrameworkCore.Migrations;

namespace XYZ.Data.Migrations
{
    public partial class addEstadoReserva : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Disponibilidad",
                table: "Habitacion");

            migrationBuilder.RenameColumn(
                name: "Calificacion",
                table: "Hotel",
                newName: "CupoMaximo");

            migrationBuilder.AddColumn<int>(
                name: "EstadoReservaId",
                table: "ReservaHabitacion",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Valor",
                table: "ReservaHabitacion",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Hotel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EstadoReserva",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoReserva", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReservaHabitacion_EstadoReservaId",
                table: "ReservaHabitacion",
                column: "EstadoReservaId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReservaHabitacion_EstadoReserva_EstadoReservaId",
                table: "ReservaHabitacion",
                column: "EstadoReservaId",
                principalTable: "EstadoReserva",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReservaHabitacion_EstadoReserva_EstadoReservaId",
                table: "ReservaHabitacion");

            migrationBuilder.DropTable(
                name: "EstadoReserva");

            migrationBuilder.DropIndex(
                name: "IX_ReservaHabitacion_EstadoReservaId",
                table: "ReservaHabitacion");

            migrationBuilder.DropColumn(
                name: "EstadoReservaId",
                table: "ReservaHabitacion");

            migrationBuilder.DropColumn(
                name: "Valor",
                table: "ReservaHabitacion");

            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Hotel");

            migrationBuilder.RenameColumn(
                name: "CupoMaximo",
                table: "Hotel",
                newName: "Calificacion");

            migrationBuilder.AddColumn<bool>(
                name: "Disponibilidad",
                table: "Habitacion",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
