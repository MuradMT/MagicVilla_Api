using AutoMapper;
using FluentValidation;
using MagicVilla_VillaApi.Data;
using MagicVilla_VillaApi.Logging.Abstract;
using MagicVilla_VillaApi.Mapping;
using MagicVilla_VillaApi.Models;
using MagicVilla_VillaApi.Models.Contexts;
using MagicVilla_VillaApi.Models.Dtos;
using MagicVilla_VillaApi.Repositories.IRepository;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace MagicVilla_VillaApi.Controllers
{
    //IEnumerable-Collection tipi belli deyilse istifade ede bilerik,iterasiya 
    //ede bilmeyimize komek edir


    [Route("api/[controller]")]
    [ApiController]
    public class VillaApiController : ControllerBase
    {
        #region Comments
        //private readonly ILogger<VillaDto> _logger;
        //private readonly ILogging<VillaDto> _logger;
        //public VillaApiController(ILogger<VillaDto> logger
        //    )
        //{
        //    _logger = logger;
        //}
        #endregion
        protected APIResponse _response;
        private IVillaRepository _db;
        private IMapper _mapper;
        public VillaApiController(IVillaRepository db,IMapper mapper)
        {
            _db=db;
            _mapper = mapper;
            _response = new();
        }
        [HttpGet("[action]", Name = "GetVillas")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetVillas()
        {
            #region Comments
            //_logger.LogInformation("Get all villas");
            //_logger.Log("Get all villas", "Info");

            //return Ok(VillaStore.villaList);
            #endregion
            try
            {
                var villas = await _db.GetAllAsync();
                _response.Result = _mapper.Map<List<VillaDto>>(villas);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch(Exception ex)
            {
                _response.IsSuccess=false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
               
            }
            return _response;

        }

        [HttpGet("[action]", Name = "GetVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetVilla(int id)
        {
            try
            {
                if (id == 0)
                {
                    #region Comments
                    //_logger.LogError("Bad Request");
                    //_logger.Log("Bad Requsest", "Error");
                    #endregion
                    _response.StatusCode=HttpStatusCode.BadRequest;

                    return BadRequest(_response);
                }
                #region Comments
                //var result = VillaStore.villaList.FirstOrDefault(p => p.Id == id);
                #endregion

                var result = await _db.GetAsync(p => p.Id == id);

                if (result == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }
                _response.Result = _mapper.Map<VillaDto>(result);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };

            }
            return _response;
        }

        [HttpPost("[action]", Name = "CreateVilla")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> CreateVilla([FromBody] VillaCreateDto villaDto)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.Result = ModelState;
                    return BadRequest(_response);
                }
                #region Comments
                //if(_dbContext.Villas.FirstOrDefault(p=>p.Id==villaDto.Id).Name!=villaDto.Name)
                //{
                //    ModelState.AddModelError("ZError", "The text is not true");
                //    return BadRequest(ModelState);
                //}
                #endregion

                if (villaDto == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.Result = villaDto;
                    return BadRequest(_response);
                }

                #region Comments
                //if (villaDto.Id > 0)
                //{
                //    return StatusCode(StatusCodes.Status500InternalServerError);
                //}
                //villaDto.Id = VillaStore.villaList.OrderByDescending(u => u.Id).FirstOrDefault().Id + 1;
                //VillaStore.villaList.Add(villaDto);
                #endregion
                var model = _mapper.Map<Villa>(villaDto);
                await _db.CreateAsync(model);
                await _db.SaveAsync();
                _response.Result = model;
                _response.StatusCode = HttpStatusCode.Created;
                return CreatedAtRoute("GetVilla", new { id = model.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };

            }
            return _response;
        }

        [HttpDelete("[action]", Name = "DeleteVilla")]
        //[ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(VillaDto))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> DeleteVilla(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                #region Comments
                //var villa = VillaStore.villaList.FirstOrDefault(u => u.Id == id);
                #endregion

                var villa = await _db.GetAsync(u => u.Id == id);
                if (villa == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }
                #region Comments
                //VillaStore.villaList.Remove(villa);
                #endregion

                await _db.RemoveAsync(villa);
                await _db.SaveAsync();

                _response.StatusCode = HttpStatusCode.NoContent;
                //_response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };

            }
            return _response;
        }

        [HttpPut("[action]", Name = "UpdateVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdateVilla(int id, [FromBody] VillaUpdateDto villaDto)
        {
            try
            {


                if (villaDto == null || id != villaDto.Id)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                #region Comments
                //var villa = VillaStore.villaList.FirstOrDefault(u => u.Id == id);
                //villa.Name = villaDto.Name;
                //villa.Occupancy = villaDto.Occupancy;
                //villa.Sqft = villaDto.Sqft;
                #endregion


                await _db.UpdateAsync(_mapper.Map<Villa>(villaDto));
                await _db.SaveAsync();
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };

            }
            return _response;
        }

        [HttpPatch("[action]", Name = "UpdatePartialVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdatePartialVilla(int id, JsonPatchDocument<VillaUpdateDto> patch)
        {
            try
            {


                if (patch == null || id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                #region Comments
                //var villa = VillaStore.villaList.FirstOrDefault(u => u.Id == id);
                #endregion
                var villa = await _db.GetAsync(u => u.Id == id, false);
                
                if (villa == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }
                var villadto = _mapper.Map<VillaUpdateDto>(villa);
                patch.ApplyTo(villadto, ModelState);
                if (!ModelState.IsValid)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.Result = ModelState;
                    return BadRequest(_response);
                }
                var model = _mapper.Map<Villa>(villadto);
                await _db.UpdateAsync(model);
                await _db.SaveAsync();
                _response.StatusCode = HttpStatusCode.NoContent;
                //_response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };

            }
            return _response;
        }

    }
}
