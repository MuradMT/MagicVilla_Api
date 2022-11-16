using MagicVilla_Utility;
using MagicVilla_Web.Models;
using MagicVilla_Web.Models.Dtos;
using MagicVilla_Web.Services.IService;

namespace MagicVilla_Web.Services
{
    public class VillaService : BaseService, IVillaService
    {
        private IHttpClientFactory _clientFactory;
        private string _url;
        public VillaService(IHttpClientFactory httpClientFactory,IConfiguration configuration) : base(httpClientFactory,configuration)
        {
            _clientFactory = httpClientFactory;
            _url = configuration.GetValue<string>("ServiceUrls:VillaApi");
        }

        public Task<T> CreateAsync<T>(VillaCreateDto dto, string token)
        {
            return SendAsync<T>(new APIRequest
            {
                apiType=SD.ApiType.Post,
                Data=dto,
                Url=_url+"/api/v1/VillaApi/CreateVilla",
                Token=token
            });
        }

        public Task<T> DeleteAsync<T>(int id, string token)
        {
            return SendAsync<T>(new APIRequest
            {
                apiType = SD.ApiType.Delete,
                Url = _url + "/api/v1/VillaApi/DeleteVilla?id=" + id,

                Token = token

            }) ;
        }

        public Task<T> GetAllAsync<T>(string token)
        {
            return SendAsync<T>(new APIRequest
            {
                apiType = SD.ApiType.Get,
                Url = _url + "/api/v1/VillaApi/GetVillas",
                Token = token
            });
        }

        public Task<T> GetAsync<T>(int id, string token)
        {
            return SendAsync<T>(new APIRequest
            {
                apiType = SD.ApiType.Get,
                Url = _url + "/api/v1/VillaApi/GetVilla?id=" + id ,
                Token = token
            });
        }

        public Task<T> UpdateAsync<T>(VillaUpdateDto dto, string token)
        {
            return SendAsync<T>(new APIRequest
            {
                apiType = SD.ApiType.Put,
                Data = dto,
                Url = _url + "/api/v1/VillaApi/UpdateVilla?id=" + dto.Id,
                Token = token
            });
        }
    }
}
