using System;
using CMS.DAL.Entities.Interfaces;

namespace CMS.DAL.Reporitories.Interfaces
{
    public interface IAppRepository<TEntity, TId> 
        where TEntity : IEntity<TId>
    {
        
    }
}