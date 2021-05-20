using System;
using AutoMapper;
using CMS.DAL.Entities;
using CMS.DAL.Reporitories.Interfaces;

namespace CMS.DAL.Reporitories
{
    public class CalendarRepository : RepositoryBase<CalendarEntity, Guid>, IAppRepository<CalendarEntity, Guid>
    {
        public CalendarRepository(Func<WebDataContext> contextFactory, IMapper mapper) 
            : base(contextFactory, mapper)
        {
        }
    }
}