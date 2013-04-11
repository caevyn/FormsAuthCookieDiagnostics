using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace CookieTest40
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

           
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void FormsAuthentication_OnAuthenticate(object sender, FormsAuthenticationEventArgs args)
        {
            var cookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (cookie == null)
            {
                HttpContext.Current.Items["HasCookie"] = false;
                return;
            }

            try
            {
                HttpContext.Current.Items["HasCookie"] = true;
                var ticket = FormsAuthentication.Decrypt(cookie.Value);
                HttpContext.Current.Items["DecryptResult"] = ticket == null ? "Decrypt returns null" : "Decypt worked ok and we should be authenticated.";
            }
            catch (Exception e)
            {
                HttpContext.Current.Items["DecryptResult"] = "Decypt threw an exception. " + e.Message;
            }

        }
    }
}