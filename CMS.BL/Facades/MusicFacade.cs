using System;
using AutoMapper;
using CMS.DAL.Entities;
using CMS.DAL.Reporitories;
using CMS.Models.Music;

namespace CMS.BL.Facades
{
    public class MusicFacade: FacadeBase<MusicListModel, MusicDetailModel, MusicNewModel, MusicUpdateModel, 
        MusicRepository, MusicEntity, Guid>
    {
        public MusicFacade(MusicRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}