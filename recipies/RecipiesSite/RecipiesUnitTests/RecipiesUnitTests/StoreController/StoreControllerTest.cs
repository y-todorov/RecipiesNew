using System.Linq;
using InventoryManagementMVC.Models;
using Kendo.Mvc.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecipiesModelNS;

namespace RecipiesUnitTests.StoreController
{
    [TestClass]
    public class StoreControllerTest
    {
        private InventoryManagementMVC.Controllers.StoreController storeController;
        private DataSourceRequest request;

        [TestInitialize]
        public void TestInitialize()
        {
            storeController = new InventoryManagementMVC.Controllers.StoreController();
            request = new DataSourceRequest();
        }

        [TestMethod]
        public void CreateTest()
        {
            CrudTestsHelper.Create(storeController, request, new StoreViewModel());
        }

        [TestMethod]
        public void ReadTest()
        {
            CrudTestsHelper.Read(storeController, request, ContextFactory.Current.Stores);
        }

        [TestMethod]
        public void UpdateTest()
        {
            CrudTestsHelper.Update(storeController, request, (new StoreViewModel()).ConvertFromEntity(ContextFactory.Current.Stores.ToList().LastOrDefault()));
        }

        [TestMethod]
        public void DeleteTest()
        {
            CrudTestsHelper.Delete(storeController, request);
        }
    }
}