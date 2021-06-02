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
    public class BandCompositionRepository : RepositoryBase<BandCompositionEntity, Guid>, IAppRepository<BandCompositionEntity, Guid>
    {
        public BandCompositionRepository(Func<WebDataContext> contextFactory, IMapper mapper) : base(contextFactory, mapper)
        {
        }
        
        public override async Task<IList<BandCompositionEntity>> GetAll()
        {
            await using var context = _contextFactory();
            return await context.Set<BandCompositionEntity>().OrderBy(m => m.Title).ToListAsync();
        }
    }
}