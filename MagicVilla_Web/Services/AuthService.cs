using MagicVilla_Utility;
using MagicVilla_Web.Models;
using MagicVilla_Web.Models.Dtos;
using MagicVilla_Web.Services.IService;

namespace MagicVilla_Web.Services
{
    public class AuthService : BaseService, IAuthService
    {
        private IHttpClientFactory httpClientFactory;
        private string villaUrl;
        public AuthService(IHttpClientFactory httpClientFactory,IConfiguration configuration):base(httpClientFactory,configuration)
        {
            this.httpClientFactory = httpClientFactory;
            villaUrl = configuration.GetValue<string>("ServiceUrls:VillaApi");
        }
        public Task<T> LoginAsync<T>(LoginRequestDto dto)
        {
            return SendAsync<T>(new APIRequest
            {
                apiType = SD.ApiType.Post,
                Data = dto,
                Url = villaUrl + "/api/UsersAuth/login"
            });
        }

        public Task<T> RegisterAsync<T>(RegistrationRequestDto dto)
        {
            return SendAsync<T>(new APIRequest
            {
                apiType = SD.ApiType.Post,
                Data = dto,
                Url = villaUrl + "/api/UsersAuth/register"
            });
        }
    }
}
