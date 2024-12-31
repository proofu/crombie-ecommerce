using System.Text.Json.Serialization;

namespace ProyectoeCommerce.Models.Entity
{
    public class WishlistProducto
    {
        public int ProductoId { get; set; }
        public int WishlistId { get; set; }

        public string Nombre { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaProductoAgregado { get; set; }
        [JsonIgnore]
        public Producto Producto { get; set; }
        [JsonIgnore]
        public Wishlist Wishlist { get; set; }
    }
}
