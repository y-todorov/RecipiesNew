using InventoryManagementMVC.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using RecipiesModelNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity; // .Include !!!!!!! THIS IS SO IMPROTANT

namespace InventoryManagementMVC.Controllers
{
    public class ProductWasteController : ControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Read(int? productWasteHeaderId, [DataSourceRequest] DataSourceRequest request)
        {
            ProductWasteHeader pih2 =
               ContextFactory.Current.ProductWasteHeaders.FirstOrDefault(
                   pi => pi.ProductWasteHeaderId == productWasteHeaderId);
            if (pih2 != null)
            {
                ProductWasteHeader.InsertMissingProductWastes(pih2);
            }

            var allPis = ContextFactory.Current.Wastes.OfType<ProductWaste>()
                .Include(pi => pi.Product.ProductCategory)
                .Include(pi => pi.Product.UnitMeasure)
                .Where(pih => pih.ProductWasteHeaderId == productWasteHeaderId.Value).ToList();

            var result = ReadBase(request, typeof(ProductWasteViewModel), typeof(ProductWaste), allPis);
            return result;
        }

        //[AcceptVerbs(HttpVerbs.Post)]
        //public ActionResult Create([DataSourceRequest] DataSourceRequest request,
        //    [Bind(Prefix = "models")] IEnumerable<ProductWasteViewModel> wastes)
        //{
        //    var result = CreateBase(request, wastes, typeof(ProductWasteViewModel), typeof(ProductWaste));
        //    return result;
        //}

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request,
            [Bind(Prefix = "models")] IEnumerable<ProductWasteViewModel> products)
        {
            var result = UpdateBase(request, products, typeof(ProductWasteViewModel), typeof(ProductWaste));
            return result;
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Destroy([DataSourceRequest] DataSourceRequest request,
            [Bind(Prefix = "models")] IEnumerable<ProductWasteViewModel> products)
        {
            var result = DestroyBase(request, products, typeof(ProductWasteViewModel), typeof(ProductWaste));
            return result;
        }
    }
}