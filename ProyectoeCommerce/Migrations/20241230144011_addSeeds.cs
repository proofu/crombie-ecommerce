using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProyectoeCommerce.Migrations
{
    /// <inheritdoc />
    public partial class addSeeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "WishlistProductos",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCreacion",
                table: "WishlistProductos",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Id", "Descripcion", "Nombre", "Precio" },
                values: new object[,]
                {
                    { 1, "Laptop moderna y rápida", "Laptop", 800.99000000000001 },
                    { 2, "Teléfono inteligente con gran cámara", "Smartphone", 600.49000000000001 },
                    { 3, "Audífonos inalámbricos", "Audífonos", 150.0 },
                    { 4, "Monitor 4K UHD", "Monitor", 300.75 },
                    { 5, "Teclado para gamers", "Teclado Mecánico", 120.5 }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Email", "Nombre", "NumeroTelefono" },
                values: new object[,]
                {
                    { 1, "juan@example.com", "Juan Pérez", "1234567890" },
                    { 2, "ana@example.com", "Ana López", "9876543210" },
                    { 3, "carlos@example.com", "Carlos Díaz", "5551234567" },
                    { 4, "luisa@example.com", "Luisa Gómez", "4449876543" },
                    { 5, "maria@example.com", "María Torres", "3336669999" }
                });

            migrationBuilder.InsertData(
                table: "Wishlists",
                columns: new[] { "Id", "Nombre", "UsuarioId" },
                values: new object[,]
                {
                    { 1, "Regalos de Navidad", 1 },
                    { 2, "Compras de Tecnología", 2 },
                    { 3, "Hogar", 3 },
                    { 4, "Libros Favoritos", 4 },
                    { 5, "Deportes", 5 }
                });

            migrationBuilder.InsertData(
                table: "WishlistProductos",
                columns: new[] { "ProductoId", "WishlistId", "FechaCreacion", "FechaProductoAgregado", "Nombre" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 12, 30, 11, 40, 10, 309, DateTimeKind.Local).AddTicks(5833), new DateTime(2024, 12, 30, 11, 40, 10, 314, DateTimeKind.Local).AddTicks(2063), "Laptop para Regalo" },
                    { 2, 2, new DateTime(2024, 12, 30, 11, 40, 10, 314, DateTimeKind.Local).AddTicks(2716), new DateTime(2024, 12, 30, 11, 40, 10, 314, DateTimeKind.Local).AddTicks(2717), "Smartphone Moderno" },
                    { 3, 1, new DateTime(2024, 12, 30, 11, 40, 10, 314, DateTimeKind.Local).AddTicks(2707), new DateTime(2024, 12, 30, 11, 40, 10, 314, DateTimeKind.Local).AddTicks(2713), "Audífonos para Juan" },
                    { 4, 3, new DateTime(2024, 12, 30, 11, 40, 10, 314, DateTimeKind.Local).AddTicks(2719), new DateTime(2024, 12, 30, 11, 40, 10, 314, DateTimeKind.Local).AddTicks(2720), "Monitor para Hogar" },
                    { 5, 4, new DateTime(2024, 12, 30, 11, 40, 10, 314, DateTimeKind.Local).AddTicks(2722), new DateTime(2024, 12, 30, 11, 40, 10, 314, DateTimeKind.Local).AddTicks(2723), "Teclado Mecánico para Gaming" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WishlistProductos",
                keyColumns: new[] { "ProductoId", "WishlistId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "WishlistProductos",
                keyColumns: new[] { "ProductoId", "WishlistId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "WishlistProductos",
                keyColumns: new[] { "ProductoId", "WishlistId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "WishlistProductos",
                keyColumns: new[] { "ProductoId", "WishlistId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "WishlistProductos",
                keyColumns: new[] { "ProductoId", "WishlistId" },
                keyValues: new object[] { 5, 4 });

            migrationBuilder.DeleteData(
                table: "Wishlists",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Wishlists",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Wishlists",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Wishlists",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Wishlists",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "WishlistProductos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCreacion",
                table: "WishlistProductos",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");
        }
    }
}
