using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CookieTest35
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string decryptResult = HttpContext.Current.Items["DecryptResult"] as string;
            HasCookie = HttpContext.Current.Items.Contains("HasCookie") && (bool)HttpContext.Current.Items["HasCookie"];
            DecryptResult = decryptResult;
            InstalledDotNetVersion = IsNet45OrNewer() ? "4.5" : Environment.Version.ToString();
            TargetRuntime = "3.5";

            // Get the Web application configuration object.
            Configuration config = WebConfigurationManager.OpenWebConfiguration("~/");

            // Get the section related object.
            MachineKeySection configSection = (MachineKeySection)config.GetSection("system.web/machineKey");
            CompatibilityMode = configSection.CompatibilityMode.ToString();
            ValidationAlgorithm = configSection.Validation;
            ValidationKey = configSection.ValidationKey;
            DecryptionAlgorithm = configSection.Decryption;
            DecryptionKey = configSection.DecryptionKey;
            SystemWeb = System.Diagnostics.FileVersionInfo.GetVersionInfo(Assembly.GetAssembly(typeof(System.Web.HttpContext)).Location);
        }

        protected void loginButton_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SetAuthCookie(loginTextBox.Text, false);
            Response.Redirect(Request.RawUrl);
        }

        public static bool IsNet45OrNewer()
        {
            // Class "ReflectionContext" exists from .NET 4.5 onwards.
            return Type.GetType("System.Reflection.ReflectionContext", false) != null;
        }

        public bool HasCookie { get; set; }

        public string DecryptResult { get; set; }

        public string InstalledDotNetVersion { get; set; }

        public string TargetRuntime { get; set; }

        public string CompatibilityMode { get; set; }

        public MachineKeyValidation ValidationAlgorithm { get; set; }

        public string ValidationKey { get; set; }

        public string DecryptionAlgorithm { get; set; }

        public string DecryptionKey { get; set; }



        public System.Diagnostics.FileVersionInfo SystemWeb { get; set; }
    }
}