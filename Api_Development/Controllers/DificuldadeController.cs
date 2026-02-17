using Api_Development.CustomActionFilters;
using Api_Development.Models.Domain;
using Api_Development.Models.DTOs;
using Api_Development.Repositories.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_Development.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DificuldadeController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IDificuldadeRepository dificuldadeRepository;



        public DificuldadeController(IMapper mapper, IDificuldadeRepository dificuldadeRepository)
        {
            this.mapper = mapper;
            this.dificuldadeRepository = dificuldadeRepository;
        }

        // Get All Dificuldades
        // Get: /api/dificuldades

        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            var dificuldadesDomainModel = await dificuldadeRepository.GetAllAsync();
            return Ok(mapper.Map<List<DificuldadeDto>>(dificuldadesDomainModel));
        }

        // Get Dificuldade by Id
        // Get: /api/dificuldades/{id}
        [HttpGet]
        [Route("{DificuldadeId:Guid}")]

        public async Task<IActionResult> GetById(Guid DificuldadeId)
        {
            var dificuldadeDomainModel = await dificuldadeRepository.GetByIdAsync(DificuldadeId);
            if (dificuldadeDomainModel == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<DificuldadeDto>(dificuldadeDomainModel));
        }

        // Create Dificuldade
        // Post: /api/dificuldades

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddDificuldadeRequestDto addDificuldadeRequestDto)
        {
            var dificuldadeDomainModel = mapper.Map<Dificuldade>(addDificuldadeRequestDto);
            await dificuldadeRepository.CreateDificuldadeAsync(dificuldadeDomainModel);
            return Ok(mapper.Map<DificuldadeDto>(dificuldadeDomainModel));


        }

        // Update Dificuldade
        // Put: /api/dificuldades/{id}

        [HttpPut]

        [Route("{DificuldadeId:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] Guid DificuldadeId, [FromBody] UpdateDificuldadeRequestDto updateDificuldadeRequestDto)
        {
            var dificuldadeDomainModel = mapper.Map<Dificuldade>(updateDificuldadeRequestDto);
            var updatedDificuldadeDomainModel = await dificuldadeRepository.UpdateDificuldadeAsync(DificuldadeId, dificuldadeDomainModel);
            if (updatedDificuldadeDomainModel == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<DificuldadeDto>(updatedDificuldadeDomainModel));
        }

        // Delete Dificuldade
        // Delete: /api/dificuldades/{id}

        [HttpDelete]
        [Route("{ID_Dificuldade:Guid}")]

        public async Task<IActionResult> Delete(Guid ID_Dificuldade)
        {
            var deletedDificuldadeDomainModel = await dificuldadeRepository.DeleteAsync(ID_Dificuldade);
            if (deletedDificuldadeDomainModel == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<DificuldadeDto>(deletedDificuldadeDomainModel));
        }

    }
}
