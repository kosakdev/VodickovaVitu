using System;
using System.Threading.Tasks;
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
        
        public virtual async Task<ArticleDetailModel> GetByUrl(string url)
        {
            var entity = await Repository.GetByUrl(url);
            return Mapper.Map<ArticleDetailModel>(entity);
        }
    }
}