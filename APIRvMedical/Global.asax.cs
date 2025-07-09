using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace APIRvMedical
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //System.Web.Http.GlobalConfiguration.Configure(APIRvMedical.WebApiConfig.Register);
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
