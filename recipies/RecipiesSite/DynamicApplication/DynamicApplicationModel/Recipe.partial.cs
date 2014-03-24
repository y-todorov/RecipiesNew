using System;
using System.Collections.Generic;
using System.Linq;


namespace RecipiesModelNS
{
    public partial class Recipe : YordanBaseEntity
    {
        public static void GetProductsWithQuantities(int? recipeId, Dictionary<int, double> productsWithQuantities, List<int> stackOverflowPreventionRecipeIds = null)
        {
            if (stackOverflowPreventionRecipeIds == null)
            {
                stackOverflowPreventionRecipeIds = new List<int>();
            }
            if (stackOverflowPreventionRecipeIds.Contains(recipeId.GetValueOrDefault()))
            {
                throw new ApplicationException(
                    "Recipe cannot contain a sub recipe that is the same recipe! Please fix that!");
            }
            stackOverflowPreventionRecipeIds.Add(recipeId.GetValueOrDefault());


            Recipe recipe = ContextFactory.Current.Recipes.FirstOrDefault(r => r.RecipeId == recipeId);
            if (recipe != null)
            {
                foreach (ProductIngredient pi in recipe.ProductIngredients)
                {
                    if (!pi.ProductId.HasValue)
                    {
                        throw new ApplicationException(
                            string.Format("Product ingredient with id {0} does not have a Product! Please select one!",
                                pi.ProductIngredientId));
                    }
                    if (productsWithQuantities.ContainsKey(pi.ProductId.Value))
                    {
                        productsWithQuantities[pi.ProductId.Value] += pi.QuantityPerPortion.GetValueOrDefault();
                    }
                    else
                    {
                        productsWithQuantities.Add(pi.ProductId.Value, pi.QuantityPerPortion.GetValueOrDefault());
                    }
                }

                foreach (RecipeIngredient ri in recipe.RecipeIngredients1)
                {
                    if (!ri.IngredientRecipeId.HasValue)
                    {
                        throw new ApplicationException(
                            string.Format("Recipe ingredient with id {0} does not have a Product! Please select one!",
                                ri.RecipeIngredientId));
                    }

                    GetProductsWithQuantities(ri.IngredientRecipeId, productsWithQuantities, stackOverflowPreventionRecipeIds);
                }
            }
        }

        public static decimal GetRecipeValuePerPortion(int? recipeId)
        {
            if (recipeId.HasValue)
            {
                Recipe recipe =
                    ContextFactory.Current.Recipes.FirstOrDefault(re => re.RecipeId == recipeId.Value);
                if (recipe != null)
                {
                    decimal? valuePerPortion = 0;
                    foreach (ProductIngredient productIngredient in recipe.ProductIngredients)
                    {
                        valuePerPortion += (decimal?)productIngredient.TotalValue;
                    }
                    foreach (RecipeIngredient recipeIngredient in recipe.RecipeIngredients1)
                    // RecipeIngredients1 is correct
                    // please find out what is RecipeIngredients and do I need it
                    {
                        valuePerPortion += (decimal?)recipeIngredient.TotalValue;
                    }
                    return valuePerPortion.GetValueOrDefault();
                    //ContextFactory.GetContextPerRequest().SaveChanges();
                }
            }
            return 0;
        }


    }
}