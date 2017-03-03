using System.Web.Mvc;

namespace Meters.Controllers
{
    public class HomeController : Controller
    {
        [Route("")]
        public ActionResult Index()
        {
            ViewBag.CurrentPage = "home";
            return View();
        }
    }
}