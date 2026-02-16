using Api_Development.Models.Domain;
using Api_Development.Models.DTOs;
using Api_Development.Repositories.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_Development.Controllers
{

    //api/walks
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IWalkRepository walkRepository;


        public WalksController(IMapper mapper, IWalkRepository walkRepository) 
        {
            this.mapper = mapper;
            this.walkRepository = walkRepository;
        
        }


        //Create Walk
        //Post: /api/walks
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDto addWalkRequestDto)
        {
           var walkDomianModel =  mapper.Map<Walk>(addWalkRequestDto);

            await walkRepository.CreateWalkAsync(walkDomianModel);

            //Map Domain Model to Dto

            return Ok(mapper.Map<WalkDto>(walkDomianModel));

        }


    }
}
