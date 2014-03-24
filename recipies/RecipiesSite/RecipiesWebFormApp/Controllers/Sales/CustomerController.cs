using System.Collections;
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
    public class CustomerController : ControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            var result = ReadBase(request, typeof(CustomerViewModel), typeof(Customer), ContextFactory.Current.Customers.ToList());
            return result;
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create([DataSourceRequest] DataSourceRequest request,
            [Bind(Prefix = "models")] IEnumerable<CustomerViewModel> customers)
        {
            var result = CreateBase(request, customers, typeof(CustomerViewModel), typeof(Customer));
            return result;
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request,
            [Bind(Prefix = "models")] IEnumerable<CustomerViewModel> customers)
        {
            var result = UpdateBase(request, customers, typeof(CustomerViewModel), typeof(Customer));
            return result;
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Destroy([DataSourceRequest] DataSourceRequest request,
            [Bind(Prefix = "models")] IEnumerable<CustomerViewModel> customers)
        {
            var result = DestroyBase(request, customers, typeof(CustomerViewModel), typeof(Customer));
            return result;
        }
    }
}