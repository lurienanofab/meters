using System.Threading.Tasks;
using System.Web.Http;
using YokogawaService.Models;

namespace Meters.Controllers.Api
{
    public class AdminController : ApiController
    {
        [Route("api/admin/index")]
        public async Task<ImportIndex> GetIndex()
        {
            using (var api = new ApiClient())
            {
                return await api.GetIndex();
            }
        }

        [Route("api/admin/index")]
        public async Task PutIndex([FromBody] ImportIndex index)
        {
            using (var api = new ApiClient())
            {
                await api.SetIndex(index);
            }
        }

        [HttpGet, Route("api/admin/index/increment")]
        public async Task<ImportIndex> IncrementIndex()
        {
            using (var api = new ApiClient())
            {
                return await api.IncrementIndex();
            }
        }
    }
}
