using System.Net.Http;
using System.Net.Http.Headers;
using Kendo.Mvc.UI;
using Newtonsoft.Json;
using NPOI.HSSF.UserModel;
using RecipiesModelNS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using RecipiesWebFormApp.Helpers;
using System.Net;
using System.Xml.Linq;
using Telerik.Reporting.Processing;
using System.Data.Entity;

namespace InventoryManagementMVC.Controllers
{
    public class DownloadController : Controller
    {
        private string GetTableXml(string completeGridXml)
        {
            //string reportHtml = File.ReadAllText("ReportHtml.txt", Encoding.GetEncoding("Windows-1251"));

            //int startIndex = completeGridXml.IndexOf("<tbody>");
            //int endIndex = completeGridXml.LastIndexOf("</tbody>");

            int startIndex = completeGridXml.IndexOf("<table");
            int endIndex = completeGridXml.LastIndexOf("</table>");

            int len = endIndex - startIndex + "</table>".Length;

            string xml = completeGridXml.Substring(startIndex, len);
            xml = xml.Replace("&nbsp;", "");
            //xml = xml.Replace("<colgroup>", "");
            //xml = xml.Replace("</colgroup>", "");
            //xml = xml.Replace("<col>", "");
            //xml = xml.Replace("<col>", "");

            // replace script blocks
            while (xml.Contains("<colgroup>"))
            {
                xml = CutSubstringData(xml, "<colgroup>", "</colgroup>");
            }

            while (xml.Contains("<script>"))
            {
                xml = CutSubstringData(xml, "<script>", "</script>");
            }

            return xml;
        }

        private string CutSubstringData(string text, string startTag, string endTag)
        {
            int startIndex = text.IndexOf(startTag);
            int endIndex = text.IndexOf(endTag);
            int len = endIndex - startIndex + endTag.Length;

            string textToRemove = text.Substring(startIndex, len);
            string result = text.Replace(textToRemove, "");

            return result;
        }

        // make these two one monethod !
        private List<XElement> GetTrsWithDataOnly(string xml)
        {
            List<XElement> result = new List<XElement>();
            XDocument xdoc = XDocument.Parse(xml);

            List<XElement> trs = xdoc.Descendants("tr").ToList();

            foreach (XElement tr in trs)
            {
                List<XAttribute> attrs = tr.Attributes().ToList();

                if (attrs.Count == 0)
                {
                    result.Add(tr);
                }

                foreach (XAttribute attr in attrs)
                {
                    //if (attr.Name == "role" && attr.Value.Contains("row") ||
                    //    attr.Name == "class" && attr.Value.Contains("k-grouping-row") ||
                    //    attr.Name == "class" && attr.Value.Contains("k-group-footer") ||
                    //    attr.Name == "class" && attr.Value.Contains("k-grouping-row") 
                    //    )
                    if (!(attr.Name == "class" && attr.Value.Contains("k-footer-template")))
                    {
                        result.Add(tr);
                        break;
                    }
                }
            }
            return result;
        }

        private List<XElement> GetTrsFromGridFooterOnly(string xml)
        {
            List<XElement> result = new List<XElement>();
            XDocument xdoc = XDocument.Parse(xml);

            List<XElement> trs = xdoc.Descendants("tr").ToList();

            foreach (XElement tr in trs)
            {
                List<XAttribute> attrs = tr.Attributes().ToList();

                foreach (XAttribute attr in attrs)
                {
                    if (attr.Name == "class" && attr.Value.Contains("k-footer-template"))
                    {
                        result.Add(tr);
                        break;
                    }
                }
            }
            return result;
        }

        private List<XElement> GetTds(XElement row)
        {
            List<XElement> result = new List<XElement>();
            List<XElement> ths = row.Descendants("th").ToList();
            List<XElement> tds = row.Descendants("td").ToList();

            foreach (XElement th in ths)
            {
                //List<XAttribute> attrs = td.Attributes().ToList();
                //foreach (XAttribute attr in attrs)
                {
                    //if (attr.Name == "role" && attr.Value == "gridcell")
                    {
                        result.Add(th); // string valToInsertInExcel = td.Value;
                    }
                }
            }

            foreach (XElement td in tds)
            {
                //List<XAttribute> attrs = td.Attributes().ToList();
                //foreach (XAttribute attr in attrs)
                {
                    //if (attr.Name == "role" && attr.Value == "gridcell")
                    {
                        result.Add(td); // string valToInsertInExcel = td.Value;
                    }
                }
            }

            return result;
        }

