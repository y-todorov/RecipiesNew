using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagementMVC.Models.Chart
{
    public class LowProduct
    {
        public double? UnitsInStock { get; set; }
        public double? UnitsOnOrder { get; set; }
        public double? ReorderLevel { get; set; }

        public string ProductName { get; set; }
    }
}