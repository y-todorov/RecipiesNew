using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Xml.Serialization;
using InventoryManagementMVC.Models;
using Kendo.Mvc.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RecipiesModelNS;
using RecipiesReports;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
using Telerik.Reporting;
using System.Xml;
using System.Data.Entity;
using System.Collections;
using RecipiesWebFormApp.Purchasing;
using System.Text;

namespace RecipiesUnitTests.SharedController
{
    [TestClass]
    public class DownloadControllerTest
    {
        private InventoryManagementMVC.Controllers.DownloadController downloadController;
        private DataSourceRequest request;

        [TestInitialize]
        public void TestInitialize()
        {
            downloadController = new InventoryManagementMVC.Controllers.DownloadController();
            request = new DataSourceRequest();
        }

        [TestMethod]
        public void MultipleStreamReportTest()
        {
            string retporname = typeof(PurchaseOrderDetailsReport).AssemblyQualifiedName;
            bool result = downloadController.RenderReport(retporname);
            //CrudTestsHelper.Create(storeController, request, new StoreViewModel());
        }

        [TestMethod]
        public byte[] SerializeReportTest()
        {
            RecipiesReports.PurchaseOrderDetailsReport salesOrderDetailsReport =
                new RecipiesReports.PurchaseOrderDetailsReport();

            using (MemoryStream ms = new MemoryStream())
            {
                Telerik.Reporting.XmlSerialization.ReportXmlSerializer xmlSerializer =
                    new Telerik.Reporting.XmlSerialization.ReportXmlSerializer();

                xmlSerializer.Serialize(ms, salesOrderDetailsReport);

                byte[] result = ms.ToArray();

                Assert.AreNotEqual(0, result.Length);

                return result;
            }
        }

        [TestMethod]
        public Telerik.Reporting.Report DeSerializeReportTest()
        {
            byte[] reportBytes = SerializeReportTest();

            System.Xml.XmlReaderSettings settings = new System.Xml.XmlReaderSettings();
            settings.IgnoreWhitespace = true;

            using (MemoryStream ms = new MemoryStream(reportBytes))
            {
                Telerik.Reporting.XmlSerialization.ReportXmlSerializer xmlSerializer =
                    new Telerik.Reporting.XmlSerialization.ReportXmlSerializer();

                Telerik.Reporting.Report report = (Telerik.Reporting.Report)
                    xmlSerializer.Deserialize(ms);
                return report;

                Assert.IsNotNull(report);


            }
        }

        [TestMethod]
        public void FullTest()
        {
            
            byte[] resultBytes = downloadController.DownloadPurchaseOrderDetailsReportAsPdf(18961);
            string tempPath = Path.GetTempFileName();

            tempPath = Path.ChangeExtension(tempPath, "pdf");

            File.WriteAllBytes(tempPath, resultBytes);
        }

        [TestMethod]
        public void GerReportWebApi()
        {
             var r = downloadController.SerializeReport(new RecipiesReports.PurchaseOrderDetailsReport());

            JsonSerializerSettings jss = new JsonSerializerSettings();

            jss.MaxDepth = 3;
            jss.PreserveReferencesHandling = PreserveReferencesHandling.All;
            jss.ReferenceLoopHandling = ReferenceLoopHandling.Serialize;

            ContextFactory.Current.Configuration.ProxyCreationEnabled = false;

            var list = ContextFactory.Current.PurchaseOrderDetails
                .Include(pod => pod.PurchaseOrderHeader).Include(pod => pod.Product).Include(pod => pod.UnitMeasure)


                .Take(300).ToList();




            string ser = JsonConvert.SerializeObject(list, jss);

            string resultString = downloadController.DownloadReportSerialization(r, ser);    

            using (var client = new HttpClient())
            {
                //client.BaseAddress = new Uri("http://localhost:60902/");
                client.BaseAddress = new Uri(" http://recipiesservices.apphb.com/");
           
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // New code:

                string url = "api/report";

                string formattedData = string.Format("{0}EscapeSequence{1}", r, ser);

                HttpResponseMessage response = client.PostAsJsonAsync(url, formattedData).Result;

                string rerr = response.Content.ReadAsStringAsync().Result;
                if (response.IsSuccessStatusCode)
                {
                    string pdfString = response.Content.ReadAsAsync<string>().Result;

                    byte[] resultBytes = Convert.FromBase64String(pdfString);
                    string tempPath = Path.GetTempFileName();

                    tempPath = Path.ChangeExtension(tempPath, "pdf");

                    File.WriteAllBytes(tempPath, resultBytes);

                }
            }
        }











    }
}