        private List<XElement> GetThs(XElement row)
        {
            List<XElement> result = new List<XElement>();
            List<XElement> ths = row.Descendants("th").ToList();

            foreach (XElement th in ths)
            {
                //List<XAttribute> attrs = td.Attributes().ToList();
                //foreach (XAttribute attr in attrs)
                {
                    //if (attr.Name == "role" && attr.Value == "gridcell")
                    {
                        result.Add(th); // string valToInsertInExcel = td.Value;
                    }
                }
            }

            return result;
        }

        private string GetThValue(XElement row)
        {
            List<XElement> anchors = row.Descendants("a").ToList();
            foreach (XElement a in anchors)
            {
                List<XAttribute> attrs = a.Attributes().ToList();
                foreach (XAttribute attr in attrs)
                {
                    if (attr.Name == "class" && attr.Value == "k-link")
                    {
                        return a.Value;
                    }
                }
            }

            return string.Empty;
        }


        private static FileContentResult lastFileContentResult;

        public ActionResult DownloadExport()
        {
            if (lastFileContentResult != null)
            {
                return lastFileContentResult;
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
        }

        public void ExportWithOpenXML(string typeName, string html, [DataSourceRequest] DataSourceRequest request)
        {
            //Create new Excel workbook
            var workbook = new HSSFWorkbook();

            //Create new Excel sheet
            var sheet = workbook.CreateSheet();

            //(Optional) set the width of the columns
            //sheet.SetColumnWidth(0, 10 * 256);
            //sheet.SetColumnWidth(1, 50 * 256);
            //sheet.SetColumnWidth(2, 50 * 256);
            //sheet.SetColumnWidth(3, 50 * 256);

            //Create a header row
            //var headerRow = sheet.CreateRow(0);

            //Set the column names in the header row
            //headerRow.CreateCell(0).SetCellValue("Product ID");
            //headerRow.CreateCell(1).SetCellValue("Product Name");
            //headerRow.CreateCell(2).SetCellValue("Unit Price");
            //headerRow.CreateCell(3).SetCellValue("Quantity Per Unit");

            //for (int i = 0; i < props.Length; i++)
            //{
            //    headerRow.CreateCell(i).SetCellValue(props[i].Name);
            //}


            //(Optional) freeze the header row so it is not scrolled
            //sheet.CreateFreezePane(0, 1, 0, 1);

            int rowNumber = 0;

            string tableXml = GetTableXml(html);
            List<XElement> trs = GetTrsWithDataOnly(tableXml);
            trs.AddRange(GetTrsFromGridFooterOnly(tableXml));
            foreach (XElement tr in trs)
            {
                var row = sheet.CreateRow(rowNumber++);

                List<XElement> ths = GetThs(tr);

                for (int i = 0; i < ths.Count; i++)
                {
                    string val = GetThValue(ths[i]);
                    row.CreateCell(i).SetCellValue(val);
                }

                List<XElement> tds = GetTds(tr);
                for (int i = 0; i < tds.Count; i++)
                {
                    string val = tds[i].Value;
                    if (val != null)
                    {
                        double dummyDouble;
                        DateTime dummyDateTime;
                        if (double.TryParse(val, System.Globalization.NumberStyles.Any, null, out dummyDouble))
                        {
                            row.CreateCell(i).SetCellValue(dummyDouble);
                        }
                            //else if (DateTime.TryParse(val, out dummyDateTime))
                            //{
                            //    row.CreateCell(i).SetCellValue(dummyDateTime); // fo not work well, should be tested more
                            //}
                        else
                        {
                            row.CreateCell(i).SetCellValue(val);
                        }
                    }
                    else
                    {
                        row.CreateCell(i).SetCellValue("");
                    }
                }
            }

            //    //Set values for the cells
            //    //row.CreateCell(0).SetCellValue(product.ProductId);
            //    //row.CreateCell(1).SetCellValue(product.Name);
            //    //row.CreateCell(2).SetCellValue(product.UnitPrice.ToString());
            //    //row.CreateCell(3).SetCellValue(product.UnitsInStock.GetValueOrDefault().ToString());
            //}

            //Write the workbook to a memory stream
            MemoryStream output = new MemoryStream();
            workbook.Write(output);

            //Return the result to the end user

            lastFileContentResult = File(output.ToArray(), //The binary data of the XLS file
                "application/vnd.ms-excel", //MIME type of Excel files
                "GridExcelExport.xls");
            //Suggested file name in the "Save as" dialog which will be displayed to the end user
        }

        public byte[] DownloadPurchaseOrderDetailsReportAsPdf(int? purchaseOrderHeaderId)
        {
            JsonSerializerSettings jss = new JsonSerializerSettings();

            jss.MaxDepth = 3;
            jss.PreserveReferencesHandling = PreserveReferencesHandling.All;
            jss.ReferenceLoopHandling = ReferenceLoopHandling.Serialize;

            ContextFactory.Current.Configuration.ProxyCreationEnabled = false;

            List<PurchaseOrderDetail> allPod = ContextFactory.Current.PurchaseOrderDetails
                .Include(pod => pod.PurchaseOrderHeader.Employee)
                .Include(pod => pod.PurchaseOrderHeader.Vendor)
                .Include(pod => pod.UnitMeasure)
                .Include(pi => pi.Product.ProductCategory)
                .Include(pi => pi.Product.UnitMeasure)
                .Where(pod => pod.PurchaseOrderId == purchaseOrderHeaderId)
                .ToList();


            List<PurchaseOrderDetail> nonEmptyOrders =
                allPod.Where(pod => pod.OrderQuantity.GetValueOrDefault() != 0).ToList();

            string serializedEntities = JsonConvert.SerializeObject(nonEmptyOrders, jss);

            var serializedReport = SerializeReport(new RecipiesReports.PurchaseOrderDetailsReport());


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(" http://recipiesservices.apphb.com/");

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                string url = "api/report";

                string formattedData = string.Format("{0}EscapeSequence{1}", serializedReport, serializedEntities);

                HttpResponseMessage response = client.PostAsJsonAsync(url, formattedData).Result;

                string rerr = response.Content.ReadAsStringAsync().Result;
                if (response.IsSuccessStatusCode)
                {
                    string pdfString = response.Content.ReadAsAsync<string>().Result;

                    byte[] resultBytes = Convert.FromBase64String(pdfString);

                    return resultBytes;
                }
            }
            return new byte[1];
        }


