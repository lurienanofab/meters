using System.Threading.Tasks;
using System.Web.Http;
using YokogawaService.Models;

namespace Meters.Controllers.Api
{
    public class ReportController : ApiController
    {
        [HttpPost, Route("api/report/run/{type}")]
        public async Task<ReportModel> RunReport([FromBody] DataQueryCriteria criteria, [FromUri] string type)
        {
            using (var api = new ApiClient())
            {
                return await api.RunReport(criteria, type);
            }
        }
    }
}
