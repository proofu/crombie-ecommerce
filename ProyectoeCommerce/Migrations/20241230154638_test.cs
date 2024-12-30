using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProyectoeCommerce.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Precio = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NumeroTelefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wishlists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wishlists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wishlists_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WishlistProductos",
                columns: table => new
                {
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    WishlistId = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    FechaProductoAgregado = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WishlistProductos", x => new { x.ProductoId, x.WishlistId });
                    table.ForeignKey(
                        name: "FK_WishlistProductos_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WishlistProductos_Wishlists_WishlistId",
                        column: x => x.WishlistId,
                        principalTable: "Wishlists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                    { 1, 1, new DateTime(2024, 12, 30, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 30, 12, 0, 0, 0, DateTimeKind.Unspecified), "Laptop para Regalo" },
                    { 2, 2, new DateTime(2024, 12, 30, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 30, 12, 0, 0, 0, DateTimeKind.Unspecified), "Smartphone Moderno" },
                    { 3, 1, new DateTime(2024, 12, 30, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 30, 12, 0, 0, 0, DateTimeKind.Unspecified), "Audífonos para Juan" },
                    { 4, 3, new DateTime(2024, 12, 30, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 30, 12, 0, 0, 0, DateTimeKind.Unspecified), "Monitor para Hogar" },
                    { 5, 4, new DateTime(2024, 12, 30, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 30, 12, 0, 0, 0, DateTimeKind.Unspecified), "Teclado Mecánico para Gaming" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_WishlistProductos_WishlistId",
                table: "WishlistProductos",
                column: "WishlistId");

            migrationBuilder.CreateIndex(
                name: "IX_Wishlists_UsuarioId",
                table: "Wishlists",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WishlistProductos");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Wishlists");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
