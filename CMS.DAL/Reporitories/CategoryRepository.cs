using System;
using AutoMapper;
using CMS.DAL.Entities;
using CMS.DAL.Reporitories.Interfaces;

namespace CMS.DAL.Reporitories
{
    public class CategoryRepository : RepositoryBase<CategoryEntity, Guid>, IAppRepository<CategoryEntity, Guid>
    {
        public CategoryRepository(Func<WebDataContext> contextFactory, IMapper mapper) 
            : base(contextFactory, mapper)
        {
        }
    }
}