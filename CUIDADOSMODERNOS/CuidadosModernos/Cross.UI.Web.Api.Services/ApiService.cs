using Cross.BusinessService.Interfaces;

namespace Cross.UI.Web.Api.Services
{
    public class ApiService<TBusinessService> : IApiService
        where TBusinessService : IBusinessService
    {
        protected TBusinessService BusinessService { get; private set; }

        protected ApiService(TBusinessService businessService)
        {
            this.BusinessService = businessService;
        }
    }
}
