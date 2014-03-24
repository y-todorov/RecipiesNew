using InventoryManagementMVC.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using RecipiesModelNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagementMVC.Controllers
{
    public class ProductWasteHeaderController : ControllerBase
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            var result = ReadBase(request, typeof(ProductWasteHeaderViewModel), typeof(ProductWasteHeader), ContextFactory.Current.ProductWasteHeaders.ToList());
            return result;
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create([DataSourceRequest] DataSourceRequest request,
            [Bind(Prefix = "models")] IEnumerable<ProductWasteHeaderViewModel> recipies)
        {
            var result = CreateBase(request, recipies, typeof(ProductWasteHeaderViewModel), typeof(ProductWasteHeader));
            return result;
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request,
            [Bind(Prefix = "models")] IEnumerable<ProductWasteHeaderViewModel> recipies)
        {
            var result = UpdateBase(request, recipies, typeof(ProductWasteHeaderViewModel), typeof(ProductWasteHeader));
            return result;
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Destroy([DataSourceRequest] DataSourceRequest request,
            [Bind(Prefix = "models")] IEnumerable<ProductWasteHeaderViewModel> recipies)
        {
            var result = DestroyBase(request, recipies, typeof(ProductWasteHeaderViewModel), typeof(ProductWasteHeader));
            return result;
        }
    }
}