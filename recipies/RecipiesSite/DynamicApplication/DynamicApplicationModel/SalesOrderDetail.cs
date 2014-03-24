//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RecipiesModelNS
{
    using System;
    using System.Collections.Generic;
    
    public partial class SalesOrderDetail
    {
        public int SalesOrderDetailId { get; set; }
        public Nullable<int> SalesOrderHeaderId { get; set; }
        public Nullable<int> RecipeId { get; set; }
        public Nullable<double> OrderQuantity { get; set; }
        public Nullable<decimal> UnitPrice { get; set; }
        public Nullable<double> UnitPriceDiscount { get; set; }
        public double LineTotal { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedByUser { get; set; }
    
        public virtual Recipe Recipe { get; set; }
        public virtual SalesOrderHeader SalesOrderHeader { get; set; }
    }
}
