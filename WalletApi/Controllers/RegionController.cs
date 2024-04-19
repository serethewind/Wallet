using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WalletApi.Data;
using WalletApi.Models.Domains;
using WalletApi.Models.DTO;
using WalletApi.Repositories;

namespace WalletApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly IRegionRepository _regionRepository;
        private readonly IMapper _iMapper;

        public RegionController(IRegionRepository _regionRepository, IMapper _iMapper)
        {
            this._regionRepository = _regionRepository;
            this._iMapper = _iMapper;
        }

        [HttpPost]
        //actionMethods
        public async Task<IActionResult> CreateRegion([FromBody] RegionRequestDto regionRequestDto)
        {
           
            var regionModel = await _regionRepository.CreateRegion(regionRequestDto);

            if (regionModel is null)
            {
                return BadRequest();
            }

            var regionModelToBeReturned = _iMapper.Map<RegionDto>(regionModel);
           // return CreatedAtAction();
            return CreatedAtAction(nameof(GetRegionById), new { Id = regionModel.Id}, regionModelToBeReturned );
        }

       
        // localhost:portnumber/api/Region
        [HttpGet]
        public async Task<IActionResult> GetRegions()
        {
            /* var regions = new List<Region>
             {
                 new Region
                 {
                     Id = Guid.NewGuid(),
                     Code = "AKL",
                     Name = "Auckland Region",
                     RegionImageUrl = null
                 },
                 new Region
                 {
                     Id = Guid.NewGuid(),
                     Code = "WLG",
                     Name = "Wellington",
                     RegionImageUrl = null
                 }
             };
            */

            var regions = await _regionRepository.GetAllAsync();
            var regionDtos = _iMapper.Map<List<RegionDto>>(regions);
        
          
            return Ok(regions);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetRegionById([FromRoute] Guid id)
        {
           
            var regionDto = await _regionRepository.GetRegionById(id);
             
            if (regionDto == null)
            {
                return NotFound();
            }
            Console.WriteLine(regionDto != null ? regionDto.Name : "Nothing found");
            return Ok(regionDto);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateRegionById([FromRoute] Guid id, [FromBody] RegionUpdateRequestDto regionUpdateRequestDto)
        {
           
            var region = await _regionRepository.UpdateRegionById(id, regionUpdateRequestDto);
            if (region == null)
            {
                return NotFound();
            }

            var regionToBeReturned = _iMapper.Map<RegionDto>(region);

            return Ok(regionToBeReturned);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteRegionById([FromRoute] Guid id)
        {

            var region = await _regionRepository.DeleteRegionById(id);
            if (region == null)
            {
                return NotFound();
            }
            
            return Ok(region);
        }
    }
}
