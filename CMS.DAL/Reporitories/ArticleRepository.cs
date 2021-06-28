using System;
using System.Threading.Tasks;
using AutoMapper;
using CMS.DAL.Entities;
using CMS.DAL.Reporitories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CMS.DAL.Reporitories
{
    public class ArticleRepository : RepositoryBase<ArticleEntity, Guid>, IAppRepository<ArticleEntity, Guid>
    {
        public ArticleRepository(Func<WebDataContext> contextFactory, IMapper mapper) 
            : base(contextFactory, mapper)
        {
        }
        
        public virtual async Task<ArticleEntity> GetByUrl(string url)
        {
            await using var context = _contextFactory();
            return await context.Set<ArticleEntity>().FirstOrDefaultAsync(entity => entity.Url.Equals(url));
        }
    }
}