using WalletApi.Models.Domains;

namespace WalletApi.Repositories
{
    public interface IRegionRepository
    {
        Task<List<Region>> GetAllAsync();

        Task<Region> GetRegionById();

        Task<Region> CreateRegion();

        Task<Region> 
    }
}
