using Service.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using RickLocalizationAPI.Models;

namespace RickLocalizationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DimensionController : ControllerBase
    {
        private IDimensionService _dimensionService;

        public DimensionController(IDimensionService dimensionService)
        {
            _dimensionService = dimensionService;
        }

        // GET: api/Morty
        [HttpGet]
        public IActionResult Get()
        {
            var obj = _dimensionService.Get<DimensionModel>();

            return Ok(obj);
        }

        [HttpPost("AddTravel")]
        public IActionResult AddTravel(RickDimensionInputModel rickDimension)
        {
            _dimensionService.AddTravel(rickDimension);

            return Ok();
        }

    }
}
