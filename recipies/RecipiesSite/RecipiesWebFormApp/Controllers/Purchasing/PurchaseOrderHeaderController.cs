using InventoryManagementMVC.Models.Purchasing;
using Kendo.Mvc.UI;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using RecipiesModelNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using System.IO;
using RecipiesWebFormApp.Helpers;
using Telerik.Reporting.Processing;
using Helpers;
using RestSharp;
using System.Net;
using System.Data.Entity;
using InventoryManagementMVC.Models;
using RecipiesWebFormApp.Extensions;

namespace InventoryManagementMVC.Controllers.Purchasing
{
    public class PurchaseOrderHeaderController : ControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            List<PurchaseOrderHeaderViewModel> purchaseOrderHeaderViewModels =
                ContextFactory.Current.PurchaseOrderHeaders
                    .ToList().Select
                    (pod =>
                        PurchaseOrderHeaderViewModel.ConvertFromPurchaseOrderHeaderEntity(pod,
                            new PurchaseOrderHeaderViewModel())).ToList();
            return Json(purchaseOrderHeaderViewModels.ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create([DataSourceRequest] DataSourceRequest request,
            [Bind(Prefix = "models")] IEnumerable<PurchaseOrderHeaderViewModel> purchaseOrderHeaders)
        {
            if (purchaseOrderHeaders != null && ModelState.IsValid)
            {
                foreach (PurchaseOrderHeaderViewModel pohViewModel in purchaseOrderHeaders)
                {
                    PurchaseOrderHeader newPohEntity =
                        PurchaseOrderHeaderViewModel.ConvertToPurchaseOrderHeaderEntity(pohViewModel,
                            new PurchaseOrderHeader());
                    ContextFactory.Current.PurchaseOrderHeaders.Add(newPohEntity);
                    ContextFactory.Current.SaveChanges();

                    List<ProductVendor> productsForVendor =
                        ContextFactory.Current.ProductVendors.Where(
                            pv => pv.VendorId == newPohEntity.VendorId && pv.ProductId != null).ToList();

                    foreach (ProductVendor pv in productsForVendor)
                    {
                        PurchaseOrderDetail pod = new PurchaseOrderDetail()
                        {
                            PurchaseOrderId = newPohEntity.PurchaseOrderId,
                            ProductId = pv.Product.ProductId,
                            UnitPrice = pv.Product.UnitPrice,
                            UnitMeasureId = pv.UnitMeasureId,
                        };

                        decimal coef = 1;
                        if (pv.UnitMeasure != null)
                        {
                            coef = (decimal) pv.Product.GetBaseUnitMeasureQuantityForProduct(1, pv.UnitMeasure);
                        }
                        pod.UnitPrice = coef*(decimal) pv.Product.UnitPrice.GetValueOrDefault();
                            //.GetAveragePriceLastDays(14); Unit price must be alwats equal to GetAveragePriceLastDays(14)

                        ContextFactory.Current.PurchaseOrderDetails.Add(pod);
                    }

                    ContextFactory.Current.SaveChanges();
                    newPohEntity.ModifiedDate = DateTime.Now;
                    PurchaseOrderHeader.UpdatePurchaseOrderHeaderSubTotalFromPurchaseOrderDetails(
                        newPohEntity.PurchaseOrderId);
                    ContextFactory.Current.SaveChanges();


                    PurchaseOrderHeaderViewModel.ConvertFromPurchaseOrderHeaderEntity(newPohEntity, pohViewModel);
                }
            }

            return Json(purchaseOrderHeaders.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request,
            [Bind(Prefix = "models")] IEnumerable<PurchaseOrderHeaderViewModel> purchaseOrderHeaders)
        {
            if (purchaseOrderHeaders != null && ModelState.IsValid)
            {
                foreach (PurchaseOrderHeaderViewModel pohViewModel in purchaseOrderHeaders)
                {
                    PurchaseOrderHeader pohEntity =
                        ContextFactory.Current.PurchaseOrderHeaders.FirstOrDefault(
                            c => c.PurchaseOrderId == pohViewModel.PurchaseOrderHeaderId);

                    PurchaseOrderHeaderViewModel.ConvertToPurchaseOrderHeaderEntity(pohViewModel, pohEntity);

                    ContextFactory.Current.SaveChanges();

                    PurchaseOrderHeaderViewModel.ConvertFromPurchaseOrderHeaderEntity(pohEntity, pohViewModel);
                }
            }

            return Json(purchaseOrderHeaders.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Destroy([DataSourceRequest] DataSourceRequest request,
            [Bind(Prefix = "models")] IEnumerable<PurchaseOrderHeaderViewModel> purchaseOrderHeaders)
        {
            foreach (PurchaseOrderHeaderViewModel poh in purchaseOrderHeaders)
            {
                PurchaseOrderHeader pod =
                    ContextFactory.Current.PurchaseOrderHeaders.FirstOrDefault(
                        c => c.PurchaseOrderId == poh.PurchaseOrderHeaderId);
                ContextFactory.Current.PurchaseOrderHeaders.Remove(pod);

                ContextFactory.Current.SaveChanges();
            }

            return Json(purchaseOrderHeaders.ToDataSourceResult(request, ModelState));
        }
     
        public ActionResult SendEmail(int? purchaseOrderHeaderId)
        {


            PurchaseOrderHeader purchaseOrder =
                ContextFactory.GetContextPerRequest()
                    .PurchaseOrderHeaders.FirstOrDefault(p => p.PurchaseOrderId == purchaseOrderHeaderId);

            //ReportProcessor reportProcessor = new ReportProcessor();

            //var instanceReportSource = new Telerik.Reporting.InstanceReportSource();
            //RecipiesReports.PurchaseOrderDetailsReport salesOrderDetailsReport =
            //    new RecipiesReports.PurchaseOrderDetailsReport();

            //List<PurchaseOrderDetail> nonEmptyOrders =
            //    purchaseOrder.PurchaseOrderDetails.Where(pod => pod.OrderQuantity.GetValueOrDefault() != 0).ToList();

            //salesOrderDetailsReport.DataSource = nonEmptyOrders;
            //instanceReportSource.ReportDocument = salesOrderDetailsReport;

            //RenderingResult result = reportProcessor.RenderReport("Image", instanceReportSource, null);

            ////PdfDocument doc = new PdfDocument();
            ////doc.Pages.Add(new PdfPage());
            ////XGraphics xgr = XGraphics.FromPdfPage(doc.Pages[0]);

            //string tempFileName = Path.GetTempFileName();
            //System.IO.File.WriteAllBytes(tempFileName, result.DocumentBytes);


            //string jpegFilePath = ImageHelper.ConvertTiffToJpeg(tempFileName).FirstOrDefault();

            //XImage img = XImage.FromFile(tempFileName);

            //xgr.DrawImage(img, 0, 0);
            //tempFileName = Path.GetTempFileName();
            //doc.Save(tempFileName);
            //doc.Close();

            EmailTemplate defaultTemplate =
                ContextFactory.GetContextPerRequest().EmailTemplates.FirstOrDefault(et => et.IsDefault);
            if (defaultTemplate != null)
            {
                byte[] documentBytes = (new DownloadController()).DownloadPurchaseOrderDetailsReportAsPdf(purchaseOrderHeaderId); ;
                RestResponse restResponse = EmailHelper.SendComplexMessage(defaultTemplate.From,
                    purchaseOrder.Vendor.Email, defaultTemplate.Cc,
                    defaultTemplate.Bcc, defaultTemplate.Subject, defaultTemplate.TextBody, defaultTemplate.HtmlBody,
                    documentBytes, defaultTemplate.AttachmentName + "." + "pdf"); // was result.Extension. It will be replaced by pdf
            }
            else
            {
            }

            return RedirectToAction("Index");
        }

        public ActionResult ReadDetail(int? purchaseOrderHeaderId, [DataSourceRequest] DataSourceRequest request)
        {
            List<PurchaseOrderDetailViewModel> purchaseOrderDetailViewModels =
                ContextFactory.Current.PurchaseOrderDetails.Where(
                    pod => purchaseOrderHeaderId.HasValue ? pod.PurchaseOrderId == purchaseOrderHeaderId.Value : true)
                    .Include(pod => pod.PurchaseOrderHeader.Vendor)
                    .Include(pod => pod.Product.ProductCategory)
                    .ToList().Select
                    (pod =>
                        PurchaseOrderDetailViewModel.ConvertFromPurchaseOrderDetailEntity(pod,
                            new PurchaseOrderDetailViewModel())).ToList();
            return Json(purchaseOrderDetailViewModels.ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CreateDetail(int? purchaseOrderHeaderId, [DataSourceRequest] DataSourceRequest request,
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
            //return View("Index");
            return Json(purchaseOrderDetails.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UpdateDetail([DataSourceRequest] DataSourceRequest request,
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

            //return View("Index");

            return Json(purchaseOrderDetails.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult DestroyDetail([DataSourceRequest] DataSourceRequest request,
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
            //return View("Index");
        }
    }
}