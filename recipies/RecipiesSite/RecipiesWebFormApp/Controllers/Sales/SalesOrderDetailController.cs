using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InventoryManagementMVC.Models;
using InventoryManagementMVC.Models.Purchasing;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using RecipiesModelNS;
using System.Data.Entity;
using DevTrends.MvcDonutCaching; // .Include !!!!!!! THIS IS SO IMPROTANT

namespace InventoryManagementMVC.Controllers
{
    public class SalesOrderDetailController : ControllerBase
    {
        public ActionResult Read(int? salesOrderHeaderId, [DataSourceRequest] DataSourceRequest request)
        {
            List<SalesOrderDetail> salesOrderDetails =
                ContextFactory.Current.SalesOrderDetails.Where(pod => pod.SalesOrderHeaderId == salesOrderHeaderId.Value).ToList();

            var result = ReadBase(request, typeof(SalesOrderDetailViewModel), typeof(SalesOrderDetail), salesOrderDetails);
            return result;
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(int? salesOrderHeaderId, [DataSourceRequest] DataSourceRequest request,
            [Bind(Prefix = "models")] IEnumerable<SalesOrderDetailViewModel> salesOrderDetails)
        {
            var result = CreateBase(request, salesOrderDetails, typeof(SalesOrderDetailViewModel), typeof(SalesOrderDetail));
            return result;
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request,
            [Bind(Prefix = "models")] IEnumerable<SalesOrderDetailViewModel> salesOrderDetails)
        {
            var result = UpdateBase(request, salesOrderDetails, typeof(SalesOrderDetailViewModel), typeof(SalesOrderDetail));
            return result;
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Destroy([DataSourceRequest] DataSourceRequest request,
            [Bind(Prefix = "models")] IEnumerable<SalesOrderDetailViewModel> salesOrderDetails)
        {
            var result = DestroyBase(request, salesOrderDetails, typeof(SalesOrderDetailViewModel), typeof(SalesOrderDetail));
            return result;
        }
    }
}