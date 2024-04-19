using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using WalletApi.Controllers.CustomActionFilters;
using WalletApi.Models.DTO;
using WalletApi.Repositories;

namespace WalletApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper _iMapper;
        private readonly IWalkRepository _walkRepository;

        public WalksController(IMapper _iMapper, IWalkRepository _walkRepository)
        {
            this._iMapper = _iMapper;
            this._walkRepository = _walkRepository;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllWalks(
            [FromQuery] string? filterOn, [FromQuery] string? filterQuery,
            [FromQuery] string? sortBy = null, [FromQuery] bool isAscending = true,
            [FromQuery][Range(1, int.MaxValue, ErrorMessage ="Value should not be less than 1")] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
           var walkModels = await _walkRepository.GetWalksAsync(filterOn,filterQuery, sortBy, isAscending, pageNumber, pageSize);
           return Ok(_iMapper.Map <List<WalkDto>>(walkModels));
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetWalkById([FromRoute]Guid id)
        {
          var walk = await _walkRepository.GetWalkByIdAsync(id);
            if (walk is null)
            {
                return NotFound();
            }
            return Ok(_iMapper.Map<WalkDto>(walk));
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> CreateWalk([FromBody]WalkRequestDto walkRequestDto)
        {
            var walk = await _walkRepository.CreateWalkAsync(walkRequestDto);
            return CreatedAtAction(nameof(GetWalkById), new { Id = walk.Id }, _iMapper.Map<WalkDto>(walk));
        }

        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> UpdateWalkById([FromRoute] Guid id, [FromBody] WalkUpdateRequestDto walkUpdateRequestDto)
        {
            if (ModelState.IsValid) {
                var walk = await _walkRepository.UpdateWalkByIdAsync(id, walkUpdateRequestDto);
                if (walk is null)
                {
                    return null;
                }
                return Ok(_iMapper.Map<WalkDto>(walk));
            } else
            {
                return BadRequest();
            }
          
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteWalkById([FromRoute] Guid id)
        {
           var walk = await _walkRepository.DeleteWalkByIdAsync(id);
            return Ok(_iMapper.Map<WalkDto>(walk));
        }
    }
}
