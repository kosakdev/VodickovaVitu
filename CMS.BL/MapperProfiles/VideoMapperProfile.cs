using AutoMapper;
using CMS.DAL.Entities;
using CMS.Models.Video;

namespace CMS.BL.MapperProfiles
{
    public class VideoMapperProfile : Profile
    {
        public VideoMapperProfile()
        {
            CreateMap<VideoEntity, VideoListModel>();
            CreateMap<VideoNewModel, VideoEntity>();
            CreateMap<VideoEntity, VideoListModel>();
            CreateMap<VideoListModel, VideoUpdateModel>();
            
            CreateMap<VideoUpdateModel, VideoEntity>();
        }
    }
}