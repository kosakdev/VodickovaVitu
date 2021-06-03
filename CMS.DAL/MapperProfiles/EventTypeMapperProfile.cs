using AutoMapper;
using CMS.DAL.Entities;

namespace CMS.DAL.MapperProfiles
{
    public class EventTypeMapperProfile : Profile
    {
        public EventTypeMapperProfile()
        {
            CreateMap<EventTypeEntity, EventTypeEntity>();
        }
    }
}