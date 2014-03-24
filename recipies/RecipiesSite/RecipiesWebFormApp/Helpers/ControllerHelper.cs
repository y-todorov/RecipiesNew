using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using InventoryManagementMVC.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using RecipiesModelNS;
using System;
using System.Globalization;

namespace InventoryManagementMVC.Helpers
{
    public static class ControllerHelper
    {
        // This presumes that weeks start with Monday.
        // Week 1 is the 1st week of the year with a Thursday in it.
        public static string GetIso8601WeekOfYear(DateTime time)
        {
            // Seriously cheat.  If its Monday, Tuesday or Wednesday, then it'll 
            // be the same week# as whatever Thursday, Friday or Saturday are,
            // and we always get those right
            //DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time);
            //if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            //{
            //    time = time.AddDays(3);
            //}

            // Return the week of our adjusted day
            int weekOfYear = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstDay,
                DayOfWeek.Monday); 
            //return weekOfYear;

            DateTime lastMonday = GetLastMonday(time);
            DateTime nextSunday = GetNextSunday(time);

            //string result = string.Format("{0} ({1:dd/MM/yyyy}-{2:dd/MM/yyyy})", weekOfYear, lastMonday, nextSunday);
            string result = weekOfYear.ToString();
            return result;
        }

        public static string GetWeekStringFromWeekNumber(int weekNumber)
        {
            DateTime time = (new DateTime(2013, 1, 1)).AddDays(7 * weekNumber); // assume we are in 2013

            DateTime lastMonday = GetLastMonday(time);
            DateTime nextSunday = GetNextSunday(time);

            string result = string.Format("{0:dd/MM/yyyy}-{1:dd/MM/yyyy}", lastMonday, nextSunday);
            return result;
        }

        public static DateTime GetLastMonday(DateTime time)
        {
            for (int i = 0; i < 7; i++)
            {
                if (time.Date.AddDays(-i).DayOfWeek == DayOfWeek.Monday)
                {
                    return time.Date.AddDays(-i);
                }
            }
            return DateTime.MinValue;
        }

        public static DateTime GetNextSunday(DateTime time)
        {
            for (int i = 0; i < 7; i++)
            {
                if (time.Date.AddDays(i).DayOfWeek == DayOfWeek.Sunday)
                {
                    return time.Date.AddDays(i);
                }
            }
            return DateTime.MinValue;
        }

        public static void PopulateUnitMeasures(ViewDataDictionary viewData)
        {
            List<UnitMeasure> unitMeasures = ContextFactory.Current.UnitMeasures.ToList();

            viewData["unitMeasures"] = unitMeasures;
            viewData["defaultUnitMeasure"] = unitMeasures.FirstOrDefault();
        }

        public static void PopulateCategories(ViewDataDictionary viewData)
        {
            List<ProductCategory> categories = ContextFactory.Current.ProductCategories.ToList();

            viewData["categories"] = categories;
            viewData["defaultCategory"] = categories.FirstOrDefault();
        }

        public static void PopulateStores(ViewDataDictionary viewData)
        {
            //List<Store> stores = ContextFactory.Current.Stores.ToList();
            var stores = ContextFactory.Current.Stores.ToList();


            viewData["stores"] = stores;
            viewData["defaultStore"] = stores.FirstOrDefault();
        }

        public static void PopulatePurchaseOrderHeaders(ViewDataDictionary viewData)
        {
            List<PurchaseOrderHeader> purchaseOrderHeaders = ContextFactory.Current.PurchaseOrderHeaders.ToList();

            viewData["purchaseOrderHeaders"] = purchaseOrderHeaders;
            viewData["defaultPurchaseOrderHeader"] = purchaseOrderHeaders.FirstOrDefault();
        }

        public static void PopulateProducts(ViewDataDictionary viewData)
        {
            List<Product> products = ContextFactory.Current.Products.ToList();

            viewData["products"] = products;
            viewData["defaultProduct"] = products.FirstOrDefault();
        } 

        


    }
}
