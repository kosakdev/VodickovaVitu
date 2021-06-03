using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CMS.DAL.Entities;
using CMS.DAL.Reporitories;
using CMS.Models.Calendar;

namespace CMS.BL.Facades
{
    public class CalendarFacade : FacadeBase<CalendarListModel, CalendarDetailModel, CalendarNewModel, CalendarUpdateModel, 
        CalendarRepository, CalendarEntity, Guid>
    {
        public CalendarFacade(CalendarRepository repository, IMapper mapper) 
            : base(repository, mapper)
        {
        }
        
        public async Task<IList<CalendarListModel>> GetAllNew(int skip=0)
        {
            return Mapper.Map<IList<CalendarListModel>>(await Repository.GetAllNew(skip));
        }
        
        public async Task<IList<CalendarListModel>> GetCountActual(int count)
        {
            return Mapper.Map<IList<CalendarListModel>>(await Repository.GetCountActual(count));
        }
        
        public async Task<IList<CalendarListModel>> GetAllOld(int skip=0)
        {
            return Mapper.Map<IList<CalendarListModel>>(await Repository.GetAllOld(skip));
        }
    }
}