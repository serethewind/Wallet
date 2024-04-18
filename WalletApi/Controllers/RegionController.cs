using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WalletApi.Data;
using WalletApi.Models.Domains;
using WalletApi.Models.DTO;

namespace WalletApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {

        private readonly WalletDbContext walletDbContext;

        public RegionController(WalletDbContext walletDbContext)
        {
            this.walletDbContext = walletDbContext;
        }

        [HttpPost]
        //actionMethods
        public IActionResult CreateRegion([FromBody] RegionRequestDto regionRequestDto)
        {
            //the dto in the format the data is received is converted to an instance of RegionModel stored in the DbContext
            //The object is saved in the db.
            //It is then returned as a model. The method to look out for is the CreatedAtAction();
            var regionModel = new Region
            {
                Id = Guid.NewGuid(),
                Code = regionRequestDto.Code,
                Name = regionRequestDto.Name,
                RegionImageUrl = regionRequestDto.RegionImageUrl
            };
            walletDbContext.Regions.Add(regionModel);
            walletDbContext.SaveChanges();


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
        public IActionResult GetRegions()
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

           
            var regions = walletDbContext.Regions.ToList().Select((x) => new RegionDto
            {
                Id = x.Id,
                Code = x.Code,
                RegionImageUrl = x.RegionImageUrl,
                Name = x.Name
            }
            ).ToList();

          
            return Ok(regions);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetRegionById([FromRoute] Guid id)
        {
            //  var region = walletDbContext.Regions.Find(id);
            //  var region = walletDbContext.Regions.FirstOrDefault(x => x.Id == id);
            var regionDto = walletDbContext.Regions
                .Where(x => x.Id == id)
                .Select(x => new RegionDto
                {
                    Id = x.Id,
                    Code = x.Code,
                    Name = x.Name,
                    RegionImageUrl = x.RegionImageUrl
                }
                ).FirstOrDefault();
             
            if (regionDto == null)
            {
                return NotFound();
            }
            Console.WriteLine(regionDto != null ? regionDto.Name : "Nothing found");
            return Ok(regionDto);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateRegionById([FromRoute] Guid id, [FromBody] RegionRequestDto regionRequestDto)
        {
            var region = walletDbContext.Regions.FirstOrDefault(x => x.Id == id);
            if (region == null)
            {
                return NotFound();
            }
            region.Code = regionRequestDto.Code;
            region.Name = regionRequestDto.Name;
            region.RegionImageUrl = regionRequestDto.RegionImageUrl;

            // walletDbContext.Regions.Update(region);
            walletDbContext.SaveChanges();

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
        public IActionResult DeleteRegionById([FromRoute] Guid id)
        {

          var region =  walletDbContext.Regions.Find(id);
            if (region == null)
            {
                return NotFound();
            }
            walletDbContext.Regions.Remove(region);
            walletDbContext.SaveChanges();
            return Ok();
        }
    }
}
