using Microsoft.AspNetCore.Mvc;
using Api_Development.Models;
using Api_Development.Models.Entities;
using Api_Development.Models.Domain;

namespace Api_Development.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly AppDbContext _context;

        //Injecao do DBContext
        public RegionController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var region = _context.Regions.ToList();

            return Ok(region);
        }

        //Get A single region
        [HttpGet]
        [Route("id:Guid")]
        public IActionResult GetById([FromRoute] Guid ID_Region)
        {
            var region = _context.Regions.Where(a=> a.Id == ID_Region);

            if(region == null)
                return NotFound();

            return Ok(region);
        }
    }
}
