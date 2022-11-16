using MagicVilla_Web.Models.Dtos;

namespace MagicVilla_Web.Services.IService
{
    public interface IAuthService
    {
        Task<T> LoginAsync<T>(LoginRequestDto dto);
        Task<T> RegisterAsync<T>(RegistrationRequestDto dto);
    }
}
