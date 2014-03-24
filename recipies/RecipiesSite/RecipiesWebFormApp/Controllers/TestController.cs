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

namespace InventoryManagementMVC.Controllers
{
    public class TestController : ControllerBase
    {
        public ActionResult ExecuteSomeAction()
        {
            List<PurchaseOrderHeader> pos = ContextFactory.Current.PurchaseOrderHeaders.ToList();

            foreach (PurchaseOrderHeader po in pos)
            {
                if (po.OrderDate.HasValue && po.OrderDate != po.OrderDate.GetValueOrDefault().Date)
                {
                    po.OrderDate = po.OrderDate.GetValueOrDefault().Date;
                }
                if (po.ShipDate.HasValue && po.ShipDate != po.ShipDate.GetValueOrDefault().Date)
                {
                    po.ShipDate = po.ShipDate.GetValueOrDefault().Date;
                }
            }


            ContextFactory.Current.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Index()
        {
            List<Product> allProducts = ContextFactory.Current.Products.ToList();
            List<ProductViewModel> productViewModels =
                allProducts.Select(p => ProductViewModel.ConvertFromProductEntity(p, new ProductViewModel())).ToList();
            return View(productViewModels);
        }

        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            List<Product> allProducts = ContextFactory.Current.Products.ToList();
            List<ProductViewModel> productViewModels =
                allProducts.Select(p => ProductViewModel.ConvertFromProductEntity(p, new ProductViewModel())).ToList();
            return Json(productViewModels.ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create([DataSourceRequest] DataSourceRequest request,
            [Bind(Prefix = "models")] IEnumerable<ProductViewModel> products)
        {
            //List<ProductViewModel> results = new List<ProductViewModel>();

            if (products != null && ModelState.IsValid)
            {
                foreach (ProductViewModel productViewModel in products)
                {
                    Product newProduct = ProductViewModel.ConvertToProductEntity(productViewModel, new Product());
                    ContextFactory.Current.Products.Add(newProduct);
                    ContextFactory.Current.SaveChanges();

                    ProductViewModel.ConvertFromProductEntity(newProduct, productViewModel);
                    //results.Add(productViewModel);
                }
            }

            return Json(products.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request,
            [Bind(Prefix = "models")] IEnumerable<ProductViewModel> products)
        {
            if (products != null && ModelState.IsValid)
            {
                foreach (ProductViewModel productViewModel in products)
                {
                    Product product =
                        ContextFactory.Current.Products.FirstOrDefault(p => p.ProductId == productViewModel.ProductId);
                    ProductViewModel.ConvertToProductEntity(productViewModel, product);
                    ContextFactory.Current.SaveChanges();

                    ProductViewModel.ConvertFromProductEntity(product, productViewModel);
                }
            }

            return Json(products.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Destroy([DataSourceRequest] DataSourceRequest request,
            [Bind(Prefix = "models")] IEnumerable<ProductViewModel> products)
        {
            if (products.Any())
            {
                foreach (ProductViewModel productViewModel in products)
                {
                    Product product =
                        ContextFactory.Current.Products.FirstOrDefault(p => p.ProductId == productViewModel.ProductId);
                    ContextFactory.Current.Products.Remove(product);

                    ContextFactory.Current.SaveChanges();
                }
            }

            return Json(products.ToDataSourceResult(request, ModelState));
        }
    }
}