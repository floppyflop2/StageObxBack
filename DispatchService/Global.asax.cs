using System;
using System.Diagnostics;
using System.Web.Http;

namespace DispatchService
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            try
            {
                GlobalConfiguration.Configure(WebApiConfig.Register);
            }
            catch (Exception e)
            {
                Debug.Print("lol");
            }
           
        }
    }
}
