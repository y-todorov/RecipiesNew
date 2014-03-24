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
    public class PurchaseOrderDetailController : ControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Read(int? purchaseOrderHeaderId, [DataSourceRequest] DataSourceRequest request)
        {
            List<PurchaseOrderDetail> purchaseOrderDetailViewModels =
                ContextFactory.Current.PurchaseOrderDetails.Where(
                     pod => purchaseOrderHeaderId.HasValue ? pod.PurchaseOrderId == purchaseOrderHeaderId.Value : true &&
                         ((pod.ReceivedQuantity.HasValue && pod.ReceivedQuantity != 0) || (pod.OrderQuantity.HasValue &&  pod.OrderQuantity != 0) || pod.LineTotal != 0 || pod.StockedQuantity != 0))
                    .Include(pod => pod.PurchaseOrderHeader.Vendor)
                    .Include(pod => pod.Product.ProductCategory)
                    .ToList();
            // remove empty PurchaseOrderDetails
            purchaseOrderDetailViewModels =
                purchaseOrderDetailViewModels.Where(
                    pod =>
                        Math.Round(pod.ReceivedQuantity.GetValueOrDefault(), 4) != 0 ||
                        Math.Round(pod.OrderQuantity.GetValueOrDefault(), 4) != 0 ||
                         Math.Round(pod.StockedQuantity, 4) != 0 ||
                         Math.Round(pod.ReturnedQuantity.GetValueOrDefault(), 4) != 0
                        ).ToList();



            var result = ReadBase(request, typeof(PurchaseOrderDetailViewModel), typeof(PurchaseOrderDetail),
                purchaseOrderDetailViewModels);

            return result;
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(int? purchaseOrderHeaderId, [DataSourceRequest] DataSourceRequest request,
            [Bind(Prefix = "models")] IEnumerable<PurchaseOrderDetailViewModel> purchaseOrderDetails)
        {
            if (purchaseOrderDetails != null && ModelState.IsValid)
            {
                foreach (PurchaseOrderDetailViewModel podViewModel in purchaseOrderDetails)
                {
                    podViewModel.PurchaseOrderHeaderId = purchaseOrderHeaderId;
                    PurchaseOrderDetail newPodEntity =
                        PurchaseOrderDetailViewModel.ConvertToPurchaseOrderDetailEntity(podViewModel,
                            new PurchaseOrderDetail());
                    ContextFactory.Current.PurchaseOrderDetails.Add(newPodEntity);
                    ContextFactory.Current.SaveChanges();
                    // Prefetch Product and others ...
                    newPodEntity = ContextFactory.Current.PurchaseOrderDetails.Include(
                        pod => pod.PurchaseOrderHeader.Vendor)
                        .Include(pod => pod.Product.ProductCategory)
                        .FirstOrDefault(pod => pod.PurchaseOrderDetailId == newPodEntity.PurchaseOrderDetailId);
                    PurchaseOrderDetailViewModel.ConvertFromPurchaseOrderDetailEntity(newPodEntity, podViewModel);
                }
            }

            return Json(purchaseOrderDetails.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request,
            [Bind(Prefix = "models")] IEnumerable<PurchaseOrderDetailViewModel> purchaseOrderDetails)
        {
            if (purchaseOrderDetails != null && ModelState.IsValid)
            {
                foreach (PurchaseOrderDetailViewModel podViewModel in purchaseOrderDetails)
                {
                    PurchaseOrderDetail pohEntity =
                        ContextFactory.Current.PurchaseOrderDetails.FirstOrDefault(
                            c => c.PurchaseOrderDetailId == podViewModel.PurchaseOrderDetailId);

                    PurchaseOrderDetailViewModel.ConvertToPurchaseOrderDetailEntity(podViewModel, pohEntity);

                    ContextFactory.Current.SaveChanges();
                    // Prefetch Product and others ...
                    pohEntity = ContextFactory.Current.PurchaseOrderDetails.Include(
                        pod => pod.PurchaseOrderHeader.Vendor)
                        .Include(pod => pod.Product.ProductCategory)
                        .FirstOrDefault(pod => pod.PurchaseOrderDetailId == pohEntity.PurchaseOrderDetailId);
                    PurchaseOrderDetailViewModel.ConvertFromPurchaseOrderDetailEntity(pohEntity, podViewModel);
                }
            }

            return Json(purchaseOrderDetails.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Destroy([DataSourceRequest] DataSourceRequest request,
            [Bind(Prefix = "models")] IEnumerable<PurchaseOrderDetailViewModel> purchaseOrderDetails)
        {
            foreach (PurchaseOrderDetailViewModel pod in purchaseOrderDetails)
            {
                PurchaseOrderDetail podEntity =
                    ContextFactory.Current.PurchaseOrderDetails.FirstOrDefault(
                        c => c.PurchaseOrderDetailId == pod.PurchaseOrderDetailId);
                ContextFactory.Current.PurchaseOrderDetails.Remove(podEntity);

                ContextFactory.Current.SaveChanges();
            }

            return Json(purchaseOrderDetails.ToDataSourceResult(request, ModelState));
        }
    }
}