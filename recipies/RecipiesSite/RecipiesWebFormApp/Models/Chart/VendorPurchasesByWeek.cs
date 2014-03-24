using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagementMVC.Models.Chart
{
    public class VendorPurchasesByWeek
    {
        public int Week { get; set; }
        public double VendorValue { get; set; }

        public double VendorValue2 { get; set; }

        public DateTime WeekDate { get; set; }
    }
}