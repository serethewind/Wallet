using WalletApi.Models.Domains;
using WalletApi.Models.DTO;

namespace WalletApi.Repositories
{
    public interface IRegionRepository
    {
        Task<List<Region>> GetAllAsync();

        Task<Region?> GetRegionById(Guid id);

        Task<Region> CreateRegion(RegionRequestDto regionRequestDto);

        Task<Region?> UpdateRegionById(Guid id, RegionUpdateRequestDto region);

        Task<Region?> DeleteRegionById(Guid id);
    }
}
