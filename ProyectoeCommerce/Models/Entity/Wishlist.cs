using System.Text.Json.Serialization;

namespace ProyectoeCommerce.Models.Entity
{
    public class Wishlist
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int UsuarioId { get; set; }
        [JsonIgnore]

        public Usuario Usuario { get; set; }
        public  ICollection<WishlistProducto> WishlistProductos { get; set; }
    }
}
