using AutoMapper;
using WalletApi.Models.Domains;
using WalletApi.Models.DTO;

namespace WalletApi.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<RegionDto, Region>().ReverseMap();
            CreateMap<RegionRequestDto, Region>().ReverseMap();
            CreateMap<RegionUpdateRequestDto, Region>().ReverseMap();

            CreateMap<WalkRequestDto, Walk>();
            CreateMap<WalkUpdateRequestDto, Walk>();
            CreateMap<WalkDto, Walk>().ReverseMap();
        }
    }
}
