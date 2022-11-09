using MagicVilla_VillaApi.Models;
using MagicVilla_VillaApi.Models.Dtos;

namespace MagicVilla_VillaApi.Repositories.IRepository
{
    public interface IUserRepository
    {
        bool IsUniqueUser(string username);
        Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto);
        Task<LocalUser> Register(RegistrationRequestDto registrationRequestDto);

    }
}
