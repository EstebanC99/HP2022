using Cross.UI.Web.Api.Services;
using System.Web.Http;

namespace Cross.UI.Web.Api.Controllers
{
    public abstract class ApiControllerBase<TApiService> : ApiController, IApiController
        where TApiService : IApiService
    {
        protected TApiService ApiService { get; private set; }

        protected ApiControllerBase(TApiService apiService)
        {
            this.ApiService = apiService;
        }
    }
}