        public string DownloadReportSerialization(string reportSerializationBytes, string reportDataSource)
        {
            ReportProcessor reportProcessor = new ReportProcessor();

            var instanceReportSource = new Telerik.Reporting.InstanceReportSource();
            Telerik.Reporting.Report salesOrderDetailsReport =
                DeserializeReport(reportSerializationBytes);

            List<PurchaseOrderDetail> serDataSource =
                JsonConvert.DeserializeObject<List<PurchaseOrderDetail>>(reportDataSource);

            salesOrderDetailsReport.DataSource = serDataSource;

            instanceReportSource.ReportDocument = salesOrderDetailsReport;

            RenderingResult result = reportProcessor.RenderReport("PDF", instanceReportSource, null);

            return Convert.ToBase64String(result.DocumentBytes);
            ;
        }


        public string SerializeReport(Telerik.Reporting.Report reportToSerialize)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                Telerik.Reporting.XmlSerialization.ReportXmlSerializer xmlSerializer =
                    new Telerik.Reporting.XmlSerialization.ReportXmlSerializer();

                xmlSerializer.Serialize(ms, reportToSerialize);

                byte[] result = ms.ToArray();

                string resultString = Convert.ToBase64String(result);

                return resultString;
            }
        }

        public Telerik.Reporting.Report DeserializeReport(string reportString)
        {
            byte[] reportBytes = Convert.FromBase64String(reportString);

            System.Xml.XmlReaderSettings settings = new System.Xml.XmlReaderSettings();
            settings.IgnoreWhitespace = true;

            using (MemoryStream ms = new MemoryStream(reportBytes))
            {
                Telerik.Reporting.XmlSerialization.ReportXmlSerializer xmlSerializer =
                    new Telerik.Reporting.XmlSerialization.ReportXmlSerializer();

                Telerik.Reporting.Report report = (Telerik.Reporting.Report)
                    xmlSerializer.Deserialize(ms);

                return report;
            }
        }


        public ActionResult DownloadPurchaseOrder(int? purchaseOrderHeaderId)
        {
            //PurchaseOrderHeader purchaseOrder =
            //    ContextFactory.GetContextPerRequest()
            //        .PurchaseOrderHeaders.FirstOrDefault(p => p.PurchaseOrderId == purchaseOrderHeaderId);

            //ReportProcessor reportProcessor = new ReportProcessor();

            //var instanceReportSource = new Telerik.Reporting.InstanceReportSource();
            //RecipiesReports.PurchaseOrderDetailsReport salesOrderDetailsReport =
            //    new RecipiesReports.PurchaseOrderDetailsReport();

            //List<PurchaseOrderDetail> nonEmptyOrders =
            //    purchaseOrder.PurchaseOrderDetails.Where(pod => pod.OrderQuantity.GetValueOrDefault() != 0).ToList();

            //salesOrderDetailsReport.DataSource = nonEmptyOrders;

            //instanceReportSource.ReportDocument = salesOrderDetailsReport;

            ////specify the output format of the produced image.
            //System.Collections.Hashtable deviceInfo =
            //    new System.Collections.Hashtable();

            //RenderingResult result = reportProcessor.RenderReport("IMAGE", instanceReportSource, null);

            //string tempFileName = Path.GetTempFileName();
            //System.IO.File.WriteAllBytes(tempFileName, result.DocumentBytes);



            //string jpegFilePath = ImageHelper.ConvertTiffToJpeg(tempFileName).FirstOrDefault();


            //  http://www.telerik.com/community/forums/reporting/telerik-reporting/out-of-memory-in-azure-websites.aspx


            DownloadPurchaseOrderDetailsReportAsPdf(purchaseOrderHeaderId);

            //string fileName = result.DocumentName + "." + result.Extension;
            // Until solving PDF problem extension will be .jpg
            string fileName = "PurchaseOrder.pdf";

            byte[] documentBytes = DownloadPurchaseOrderDetailsReportAsPdf(purchaseOrderHeaderId);


            return File(documentBytes, "application/pdf", fileName);
        }


        private System.Collections.Generic.List<System.IO.Stream> streams =
            new System.Collections.Generic.List<System.IO.Stream>();

        public bool RenderReport(string reportName)
        {
            Telerik.Reporting.Processing.ReportProcessor reportProcessor =
                new Telerik.Reporting.Processing.ReportProcessor();

            string documentName = "";

            // specify the output format of the produced image.
            System.Collections.Hashtable deviceInfo =
                new System.Collections.Hashtable();

            deviceInfo["OutputFormat"] = "JPEG";

            //Telerik.Reporting.TypeReportSource typeReportSource =
            //             new Telerik.Reporting.TypeReportSource();

            // reportName is the Assembly Qualified Name of the report
            //typeReportSource.TypeName = reportName;

            var instanceReportSource = new Telerik.Reporting.InstanceReportSource();
            RecipiesReports.PurchaseOrderDetailsReport salesOrderDetailsReport =
                new RecipiesReports.PurchaseOrderDetailsReport();


            List<PurchaseOrderDetail> nonEmptyOrders =
                ContextFactory.Current.PurchaseOrderDetails.Where(
                    ppd => ppd.PurchaseOrderHeader.OrderDate > new DateTime(2014, 2, 1)).ToList();


            salesOrderDetailsReport.DataSource = nonEmptyOrders;

            instanceReportSource.ReportDocument = salesOrderDetailsReport;


            bool result = reportProcessor.RenderReport("PDF", instanceReportSource, deviceInfo, this.CreateStream,
                out documentName);
            this.CloseStreams();

            return result;
        }

        private void CloseStreams()
        {
            foreach (System.IO.Stream stream in this.streams)
            {
                stream.Close();
            }
            this.streams.Clear();
        }

        private System.IO.Stream CreateStream(string name, string extension, System.Text.Encoding encoding,
            string mimeType)
        {
            string path = System.IO.Path.GetTempPath();
            string filePath = System.IO.Path.Combine(path, "name" + "." + extension);

            System.IO.FileStream fs = new System.IO.FileStream(filePath, System.IO.FileMode.Create);
            this.streams.Add(fs);
            return fs;
        }
    }
}