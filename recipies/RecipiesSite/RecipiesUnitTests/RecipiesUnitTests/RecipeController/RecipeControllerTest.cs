using System.Linq;
using InventoryManagementMVC.Models;
using Kendo.Mvc.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecipiesModelNS;
using RecipiesWebFormApp.Quartz.Jobs;
using RecipiesWebFormApp.Shared;

namespace RecipiesUnitTests.RecipeController
{
    [TestClass]
    public class RecipeControllerTest
    {
        private InventoryManagementMVC.Controllers.RecipeController recipeController;
        private DataSourceRequest request;

        [TestInitialize]
        public void TestInitialize()
        {
            recipeController = new InventoryManagementMVC.Controllers.RecipeController();
            request = new DataSourceRequest();
        }

        [TestMethod]
        public void CreateTest()
        {
            CrudTestsHelper.Create(recipeController, request, new RecipeViewModel());
        }

        [TestMethod]
        public void ReadTest()
        {
            CrudTestsHelper.Read(recipeController, request, ContextFactory.Current.Recipes);
        }

        [TestMethod]
        public void UpdateTest()
        {
            CrudTestsHelper.Update(recipeController, request, (new RecipeViewModel()).ConvertFromEntity(ContextFactory.Current.Recipes.ToList().LastOrDefault()));
        }

        [TestMethod]
        public void DeleteTest()
        {
            CrudTestsHelper.Delete(recipeController, request);
        }

        [TestMethod]
        public void UpdateProductionValueOfAllRecipes()
        {
            CalculateRecipesProductionValuePerPortionJob job = new CalculateRecipesProductionValuePerPortionJob();
            job.Execute(null);
        }

        [TestMethod]
        public void Test()
        {
            StopwatchHelper.StartNewMeasurement("1");
            ContextFactory.Current.PurchaseOrderDetails.ToList(); 
            double d =  StopwatchHelper.StopLastMeasurement("1");

            StopwatchHelper.StartNewMeasurement("2");
            ContextFactory.Current.PurchaseOrderDetails.ToList();
            double d2 = StopwatchHelper.StopLastMeasurement("2");



        }

    }
}