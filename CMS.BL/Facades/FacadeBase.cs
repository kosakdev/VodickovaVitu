using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CMS.BL.Facades.Interfaces;
using CMS.DAL.Entities.Interfaces;
using CMS.DAL.Reporitories;

namespace CMS.BL.Facades
{
    public class FacadeBase<TListModel, TDetailModel, TNewModel, TUpdateModel, TRepository, TEntity, TId> : IAppFacade
        where TRepository : RepositoryBase<TEntity, TId> 
        where TEntity : class, IEntity<TId>
    {
        private readonly TRepository _repository;
        private readonly IMapper _mapper;

        public FacadeBase(TRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public virtual async Task<List<TListModel>> GetAll()
        {
            return _mapper.Map<List<TListModel>>(await _repository.GetAll());
        }

        public virtual async Task<TDetailModel> GetById(TId id)
        {
            var entity = await _repository.GetById(id);
            return _mapper.Map<TDetailModel>(entity);
        }

        public virtual async Task<TId> Create(TNewModel newModel)
        {
            var entity = _mapper.Map<TEntity>(newModel);
            return await _repository.Insert(entity);
        }

        public virtual async Task<TId> Update(TUpdateModel updateModel)
        {
            var entity = _mapper.Map<TEntity>(updateModel);
            return await _repository.Update(entity);
        }

        public virtual async Task Remove(TId id)
        {
            await _repository.Remove(id);
        }
    }
}