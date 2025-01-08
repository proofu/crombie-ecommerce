using ProyectoeCommerce.Models.Entity;

namespace ProyectoeCommerce.Services
{
    public interface IJwtService
    {
        Task<AuthResponse> GenerateToken(ApplicationUser user);
    }
}
