using System;
using AutoMapper;
using CMS.DAL.Entities;
using CMS.DAL.Reporitories.Interfaces;

namespace CMS.DAL.Reporitories
{
    public class MusicRepository : RepositoryBase<MusicEntity, Guid>, IAppRepository<MusicEntity, Guid>
    {
        public MusicRepository(Func<WebDataContext> contextFactory, IMapper mapper) : base(contextFactory, mapper)
        {
        }
    }
}