using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InventoryManagementMVC.Models.Chart;
using RecipiesModelNS;
using System.Data.Entity;
using DevTrends.MvcDonutCaching;
using InventoryManagementMVC.Models.Chart;
using System.Globalization;
using System.Diagnostics;
using System.Dynamic;
using System.Data;
using InventoryManagementMVC.Helpers;
using System.Threading.Tasks;

namespace InventoryManagementMVC.Controllers
{
    public class ChartController : ControllerBase
    {
        private int maxXLabelTextLenght = 10;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dateEncoded"int the form of 2013-14></param>
        /// <returns></returns>
        public string GetWeekString(string dateEncoded)
        {
            string[] dates = dateEncoded.Split('-');

            int year = int.Parse(dates[0]);
            int numberOfMonths = int.Parse(dates[1]);

            DateTime startDate = new DateTime(year, 1, 1);

            DateTime correctDate = DateTime.Now;

            for (int i = 0; i < CultureInfo.InvariantCulture.Calendar.GetDaysInYear(year); i++)
            {
                DateTime dayToCheck = startDate.AddDays(i);
                if (numberOfMonths.ToString() == ControllerHelper.GetIso8601WeekOfYear(dayToCheck))
                {
                    correctDate = dayToCheck;
                }
            }

            DateTime lastMonday = ControllerHelper.GetLastMonday(correctDate);
            DateTime nextSunday = ControllerHelper.GetNextSunday(correctDate);

            string result = string.Format("{0:dd/MM/yyyy}-{1:dd/MM/yyyy}", lastMonday, nextSunday);
            return result;

            //string res = ControllerHelper.GetWeekStringFromWeekNumber(week);
            //return res;
        }

        public void VendorPurchasesByWeek( List<string> weeksResult,List<Dictionary<int, double>> listResult)
        {
            try
            {
                List<PurchaseOrderDetail> pods =
                    ContextFactory.GetContextPerRequest()
                        .PurchaseOrderDetails.Include(p => p.PurchaseOrderHeader).ToList().Where(
                            pod => pod.PurchaseOrderHeader.StatusId == (int) PurchaseOrderStatusEnum.Completed).ToList();
            
                var grouping =
                    pods.OrderBy(pod => pod.PurchaseOrderHeader.ShipDate)
                        .GroupBy(
                            pod => pod.PurchaseOrderHeader.ShipDate.GetValueOrDefault().Year * 100 + int.Parse(
                                ControllerHelper.GetIso8601WeekOfYear(
                                    pod.PurchaseOrderHeader.ShipDate.GetValueOrDefault()))).ToList();


                List<Vendor> allVendors = ContextFactory.Current.Vendors.ToList();

                Vendor fakeTotalVendor = new Vendor()
                {
                    Name = "Total All Vendors",
                    VendorId = 0
                };

                List<string> weeks = new List<string>();

                List<Dictionary<int, double>> list = new List<Dictionary<int, double>>();

                foreach (var item in grouping)
                {
                    weeks.Add(string.Format("{0}-{1}", item.Key/100, item.Key % 100));


                    Dictionary<int, double> entry = new Dictionary<int, double>();
                  
                   

                    entry.Add(fakeTotalVendor.VendorId,
                        Math.Round(item.Sum(pod => pod.LineTotal), 3));

                    foreach (Vendor ven in allVendors)
                    {
                        entry.Add(ven.VendorId,
                            Math.Round(
                                item.Where(pod => pod.PurchaseOrderHeader.VendorId == ven.VendorId)
                                    .Sum(pod => pod.LineTotal), 3));
                    }
                    list.Add(entry);
                }
                weeksResult.AddRange(weeks);
                listResult.AddRange(list);
                return;
            }
               
            catch (Exception ex)
            {
                Debugger.Break();
            }
            throw new ApplicationException();
        }



