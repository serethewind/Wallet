using WalletApi.Models.Domains;
using WalletApi.Models.DTO;

namespace WalletApi.Repositories
{
    public interface IWalkRepository
    {
        Task<List<Walk>> GetWalksAsync(string? filterOn = null, string? filterQuery = null, string? sortBy = null, bool isAscending = true, int pageNumber = 1, int pageSize = 10);

        Task<Walk?> GetWalkByIdAsync(Guid id);

        Task<Walk> CreateWalkAsync(WalkRequestDto walkRequestDto);

        Task<Walk?> UpdateWalkByIdAsync(Guid id, WalkUpdateRequestDto walkUpdateRequestDto);

        Task<Walk?> DeleteWalkByIdAsync(Guid id);
    }
}
