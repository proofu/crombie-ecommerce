

namespace ProyectoeCommerce.Models.Entity
{
    //[Table("Usuario")]
        public class Usuario
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public string Email { get; set; }
            public string NumeroTelefono { get; set; }
            // Campos adicionales para autenticación
            public string Password { get; set; }
            public string Role { get; set; } = "User";
            public ICollection<Wishlist> Wishlists { get; set; }
        }
}
