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