using System;

namespace RecipiesWebFormApp
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();
            string details = string.Empty;
            if (ex.InnerException != null)
            {
                details = ex.InnerException.Message;
            }
            lblError.Text = string.Format("Exception: {0}! Details: {1}!", ex.Message, details);

            Uri urlReferrer = Request.UrlReferrer;
            //Response.Redirect(u.ToString(), false);
        }
    }
}