using System;
using AutoMapper;
using CMS.DAL.Entities;
using CMS.DAL.Reporitories;
using CMS.Models.Video;

namespace CMS.BL.Facades
{
    public class VideoFacade: FacadeBase<VideoListModel, VideoListModel, VideoNewModel, VideoUpdateModel, 
        VideoRepository, VideoEntity, Guid>
    {
        public VideoFacade(VideoRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}