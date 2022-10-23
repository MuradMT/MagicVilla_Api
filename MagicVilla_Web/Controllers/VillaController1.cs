using AutoMapper;
using MagicVilla_Web.Models;
using MagicVilla_Web.Models.Dtos;
using MagicVilla_Web.Services.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MagicVilla_Web.Controllers
{
    public class VillaController1 : Controller
    {
        private IVillaService _service;
        private IMapper _mapper;
        public VillaController1(IVillaService service,IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        public async Task<IActionResult> IndexVilla()
        {
            List<VillaDto> list = new();
            var response = await _service.GetAllAsync<APIResponse>();
            if(response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<VillaDto>>(Convert.ToString
                    (response.Result));
            }
            return View(list) ;
        }
    }
}
