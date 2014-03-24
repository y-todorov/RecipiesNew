using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using InventoryManagementMVC.Models;
using Kendo.Mvc.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecipiesModelNS;

namespace RecipiesUnitTests.ProductController
{
    [TestClass]
    public class ProductControllerTest
    {
        private InventoryManagementMVC.Controllers.ProductController productController;
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
            productController = new InventoryManagementMVC.Controllers.ProductController();
            request = new DataSourceRequest();
        }

        [TestCleanup]
        public void TestCleanUp()
        {
        }

        [TestMethod]
        public void CreateProductTest()
        {
            CrudTestsHelper.Create(productController, request, new ProductViewModel());
        }

        [TestMethod]
        public void ReadProductTest()
        {
            CrudTestsHelper.Read(productController, request, ContextFactory.Current.Products);
        }

        [TestMethod]
        public void UpdateProductTest()
        {
            CrudTestsHelper.Update(productController, request, (new ProductViewModel()).ConvertFromEntity(ContextFactory.Current.Products.ToList().LastOrDefault()));
        }

        [TestMethod]
        public void DeleteProductTest()
        {
            CrudTestsHelper.Delete(productController, request);
        }

          [TestMethod]
        public void UnitsOnOrderTest()
        {
            ProductViewModel newProductViewModel = new ProductViewModel();
            newProductViewModel.UnitMeasureId = ContextFactory.Current.UnitMeasures.FirstOrDefault().UnitMeasureId;
            CrudTestsHelper.Create(productController, request, newProductViewModel);

            PurchaseOrderHeader poh = new PurchaseOrderHeader();
            poh.OrderDate = DateTime.Now;
            poh.ShipDate = DateTime.Now;
            poh.StatusId = (int)PurchaseOrderStatusEnum.Approved;

            ContextFactory.Current.PurchaseOrderHeaders.Add(poh);
            ContextFactory.Current.SaveChanges();


            PurchaseOrderDetail pod = new PurchaseOrderDetail();
            pod.ProductId = newProductViewModel.ProductId;
            pod.UnitMeasureId = newProductViewModel.UnitMeasureId;
            pod.PurchaseOrderId = poh.PurchaseOrderId;
            ContextFactory.Current.PurchaseOrderDetails.Add(pod);
            ContextFactory.Current.SaveChanges();

        }
    }
}