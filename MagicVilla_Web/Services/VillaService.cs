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

        public Task<T> CreateAsync<T>(VillaCreateDto dto)
        {
            return SendAsync<T>(new APIRequest
            {
                apiType=SD.ApiType.Post,
                Data=dto,
                Url=_url+"/api/CreateVilla"
            });
        }

        public Task<T> DeleteAsync<T>(int id)
        {
            return SendAsync<T>(new APIRequest
            {
                apiType = SD.ApiType.Delete,
                Url = _url + "/api/DeleteVilla/" + id
            }) ;
        }

        public Task<T> GetAllAsync<T>()
        {
            return SendAsync<T>(new APIRequest
            {
                apiType = SD.ApiType.Get,
                Url = _url + "/api/GetVillas"
            });
        }

        public Task<T> GetAsync<T>(int id)
        {
            return SendAsync<T>(new APIRequest
            {
                apiType = SD.ApiType.Get,
                Url = _url + "/api/GetVilla/"+id 
            });
        }

        public Task<T> UpdateAsync<T>(VillaUpdateDto dto)
        {
            return SendAsync<T>(new APIRequest
            {
                apiType = SD.ApiType.Put,
                Data = dto,
                Url = _url + "/api/UpdateVilla/" +dto.Id
            });
        }
    }
}
