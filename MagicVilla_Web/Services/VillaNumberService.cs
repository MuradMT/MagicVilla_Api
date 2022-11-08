using MagicVilla_Utility;
using MagicVilla_Web.Models;
using MagicVilla_Web.Models.Dtos;
using MagicVilla_Web.Services.IService;

namespace MagicVilla_Web.Services
{
    public class VillaNumberService : BaseService, IVillaNumberService
    {
        private IHttpClientFactory _clientFactory;
        private string _url;
        public VillaNumberService(IHttpClientFactory clientFactory,IConfiguration configuration)
            :base(clientFactory,configuration)
        {
            _clientFactory = clientFactory;
            _url = configuration.GetValue<string>("ServiceUrls:VillaApi");
        }
        public Task<T> CreateAsync<T>(VillaNumberCreateDto dto)
        {
            return SendAsync<T>(new APIRequest
            {
                apiType=SD.ApiType.Post,
                Data=dto,
                Url=_url+ "/CreateVillaNumber"

            });
        }

        public Task DeleteAsync<T>(int id)
        {
            return SendAsync<T>(new APIRequest
            {
                apiType = SD.ApiType.Delete,
                Url = _url + "/DeleteVillaNumber?id=" + id
            }) ;
        }

        public Task<T> GetAllAsync<T>()
        {
            return SendAsync<T>(new APIRequest
            {
                apiType = SD.ApiType.Post,
                Url = _url + "/GetVillaNumbers"
            });
        }

        public Task<T> GetAsync<T>(int id)
        {
            return SendAsync<T>(new APIRequest
            {
                apiType = SD.ApiType.Get,
                Url = _url + "/GetVillaNumber?id=" + id
            });
        }

        public Task<T> UpdateAsync<T>(VillaNumberUpdateDto dto)
        {
            return SendAsync<T>(new APIRequest
            {
                apiType = SD.ApiType.Put,
                Data = dto,
                Url = _url + "/UpdateVillaNumber?id="+dto.VillaNo

            });
        }
    }
}
