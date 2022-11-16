using MagicVilla_VillaApi.Models;
using MagicVilla_VillaApi.Models.Dtos;
using MagicVilla_VillaApi.Repositories.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MagicVilla_VillaApi.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    //[Route("api/UsersAuth")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IUserRepository _userRepository;
        protected APIResponse _response;
        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            this._response = new();
        }
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> Login([FromBody] LoginRequestDto dto)
        {
            var response = await _userRepository.Login(dto);
            if (response.User == null || string.IsNullOrEmpty(response.Token))
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.ErrorMessages.Add("Username or paswword is incorrect");
                return BadRequest(_response);
            }
            _response.IsSuccess = true;
            _response.StatusCode = HttpStatusCode.OK;
            _response.Result = response;
            return Ok(_response);
        }
        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register([FromBody] RegistrationRequestDto dto)
        {
            bool isUniqueUser = _userRepository.IsUniqueUser(dto.UserName);
            if (!isUniqueUser)
            {
                _response.StatusCode=HttpStatusCode.BadRequest;
                _response.IsSuccess=false;
                _response.ErrorMessages.Add("Username is already exists");
                return BadRequest(_response);
            }
            var user=await _userRepository.Register(dto);
            if (user == null)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Error while registering");
                return BadRequest(_response);
            }
            _response.IsSuccess=true;
            _response.Result=user;
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);
        }
    }
}
