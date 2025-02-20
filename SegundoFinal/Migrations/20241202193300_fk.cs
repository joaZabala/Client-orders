using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SegundoFinal.Migrations
{
    /// <inheritdoc />
    public partial class fk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_HistorialAcciones_UsuarioId",
                table: "HistorialAcciones",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_HistorialAcciones_Clientes_UsuarioId",
                table: "HistorialAcciones",
                column: "UsuarioId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HistorialAcciones_Clientes_UsuarioId",
                table: "HistorialAcciones");

            migrationBuilder.DropIndex(
                name: "IX_HistorialAcciones_UsuarioId",
                table: "HistorialAcciones");
        }
    }
}
