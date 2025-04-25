using AutoMapper;
using NZWalks.API.Domain.DTO;
using NZWalks.API.Domain.Models;

namespace NZWalks.API.Mappings
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles() 
        {
            CreateMap<Region, RegionDto>().ReverseMap();
            CreateMap<AddRegionRequestDto, Region>().ReverseMap();
            CreateMap<UpdateRegionRequestDto, Region>().ReverseMap();
            CreateMap<WalkDto, Walk>().ReverseMap();
            CreateMap<AddWalkRequestDto, Walk>().ReverseMap();
        }
    }
}
