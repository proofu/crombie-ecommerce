using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProyectoeCommerce.Models.Entity;
using ProyectoeCommerce.Services.Auth;

namespace ProyectoeCommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly eCommerceContext _context;
        private readonly PasswordHasher<Usuario> _passwordHasher;    
        private readonly LoginService _loginService;                 
        private readonly IConfiguration _configuration;

        public UsuarioController(
            eCommerceContext context,
            PasswordHasher<Usuario> passwordHasher,
            LoginService loginService,
            IConfiguration configuration)
        {
            _context = context;
            _passwordHasher = passwordHasher;
            _loginService = loginService;
            _configuration = configuration;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] AuthRequest request)
        {
            if (_context.Usuarios.Any(u => u.Email == request.Username))
            {
                return BadRequest("Email already exists");
            }

            // Enfoque anterior (mantenido como referencia)
            /*
            var newUser = new Usuario
            {
                Nombre = request.Username,
                Email = request.Username,
                Role = "User"
            };
            newUser.Password = _passwordHasher.HashPassword(newUser, request.Password);
            */

            //usando LoginService
            var newUser = _loginService.Register(
                nombre: request.Username,
                email: request.Username,
                numeroTelefono: "",
                password: request.Password
            );

            _context.Usuarios.Add(newUser);
            await _context.SaveChangesAsync();

            return Ok("User registered successfully");
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] AuthRequest request)
        {
            var loggingUser = GetUserByEmail(request.Username);
            if (loggingUser == null)
            {
                return Unauthorized("user not found");
            }

            // Método con PasswordHasher
            PasswordVerificationResult isCorrectPassword = _passwordHasher.VerifyHashedPassword(
                loggingUser, loggingUser.Password, request.Password);

            if (isCorrectPassword == PasswordVerificationResult.Success)
            {
                string token = CreateJWTAuthToken(loggingUser);
                return Ok(new { Token = token });
            }

            throw new Exception("Unable to authenticate");
        }
        [HttpGet("jwt-token")]
        private string CreateJWTAuthToken(Usuario user)
        {
            // creando la JWT token
            //string secretKey = this._configuration["JWT:SECRET"] ?? "";
            string secretKey = "a-very-long-secret-key-that-is-at-least-16-characters";

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            if (secretKey == null)
            {
                throw new Exception("Unable to create token");
            }


            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity([
                    new Claim(JwtRegisteredClaimNames.Name, user.Nombre),
                    new Claim("Roles", user.Role) // incluye roles de usuario
                ]),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = credentials,
                Issuer = this._configuration["JWT:ISSUER"],
                Audience = this._configuration["JWT:AUDIENCE"]
            };
            var handler = new Microsoft.IdentityModel.JsonWebTokens.JsonWebTokenHandler();
            string token = handler.CreateToken(tokenDescriptor);
            return token;
        }
        [HttpGet("email")]
        public Usuario GetUserByEmail(string email)
        {
            return _context.Usuarios.FirstOrDefault(u => u.Email == email);
        }
        // GET: UsuarioController/GetAll
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }

        // GET: api/usuarios/X
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var user = await _context.Usuarios.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // POST: api/usuarios
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUser(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUsuario), new { id = usuario.Id }, usuario);
        }

        // PUT: api/usuarios/X
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return BadRequest();
            }

            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/usuarios/X
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.Id == id);
        }
    }
}
