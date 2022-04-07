using Cross.UI.Web.Models;
using System.Collections.Generic;

namespace Cross.UI.Web.Api.Services
{
    public interface IBasicApiService<TFilterViewModel, TKey> : IApiService
        where TFilterViewModel : FilterViewModel<TKey>
    {
        List<DataViewModel> ReadAll();

        List<DataViewModel> ReadViewByDependencyValues(List<TKey> values);

        List<DataViewModel> ReadViewByCriteria(TFilterViewModel filter);

        List<DataViewModel> ReadByPattern(TFilterViewModel filter);

        List<DataViewModel> ReadByID(TFilterViewModel filter);
    }

    public interface IBasicApiService<TFilterViewModel> : IBasicApiService<TFilterViewModel, int>
        where TFilterViewModel : FilterViewModel
    {

    }
}