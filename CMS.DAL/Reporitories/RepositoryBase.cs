using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CMS.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace CMS.DAL.Reporitories
{
    public class RepositoryBase<TEntity> where TEntity : EntityBase
    {
        private readonly Func<WebDataContext> _contextFactory;
        private readonly IMapper _mapper;

        public RepositoryBase(Func<WebDataContext> contextFactory, IMapper mapper)
        {
            _contextFactory = contextFactory;
            _mapper = mapper;
        }
        
        public virtual async Task<IList<TEntity>> GetAll()
        {
            await using var context = _contextFactory();
            return await context.Set<TEntity>().ToListAsync();
        }

        public virtual async Task<TEntity> GetById(Guid id)
        {
            await using var context = _contextFactory();
            return await context.Set<TEntity>().FirstOrDefaultAsync(entity => entity.Id == id);
        }

        public virtual async Task<Guid> Insert(TEntity entity)
        {
            await using var context = _contextFactory();

            entity.Id = Guid.NewGuid();
            await context.Set<TEntity>().AddAsync(entity);
            await context.SaveChangesAsync();
            return entity.Id;
        }
        
        public virtual async Task<Guid?> Update(TEntity entity)
        {
            await using var context = _contextFactory();
            
            var entityExists = await GetById(entity.Id);
            if (entityExists == null) return null;
            _mapper.Map(entity, entityExists);
            context.Set<TEntity>().Update(entityExists);
            await context.SaveChangesAsync();

            return entityExists.Id;
        }
        
        public virtual async Task Remove(Guid id)
        {
            await using var context = _contextFactory();
            
            var entityExists = await GetById(id);
            context.Set<TEntity>().Remove(entityExists);
            await context.SaveChangesAsync();
        }
    }
}