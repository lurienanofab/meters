/*
   Copyright 2017 University of Michigan

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License. 
*/

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
