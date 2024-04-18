using Microsoft.EntityFrameworkCore;
using WalletApi.Data;
using WalletApi.Models.Domains;

namespace WalletApi.Repositories.Implementations
{
    public class RegionRepository : IRegionRepository
    {

        //dependency injection of the dbwalkcontext

        private readonly WalletDbContext walletDbContext;

        public RegionRepository(WalletDbContext walletDbContext)
        {
            this.walletDbContext = walletDbContext;
        }


        public async Task<List<Region>> GetAllAsync()
        {
            return await walletDbContext.Regions.ToListAsync();
        }
    }
}
