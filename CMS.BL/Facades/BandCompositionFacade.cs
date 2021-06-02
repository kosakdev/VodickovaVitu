using System;
using AutoMapper;
using CMS.DAL.Entities;
using CMS.DAL.Reporitories;
using CMS.Models.BandComposition;

namespace CMS.BL.Facades
{
    public class BandCompositionFacade : FacadeBase<BandCompositionListModel, BandCompositionDetailModel, BandCompositionNewModel, BandCompositionUpdateModel, 
        BandCompositionRepository, BandCompositionEntity, Guid>
    {
        public BandCompositionFacade(BandCompositionRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}