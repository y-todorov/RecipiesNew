using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using InventoryManagementMVC.Models;
using Kendo.Mvc.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RecipiesUnitTests
{
    public static class CrudTestsHelper
    {
        public static void Create(dynamic controller, DataSourceRequest request, object newModel)
        {
            UnitTestHelper.InitializeModelWithRandomValues(newModel);

            Type modelType = newModel.GetType();

            Type listType = typeof(List<>);
            Type constructedListType = listType.MakeGenericType(modelType);

            dynamic listOfModelsInstance = Activator.CreateInstance(constructedListType);
            dynamic dummy = Activator.CreateInstance(modelType);
            dummy = newModel;
            listOfModelsInstance.Add(dummy);

            var jr = controller.Create(request, listOfModelsInstance) as JsonResult;
            // Act
            object savedModel = (jr.Data as DataSourceResult).Data.Cast<object>().FirstOrDefault();
            bool areEqual = UnitTestHelper.CheckIfTwoModelsAreEqual(newModel, savedModel);
            // Assert
            Assert.IsTrue(areEqual, "Saved product field values are not equal to values that are to be saved!");
        }
    

        public static void Read(dynamic controller, DataSourceRequest request, IEnumerable entities)
        {
            // Arrange
            var jr = controller.Read(request) as JsonResult;
            // Act
            List<object> resultProducts = (jr.Data as DataSourceResult).Data.Cast<object>().ToList();
            // Assert
            Assert.AreEqual(resultProducts.Count, entities.Cast<object>().Count());
        }

        public static void Update(dynamic controller, DataSourceRequest request, object existingModel)
        {
            UnitTestHelper.InitializeModelWithRandomValues(existingModel);

            Type modelType = existingModel.GetType();

            Type listType = typeof(List<>);
            Type constructedListType = listType.MakeGenericType(modelType);

            dynamic listOfModelsInstance = Activator.CreateInstance(constructedListType);
            dynamic dummy = Activator.CreateInstance(modelType);
            dummy = existingModel;
            listOfModelsInstance.Add(dummy);

            var jr = controller.Update(request, listOfModelsInstance) as JsonResult;
            // Act
            object savedModel = (jr.Data as DataSourceResult).Data.Cast<object>().FirstOrDefault();
            bool areEqual = UnitTestHelper.CheckIfTwoModelsAreEqual(existingModel, savedModel);
            // Assert
            Assert.IsTrue(areEqual, "Saved product field values are not equal to values that are to be saved!");
        }

        public static void Delete(dynamic controller, DataSourceRequest request)
        {
            // Arrange
            var jrr = controller.Read(request) as JsonResult;

            List<object> allProducts = (jrr.Data as DataSourceResult).Data.Cast<object>().ToList();

            Type modelType = allProducts.First().GetType();

            // Act
            IEnumerable modelForDelete = (jrr.Data as DataSourceResult).Data;

            Type listType = typeof (List<>);
            Type constructedListType = listType.MakeGenericType(modelType);

            dynamic listOfModelsInstance = Activator.CreateInstance(constructedListType);

            IEnumerator en = modelForDelete.GetEnumerator();
            //en.MoveNext();

            dynamic correctInstance = Activator.CreateInstance(modelType);
            while (en.MoveNext())
            {
                correctInstance = en.Current; // get the last one
            }
            //correctInstance = en.Current;

            listOfModelsInstance.Add(correctInstance);

            var jru = controller.Destroy(request, listOfModelsInstance) as JsonResult;
            object deletedProduct = (jru.Data as DataSourceResult).Data.Cast<object>().FirstOrDefault();

            var jrAfterDelete = controller.Read(request) as JsonResult;
            List<object> allProductsAfterDelete = (jrAfterDelete.Data as DataSourceResult).Data.Cast<object>().ToList();

            Assert.AreEqual(allProducts.Count - 1, allProductsAfterDelete.Count);
        }
    }
}