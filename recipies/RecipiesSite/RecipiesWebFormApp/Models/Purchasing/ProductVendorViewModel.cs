using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using InventoryManagementMVC.DataAnnotations;
using RecipiesModelNS;

namespace InventoryManagementMVC.Models
{
    public class ProductVendorViewModel
    {
        [Key]
        public int ProductVendorId { get; set; }

        [Relation(EntityType = typeof (Product), DataFieldValue = "ProductId", DataFieldText = "Name")]
        [Display(Name = "Product")]
        public int? ProductId { get; set; }

        [Relation(EntityType = typeof (UnitMeasure), DataFieldValue = "UnitMeasureId", DataFieldText = "Name")]
        [Display(Name = "Unit Measure")]
        public int? UnitMeasureId { get; set; }

        [Relation(EntityType = typeof (Vendor), DataFieldValue = "VendorId", DataFieldText = "Name")]
        [Display(Name = "Vendor")]
        public int? VendorId { get; set; }

        [Description("The average span of time (in days) between placing an order with the vendor and receiving the purchased product.")]
        public double? AverageLeadTime { get; set; }

        [Display(
            Description =
                "The average span of time (in days) between placing an order with the vendor and receiving the purchased product."
            )]
        public decimal? StandardPrice { get; set; }

        public decimal? LastReceiptCost { get; set; }

        public DateTime? LastReceiptDate { get; set; }

        public double? MinOrderQuantity { get; set; }

        public double? MaxOrderQuantity { get; set; }

        public double? OnOrderQuantity { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string ModifiedByUser { get; set; }

        public ProductVendorViewModel ConvertFromEntity(ProductVendor entity)
        {
            AverageLeadTime = entity.AverageLeadTime;
            LastReceiptCost = entity.LastReceiptCost;
            LastReceiptDate = entity.LastReceiptDate;
            MaxOrderQuantity = entity.MaxOrderQuantity;
            MinOrderQuantity = entity.MinOrderQuantity;
            ModifiedByUser = entity.ModifiedByUser;
            ModifiedDate = entity.ModifiedDate;
            OnOrderQuantity = entity.OnOrderQuantity;
            ProductId = entity.ProductId;
            ProductVendorId = entity.ProductVendorId;
            StandardPrice = entity.StandardPrice;
            UnitMeasureId = entity.UnitMeasureId;
            VendorId = entity.VendorId;

            return this;
        }

        public ProductVendor ConvertToEntity(ProductVendor entity)
        {
            entity.AverageLeadTime = AverageLeadTime;
            entity.LastReceiptCost = LastReceiptCost;
            entity.LastReceiptDate = LastReceiptDate;
            entity.MaxOrderQuantity = MaxOrderQuantity;
            entity.MinOrderQuantity = MinOrderQuantity;
            entity.ModifiedByUser = ModifiedByUser;
            entity.ModifiedDate = ModifiedDate;
            entity.OnOrderQuantity = OnOrderQuantity;
            entity.ProductId = ProductId;
            entity.ProductVendorId = ProductVendorId;
            entity.StandardPrice = StandardPrice;
            entity.UnitMeasureId = UnitMeasureId;
            entity.VendorId = VendorId;

            return entity;
        }
    }
}