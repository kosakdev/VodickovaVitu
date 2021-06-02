using AutoMapper;
using CMS.DAL.Entities;

namespace CMS.DAL.MapperProfiles
{
    public class BandCompositionMapperProfile : Profile
    {
        public BandCompositionMapperProfile()
        {
            CreateMap<BandCompositionEntity, BandCompositionEntity>();
        }
    }
}