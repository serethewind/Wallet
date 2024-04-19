using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using WalletApi.Data;
using WalletApi.Models.Domains;
using WalletApi.Models.DTO;

namespace WalletApi.Repositories.Implementations
{
    public class WalkRepository : IWalkRepository
    {
        private readonly WalletDbContext walletDbContext;
        private readonly IMapper _iMapper;
        
        public WalkRepository(WalletDbContext walletDbContext, IMapper _iMapper)
        {
            this.walletDbContext = walletDbContext;
            this._iMapper = _iMapper;
        }

        public async Task<Walk> CreateWalkAsync(WalkRequestDto walkRequestDto)
        {
            var walk = _iMapper.Map<Walk>(walkRequestDto);
            await walletDbContext.Walks.AddAsync(walk);
            await walletDbContext.SaveChangesAsync();

            return walk;
        }

        public async Task<Walk?> DeleteWalkByIdAsync(Guid id)
        {
            var walk = await walletDbContext.Walks.FirstOrDefaultAsync(walk => walk.Id == id);
            if (walk is null)
            {
                return null;
            }
            walletDbContext.Walks.Remove(walk);
            await walletDbContext.SaveChangesAsync();

            return walk;
        }

        public async Task<Walk?> GetWalkByIdAsync(Guid id)
        {
            var walk = await walletDbContext.Walks.Include(x => x.Difficulty).Include(x => x.Region).FirstOrDefaultAsync(walk => walk.Id == id);
            if (walk is null)
            {
                return null;
            }
            return walk;
        }

        public async Task<List<Walk>> GetWalksAsync(string? filterOn = null, string? filterQuery = null, 
                                                    string? sortBy = null, bool isAscending = true,
                                                    int pageNumber = 1, int pageSize = 10
                                                    )
        {
           
            //fitering
           var walks = walletDbContext.Walks.Include(x => x.Difficulty).Include(x => x.Region).AsQueryable();

            if (string.IsNullOrWhiteSpace(filterOn) == false && string.IsNullOrWhiteSpace(filterQuery) == false)
            {
                if (filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                   walks = walks.Where(walk => walk.Name.Contains(filterQuery));
                }
            }

            //soring
            if (string.IsNullOrWhiteSpace(sortBy) == false)
            {
                if (sortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walks = isAscending ? walks.OrderBy(walk => walk.Name) : walks.OrderByDescending(walk => walk.Name);
                }
                else if (sortBy.Equals("LengthInKm", StringComparison.OrdinalIgnoreCase))
                {
                    walks = isAscending ? walks.OrderBy(walk => walk.LengthInKm) : walks.OrderByDescending(walk => walk.LengthInKm);
                }
               
            }

            //pagination
            int skippedResults = (pageNumber - 1) * pageSize;

           return await walks.Skip(skippedResults).Take(pageSize).ToListAsync();

        }

        public async Task<Walk?> UpdateWalkByIdAsync(Guid id, WalkUpdateRequestDto walkUpdateRequestDto)
        {
            var walk = await walletDbContext.Walks.FirstOrDefaultAsync(walk => walk.Id == id);
            if (walk is null)
            {
                return null;
            }
            //fix the set up 
            return walk;
        }
    }
}
