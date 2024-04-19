using AutoMapper;
using Microsoft.EntityFrameworkCore;
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

        public async Task<List<Walk>> GetWalksAsync()
        {
            return await walletDbContext.Walks.Include(x => x.Region).Include(x => x.Difficulty).
                ToListAsync();

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
