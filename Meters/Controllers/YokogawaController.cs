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

using System.Web.Mvc;

namespace Meters.Controllers
{
    public class YokogawaController : Controller
    {
        [Route("yokogawa")]
        public ActionResult Index()
        {
            ViewBag.CurrentPage = "yokogawa";
            ViewBag.CurrentTab = "summary";
            return View();
        }

        [Route("yokogawa/reports")]
        public ActionResult Reports()
        {
            ViewBag.CurrentPage = "yokogawa";
            ViewBag.CurrentTab = "reports";
            return View();
        }


        [Route("yokogawa/admin")]
        public ActionResult Admin()
        {
            ViewBag.CurrentPage = "yokogawa";
            ViewBag.CurrentTab = "admin";
            return View();
        }
    }
}