using AutoMapper;
using MagicVilla_VillaApi.Models;
using MagicVilla_VillaApi.Repositories.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MagicVilla_VillaApi.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("2.0")]
    //[ApiVersionNeutral]
    public class VillaApiV2Controller : ControllerBase
    {
        protected APIResponse _response;
        private IVillaRepository _db;
        private IMapper _mapper;

        public VillaApiV2Controller(IVillaRepository db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            _response = new();
        }
        [MapToApiVersion("2.0")]
        [HttpGet("[action]")]
        public IEnumerable<string> Get()
        {
            return new List<string>() { "Murad" };
        }
    }
}
