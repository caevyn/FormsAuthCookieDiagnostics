using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace CookieTest35
{
    public class Global : System.Web.HttpApplication
    {
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