using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Proyecto.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Tarea",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categoria",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Descripcion", "Nombre", "Peso" },
                values: new object[,]
                {
                    { new Guid("78d2005c-20d4-4ada-980c-4e990fe23114"), "", "Actividades Pendientes", 20 },
                    { new Guid("78d2005c-20d4-4ada-980c-4e990fe23115"), "", "Actividades Privadas", 20 },
                    { new Guid("78d2005c-20d4-4ada-980c-4e990fe23116"), "", "Actividades Personales", 50 }
                });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaId", "CategoriaId", "Descripcion", "FechaCreacion", "Prioridad", "Titulo" },
                values: new object[,]
                {
                    { new Guid("78d2005c-20d4-4ada-980c-4e990fe23117"), new Guid("78d2005c-20d4-4ada-980c-4e990fe23116"), "", new DateTime(2024, 4, 2, 12, 39, 22, 469, DateTimeKind.Local).AddTicks(444), 2, "Actividades Personales.pilates" },
                    { new Guid("78d2005c-20d4-4ada-980c-4e990fe23118"), new Guid("78d2005c-20d4-4ada-980c-4e990fe23115"), "", new DateTime(2024, 4, 2, 12, 39, 22, 469, DateTimeKind.Local).AddTicks(439), 0, "Actividades Privadas.terminar Peli" },
                    { new Guid("78d2005c-20d4-4ada-980c-4e990fe23119"), new Guid("78d2005c-20d4-4ada-980c-4e990fe23114"), "", new DateTime(2024, 4, 2, 12, 39, 22, 469, DateTimeKind.Local).AddTicks(409), 1, "Actividades Pendientes.Estudiar" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("78d2005c-20d4-4ada-980c-4e990fe23117"));

            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("78d2005c-20d4-4ada-980c-4e990fe23118"));

            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("78d2005c-20d4-4ada-980c-4e990fe23119"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("78d2005c-20d4-4ada-980c-4e990fe23114"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("78d2005c-20d4-4ada-980c-4e990fe23115"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("78d2005c-20d4-4ada-980c-4e990fe23116"));

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Tarea",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categoria",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
