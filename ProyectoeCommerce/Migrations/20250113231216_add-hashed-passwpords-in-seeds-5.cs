using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProyectoeCommerce.Migrations
{
    /// <inheritdoc />
    public partial class addhashedpasswpordsinseeds5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Usuarios",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Usuarios",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "Nombre", "Password", "Role" },
                values: new object[] { "admin1@example.com", "Admin User 1", "AQAAAAIAAYagAAAAEHjAWkN+Y7Q1oce4X8NtZAUwKU4aNWVPuyMMmtvZzlP76vdZGQfmD6k/lC/h5t61Uw==", "Admin" });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Email", "Nombre", "NumeroTelefono", "Password", "Role" },
                values: new object[] { "admin2@example.com", "Admin User 2", "1234567891", "AQAAAAIAAYagAAAAENOixQmbDMm4i3SWt/rrymBid0PzUNf0TrpYYLxQ+GxNbeBSU86IP7KredW0lxnU6Q==", "Admin" });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Email", "Nombre", "NumeroTelefono", "Password" },
                values: new object[] { "testuser1@example.com", "Test User 1", "1234567892", "AQAAAAIAAYagAAAAEPRKFHl6v++8Jsyg6ylYJC4m9a+cmWd1ytIygwHn/tmGJuQscItnWtGu4UnlET9LtA==" });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Email", "Nombre", "NumeroTelefono", "Password" },
                values: new object[] { "testuser2@example.com", "Test User 2", "1234567893", "AQAAAAIAAYagAAAAEA4ipEs/fQkPzPaSU1xNuDWQ0YEOnqTnU6ZOBlcbQwi9Pskh38gfM785plmnvTGngw==" });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Email", "Nombre", "NumeroTelefono", "Password" },
                values: new object[] { "testuser3@example.com", "Test User 3", "1234567894", "AQAAAAIAAYagAAAAEBjVcFSOinTo3TpO/9hd1B9ODXEqc/jc0YGVWbfLnwFJBfPXocofGk/aREl6ik5iEA==" });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Email", "Nombre", "NumeroTelefono", "Password", "Role" },
                values: new object[,]
                {
                    { 6, "testuser4@example.com", "Test User 4", "1234567895", "AQAAAAIAAYagAAAAEObi6MSDNP+62nkN7gwW+Z3mtKEsGaYrwdViqrGV2u4APXTWeZXRakww2Y4DF6JoBg==", "User" },
                    { 7, "admin3@example.com", "Admin User 3", "1234567896", "AQAAAAIAAYagAAAAEDvd5hWUC0Qx91U6XuEoelcTtzsAJn1l7HD5bdiyYBnFBgaILkb6iPrf//8ZooQm3g==", "Admin" },
                    { 8, "testuser5@example.com", "Test User 5", "1234567897", "AQAAAAIAAYagAAAAEIEkhPASpAcY437nCZ5aKH0XgQSfIl+H0EtF73D7TNVHGeq+EZTQ2iSEZUCz8GeBcQ==", "User" },
                    { 9, "testuser6@example.com", "Test User 6", "1234567898", "AQAAAAIAAYagAAAAEFnS9sjquuxTzKrGs69HhhNhum3M20M5CsRj4Z5CpBNCJfP+Ixx7+o6rvuaj+dmyJw==", "User" },
                    { 10, "testuser7@example.com", "Test User 7", "1234567899", "AQAAAAIAAYagAAAAECAtE4Ibq1QksEOsI3Ovj9ML+W2da2vP8ZDxIEZIcWl+eZXpQ5SPwVZBnGsQRLX8gw==", "User" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Usuarios",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

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
                columns: new[] { "Email", "Nombre", "NumeroTelefono", "Password", "Role" },
                values: new object[] { "jane.smith@example.com", "Jane Smith", "9876543210", "hashed_password_2", "User" });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Email", "Nombre", "NumeroTelefono", "Password" },
                values: new object[] { "alice.johnson@example.com", "Alice Johnson", "4567891230", "hashed_password_3" });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Email", "Nombre", "NumeroTelefono", "Password" },
                values: new object[] { "bob.brown@example.com", "Bob Brown", "3216549870", "hashed_password_4" });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Email", "Nombre", "NumeroTelefono", "Password" },
                values: new object[] { "charlie.davis@example.com", "Charlie Davis", "6549873210", "hashed_password_5" });
        }
    }
}