        public ActionResult ProductsCountByCategory()
        {
            var pc = ContextFactory.Current.ProductCategories.Include(c => c.Products).ToList()
                .Select(
                    cat =>
                        new ProductsPerCategory
                        {
                            CategoryName =
                                cat.Name.Substring(0,
                                    cat.Name.Length >= maxXLabelTextLenght ? maxXLabelTextLenght : cat.Name.Length),
                            //CategoryName = cat.Name,
                            ProductCount = cat.Products.Count,
                            ProductValue =
                                (decimal)
                                    (cat.Products.Count != 0 ? Math.Round(cat.Products.Sum(p => p.StockValue), 3) : 0)
                        })
                .OrderByDescending(res => res.ProductCount).Where(ppc => ppc.ProductCount != 0)
                .ToList();


            return Json(pc);
        }

        public ActionResult GpPerDayLastDays()
        {
            int lastNdays = 15;

            List<GpPerDay> list = new List<GpPerDay>();
            
            for (int i = lastNdays; i >= 0; i--)
            {
                DateTime fromDate = DateTime.Now.Date.AddDays(-i * 7);
                DateTime toDate = DateTime.Now.Date.AddDays((-i + 1) * 7);
                double sales =
                    SalesOrderHeader.GetSalesOrderHeadersInPeriod(fromDate, toDate, SalesOrderStatusEnum.Approved)
                        .Sum(soh => soh.SalesOrderDetails.Sum(sod => sod.LineTotal));
                double purchases =
                    (double)
                        PurchaseOrderHeader.GetPurchaseOrderDetailsInPeriod(fromDate, toDate,
                            PurchaseOrderStatusEnum.Completed, ProductCategory.GetCategoriesToExcludeFromGP())
                            .Sum(poh => poh.LineTotal);
                double dayGp = sales - purchases;

                GpPerDay gh = new GpPerDay()
                {
                    Days = string.Format("{0}-{1}", fromDate.Year, ControllerHelper.GetIso8601WeekOfYear(fromDate)),
                    DayGp = Math.Round(dayGp, 3)
                };
                list.Add(gh);
            }

            return Json(list);
        }

        public ActionResult RecipeByGpDescending()
        {
            List<RecipeByGP> list =
                ContextFactory.Current.Recipes.OrderByDescending(r => r.GrossProfit)
                    .Select(r => new RecipeByGP() { RecipeName = r.Name, GP = r.GrossProfit })
                    .ToList();

            return Json(list);
        }

        public ActionResult LowProducts()
        {
            var list = ContextFactory.GetContextPerRequest().Products
                .Where(product => product.UnitsInStock <= product.ReorderLevel)
                .OrderByDescending(product => product.ReorderLevel)
                .Select(
                    p =>
                        new LowProduct
                        {
                            UnitsInStock = p.UnitsInStock,
                            UnitsOnOrder = p.UnitsOnOrder,
                            ReorderLevel = p.ReorderLevel,
                            ProductName = p.Name.Substring(0, maxXLabelTextLenght)
                        }).Take(10).ToList();

            return Json(list);
        }

        public ActionResult TotalPosValuePerVendor()
        {
            List<PurchaseOrderHeader> allPos = ContextFactory.GetContextPerRequest().PurchaseOrderHeaders.ToList();
            List<Vendor> allVendors = ContextFactory.GetContextPerRequest().Vendors.ToList();
            List<TotalPoByVendor> list = allVendors
                .Select(
                    vendor =>
                        new TotalPoByVendor
                        {
                            VendorName =
                                vendor.Name.Substring(0,
                                    vendor.Name.Length >= maxXLabelTextLenght ? maxXLabelTextLenght : vendor.Name.Length),
                            PoTotalValue = allPos.Where(pod => pod.VendorId == vendor.VendorId)
                                .Sum(pod => pod.TotalDue)
                        }).ToList();

            list = list.OrderByDescending(l => l.PoTotalValue).ToList();
            return Json(list);
        }
    }
}