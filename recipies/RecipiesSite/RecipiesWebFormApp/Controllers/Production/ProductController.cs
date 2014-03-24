using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using InventoryManagementMVC.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using RecipiesModelNS;
using RecipiesWebFormApp;
using System.Web;
using System.Web.Caching;
using RecipiesWebFormApp.Caching;
using DevTrends.MvcDonutCaching;
using System;

namespace InventoryManagementMVC.Controllers
{
    public class ProductController : ControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            var result = ReadBase(request, typeof (ProductViewModel), typeof (Product),
                ContextFactory.Current.Products.ToList());
            return result;
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create([DataSourceRequest] DataSourceRequest request,
            [Bind(Prefix = "models")] IEnumerable<ProductViewModel> products)
        {
            var result = CreateBase(request, products, typeof (ProductViewModel), typeof (Product));
            return result;
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request,
            [Bind(Prefix = "models")] IEnumerable<ProductViewModel> products)
        {
            var result = UpdateBase(request, products, typeof (ProductViewModel), typeof (Product));
            return result;
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Destroy([DataSourceRequest] DataSourceRequest request,
            [Bind(Prefix = "models")] IEnumerable<ProductViewModel> products)
        {
            var result = DestroyBase(request, products, typeof (ProductViewModel), typeof (Product));
            return result;
        }

        public ActionResult ReadProductRecipies(int? productId, [DataSourceRequest] DataSourceRequest request)
        {
            var result = ReadBase(request, typeof (RecipeViewModel), typeof (Recipe),
                ContextFactory.Current.Recipes.Where(r => r.ProductIngredients.Any(pi => pi.ProductId == productId))
                    .ToList());
            return result;
        }

        public ActionResult ReadProductInventories(int? productId, [DataSourceRequest] DataSourceRequest request)
        {
            List<ProductInventory> productInventories =
                ContextFactory.Current.Inventories.OfType<ProductInventory>()
                    .Where(pi => pi.ProductId == productId)
                    .OrderByDescending(de => de.ProductInventoryHeader.ForDate)
                    .ToList();

            var result = ReadBase(request, typeof (ProductInventoryViewModel), typeof (ProductInventory),
                productInventories);
            return result;
        }

        public ActionResult ReadProductPurchaseOrders(int? productId, [DataSourceRequest] DataSourceRequest request)
        {
            List<PurchaseOrderDetail> productPurchaseOrders =
                ContextFactory.Current.PurchaseOrderDetails.Where
                    (pi => pi.ProductId == productId)
                    .OrderByDescending(de => de.PurchaseOrderHeader.OrderDate)
                    .ToList();
            List<PurchaseOrderDetailViewModel> productPurchaseOrdersModels = productPurchaseOrders.Select
                (r =>
                    PurchaseOrderDetailViewModel.ConvertFromPurchaseOrderDetailEntity(r,
                        new PurchaseOrderDetailViewModel()))
                .ToList();

            return Json(productPurchaseOrdersModels.ToDataSourceResult(request));
        }

        public ActionResult ReadProductWastes(int? productId, [DataSourceRequest] DataSourceRequest request)
        {
            List<ProductWaste> productWastes =
                ContextFactory.Current.Wastes.OfType<ProductWaste>().Where
                    (pi => pi.ProductId == productId).ToList().Where(w => w.Quantity.GetValueOrDefault() != 0)
                    .OrderByDescending(de => de.ProductWasteHeader.ForDate)
                    .ToList();
            var result = ReadBase(request, typeof (ProductWasteViewModel), typeof (ProductWaste),
                productWastes);


            return result;
        }

        public ActionResult ReadProductUnitsInStockPurchaseOrders(int? productId,
            [DataSourceRequest] DataSourceRequest request)
        {
            Product product = ContextFactory.Current.Products.FirstOrDefault(p => p.ProductId == productId);
            if (product != null)
            {
                var inv = product.GetLastInventoryForDate(DateTime.Now.Date);

                if (inv != null)
                {
                    var res = product.GetPurchaseOrderDetailsInPeriod(inv.ProductInventoryHeader.ForDate.GetValueOrDefault(), DateTime.Now);
                    var result = ReadBase(request, typeof(PurchaseOrderDetailViewModel), typeof(PurchaseOrderDetail),
               res);
                    return result;
                }
                else
                {

                }
            }
            return null;

        }

        public ActionResult ReadProductUnitsInStockSalesOrderDetails(int? productId,
            [DataSourceRequest] DataSourceRequest request)
        {
            Product product = ContextFactory.Current.Products.FirstOrDefault(p => p.ProductId == productId);
            if (product != null)
            {
                var inv = product.GetLastInventoryForDate(DateTime.Now.Date);

                if (inv != null)
                {
                    var res = product.GetSalesOrderDetailsForPeriod(inv.ProductInventoryHeader.ForDate.GetValueOrDefault(), DateTime.Now);
                    var result = ReadBase(request, typeof(SalesOrderDetailViewModel), typeof(SalesOrderDetail),
               res);
                    return result;
                }
                else
                {

                }
            }
            return null;

        }

          public ActionResult ReadProductUnitsInStockProductWastes(int? productId,
            [DataSourceRequest] DataSourceRequest request)
        {
            Product product = ContextFactory.Current.Products.FirstOrDefault(p => p.ProductId == productId);
            if (product != null)
            {
                var inv = product.GetLastInventoryForDate(DateTime.Now.Date);

                if (inv != null)
                {
                    var res = product.GetProductWastes(inv.ProductInventoryHeader.ForDate.GetValueOrDefault(), DateTime.Now);
                    var result = ReadBase(request, typeof(ProductWasteViewModel), typeof(ProductWaste),
               res);
                    return result;
                }
                else
                {

                }
            }
            return null;
        }

          public ActionResult ReadProductInventory(int? productId,
            [DataSourceRequest] DataSourceRequest request)
          {
              Product product = ContextFactory.Current.Products.FirstOrDefault(p => p.ProductId == productId);
              if (product != null)
              {
                  ProductInventory inv = product.GetLastInventoryForDate(DateTime.Now.Date);

                  List<ProductInventory> invs = new List<ProductInventory>() {inv};

                  var result = ReadBase(request, typeof(ProductInventoryViewModel), typeof(ProductInventory), invs);
                  return result;
                  
              }
              return null;
          }


          public string Test(int? productId)
        {
            return DateTime.Now.ToString();
        }
        
        
    }
}