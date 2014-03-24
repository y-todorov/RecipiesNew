using InventoryManagementMVC.Models.Purchasing;
using Kendo.Mvc.UI;
using RecipiesModelNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using System.IO;
using Telerik.Reporting.Processing;
using Helpers;
using RestSharp;
using System.Net;
using System.Data.Entity;
using InventoryManagementMVC.Models;

namespace InventoryManagementMVC.Controllers.Purchasing
{
    public class SalesOrderHeaderController : ControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            var result = ReadBase(request, typeof(SalesOrderHeaderViewModel), typeof(SalesOrderHeader), ContextFactory.Current.SalesOrderHeaders.ToList());
            return result;
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create([DataSourceRequest] DataSourceRequest request,
            [Bind(Prefix = "models")] IEnumerable<SalesOrderHeaderViewModel> salesOrderHeaders)
        {
            var result = CreateBase(request, salesOrderHeaders, typeof(SalesOrderHeaderViewModel), typeof(SalesOrderHeader));
            return result;
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request,
            [Bind(Prefix = "models")] IEnumerable<SalesOrderHeaderViewModel> sohs)
        {
            var result = UpdateBase(request, sohs, typeof(SalesOrderHeaderViewModel), typeof(SalesOrderHeader));
            return result;
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Destroy([DataSourceRequest] DataSourceRequest request,
            [Bind(Prefix = "models")] IEnumerable<SalesOrderHeaderViewModel> sohs)
        {
            var result = DestroyBase(request, sohs, typeof(SalesOrderHeaderViewModel), typeof(SalesOrderHeader));
            return result;
        }
    }
}