using System;
using AutoMapper;
using CMS.DAL.Entities;
using CMS.DAL.Reporitories.Interfaces;

namespace CMS.DAL.Reporitories
{
    public class EventTypeRepository : RepositoryBase<EventTypeEntity, Guid>, IAppRepository<MusicEntity, Guid>
    {
        public EventTypeRepository(Func<WebDataContext> contextFactory, IMapper mapper) : base(contextFactory, mapper)
        {
        }
    }
}