using System;
using System.Diagnostics;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using Telerik.Web.UI;

namespace RecipiesWebFormApp
{
    public partial class SiteMaster : MasterPage
    {
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        private string _antiXsrfTokenValue;

        public RadWindowManager MasterRadWindowManager
        {
            get { return RadWindowManager1; }
        }

        public RadNotification MasterRadNotification
        {
            get { return RadNotification1; }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            // This prevents back button after log out 

            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
            Response.Cache.SetNoStore();

            //


            // The code below helps to protect against XSRF attacks
            var requestCookie = Request.Cookies[AntiXsrfTokenKey];
            Guid requestCookieGuidValue;
            if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
            {
                // Use the Anti-XSRF token from the cookie
                _antiXsrfTokenValue = requestCookie.Value;
                Page.ViewStateUserKey = _antiXsrfTokenValue;
            }
            else
            {
                // Generate a new Anti-XSRF token and save to the cookie
                _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
                Page.ViewStateUserKey = _antiXsrfTokenValue;

                var responseCookie = new HttpCookie(AntiXsrfTokenKey)
                {
                    HttpOnly = true,
                    Value = _antiXsrfTokenValue
                };
                if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
                {
                    responseCookie.Secure = true;
                }
                Response.Cookies.Set(responseCookie);
            }

            Page.PreLoad += master_Page_PreLoad;
        }

        protected void master_Page_PreLoad(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Set Anti-XSRF token
                ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
                ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
            }
            else
            {
                // Validate the Anti-XSRF token
                if ((string) ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                    || (string) ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
                {
                    throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Unnamed_Load(object sender, EventArgs e)
        {
            RadMenuItem rmi = sender as RadMenuItem;
            rmi.Text = string.Concat("You are logged in as ", Page.User.Identity.Name);
        }

        protected void Unnamed_ItemClick(object sender, RadMenuEventArgs e)
        {
            // We get here only if navigate url is not changed
            //RadMenu rm = sender as RadMenu;
            //if (rm.SelectedItem != null && rm.SelectedItem.Value.Equals("Log off"))
            //{
            //    FormsAuthentication.SignOut();
            //    FormsAuthentication.RedirectToLoginPage();
            //}            
        }

        protected void RadScriptManager1_AsyncPostBackError(object sender, AsyncPostBackErrorEventArgs e)
        {
            Debugger.Break();
            MasterRadNotification.Show("Error: " + e.Exception.Message);
            //MasterRadWindowManager.RadAlert(e.Exception.Message, 400, 200, "Error", string.Empty);
        }

        public override void DataBind()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            base.DataBind();
            stopwatch.Stop();
            long mills = stopwatch.ElapsedMilliseconds;
        }
    }
}