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
    public class CaminhadaController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ICaminhadaRepository caminhadaRepository;


        public CaminhadaController(IMapper mapper, ICaminhadaRepository caminhadaRepository)
        {
            this.mapper = mapper;
            this.caminhadaRepository = caminhadaRepository;

        }


        //Create Walk
        //Post: /api/walks
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddCaminhadaRequestDto addWalkRequestDto)
        {
            var walkDomianModel = mapper.Map<Caminhada>(addWalkRequestDto);

            await caminhadaRepository.CreateCaminhadaAsync(walkDomianModel);

            //Map Domain Model to Dto

            return Ok(mapper.Map<CaminhadaDto>(walkDomianModel));
        }

        //Get All Walks
        //Get: /api/walks
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var walksDomainModel = await caminhadaRepository.GetAllAsync();
            return Ok(mapper.Map<List<CaminhadaDto>>(walksDomainModel));
        }

        // Get Walk by Id
        //Get: /api/walks/{id}

        [HttpGet]
        [Route("{walkId:guid}")]

        public async Task<IActionResult> GetById(Guid walkId)
        {
            var walkDomainModel = await caminhadaRepository.GetByIdAsync(walkId);
            if (walkDomainModel == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<CaminhadaDto>(walkDomainModel));


        }

        //Delete Walk by Id
        //Delete: /api/walks/{id}

        [HttpDelete]
        [Route("{walkId:guid}")]

        public async Task<ActionResult> Delete(Guid walkId)
        {
            var walkDomainModel = await caminhadaRepository.DeleteAsync(walkId);

            if (walkDomainModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<CaminhadaDto>(walkDomainModel));
        }

        [HttpPut]
        [Route("{caminhaId:Guid}")]

        public async Task<IActionResult> Update([FromRoute] Guid caminhaId, [FromBody] UpdateCaminhadaRequestDto updateCaminhadaRequestDto)
        {
            var caminhadaDomainModel = mapper.Map<Caminhada>(updateCaminhadaRequestDto);
            var updatedCaminhadaDomainModel = await caminhadaRepository.UpdateCaminhadaAsync(caminhaId, caminhadaDomainModel);
            if (updatedCaminhadaDomainModel == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<CaminhadaDto>(updatedCaminhadaDomainModel));


        }
    }
}
