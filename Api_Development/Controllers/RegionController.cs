using Microsoft.AspNetCore.Mvc;
using Api_Development.Models;
using Api_Development.Models.Entities;
using Api_Development.Models.Domain;
using Api_Development.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using Api_Development.Repositories;
using Api_Development.Repositories.Interfaces;
using AutoMapper;

namespace Api_Development.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        //Injecao do DBContext/Repositorio/Mapper
        public RegionController(AppDbContext context, IRegionRepository regionRepository, IMapper mapper)
        {
            _context = context;
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            #region Without Repository
            //Get Data From Database - Domain Models
            //var regionsDomain = await _context.Regions.ToListAsync();
            #endregion

            var regionsDomain = await regionRepository.GetAllAsync();

            #region Mapper Manual
            ////Map Domain Models to DTOs
            //var regionsDto = new List<RegionDto>();
            //foreach (var regionDomain in regionsDomain)
            //{
            //    var regionItemDto = new RegionDto()
            //    {
            //        Id = regionDomain.Id,
            //        Code = regionDomain.Code,
            //        Name = regionDomain.Name,
            //        RegionImageUrl = regionDomain.RegionImageUrl
            //    };
            //    regionsDto.Add(regionItemDto);
            //}
            #endregion

            //Map Domain Models to DTOs using AutoMapper
            var regionsDto = mapper.Map<List<RegionDto>>(regionsDomain);

            return Ok(regionsDto);
        }

        //Get A single region
        [HttpGet]
        [Route("{ID_Region:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid ID_Region)
        {
            //Sem a utilização do Repositório
            //var regionDomain = await _context.Regions.FirstOrDefaultAsync(a => a.Id == ID_Region);
            var regionDomain = await regionRepository.GetByIdAsync(ID_Region);

            if (regionDomain == null)
                return NotFound();

            #region Mapper Manual
            //Map Domain Model to DTO

            //var regionDto = new RegionDto()
            //{
            //    Id = regionDomain.Id,
            //    Code = regionDomain.Code,
            //    Name = regionDomain.Name,
            //    RegionImageUrl = regionDomain.RegionImageUrl
            //};
            #endregion
            
            var regionDto = mapper.Map<RegionDto>(regionDomain);

            //retun Dto
            return Ok(regionDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRegion([FromBody] AddRegionRequestDto AddRegionDto)
        {
            #region Forma Inicial
            //Map DTO to Domain Model
            //var regionDomain = new Region()
            //{
            //    Id = Guid.NewGuid(),
            //    Code = AddRegionDto.Code,
            //    Name = AddRegionDto.Name,
            //    RegionImageUrl = AddRegionDto.RegionImageUrl
            //};
            //Save to Database sem o repositoriio
            //await _context.Regions.AddAsync(regionDomain);
            //await _context.SaveChangesAsync();

            #endregion

            var regionDomain = mapper.Map<Region>(AddRegionDto);
            await regionRepository.CreateRegionAsync(regionDomain);

            #region Forma Inicial
            ////Map Domain Model to DTO
            //var regionItemDto = new RegionDto()
            //{
            //    Id = regionDomain.Id,
            //    Code = regionDomain.Code,
            //    Name = regionDomain.Name,
            //    RegionImageUrl = regionDomain.RegionImageUrl
            //};
            #endregion

            var regionItemDto = mapper.Map<RegionDto>(regionDomain);

            //Dá 201 pois criar e envia o objecto
            return CreatedAtAction(nameof(GetById), new { ID_Region = regionItemDto.Id }, regionItemDto);
        }

        // Update Region 
        // Put: https://localhost:portnumber/api/regions/{id}
        [HttpPut]
        [Route("{ID_Region:Guid}")]
        public async Task<IActionResult> UpdateRegion([FromRoute] Guid ID_Region, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {

            #region Forma Inicial
            //Map Dto do Domain Model

            //var regionDomain = new Region
            //{
            //    Code = updateRegionRequestDto.Code,
            //    Name = updateRegionRequestDto.Name,
            //    RegionImageUrl = updateRegionRequestDto.RegionImageUrl

            //};

            //Metodo sem repositório
            //var regionDomain = await _context.Regions.FirstOrDefaultAsync(a => a.Id == ID_Region);
            #endregion

            var regionDomain = mapper.Map<Region>(updateRegionRequestDto);

            regionDomain = await regionRepository.UpdateRegionAsync(ID_Region, regionDomain);

            if (regionDomain == null)
                return NotFound();

            #region Forma Inicial
            //var regionDto = new RegionDto()
            //{
            //    Id = regionDomain.Id,
            //    Code = regionDomain.Code,
            //    Name = regionDomain.Name,
            //    RegionImageUrl = regionDomain.RegionImageUrl

            //};
            #endregion

            var regionDto = mapper.Map<RegionDto>(regionDomain);

            return Ok(regionDto);
        }

        //Delete Region
        //Detele: https://localhost:portnumber/api/regions/{id}
        [HttpDelete]
        [Route("{ID_Region:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid ID_Region)
        {
            var regionDomain = await regionRepository.DeleteAsync(ID_Region);

            if (regionDomain == null)
                return NotFound();

            #region Forma Inicial
            ////return deleted Region Back
            ////map domain model to Dto
            //var regionDto = new RegionDto()
            //{
            //    Id = regionDomain.Id,
            //    Code = regionDomain.Code,
            //    Name = regionDomain.Name,
            //    RegionImageUrl = regionDomain.RegionImageUrl

            //};
            #endregion

            var regionDto = mapper.Map<RegionDto>(regionDomain);

            return Ok(regionDto);
        }
    }
}
