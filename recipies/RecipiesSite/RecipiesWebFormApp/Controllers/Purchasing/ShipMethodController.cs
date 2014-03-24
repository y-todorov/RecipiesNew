using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using InventoryManagementMVC.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using RecipiesModelNS;
using Kendo.Mvc;

namespace InventoryManagementMVC.Controllers
{
    public class ShipMethodController : ControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            var result = ReadBase(request, typeof(ShipMethodViewModel), typeof(ShipMethod), ContextFactory.Current.ShipMethods.ToList());
            return result;
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create([DataSourceRequest] DataSourceRequest request,
            [Bind(Prefix = "models")] IEnumerable<ShipMethodViewModel> shipMethods)
        {
            var result = CreateBase(request, shipMethods, typeof(ShipMethodViewModel), typeof(ShipMethod));
            return result;
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request,
            [Bind(Prefix = "models")] IEnumerable<ShipMethodViewModel> shipMethods)
        {
            var result = UpdateBase(request, shipMethods, typeof(ShipMethodViewModel), typeof(ShipMethod));
            return result;
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Destroy([DataSourceRequest] DataSourceRequest request,
            [Bind(Prefix = "models")] IEnumerable<ShipMethodViewModel> shipMethods)
        {
            var result = DestroyBase(request, shipMethods, typeof(ShipMethodViewModel), typeof(ShipMethod));
            return result;
        }
    }
}