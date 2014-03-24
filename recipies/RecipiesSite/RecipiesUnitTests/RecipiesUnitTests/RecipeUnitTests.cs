using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecipiesModelNS;

namespace RecipiesUnitTests
{
    //[Ignore()] // These test are tun in the cloud and deployment fails if a test fails.
    [TestClass]
    public class RecipeUnitTests
    {
        [TestMethod]
        public void FindAllProductsWithQuantitiesInRecipe()
        {
            Recipe aRecipie = ContextFactory.Current.Recipes.FirstOrDefault();
            var products = new Dictionary<int, double>();
            Recipe.GetProductsWithQuantities(aRecipie.RecipeId, products);
            Assert.AreNotEqual(0, products.Count);
        }
    }
}