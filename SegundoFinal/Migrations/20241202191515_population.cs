using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SegundoFinal.Migrations
{
    /// <inheritdoc />
    public partial class population : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Precio",
                table: "Productos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "Id", "Descripcion", "FechaCreacion", "Nombre" },
                values: new object[] { 1, "productos de deportes", new DateTime(2024, 12, 2, 0, 0, 0, 0, DateTimeKind.Local), "Deportes" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Precio",
                table: "Productos");
        }
    }
}
