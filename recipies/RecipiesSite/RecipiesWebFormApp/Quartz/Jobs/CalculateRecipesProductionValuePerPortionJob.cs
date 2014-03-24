using Quartz;
using RecipiesModelNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace RecipiesWebFormApp.Quartz.Jobs
{
    public class CalculateRecipesProductionValuePerPortionJob : JobBase
    {
        public override void Execute(IJobExecutionContext context)
        {
            var recipes = ContextFactory.Current.Recipes.ToList();
            //Parallel.ForEach(recipes, recipe =>
            //{
            //    ProductIngredient.UpdateRecipesValuePerPortionFromIngredientsChange(recipe.RecipeId);
            //});
            foreach (var recipe in recipes)
            {
                ProductIngredient.UpdateRecipesValuePerPortionFromIngredientsChange(recipe.RecipeId);
            }
            base.Execute(context);
        }
    }
}