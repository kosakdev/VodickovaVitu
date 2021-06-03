using AutoMapper;
using CMS.DAL.Entities;
using CMS.Models.Music;

namespace CMS.BL.MapperProfiles
{
    public class MusicMapperProfile : Profile
    {
        public MusicMapperProfile()
        {
            CreateMap<MusicEntity, MusicListModel>();
            CreateMap<MusicNewModel, MusicEntity>();
            CreateMap<MusicEntity, MusicDetailModel>();
            CreateMap<MusicDetailModel, MusicUpdateModel>();
            
            CreateMap<MusicUpdateModel, EventTypeEntity>();
            CreateMap<MusicDetailModel, MusicUpdateModel>();
        }
    }
}