using MagicVilla_Utility;
using MagicVilla_Web.Models;
using MagicVilla_Web.Models.Dtos;
using MagicVilla_Web.Services.IService;
using Newtonsoft.Json.Linq;

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
        public Task<T> CreateAsync<T>(VillaNumberCreateDto dto,string token)
        {
            return SendAsync<T>(new APIRequest
            {
                apiType=SD.ApiType.Post,
                Data=dto,
                Url=_url+ "/CreateVillaNumber",
                Token = token
            });
        }

        public Task<T> DeleteAsync<T>(int id,string token)
        {
            return SendAsync<T>(new APIRequest
            {
                apiType = SD.ApiType.Delete,
                Url = _url + "/DeleteVillaNumber?id=" + id,
                Token = token
            }) ;
        }

        public Task<T> GetAllAsync<T>(string token)
        {
            return SendAsync<T>(new APIRequest
            {
                apiType = SD.ApiType.Post,
                Url = _url + "/GetVillaNumbers",
                Token = token
            });
        }

        public Task<T> GetAsync<T>(int id,string token)
        {
            return SendAsync<T>(new APIRequest
            {
                apiType = SD.ApiType.Get,
                Url = _url + "/GetVillaNumber?id=" + id,
                Token = token
            });
        }

        public Task<T> UpdateAsync<T>(VillaNumberUpdateDto dto, string token)
        {
            return SendAsync<T>(new APIRequest
            {
                apiType = SD.ApiType.Put,
                Data = dto,
                Url = _url + "/UpdateVillaNumber?id="+dto.VillaNo,
                Token=token
            });
        }
    }
}
