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
    public class PaymentTypeController : ControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            var result = ReadBase(request, typeof(PaymentTypeViewModel), typeof(PaymentType), ContextFactory.Current.PaymentTypes.ToList());
            return result;
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create([DataSourceRequest] DataSourceRequest request,
            [Bind(Prefix = "models")] IEnumerable<PaymentTypeViewModel> paymentTypes)
        {
            var result = CreateBase(request, paymentTypes, typeof(PaymentTypeViewModel), typeof(PaymentType));
            return result;
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request,
            [Bind(Prefix = "models")] IEnumerable<PaymentTypeViewModel> paymentTypes)
        {
            var result = UpdateBase(request, paymentTypes, typeof(PaymentTypeViewModel), typeof(PaymentType));
            return result;
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Destroy([DataSourceRequest] DataSourceRequest request,
            [Bind(Prefix = "models")] IEnumerable<PaymentTypeViewModel> paymentTypes)
        {
            var result = DestroyBase(request, paymentTypes, typeof(PaymentTypeViewModel), typeof(PaymentType));
            return result;
        }
    }
}