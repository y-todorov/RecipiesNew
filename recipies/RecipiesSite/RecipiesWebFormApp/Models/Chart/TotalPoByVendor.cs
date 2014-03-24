using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagementMVC.Models.Chart
{
    public class TotalPoByVendor
    {
        public string VendorName { get; set; }

        public decimal? PoTotalValue { get; set; }
    }
}