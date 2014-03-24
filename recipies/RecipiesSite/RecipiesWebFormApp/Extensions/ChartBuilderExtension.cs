using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using InventoryManagementMVC.Models;
using Kendo.Mvc.UI;
using Kendo.Mvc.UI.Fluent;
using System.Web;
using System.Web.Mvc;
using System.Web.Security.AntiXss;
using System.Web.Util;
using System.Diagnostics;
using InventoryManagementMVC.DataAnnotations;
using RecipiesModelNS;
using System.Collections;
using System.Collections.Generic;
using InventoryManagementMVC.Controllers;

namespace InventoryManagementMVC.Extensions
{
    public static class ChartBuilder
    {
        public static ChartBuilder<T> AddVendorsValuePerWeekOptions<T>(this ChartBuilder<T> builder) where T : class
        {
            ChartController cc = new ChartController();
            List<string> weeks = new List<string>();

            List<Dictionary<int, double>> list = new List<Dictionary<int, double>>();
            cc.VendorPurchasesByWeek(weeks, list);
            

            List<Vendor> vendors = ContextFactory.Current.Vendors.ToList();

            Vendor fakeTotalVendor = new Vendor()
            {
                Name = "Total All Vendors",
                VendorId = 0
            };
            vendors.Insert(0, fakeTotalVendor);


            Stopwatch sw = new Stopwatch();
            sw.Start();

            builder.Series(series =>
            { 
                bool isVisible = true;
                int counter = 0;
                foreach (Vendor vendor in vendors)
                {
                    List<double> vals = list.Select(dic => dic[vendor.VendorId]).ToList();
                    series.Line(vals)
                        .Name(vendor.Name)
                        .Labels(l => l.Format("{0:C3}").Visible(true))
                        .Axis("Value")
                        .Visible(isVisible);

                        //.Tooltip(tp => tp.Template("Time interval:<label id=\"lblVendorPO\"></label> <script> document.getElementById(\"lblVendorPO\").innerHTML = getWeekString(#= category #)</script>Vendor: #= series.name # Value: #= value #"));
                    counter++;
                    if (counter >= 3)
                    {
                        isVisible = false;
                    }
                    // only the first 3 will be visible by default
                }
            });

            builder.CategoryAxis(axis => axis
                .Categories(weeks).Labels(labels => labels.Rotation(90).Template("#= value #"))
               
                .AxisCrossingValue(32, 32, 0)
                .Justify(true)
                );


            sw.Stop();
            long mils = sw.ElapsedMilliseconds;

            return builder;
        }
    }
}