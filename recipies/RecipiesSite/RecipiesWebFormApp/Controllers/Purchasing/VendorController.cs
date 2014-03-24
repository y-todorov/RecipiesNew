using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using InventoryManagementMVC.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using RecipiesModelNS;
using Kendo.Mvc;

namespace InventoryManagementMVC.Controllers
{
    public class VendorController : ControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            var result = ReadBase(request, typeof(VendorViewModel), typeof(Vendor), ContextFactory.Current.Vendors.ToList());
            return result;
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create([DataSourceRequest] DataSourceRequest request,
            [Bind(Prefix = "models")] IEnumerable<VendorViewModel> vendors)
        {
            var result = CreateBase(request, vendors, typeof(VendorViewModel), typeof(Vendor));
            return result;
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request,
            [Bind(Prefix = "models")] IEnumerable<VendorViewModel> vendors)
        {
            var result = UpdateBase(request, vendors, typeof(VendorViewModel), typeof(Vendor));
            return result;
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Destroy([DataSourceRequest] DataSourceRequest request,
            [Bind(Prefix = "models")] IEnumerable<VendorViewModel> vendors)
        {
            var result = DestroyBase(request, vendors, typeof(VendorViewModel), typeof(Vendor));
            return result;
        }
    }
}