using InventoryManagementMVC.Models;
using Kendo.Mvc.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecipiesModelNS;
using System.Diagnostics;
using System.Linq;

namespace RecipiesUnitTests.CategoryController
{
    [TestClass]
    public class CategoryControllerTest
    {
        private InventoryManagementMVC.Controllers.CategoryController categoryController;
        private DataSourceRequest request;

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
        }

        [TestInitialize]
        public void TestInitialize()
        {
            categoryController = new InventoryManagementMVC.Controllers.CategoryController();
            request = new DataSourceRequest();
        }

        [TestCleanup]
        public void TestCleanUp()
        {
        }

        [TestMethod]
        public void CreateCategoryTest()
        {
            Stopwatch s = new Stopwatch();
            s.Start();
            CrudTestsHelper.Create(categoryController, request, new CategoryViewModel());
            s.Stop();
            long mils = s.ElapsedMilliseconds;
        }

        [TestMethod]
        public void ReadCategoryTest()
        {
            Stopwatch s = new Stopwatch();
            s.Start();
            CrudTestsHelper.Read(categoryController, request, ContextFactory.Current.ProductCategories);
            s.Stop();
            long mils = s.ElapsedMilliseconds;
        }

        [TestMethod]
        public void UpdateCategoryTest()
        {
            Stopwatch s = new Stopwatch();
            s.Start();
            CrudTestsHelper.Update(categoryController, request, (new CategoryViewModel()).ConvertFromEntity(ContextFactory.Current.ProductCategories.ToList().LastOrDefault()));
            s.Stop();
            long mils = s.ElapsedMilliseconds;
        }

        [TestMethod]
        public void DeleteCategoryTest()
        {
            Stopwatch s = new Stopwatch();
            s.Start();
            CrudTestsHelper.Delete(categoryController, request);
            s.Stop();
            long mils = s.ElapsedMilliseconds;
        }
    }
}