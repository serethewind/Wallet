using WalletApi.Models.Domains;
using WalletApi.Models.DTO;

namespace WalletApi.Repositories
{
    public interface IWalkRepository
    {
        Task<List<Walk>> GetWalksAsync();

        Task<Walk?> GetWalkByIdAsync(Guid id);

        Task<Walk> CreateWalkAsync(WalkRequestDto walkRequestDto);

        Task<Walk?> UpdateWalkByIdAsync(Guid id, WalkUpdateRequestDto walkUpdateRequestDto);

        Task<Walk?> DeleteWalkByIdAsync(Guid id);
    }
}
