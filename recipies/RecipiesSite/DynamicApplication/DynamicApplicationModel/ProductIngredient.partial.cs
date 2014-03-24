using System.Linq;

namespace RecipiesModelNS
{
    public partial class ProductIngredient : YordanBaseEntity
    {
        private static int? recipeIdToUpdate;

        public override void Added(System.Data.Entity.Infrastructure.DbEntityEntry e = null)
        {
            UpdateRecipesValuePerPortionFromIngredientsChange(RecipeId);
            base.Added(e);
        }

        public override void Changed(System.Data.Entity.Infrastructure.DbEntityEntry e = null)
        {
            UpdateRecipesValuePerPortionFromIngredientsChange(RecipeId);
            base.Changed(e);
        }

        public override void Removing(System.Data.Entity.Infrastructure.DbEntityEntry e = null)
        {
            //recipeIdToUpdate = RecipeId; // THIS CAN BE ONLY THE PRIMARY KEY OF THE DELETED ENTITY THIS IS PROBLEM AND DO NOT WORK
            using (RecipiesEntities context = ContextFactory.CreateNewContext())
            {
                ProductIngredient ri =
                    context.ProductIngredients.FirstOrDefault(r => r.ProductIngredientId == ProductIngredientId);
                if (ri != null)
                {
                    recipeIdToUpdate = ri.RecipeId;
                }
            }
            base.Removing(e);
        }

        public override void Removed(System.Data.Entity.Infrastructure.DbEntityEntry e = null)
        {
            UpdateRecipesValuePerPortionFromIngredientsChange(recipeIdToUpdate);
            base.Removed(e);
        }


        public static void UpdateRecipesValuePerPortionFromIngredientsChange(int? recipeId)
        {
            if (recipeId.HasValue)
            {
                Recipe recipe =
                    ContextFactory.GetContextPerRequest().Recipes.FirstOrDefault(re => re.RecipeId == recipeId.Value);
                if (recipe != null)
                {
                    decimal? valuePerPortion = 0;
                    foreach (ProductIngredient productIngredient in recipe.ProductIngredients)
                    {
                        valuePerPortion += (decimal?) productIngredient.TotalValue;
                    }
                    foreach (RecipeIngredient recipeIngredient in recipe.RecipeIngredients1)
                        // RecipeIngredients1 is correct
                        // please find out what is RecipeIngredients and do I need it
                    {
                        valuePerPortion += (decimal?) recipeIngredient.TotalValue;
                    }
                    recipe.ProductionValuePerPortion = valuePerPortion;
                    ContextFactory.GetContextPerRequest().SaveChanges();
                }
            }
        }

      

    }
}