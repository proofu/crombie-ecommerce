using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoeCommerce.Migrations
{
    /// <inheritdoc />
    public partial class modifyuserauth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Usuarios",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "Nombre", "Password", "Role" },
                values: new object[] { "john.doe@example.com", "John Doe", "hashed_password_1", "User" });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Email", "Nombre", "Password", "Role" },
                values: new object[] { "jane.smith@example.com", "Jane Smith", "hashed_password_2", "User" });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Email", "Nombre", "NumeroTelefono", "Password", "Role" },
                values: new object[] { "alice.johnson@example.com", "Alice Johnson", "4567891230", "hashed_password_3", "User" });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Email", "Nombre", "NumeroTelefono", "Password", "Role" },
                values: new object[] { "bob.brown@example.com", "Bob Brown", "3216549870", "hashed_password_4", "User" });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Email", "Nombre", "NumeroTelefono", "Password", "Role" },
                values: new object[] { "charlie.davis@example.com", "Charlie Davis", "6549873210", "hashed_password_5", "User" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Usuarios");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "Nombre" },
                values: new object[] { "juan@example.com", "Juan Pérez" });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Email", "Nombre" },
                values: new object[] { "ana@example.com", "Ana López" });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Email", "Nombre", "NumeroTelefono" },
                values: new object[] { "carlos@example.com", "Carlos Díaz", "5551234567" });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Email", "Nombre", "NumeroTelefono" },
                values: new object[] { "luisa@example.com", "Luisa Gómez", "4449876543" });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Email", "Nombre", "NumeroTelefono" },
                values: new object[] { "maria@example.com", "María Torres", "3336669999" });
        }
    }
}
