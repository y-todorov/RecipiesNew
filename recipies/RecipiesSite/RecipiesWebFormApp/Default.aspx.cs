using RecipiesModelNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;

namespace RecipiesWebFormApp
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int maxXLabelTextLenght = 10;

                rhcLast10ModifiedProducts.DataSource = ContextFactory.GetContextPerRequest().Products
                    .OrderByDescending(pr => pr.ModifiedDate)
                    .Select(
                        p =>
                            new
                            {
                                p.UnitsInStock,
                                p.UnitsOnOrder,
                                p.ReorderLevel,
                                Name = p.Name.Substring(0, maxXLabelTextLenght)
                            }).Take(10).ToList();

                rhcProductsCountByCategory.DataSource = ContextFactory.GetContextPerRequest().ProductCategories.Take(20)
                    .Select(
                        cat =>
                            new
                            {
                                CategoryName = cat.Name.Substring(0, maxXLabelTextLenght),
                                ProductCount = cat.Products.Count,
                                ProductValue =
                                    cat.Products.Count != 0 ? Math.Round(cat.Products.Sum(p => p.StockValue), 3) : 0
                            })
                    .OrderByDescending(res => res.ProductCount)
                    .ToList();

                rhcProductsForReorder.DataSource = ContextFactory.GetContextPerRequest().Products
                    .Where(product => product.UnitsInStock <= product.ReorderLevel)
                    .OrderByDescending(product => product.ReorderLevel)
                    .Select(
                        p =>
                            new
                            {
                                p.UnitsInStock,
                                p.UnitsOnOrder,
                                p.ReorderLevel,
                                Name = p.Name.Substring(0, maxXLabelTextLenght)
                            }).Take(10).ToList();

                rhcMostExpensiveProducts.DataSource = ContextFactory.GetContextPerRequest()
                    .Products.OrderByDescending(product => product.UnitPrice)
                    .Select(p => new {p.UnitPrice, Name = p.Name.Substring(0, maxXLabelTextLenght)})
                    .Take(10).ToList();

                rhcGpRecipies.DataSource =
                    ContextFactory.GetContextPerRequest().Recipes.OrderByDescending(r => r.GrossProfit) //.Take(20)
                        .Select(recipie => new
                        {
                            recipie.Name,
                            GrossProfit = recipie.GrossProfit,
                            SellValuePerPortion = recipie.SellValuePerPortion
                        })
                        .ToList();


                List<GpHelper> list = new List<GpHelper>();
                for (int i = 29; i >= 0; i--)
                {
                    DateTime date = DateTime.Now.Date.AddDays(-i);
                    double sales =
                        SalesOrderHeader.GetSalesOrderHeadersInPeriod(date, date, SalesOrderStatusEnum.Approved)
                            .Sum(soh => soh.SalesOrderDetails.Sum(sod => sod.LineTotal));
                    double purchases =
                        (double)
                            PurchaseOrderHeader.GetPurchaseOrderDetailsInPeriod(date, date,
                                PurchaseOrderStatusEnum.Completed, ProductCategory.GetCategoriesToExcludeFromGP())
                                .Sum(poh => poh.LineTotal);
                    double dayGp = sales - purchases;

                    GpHelper gh = new GpHelper() {Days = date.ToString("dd/MM"), DayGp = dayGp};
                    //if (gh.DayGp != 0)
                    {
                        list.Add(gh);
                    }
                }
                //list.Add(new GpHelper() { Dat = DateTime.Now.ToString("dd/MM"), DayGp = 2 });
                //list.Add(new GpHelper() { Dat = DateTime.Now.AddDays(1).ToString("dd/MM"), DayGp = 22 });
                //list.Add(new GpHelper() { Dat = DateTime.Now.AddDays(3).ToString("dd/MM"), DayGp = -3 }); 


                rhcGP.DataSource = list;

                //DateTime defaultDate = new DateTime(2000, 1, 1);
                //rhcGP.DataSource = ContextFactory.GetContextPerRequest().PurchaseOrderHeaders.GroupBy(p => p.OrderDate.GetValueOrDefault(defaultDate)).Select(p => new { Date = p.Key, DayGp = p.Sum(poh => poh.TotalDue) });
            }
        }
    }

    public class GpHelper
    {
        public string Days { get; set; }
        public double DayGp { get; set; }
    }
}