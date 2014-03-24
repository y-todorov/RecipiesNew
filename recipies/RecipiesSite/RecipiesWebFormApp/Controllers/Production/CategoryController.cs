using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;
using InventoryManagementMVC.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using RecipiesModelNS;
using Kendo.Mvc;

namespace InventoryManagementMVC.Controllers
{
    public class CategoryController : ControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            Stopwatch s = new Stopwatch();
            s.Start();
            var result = ReadBase(request, typeof(CategoryViewModel), typeof(ProductCategory), ContextFactory.Current.ProductCategories.ToList());
            s.Stop();
            long mils = s.ElapsedMilliseconds;
            return result;
        }

        public ActionResult ReadProducts(int categoryId, [DataSourceRequest] DataSourceRequest request)
        {
            var result = ReadBase(request, typeof(ProductViewModel), typeof(Product), ContextFactory.Current.Products.Where(p => p.CategoryId == categoryId).ToList());
            return result;
        }


        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create([DataSourceRequest] DataSourceRequest request,
            [Bind(Prefix = "models")] IEnumerable<CategoryViewModel> categories)
        {
            Stopwatch s = new Stopwatch();
            s.Start();
            var result = CreateBase(request, categories, typeof(CategoryViewModel), typeof(ProductCategory));
            s.Stop();
            long mils = s.ElapsedMilliseconds;
            return result;
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request,
            [Bind(Prefix = "models")] IEnumerable<CategoryViewModel> categories)
        {
            Stopwatch s = new Stopwatch();
            s.Start();
            var result = UpdateBase(request, categories, typeof(CategoryViewModel), typeof(ProductCategory));
            s.Stop();
            long mils = s.ElapsedMilliseconds;
            return result;
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Destroy([DataSourceRequest] DataSourceRequest request,
            [Bind(Prefix = "models")] IEnumerable<CategoryViewModel> categories)
        {
            Stopwatch s = new Stopwatch();
            s.Start();
            var result = DestroyBase(request, categories, typeof(CategoryViewModel), typeof(ProductCategory));
            s.Stop();
            long mils = s.ElapsedMilliseconds;
            return result;
        }
    }
}