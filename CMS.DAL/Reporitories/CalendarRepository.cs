using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CMS.DAL.Entities;
using CMS.DAL.Reporitories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CMS.DAL.Reporitories
{
    public class CalendarRepository : RepositoryBase<CalendarEntity, Guid>, IAppRepository<CalendarEntity, Guid>
    {
        public CalendarRepository(Func<WebDataContext> contextFactory, IMapper mapper) 
            : base(contextFactory, mapper)
        {
        }
        
        public override async Task<IList<CalendarEntity>> GetAll()
        {
            await using var context = _contextFactory();
            return await context.Set<CalendarEntity>().Include(i => i.EventType)
                .OrderByDescending(o => o.DateTime).ToListAsync();
        }

        public async Task<IList<CalendarEntity>> GetAllNew(int skip=0)
        {
            await using var context = _contextFactory();
            return await context.Set<CalendarEntity>()
                .Include(i => i.EventType)
                .OrderBy(o => o.DateTime)
                .Where(w => w.DateTime >= DateTime.Today).Skip(skip).ToListAsync();
        }
        
        public async Task<IList<CalendarEntity>> GetCountActual(int count)
        {
            await using var context = _contextFactory();
            return await context.Set<CalendarEntity>()
                .Include(i => i.EventType)
                .OrderBy(o => o.DateTime)
                .Where(w => w.DateTime >= DateTime.Today).Take(count).ToListAsync();
        }
        
        public async Task<IList<CalendarEntity>> GetAllOld(int skip=0)
        {
            await using var context = _contextFactory();
            return await context.Set<CalendarEntity>()
                .Include(i => i.EventType)
                .OrderByDescending(o => o.DateTime)
                .Where(w => w.DateTime < DateTime.Today).Skip(skip).Take(5).ToListAsync();
        }
    }
}