using AutoMapper;
using CMS.DAL.Entities;
using CMS.Models.BandComposition;

namespace CMS.BL.MapperProfiles
{
    public class BandCompositionMapperProfile : Profile
    {
        public BandCompositionMapperProfile()
        {
            CreateMap<BandCompositionEntity, BandCompositionListModel>();
            CreateMap<BandCompositionNewModel, BandCompositionEntity>();
            CreateMap<BandCompositionEntity, BandCompositionDetailModel>();
            CreateMap<BandCompositionDetailModel, BandCompositionNewModel>();
            
            CreateMap<BandCompositionUpdateModel, BandCompositionEntity>();
            CreateMap<BandCompositionDetailModel, BandCompositionUpdateModel>();
        }
    }
}