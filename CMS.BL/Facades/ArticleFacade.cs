using System;
using AutoMapper;
using CMS.DAL.Entities;
using CMS.DAL.Reporitories;
using CMS.Models.Article;

namespace CMS.BL.Facades
{
    public class ArticleFacade : FacadeBase<ArticleListModel, ArticleDetailModel, ArticleNewModel, ArticleUpdateModel, 
        ArticleRepository, ArticleEntity, Guid>
    {
        public ArticleFacade(ArticleRepository repository, IMapper mapper) 
            : base(repository, mapper)
        {
        }
    }
}