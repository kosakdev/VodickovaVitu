using System;
using AutoMapper;
using CMS.DAL.Entities;
using CMS.DAL.Reporitories.Interfaces;

namespace CMS.DAL.Reporitories
{
    public class ArticleRepository : RepositoryBase<ArticleEntity, Guid>, IAppRepository<ArticleEntity, Guid>
    {
        public ArticleRepository(Func<WebDataContext> contextFactory, IMapper mapper) 
            : base(contextFactory, mapper)
        {
        }
    }
}