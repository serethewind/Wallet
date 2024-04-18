using AutoMapper;
using WalletApi.Models.Domains;
using WalletApi.Models.DTO;

namespace WalletApi.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<RegionDto, Region>()              
                .ReverseMap();
            CreateMap<RegionRequestDto, Region>();
            CreateMap<RegionUpdateRequestDto, Region>();
        }
    }
}
