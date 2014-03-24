using System.Linq;
using InventoryManagementMVC.Models;
using Kendo.Mvc.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecipiesModelNS;

namespace RecipiesUnitTests.UnitMeasureController
{
    [TestClass]
    public class UnitMeasureControllerTest
    {
        private InventoryManagementMVC.Controllers.UnitMeasureController unitMeasureController;
        private DataSourceRequest request;

        [TestInitialize]
        public void TestInitialize()
        {
            unitMeasureController = new InventoryManagementMVC.Controllers.UnitMeasureController();
            request = new DataSourceRequest();
        }

        [TestMethod]
        public void CreateTest()
        {
            CrudTestsHelper.Create(unitMeasureController, request, new UnitMeasureViewModel());
        }

        [TestMethod]
        public void ReadTest()
        {
            CrudTestsHelper.Read(unitMeasureController, request, ContextFactory.Current.UnitMeasures);
        }

        [TestMethod]
        public void UpdateTest()
        {
            CrudTestsHelper.Update(unitMeasureController, request, (new UnitMeasureViewModel()).ConvertFromEntity(ContextFactory.Current.UnitMeasures.ToList().LastOrDefault()));
        }

        [TestMethod]
        public void DeleteTest()
        {
            CrudTestsHelper.Delete(unitMeasureController, request);
        }
    }
}