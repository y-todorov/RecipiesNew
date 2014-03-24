using System;
using System.Web.Security;
using System.Web.UI;

namespace RecipiesWebFormApp.Account
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (User.Identity.IsAuthenticated)
                {
                    FormsAuthentication.SignOut();
                }
            }
        }
    }
}