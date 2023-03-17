using AutoMapper;

namespace NZWalks.Api.Profiles
{
    public class RegionsProfile : Profile
    {
        public RegionsProfile()
        {
            CreateMap<Models.Domain.Region, Models.DTO.Region>();
        }
    }
}
