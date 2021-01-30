using System;
using CMS.DAL.Entities.Interfaces;

namespace CMS.DAL.Entities
{
    public class EntityBase : IEntity
    {
        public Guid Id { get; set; }
    }
}