using AutoMapper;
using DotNetDemo.API.Models.Domain;
using DotNetDemo.API.Models.DTO;

namespace DotNetDemo.API.Mappings
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Region,RegionDto>().ReverseMap();
            CreateMap<AddRegionRequestDto,RegionDto>().ReverseMap();
            CreateMap<UpdateRegionrRquestDto,Region>().ReverseMap();
        }

    }
}
