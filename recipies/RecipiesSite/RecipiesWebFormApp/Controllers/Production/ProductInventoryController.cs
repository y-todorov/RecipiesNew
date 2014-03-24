using InventoryManagementMVC.Models;
using Kendo.Mvc.UI;
using RecipiesModelNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using System.Data.Entity; // .Include !!!!!!! THIS IS SO IMPROTANT

namespace InventoryManagementMVC.Controllers
{
    public class ProductInventoryController : ControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Read(int? productInventoryHeaderId, [DataSourceRequest] DataSourceRequest request)
        {
            ProductInventoryHeader pih2 =
                ContextFactory.Current.ProductInventoryHeaders.FirstOrDefault(
                    pi => pi.ProductInventoryHeaderId == productInventoryHeaderId);
            if (pih2 != null)
            {
                ProductInventoryHeader.InsertMissingProductInventories(pih2);
            }

            var allPis = ContextFactory.Current.Inventories.OfType<ProductInventory>()
                .Include(pi => pi.Product.ProductCategory)
                .Include(pi => pi.Product.UnitMeasure)
                .Where(pih =>pih.ProductInventoryHeaderId == productInventoryHeaderId.Value).ToList();

            var result = ReadBase(request, typeof (ProductInventoryViewModel), typeof (ProductInventory), allPis);
            return result;
        }


        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(int? productInventoryHeaderId, [DataSourceRequest] DataSourceRequest request,
            [Bind(Prefix = "models")] IEnumerable<ProductInventoryViewModel> pis)
        {
            var result = CreateBase(request, pis, typeof (ProductInventoryViewModel), typeof (ProductInventory));
            return result;
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request,
            [Bind(Prefix = "models")] IEnumerable<ProductInventoryViewModel> pis)
        {
            var result = UpdateBase(request, pis, typeof (ProductInventoryViewModel), typeof (ProductInventory));
            return result;
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Destroy([DataSourceRequest] DataSourceRequest request,
            [Bind(Prefix = "models")] IEnumerable<ProductInventoryViewModel> pis)
        {
            var result = DestroyBase(request, pis, typeof (ProductInventoryViewModel), typeof (ProductInventory));
            return result;
        }

      
    }
}