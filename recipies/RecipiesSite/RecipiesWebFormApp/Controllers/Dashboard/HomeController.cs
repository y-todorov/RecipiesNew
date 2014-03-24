using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using RecipiesModelNS;
using System;
using System.Diagnostics;
using InventoryManagementMVC.Helpers;


namespace InventoryManagementMVC.Controllers
{
    public class HomeController : ControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NavigateToOldSite()
        {
            Response.Redirect("/Default.aspx", false);
            return new ContentResult();
        }
    }
}