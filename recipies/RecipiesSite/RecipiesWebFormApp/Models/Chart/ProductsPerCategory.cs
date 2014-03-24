using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagementMVC.Models.Chart
{
    public class ProductsPerCategory
    {
        public string CategoryName { get; set; }

        public int ProductCount { get; set; }

        public decimal ProductValue { get; set; }
    }
}