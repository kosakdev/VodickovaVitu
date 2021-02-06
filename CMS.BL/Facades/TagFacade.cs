using System;
using AutoMapper;
using CMS.DAL.Entities;
using CMS.DAL.Reporitories;
using CMS.Models.Tag;

namespace CMS.BL.Facades
{
    public class TagFacade : FacadeBase<TagListModel, TagDetailModel, TagNewModel, TagUpdateModel, 
        TagRepository, TagEntity, Guid>
    {
        public TagFacade(TagRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}