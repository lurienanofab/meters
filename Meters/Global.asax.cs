using LNF;
using LNF.Repository;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace Meters
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private IUnitOfWork _uow;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

        protected void Application_BeginRequest()
        {
            _uow = Providers.DataAccess.StartUnitOfWork();
        }

        protected void Application_EndRequest()
        {
            _uow.Dispose();
        }
    }
}
