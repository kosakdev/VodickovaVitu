using System;
using AutoMapper;
using CMS.DAL.Entities;
using CMS.DAL.Reporitories;
using CMS.Models.Event;

namespace CMS.BL.Facades
{
    public class EventFacade : FacadeBase<EventListModel, EventDetailModel, EventNewModel, EventUpdateModel, 
        EventRepository, EventEntity, Guid>
    {
        public EventFacade(EventRepository repository, IMapper mapper) 
            : base(repository, mapper)
        {
        }
    }
}