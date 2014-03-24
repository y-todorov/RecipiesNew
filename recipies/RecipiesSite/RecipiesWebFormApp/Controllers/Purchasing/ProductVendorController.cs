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
    public class ProductVendorController : ControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            var result = ReadBase(request, typeof(ProductVendorViewModel), typeof(ProductVendor), ContextFactory.Current.ProductVendors.ToList());
            return result;
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create([DataSourceRequest] DataSourceRequest request,
            [Bind(Prefix = "models")] IEnumerable<ProductVendorViewModel> productVendors)
        {
            var result = CreateBase(request, productVendors, typeof(ProductVendorViewModel), typeof(ProductVendor));
            return result;
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request,
            [Bind(Prefix = "models")] IEnumerable<ProductVendorViewModel> productVendors)
        {
            var result = UpdateBase(request, productVendors, typeof(ProductVendorViewModel), typeof(ProductVendor));
            return result;
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Destroy([DataSourceRequest] DataSourceRequest request,
            [Bind(Prefix = "models")] IEnumerable<ProductVendorViewModel> productVendors)
        {
            var result = DestroyBase(request, productVendors, typeof(ProductVendorViewModel), typeof(ProductVendor));
            return result;
        }
    }
}