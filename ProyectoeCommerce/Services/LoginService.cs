using Microsoft.AspNetCore.Identity;
using ProyectoeCommerce.Models.Entity;

namespace ProyectoeCommerce.Services.Auth
{
    public class LoginService
    {
        private readonly PasswordHasher<Usuario> _passwordHasher;

        public LoginService(PasswordHasher<Usuario> passwordHasher)
        {
            _passwordHasher = passwordHasher;
        }

        // Registrar nuevo usuario
        public Usuario Register(string nombre, string email, string numeroTelefono, string password)
        {
            var usuario = new Usuario
            {
                Nombre = nombre,
                Email = email,
                NumeroTelefono = numeroTelefono,
                Role = "User",
                Wishlists = new List<Wishlist>()
            };

            usuario.Password = _passwordHasher.HashPassword(usuario, password);
            return usuario;
        }

        // Verificar credenciales
        public bool VerifyCredentials(Usuario usuario, string password)
        {
            if (usuario == null) return false;

            var result = _passwordHasher.VerifyHashedPassword(usuario, usuario.Password, password);
            return result == PasswordVerificationResult.Success;
        }

        // Actualizar contraseña
        public void UpdatePassword(Usuario usuario, string newPassword)
        {
            usuario.Password = _passwordHasher.HashPassword(usuario, newPassword);
        }
    }
}