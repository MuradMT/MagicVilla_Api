using MagicVilla_Utility;
using MagicVilla_Web.Models;
using MagicVilla_Web.Services.IService;
using Newtonsoft.Json;
using System.Text;

namespace MagicVilla_Web.Services
{
    public class BaseService : IBaseService
    {
        private IConfiguration configuration;

        public APIResponse responseModel { get; set; }
        public IHttpClientFactory _httpClientFactory { get; set; }
        public BaseService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            this.responseModel = new ();
            _httpClientFactory = httpClientFactory;
            this.configuration = configuration;
        }

        public async Task<T> SendAsync<T>(APIRequest apiRequest)
        {
            try
            {
                var client = _httpClientFactory.CreateClient("MagicVilla");
                var message = new HttpRequestMessage();
                message.Headers.Add("Accept", "application/json");
                message.RequestUri=new Uri(apiRequest.Url);
                if (apiRequest.Data != null)
                {
                    message.Content=new StringContent(JsonConvert.SerializeObject(apiRequest.Data),
                        Encoding.UTF8,"application/json");
                }
                switch (apiRequest.apiType)
                {
                   default:
                        message.Method=HttpMethod.Get;
                        break;
                    case SD.ApiType.Post:
                        message.Method = HttpMethod.Post;
                        break;
                    case SD.ApiType.Put:
                        message.Method = HttpMethod.Put;
                        break;
                    case SD.ApiType.Delete:
                        message.Method = HttpMethod.Delete;
                        break;
                    case SD.ApiType.Patch:
                        message.Method = HttpMethod.Patch;
                        break;
                }
                HttpResponseMessage apiresponse= null;
                apiresponse= await client.SendAsync(message);
                var apicontent = await apiresponse.Content.ReadAsStringAsync();
                var APIResponse = JsonConvert.DeserializeObject<T>(apicontent);
                return APIResponse;
            }
            catch(Exception ex)
            {
                var dto = new APIResponse
                {
                    ErrorMessages = new List<string>
                        {
                        Convert.ToString(ex.Message) }
                    ,
                    IsSuccess = false

                };
                var res = JsonConvert.SerializeObject(dto);
                var APIResponse= JsonConvert.DeserializeObject<T>(res);
                return APIResponse;
            }
        }
    }
}
