using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using InventoryManagementMVC.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using RecipiesModelNS;

namespace InventoryManagementMVC.Controllers
{
    public class RecipeIngredientController : ControllerBase
    {
        public ActionResult Read(int? recipeId, [DataSourceRequest] DataSourceRequest request)
        {
            List<RecipeIngredientViewModel> productIngredients = ContextFactory.Current.RecipeIngredients
                .Where(
                    pod => recipeId.HasValue ? pod.ParentRecipeId == recipeId.Value : true)
                .ToList().Select
                (c => RecipeIngredientViewModel.ConvertFromProductIngredientEntity(c, new RecipeIngredientViewModel()))
                .ToList();
            return Json(productIngredients.ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(int? recipeId, [DataSourceRequest] DataSourceRequest request,
            [Bind(Prefix = "models")] IEnumerable<RecipeIngredientViewModel> productIngredients)
        {
            if (productIngredients != null && ModelState.IsValid)
            {
                foreach (RecipeIngredientViewModel pi in productIngredients)
                {
                    pi.ParentRecipeId = recipeId; // this must be before next line
                    RecipeIngredient newProductIngredient =
                        RecipeIngredientViewModel.ConvertToProductIngredientEntity(pi,
                            new RecipeIngredient());

                    ContextFactory.Current.RecipeIngredients.Add(newProductIngredient);
                    ContextFactory.Current.SaveChanges();

                    RecipeIngredientViewModel.ConvertFromProductIngredientEntity(newProductIngredient, pi);
                }
            }

            return Json(productIngredients.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request,
            [Bind(Prefix = "models")] IEnumerable<RecipeIngredientViewModel> recipeIngredients)
        {
            if (recipeIngredients != null && ModelState.IsValid)
            {
                foreach (RecipeIngredientViewModel recipeIngredient in recipeIngredients)
                {
                    RecipeIngredient riEntity =
                        ContextFactory.Current.RecipeIngredients.FirstOrDefault(
                            r => r.RecipeIngredientId == recipeIngredient.RecipeIngredientId);
                    recipeIngredient.ParentRecipeId = riEntity.ParentRecipeId;

                    RecipeIngredientViewModel.ConvertToProductIngredientEntity(recipeIngredient, riEntity);

                    ContextFactory.Current.SaveChanges();

                    RecipeIngredientViewModel.ConvertFromProductIngredientEntity(riEntity, recipeIngredient);
                }
            }

            return Json(recipeIngredients.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Destroy([DataSourceRequest] DataSourceRequest request,
            [Bind(Prefix = "models")] IEnumerable<RecipeIngredientViewModel> recipeIngredients)
        {
            if (recipeIngredients.Any())
            {
                foreach (RecipeIngredientViewModel recipeIngredient in recipeIngredients)
                {
                    RecipeIngredient piEntity =
                        ContextFactory.Current.RecipeIngredients.FirstOrDefault(
                            r => r.RecipeIngredientId == recipeIngredient.RecipeIngredientId);
                    ContextFactory.Current.RecipeIngredients.Remove(piEntity);

                    ContextFactory.Current.SaveChanges();
                }
            }

            return Json(recipeIngredients.ToDataSourceResult(request, ModelState));
        }
    }
}