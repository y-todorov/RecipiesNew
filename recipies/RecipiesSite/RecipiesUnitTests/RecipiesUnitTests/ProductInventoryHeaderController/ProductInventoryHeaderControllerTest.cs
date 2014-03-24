using System.Linq;
using InventoryManagementMVC.Models;
using Kendo.Mvc.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecipiesModelNS;

namespace RecipiesUnitTests.StoreController
{
    [TestClass]
    public class ProductInventoryHeaderControllerTest
    {
        private InventoryManagementMVC.Controllers.ProductInventoryHeaderController productInventoryHeaderController;
        private DataSourceRequest request;

        [TestInitialize]
        public void TestInitialize()
        {
            productInventoryHeaderController = new InventoryManagementMVC.Controllers.ProductInventoryHeaderController();
            request = new DataSourceRequest();
        }

        [TestMethod]
        public void CreateTest()
        {
            CrudTestsHelper.Create(productInventoryHeaderController, request, new ProductInventoryHeaderViewModel());
        }

        [TestMethod]
        public void ReadTest()
        {
            CrudTestsHelper.Read(productInventoryHeaderController, request, ContextFactory.Current.ProductInventoryHeaders);
        }

        [TestMethod]
        [Ignore()]
        public void UpdateTest()
        {
            //CrudTestsHelper.Update(productInventoryHeaderController, request, (new ProductInventoryHeaderViewModel()).ConvertFromEntity(ContextFactory.Current.ProductInventoryHeaders.ToList().LastOrDefault()));
        }

        [TestMethod]
        public void DeleteTest()
        {
            CrudTestsHelper.Delete(productInventoryHeaderController, request);
        }
    }
}