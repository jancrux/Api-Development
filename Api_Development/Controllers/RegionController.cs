using Microsoft.AspNetCore.Mvc;
using Api_Development.Models;
using Api_Development.Models.Entities;
using Api_Development.Models.Domain;
using Api_Development.Models.DTOs;

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

            //Get Data From Database - Domain Models
            var regionsDomain = _context.Regions.ToList();

            //Map Domain Models to DTOs
            var regionsDto = new List<RegionDto>();
            foreach (var regionDomain in regionsDomain)
            {
                var regionItemDto = new RegionDto()
                {
                    Id = regionDomain.Id,
                    Code = regionDomain.Code,
                    Name = regionDomain.Name,
                    RegionImageUrl = regionDomain.RegionImageUrl
                };
                regionsDto.Add(regionItemDto);
            }

            return Ok(regionsDto);


        }

        //Get A single region
        [HttpGet]
        [Route("ID_Region:Guid")]
        public IActionResult GetById([FromRoute] Guid ID_Region)
        {


            var regionDomain = _context.Regions.Where(a => a.Id == ID_Region);

            if (regionDomain == null)
                return NotFound();

            //Map Domain Model to DTO

            var regionDto = new RegionDto()
            {
                Id = regionDomain.First().Id,
                Code = regionDomain.First().Code,
                Name = regionDomain.First().Name,
                RegionImageUrl = regionDomain.First().RegionImageUrl
            };

            //retun Dto
            return Ok(regionDto);
        }

        [HttpPost]

        public IActionResult CreateRegion([FromBody] AddRegionRequestDto AddRegionDto)
        {
            //Map DTO to Domain Model
            var regionDomain = new Region()
            {
                Id = Guid.NewGuid(),
                Code = AddRegionDto.Code,
                Name = AddRegionDto.Name,
                RegionImageUrl = AddRegionDto.RegionImageUrl
            };
            //Save to Database
            _context.Regions.Add(regionDomain);
            _context.SaveChanges();
            //Map Domain Model to DTO
            var regionItemDto = new RegionDto()
            {
                Id = regionDomain.Id,
                Code = regionDomain.Code,
                Name = regionDomain.Name,
                RegionImageUrl = regionDomain.RegionImageUrl
            };
            return CreatedAtAction(nameof(GetById), new { ID_Region = regionItemDto.Id }, regionItemDto);
        }
    }
}
