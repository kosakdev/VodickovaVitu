using System;
using AutoMapper;
using CMS.DAL.Entities;
using CMS.DAL.Reporitories.Interfaces;

namespace CMS.DAL.Reporitories
{
    public class TagRepository : RepositoryBase<TagEntity, Guid>, IAppRepository<TagEntity, Guid>
    {
        public TagRepository(Func<WebDataContext> contextFactory, IMapper mapper) 
            : base(contextFactory, mapper)
        {
        }
    }
}