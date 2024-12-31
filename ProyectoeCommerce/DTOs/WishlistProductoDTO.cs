namespace ProyectoeCommerce.DTOs
{
    public class WishlistProductoDto
    {
        public int ProductoId { get; set; }
        public int WishlistId { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaProductoAgregado { get; set; }
    }

}
