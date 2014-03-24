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
    
    public partial class UnitMeasure
    {
        public UnitMeasure()
        {
            this.Products = new HashSet<Product>();
            this.ProductVendors = new HashSet<ProductVendor>();
            this.PurchaseOrderDetails = new HashSet<PurchaseOrderDetail>();
            this.Wastes = new HashSet<Waste>();
        }
    
        public int UnitMeasureId { get; set; }
        public string Name { get; set; }
        public Nullable<bool> IsBaseUnit { get; set; }
        public Nullable<int> BaseUnitId { get; set; }
        public Nullable<double> BaseUnitFactor { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedByUser { get; set; }
    
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<ProductVendor> ProductVendors { get; set; }
        public virtual ICollection<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
        public virtual ICollection<Waste> Wastes { get; set; }
    }
}
