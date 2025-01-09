using Microsoft.CodeAnalysis.Scripting;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProyectoeCommerce.DTOs;
using ProyectoeCommerce.Models.Entity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProyectoeCommerce.Services
{
    public class AuthService : IAuthService
    {
        private readonly DbContext _context;
        private readonly IConfiguration _configuration;

        public AuthService(DbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<AuthResponseDto> Register(RegisterRequestDto request)
        {
            // Verificar si el usuario ya existe
            if (await _context.Usuarios.AnyAsync(u => u.Email == request.Email))
            {
                throw new Exception("El email ya está registrado");
            }

            // Crear hash de la contraseña
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            // Crear nuevo usuario
            var usuario = new Usuario
            {
                Nombre = request.Nombre,
                Email = request.Email,
                NumeroTelefono = request.NumeroTelefono,
                PasswordHash = passwordHash,
                Role = "User",
                Wishlists = new List<Wishlist>()
            };

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            // Generar token
            return new AuthResponseDto
            {
                Token = GenerateToken(usuario),
                Email = usuario.Email,
                Nombre = usuario.Nombre,
                Role = usuario.Role
            };
        }

        public async Task<AuthResponseDto> Login(AuthRequestDto request)
        {
            // Buscar usuario
            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Email == request.Email);

            if (usuario == null)
            {
                throw new Exception("Usuario no encontrado");
            }

            // Verificar contraseña
            if (!BCrypt.Net.BCrypt.Verify(request.Password, usuario.PasswordHash))
            {
                throw new Exception("Contraseña incorrecta");
            }

            // Generar token
            return new AuthResponseDto
            {
                Token = GenerateToken(usuario),
                Email = usuario.Email,
                Nombre = usuario.Nombre,
                Role = usuario.Role
            };
        }

        private string GenerateToken(Usuario usuario)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Email, usuario.Email),
                new Claim(ClaimTypes.Name, usuario.Nombre),
                new Claim(ClaimTypes.Role, usuario.Role),
                new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("JWT:Key").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

}
