using AutoMapper;
using Cross.Business.Domain.Queries;
using Cross.BusinessService.Interfaces;
using Cross.UI.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cross.UI.Web.Api.Services
{
    public abstract class BasicApiService<TCriteria, TFilterViewModel, TBusinessService, TKey> : ApiService<TBusinessService>, IBasicApiService<TFilterViewModel, TKey>
        where TCriteria : Criteria<TKey>, new()
        where TFilterViewModel : FilterViewModel<TKey>
        where TBusinessService : IBasicBusinessService<TCriteria, TKey>
    {

        protected BasicApiService(TBusinessService businessService) : base(businessService)
        {

        }

        protected IMapper FilterToCriteriaMapper
        {
            get
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<TFilterViewModel, TCriteria>());
                return config.CreateMapper();
            }
        }

        private readonly Func<DataView, DataViewModel> CreateDataViewModelFromDataView = e =>
        {
            var vm = new DataViewModel()
            {
                ID = e.ID,
                Descripcion = e.Descripcion
            };

            return vm;
        };

        public List<DataViewModel> ReadAll()
        {
            return this.BusinessService.ReadAll().Select<DataView, DataViewModel>(this.CreateDataViewModelFromDataView).ToList();
        }

        public List<DataViewModel> ReadViewByDependencyValues(List<TKey> values)
        {
            return this.BusinessService.ReadViewByDependencyValues(values).Select<DataView, DataViewModel>(this.CreateDataViewModelFromDataView).ToList();
        }

        public List<DataViewModel> ReadViewByCriteria(TFilterViewModel filter)
        {
            var criteria = this.FilterToCriteriaMapper.Map<TCriteria>(filter);

            return this.BusinessService.ReadViewByCriteria(criteria).Select<DataView, DataViewModel>(this.CreateDataViewModelFromDataView).ToList();
        }

        public List<DataViewModel> ReadByPattern(TFilterViewModel filter)
        {
            var criteria = this.FilterToCriteriaMapper.Map<TCriteria>(filter);

            return this.BusinessService.ReadByID(criteria.ID).Select<DataView, DataViewModel>(this.CreateDataViewModelFromDataView).ToList();
        }

        public List<DataViewModel> ReadByID(TFilterViewModel filter)
        {
            var criteria = this.FilterToCriteriaMapper.Map<TCriteria>(filter);

            return this.BusinessService.ReadByID(criteria.ID).Select<DataView, DataViewModel>(this.CreateDataViewModelFromDataView).ToList();
        }
    }

    public abstract class BasicApiService<TCriteria, TFilterViewModel, TBusinessService> : BasicApiService<TCriteria, TFilterViewModel, TBusinessService, int>
        where TCriteria : Criteria, new()
        where TFilterViewModel : FilterViewModel
        where TBusinessService : IBasicBusinessService<TCriteria, int>
    {
        protected BasicApiService(TBusinessService businessService) : base(businessService)
        {

        }
    }
}
