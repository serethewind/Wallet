using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WalletApi.Data;
using WalletApi.Models.Domains;
using WalletApi.Models.DTO;

namespace WalletApi.Repositories.Implementations
{
    public class RegionRepository : IRegionRepository
    {

        //dependency injection of the dbwalkcontext

        private readonly WalletDbContext walletDbContext;
        private readonly IMapper _iMapper;

        public RegionRepository(WalletDbContext walletDbContext, IMapper _iMapper)
        {
            this.walletDbContext = walletDbContext;
            this._iMapper = _iMapper;
        }

        public async Task<Region> CreateRegion(RegionRequestDto regionRequestDto)
        {
            //var region = new Region
            //{
            //    Id = Guid.NewGuid(),
            //    Name = regionRequestDto.Name,
            //    Code = regionRequestDto.Code,
            //    RegionImageUrl = regionRequestDto.RegionImageUrl
            //};
            var region = _iMapper.Map<Region>(regionRequestDto);

            await walletDbContext.Regions.AddAsync(region);
            await walletDbContext.SaveChangesAsync();

            return region;
         
        }

        public async Task<Region?> DeleteRegionById(Guid id)
        {
           var region = await walletDbContext.Regions.FindAsync(id);
            if (region is null)
            {
                return null;
            }
            walletDbContext.Regions.Remove(region);
            await walletDbContext.SaveChangesAsync();
            return region;
        }

        public async Task<List<Region>> GetAllAsync()
        {
            return await walletDbContext.Regions.ToListAsync();
        }

        public async Task<Region?> GetRegionById(Guid id)
        {
           var regionModel = await walletDbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (regionModel is null)
            {
                return null;
            }
            return regionModel;
        }

        public async Task<Region?> UpdateRegionById(Guid id, RegionUpdateRequestDto region)
        {
            var existingRegion = await walletDbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

            if (existingRegion is null)
            {
                return null;
            }

            existingRegion.Code = region.Code;
            existingRegion.Name = region.Name;
            existingRegion.RegionImageUrl = region.RegionImageUrl;

            await walletDbContext.SaveChangesAsync();
            return existingRegion;
        }
    }
}
