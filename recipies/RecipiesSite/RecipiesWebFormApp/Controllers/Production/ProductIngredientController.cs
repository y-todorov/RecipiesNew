using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using InventoryManagementMVC.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using RecipiesModelNS;
using System.Data.Entity;

namespace InventoryManagementMVC.Controllers
{
    public class ProductIngredientController : ControllerBase
    {
        public ActionResult Read(int? recipeId, [DataSourceRequest] DataSourceRequest request)
        {
            List<ProductIngredientViewModel> productIngredients = ContextFactory.Current.ProductIngredients
                .Where(
                    pod => recipeId.HasValue ? pod.RecipeId == recipeId.Value : true)
                .ToList().Select
                (c => ProductIngredientViewModel.ConvertFromProductIngredientEntity(c, new ProductIngredientViewModel()))
                .ToList();
            return Json(productIngredients.ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(int? recipeId, [DataSourceRequest] DataSourceRequest request,
            [Bind(Prefix = "models")] IEnumerable<ProductIngredientViewModel> productIngredients)
        {
            if (productIngredients != null && ModelState.IsValid)
            {
                foreach (ProductIngredientViewModel pi in productIngredients)
                {
                    ProductIngredient newProductIngredient =
                        ProductIngredientViewModel.ConvertToProductIngredientEntity(pi,
                            new ProductIngredient());
                    newProductIngredient.RecipeId = recipeId;
                    ContextFactory.Current.ProductIngredients.Add(newProductIngredient);
                    ContextFactory.Current.SaveChanges();
                    newProductIngredient =
                        ContextFactory.Current.ProductIngredients.Include(p => p.Product)
                            .FirstOrDefault(ppi => ppi.ProductIngredientId == newProductIngredient.ProductIngredientId);
                    ProductIngredientViewModel.ConvertFromProductIngredientEntity(newProductIngredient, pi);
                }
            }

            return Json(productIngredients.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request,
            [Bind(Prefix = "models")] IEnumerable<ProductIngredientViewModel> productIngredients)
        {
            if (productIngredients != null && ModelState.IsValid)
            {
                foreach (ProductIngredientViewModel productIngredient in productIngredients)
                {
                    ProductIngredient piEntity =
                        ContextFactory.Current.ProductIngredients.FirstOrDefault(
                            r => r.ProductIngredientId == productIngredient.ProductIngredientId);

                    productIngredient.RecipeId = piEntity.RecipeId;
                    ProductIngredientViewModel.ConvertToProductIngredientEntity(productIngredient, piEntity);

                    ContextFactory.Current.SaveChanges();

                    ProductIngredientViewModel.ConvertFromProductIngredientEntity(piEntity, productIngredient);
                }
            }

            return Json(productIngredients.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Destroy([DataSourceRequest] DataSourceRequest request,
            [Bind(Prefix = "models")] IEnumerable<ProductIngredientViewModel> productIngredients)
        {
            if (productIngredients.Any())
            {
                foreach (ProductIngredientViewModel pi in productIngredients)
                {
                    ProductIngredient piEntity =
                        ContextFactory.Current.ProductIngredients.FirstOrDefault(
                            r => r.ProductIngredientId == pi.ProductIngredientId);
                    ContextFactory.Current.ProductIngredients.Remove(piEntity);

                    ContextFactory.Current.SaveChanges();
                }
            }

            return Json(productIngredients.ToDataSourceResult(request, ModelState));
        }
    }
}