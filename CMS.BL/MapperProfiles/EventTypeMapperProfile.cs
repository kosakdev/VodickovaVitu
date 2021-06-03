using AutoMapper;
using CMS.DAL.Entities;
using CMS.Models.EventType;

namespace CMS.BL.MapperProfiles
{
    public class EventTypeMapperProfile : Profile
    {
        public EventTypeMapperProfile()
        {
            CreateMap<EventTypeEntity, EventTypeListModel>();
            CreateMap<EventTypeNewModel, EventTypeEntity>();
            CreateMap<EventTypeEntity, EventTypeDetailModel>();
            CreateMap<EventTypeDetailModel, EventTypeNewModel>();
            
            CreateMap<EventTypeUpdateModel, EventTypeEntity>();
            CreateMap<EventTypeDetailModel, EventTypeUpdateModel>();
        }
    }
}