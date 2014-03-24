using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using InventoryManagementMVC.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using RecipiesModelNS;

namespace InventoryManagementMVC.Controllers
{
    public class UnitMeasureController : ControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            var result = ReadBase(request, typeof(UnitMeasureViewModel), typeof(UnitMeasure), ContextFactory.Current.UnitMeasures.ToList());
            return result;
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create([DataSourceRequest] DataSourceRequest request,
            [Bind(Prefix = "models")] IEnumerable<UnitMeasureViewModel> unitMeasures)
        {
            var result = CreateBase(request, unitMeasures, typeof(UnitMeasureViewModel), typeof(UnitMeasure));
            return result;
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request,
            [Bind(Prefix = "models")] IEnumerable<UnitMeasureViewModel> unitMeasures)
        {
            var result = UpdateBase(request, unitMeasures, typeof(UnitMeasureViewModel), typeof(UnitMeasure));
            return result;
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Destroy([DataSourceRequest] DataSourceRequest request,
            [Bind(Prefix = "models")] IEnumerable<UnitMeasureViewModel> unitMeasures)
        {
            var result = DestroyBase(request, unitMeasures, typeof(UnitMeasureViewModel), typeof(UnitMeasure));
            return result;
        }
    }
}