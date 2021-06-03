using System;
using AutoMapper;
using CMS.DAL.Entities;
using CMS.DAL.Reporitories;
using CMS.Models.EventType;

namespace CMS.BL.Facades
{
    public class EventTypeFacade : FacadeBase<EventTypeListModel, EventTypeDetailModel, EventTypeNewModel, EventTypeUpdateModel, 
        EventTypeRepository, EventTypeEntity, Guid>
    {
        public EventTypeFacade(EventTypeRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}