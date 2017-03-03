using System.Threading.Tasks;
using System.Web.Http;
using YokogawaService.Models;

namespace Meters.Controllers.Api
{
    public class SummaryController : ApiController
    {
        [Route("api/summary")]
        public async Task<ServiceSummary> Get()
        {
            using (var api = new ApiClient())
            {
                return await api.GetSummary();
            }
        }
    }
}
