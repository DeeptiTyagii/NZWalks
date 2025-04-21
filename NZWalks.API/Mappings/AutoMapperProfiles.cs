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
        }
    }
}
