namespace ProyectoeCommerce.Models.Entity
{
    public class AuthResponse
    {
        public required string Token { get; set; }
        public required string RefreshToken { get; set; }
        public DateTime Expiration { get; set; }
    }
}
