using ProyectoeCommerce.DTOs;

namespace ProyectoeCommerce.Services
{
    public interface IAuthService
    {
        Task<AuthResponseDto> Register(RegisterRequestDto request);
        Task<AuthResponseDto> Login(AuthRequestDto request);
    }
}
