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
        public VillaApiController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet("[action]", Name = "GetVillas")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<VillaDto>> GetVillas()
        {
            #region Comments
            //_logger.LogInformation("Get all villas");
            //_logger.Log("Get all villas", "Info");

            //return Ok(VillaStore.villaList);
            #endregion
            return Ok(_dbContext.Villas);
        }

        [HttpGet("[action]", Name = "GetVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<VillaDto> GetVilla(int id)
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

            var result = _dbContext.Villas.FirstOrDefault(p => p.Id == id);
            
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost("[action]", Name = "CreateVilla")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<VillaDto> CreateVilla([FromBody] VillaDto villaDto)
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
            if (villaDto.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            #region Comments
            //villaDto.Id = VillaStore.villaList.OrderByDescending(u => u.Id).FirstOrDefault().Id + 1;
            //VillaStore.villaList.Add(villaDto);
            #endregion
            _dbContext.Villas.Add(Map.VillaMapper(villaDto));
            _dbContext.SaveChanges();
            return CreatedAtRoute("GetVilla", new { id = villaDto.Id }, villaDto);
        }

        [HttpDelete("[action]", Name = "DeleteVilla")]
        //[ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(VillaDto))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteVilla(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            #region Comments
            //var villa = VillaStore.villaList.FirstOrDefault(u => u.Id == id);
            #endregion

            var villa = _dbContext.Villas.FirstOrDefault(u => u.Id == id);
            if (villa == null)
            {
                return NotFound();
            }
            #region Comments
            //VillaStore.villaList.Remove(villa);
            #endregion

            _dbContext.Villas.Remove(villa);
            _dbContext.SaveChanges();
            return NoContent();
        }

        [HttpPut("[action]", Name = "UpdateVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateVilla(int id, [FromBody] VillaDto villaDto)
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

           
            _dbContext.Villas.Update(Map.VillaMapper(villaDto));
            _dbContext.SaveChanges();
            return NoContent();
        }

        [HttpPatch("[action]", Name = "UpdatePartialVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdatePartialVilla(int id, JsonPatchDocument<VillaDto> patch)
        {
            if (patch == null || id == 0)
            {
                return BadRequest();
            }
            #region Comments
            //var villa = VillaStore.villaList.FirstOrDefault(u => u.Id == id);
            #endregion
            var villa = _dbContext.Villas.AsNoTracking().FirstOrDefault(u => u.Id == id);
            var villadto = Map.VillaDtoMapper(villa);
            if (villa == null)
            {
                return NotFound();
            }
            patch.ApplyTo(villadto,ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var model=Map.VillaMapper(villadto);
            _dbContext.Villas.Update(model);
            _dbContext.SaveChanges();
            return NoContent();
        }

    }
}
