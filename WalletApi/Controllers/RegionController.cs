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

        private readonly WalletDbContext walletDbContext;

        public RegionController(WalletDbContext walletDbContext, IRegionRepository _regionRepository)
        {
            this.walletDbContext = walletDbContext;
            this._regionRepository = _regionRepository;
        }

        [HttpPost]
        //actionMethods
        public async Task<IActionResult> CreateRegion([FromBody] RegionRequestDto regionRequestDto)
        {
            //the dto in the format the data is received is converted to an instance of RegionModel stored in the DbContext
            //The object is saved in the db.
            //It is then returned as a model. The method to look out for is the CreatedAtAction();
            var regionModel = await _regionRepository.CreateRegion(regionRequestDto);

            if (regionModel is null)
            {
                return BadRequest();
            }

            var regionModelToBeReturned = new RegionDto
            {
                Id = regionModel.Id,
                Code = regionModel.Code,
                Name = regionModel.Name,
                RegionImageUrl = regionModel.RegionImageUrl
            };
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
            var regionDtos = regions.Select(x => new RegionDto
            {
                Id = x.Id,
                Code = x.Code,
                RegionImageUrl = x.RegionImageUrl,
                Name = x.Name
            }).ToList();
        /*    var regions = await walletDbContext.Regions.ToListAsync().Select((x) => new RegionDto
            {
                Id = x.Id,
                Code = x.Code,
                RegionImageUrl = x.RegionImageUrl,
                Name = x.Name
            }
            ).ToList();
        */
          
            return Ok(regions);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetRegionById([FromRoute] Guid id)
        {
            //  var region = walletDbContext.Regions.Find(id);
            //  var region = walletDbContext.Regions.FirstOrDefault(x => x.Id == id);
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
            // var region =  await walletDbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            var region = await _regionRepository.UpdateRegionById(id, regionUpdateRequestDto);
            if (region == null)
            {
                return NotFound();
            }
           
            RegionDto regionToBeReturned = new RegionDto
            {
                Id = region.Id,
                Name = region.Name,
                Code = region.Code,
                RegionImageUrl = region.RegionImageUrl
            };

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
            walletDbContext.Regions.Remove(region);
            await walletDbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
