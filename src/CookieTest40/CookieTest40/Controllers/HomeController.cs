using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Security;

namespace CookieTest45.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string decryptResult = HttpContext.Items["DecryptResult"] as string;
            ViewBag.HasCookie = HttpContext.Items.Contains("HasCookie") && (bool)HttpContext.Items["HasCookie"];
            ViewBag.DecryptResult = decryptResult;
            ViewBag.InstalledDotNetVersion = IsNet45OrNewer() ? "4.5" : Environment.Version.ToString();
            ViewBag.TargetRuntime = System.Web.Compilation.BuildManager.TargetFramework;


            // Get the Web application configuration object.
            Configuration config = WebConfigurationManager.OpenWebConfiguration("~/");

            // Get the section related object.
            MachineKeySection configSection = (MachineKeySection)config.GetSection("system.web/machineKey");
            ViewBag.CompatibilityMode = configSection.CompatibilityMode.ToString();
            ViewBag.ValidationAlgorithm = configSection.Validation;
            ViewBag.ValidationKey = configSection.ValidationKey;
            ViewBag.DecryptionAlgorithm = configSection.Decryption;
            ViewBag.DecryptionKey = configSection.DecryptionKey;
            ViewBag.SystemWeb = System.Diagnostics.FileVersionInfo.GetVersionInfo(Assembly.GetAssembly(typeof(System.Web.HttpContext)).Location);
            return View();
        }

        [HttpPost]
        public ActionResult Index(string username)
        {
            FormsAuthentication.SetAuthCookie(username, false);
            return RedirectToAction("Index");
        }

        public static bool IsNet45OrNewer()
        {
            // Class "ReflectionContext" exists from .NET 4.5 onwards.
            return Type.GetType("System.Reflection.ReflectionContext", false) != null;
        }

    }
}
