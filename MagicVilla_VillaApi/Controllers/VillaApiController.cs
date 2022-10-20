using AutoMapper;
using MagicVilla_VillaApi.Data;
using MagicVilla_VillaApi.Logging.Abstract;
using MagicVilla_VillaApi.Mapping;
using MagicVilla_VillaApi.Models;
using MagicVilla_VillaApi.Models.Contexts;
using MagicVilla_VillaApi.Models.Dtos;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla_VillaApi.Controllers
{
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
        private ApplicationDbContext _dbContext;
        private IMapper _mapper;
        public VillaApiController(ApplicationDbContext dbContext,IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;   
        }
        [HttpGet("[action]", Name = "GetVillas")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<VillaDto>>> GetVillas()
        {
            #region Comments
            //_logger.LogInformation("Get all villas");
            //_logger.Log("Get all villas", "Info");

            //return Ok(VillaStore.villaList);
            #endregion
            var villas = await _dbContext.Villas.ToListAsync();
            return Ok(_mapper.Map<VillaDto>(villas));
        }

        [HttpGet("[action]", Name = "GetVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<VillaDto>> GetVilla(int id)
        {
            if (id == 0)
            {
                #region Comments
                //_logger.LogError("Bad Request");
                //_logger.Log("Bad Requsest", "Error");
                #endregion

                return BadRequest();
            }
            #region Comments
            //var result = VillaStore.villaList.FirstOrDefault(p => p.Id == id);
            #endregion

            var result =await _dbContext.Villas.FirstOrDefaultAsync(p => p.Id == id);
            
            if (result == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<VillaDto>(result));
        }

        [HttpPost("[action]", Name = "CreateVilla")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<VillaDto>> CreateVilla([FromBody] VillaCreateDto villaDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
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
                return BadRequest(villaDto);
            }

            #region Comments
            //if (villaDto.Id > 0)
            //{
            //    return StatusCode(StatusCodes.Status500InternalServerError);
            //}
            //villaDto.Id = VillaStore.villaList.OrderByDescending(u => u.Id).FirstOrDefault().Id + 1;
            //VillaStore.villaList.Add(villaDto);
            #endregion
            var model =_mapper.Map<Villa>(villaDto);
            await _dbContext.Villas.AddAsync(model);
            await _dbContext.SaveChangesAsync();
            return CreatedAtRoute("GetVilla", new { id = model.Id },model);
        }

        [HttpDelete("[action]", Name = "DeleteVilla")]
        //[ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(VillaDto))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteVilla(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            #region Comments
            //var villa = VillaStore.villaList.FirstOrDefault(u => u.Id == id);
            #endregion

            var villa =await _dbContext.Villas.FirstOrDefaultAsync(u => u.Id == id);
            if (villa == null)
            {
                return NotFound();
            }
            #region Comments
            //VillaStore.villaList.Remove(villa);
            #endregion

             _dbContext.Villas.Remove(villa);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("[action]", Name = "UpdateVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateVilla(int id, [FromBody] VillaUpdateDto villaDto)
        {
            if (villaDto == null || id != villaDto.Id)
            {
                return BadRequest();
            }
            #region Comments
            //var villa = VillaStore.villaList.FirstOrDefault(u => u.Id == id);
            //villa.Name = villaDto.Name;
            //villa.Occupancy = villaDto.Occupancy;
            //villa.Sqft = villaDto.Sqft;
            #endregion

           
            _dbContext.Villas.Update(_mapper.Map<Villa>(villaDto));
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }

        [HttpPatch("[action]", Name = "UpdatePartialVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdatePartialVilla(int id, JsonPatchDocument<VillaUpdateDto> patch)
        {
            if (patch == null || id == 0)
            {
                return BadRequest();
            }
            #region Comments
            //var villa = VillaStore.villaList.FirstOrDefault(u => u.Id == id);
            #endregion
            var villa = await _dbContext.Villas.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
            var villadto =_mapper.Map<VillaUpdateDto>(villa);
            if (villa == null)
            {
                return NotFound();
            }
            patch.ApplyTo(villadto,ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var model=_mapper.Map<Villa>(villadto);
            _dbContext.Villas.Update(model);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }

    }
}
