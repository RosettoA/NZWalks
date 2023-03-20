using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalks.Api.Models.DTO;
using NZWalks.Api.Repositories;

namespace NZWalks.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WalkDifficultiesController : Controller
    {
        private readonly IWalkDifficultyRepository _walkDifficultyRepository;
        private readonly IMapper _mapper;

        public WalkDifficultiesController(IWalkDifficultyRepository walkDifficultyRepository, IMapper mapper)
        {
            this._walkDifficultyRepository = walkDifficultyRepository;
            this._mapper = mapper;
        }

        [HttpGet] 
        public async Task<IActionResult> GetAllWalkDifficulties()
        {
            var walkDifficulty = await _walkDifficultyRepository.GetAllAsync();

            var walkDifficultyDTO = _mapper.Map<List<Models.DTO.WalkDifficulty>>(walkDifficulty);

            return Ok(walkDifficultyDTO);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetWalkDifficultyById")]
        public async Task<IActionResult> GetWalkDifficultyById(Guid id)
        {
            var walkdifficulty = await _walkDifficultyRepository.GetAsync(id);
            if(walkdifficulty == null)
            {
                return NotFound();
            }
            //convert domain to DTOs
            var walkDifficultyDTO = _mapper.Map<Models.DTO.WalkDifficulty>(walkdifficulty);
            return Ok(walkDifficultyDTO);
        }

        [HttpPost]
        public async Task<IActionResult> AddWalkDifficultyAsync(Models.DTO.AddWalkDifficultyRequest addWalkDifficultyRequest)
        {
            var walkDifficultyDomain = new Models.Domain.WalkDifficulty
            {
                Code = addWalkDifficultyRequest.Code,
            };
            walkDifficultyDomain = await _walkDifficultyRepository.AddAsync(walkDifficultyDomain);
            var walkDifficultyDTO = _mapper.Map<Models.DTO.WalkDifficulty>(walkDifficultyDomain);

            return CreatedAtAction(nameof(GetWalkDifficultyById), new { id = walkDifficultyDTO.Id }, walkDifficultyDTO);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteWalkDifficultyAsync(Guid id)
        {
            //Get Walk from DB
            var walkDifficulty = await _walkDifficultyRepository.DeleteAsync(id);
            //if null = NotFound
            if (walkDifficulty == null)
            {
                return NotFound();
            }
            //Convert response back to DTO
            var walkDifficultyDTO = _mapper.Map<Models.DTO.WalkDifficulty>(walkDifficulty);
            //return OK response
            return Ok(walkDifficultyDTO);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateWalkDifficultyAsync([FromRoute] Guid id, [FromBody] Models.DTO.UpdateWalkDifficultyRequest updateWalkDifficultyRequest)
        {
            //Convert DTO Domain model
            var walkDifficulty = new Models.Domain.WalkDifficulty()
            {
                Code = updateWalkDifficultyRequest.Code,
            };
            //Update Walk using repository
            walkDifficulty = await _walkDifficultyRepository.UpdateAsync(id, walkDifficulty);
            //if null then notfound
            if (walkDifficulty == null)
            {
                return NotFound();
            }

            //Convert domain back to DTO
            var walkDifficultyDTO = new Models.DTO.WalkDifficulty()
            {
                Id = walkDifficulty.Id,
                Code = walkDifficulty.Code,
            };
            //return ok response
            return Ok(walkDifficultyDTO);
        }
    }
}
