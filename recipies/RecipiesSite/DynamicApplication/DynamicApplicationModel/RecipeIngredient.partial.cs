using System.Linq;

namespace RecipiesModelNS
{
    public partial class RecipeIngredient : YordanBaseEntity
    {
        private static int? recipeIdToUpdate;

        public override void Added(System.Data.Entity.Infrastructure.DbEntityEntry e = null)
        {
            ProductIngredient.UpdateRecipesValuePerPortionFromIngredientsChange(ParentRecipeId);
            base.Added(e);
        }

        public override void Changed(System.Data.Entity.Infrastructure.DbEntityEntry e = null)
        {
            ProductIngredient.UpdateRecipesValuePerPortionFromIngredientsChange(ParentRecipeId);
            base.Changed(e);
        }

        public override void Removing(System.Data.Entity.Infrastructure.DbEntityEntry e = null)
        {
            //recipeIdToUpdate = ParentRecipeId; // THIS CAN BE ONLY THE PRIMARY KEY OF THE DELETED ENTITY THIS IS PROBLEM AND DO NOT WORK
            using (RecipiesEntities context = ContextFactory.CreateNewContext())
            {
                RecipeIngredient ri =
                    context.RecipeIngredients.FirstOrDefault(r => r.RecipeIngredientId == RecipeIngredientId);
                if (ri != null)
                {
                    recipeIdToUpdate = ri.ParentRecipeId;
                }
            }
            base.Removing(e);
        }

        public override void Removed(System.Data.Entity.Infrastructure.DbEntityEntry e = null)
        {
            ProductIngredient.UpdateRecipesValuePerPortionFromIngredientsChange(recipeIdToUpdate);
            base.Removed(e);
        }
    }
}