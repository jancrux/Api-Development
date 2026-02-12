using Api_Development.Models.Domain;
using Api_Development.Models.DTOs;
using AutoMapper;

namespace Api_Development.Mappings
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Region, RegionDto>().ReverseMap();
        }
    }
}
