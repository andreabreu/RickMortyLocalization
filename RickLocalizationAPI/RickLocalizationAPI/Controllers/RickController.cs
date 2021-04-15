using Domain.Filter;
using Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using RickLocalizationAPI.Helpers;
using RickLocalizationAPI.Models;
using System.Linq;

namespace RickLocalizationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RickController : ControllerBase
    {
        private IRickService _rickService;
        private readonly IUriService _uriService;

        public RickController(IRickService rickService, IUriService uriService)
        {
            _rickService = rickService;
            _uriService = uriService;
        }

        // GET: api/Rick
        [HttpGet]
        public IActionResult Get([FromQuery] PaginationFilter filter)
        {
            var route = Request.Path.Value;
            var pagedData = _rickService.GetRicks(filter).ToList();
            var totalRecords = _rickService.CountTotal();
            var pagedReponse = PaginationHelper.CreatePagedReponse<RickModel>(pagedData, filter, totalRecords, _uriService, route);

            return Ok(pagedReponse);
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var rick = _rickService.GetInfo(id);

            if (rick == null)
            {
                return NotFound();
            }

            return Ok(rick);
        }
    }
}
