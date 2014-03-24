using InventoryManagementMVC.DataAnnotations;
using RecipiesModelNS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InventoryManagementMVC.Models.Purchasing
{
    public class PurchaseOrderHeaderViewModel
    {
        [Key]
        public int PurchaseOrderHeaderId { get; set; }

        [Relation(EntityType = typeof (PurchaseOrderStatu), DataFieldValue = "PurchaseOrderStatusId",
            DataFieldText = "Name")]
        [Display(Name = "Status")]
        public int? StatusId { get; set; }

        [Relation(EntityType = typeof (Employee), DataFieldValue = "EmployeeId", DataFieldText = "FirstName")]
        [Display(Name = "Employee")]
        public int? EmployeeId { get; set; }

        [Relation(EntityType = typeof (Vendor), DataFieldValue = "VendorId", DataFieldText = "Name")]
        [Display(Name = "Vendor")]
        public int? VendorId { get; set; }

        [Relation(EntityType = typeof (ShipMethod), DataFieldValue = "ShipMethodId", DataFieldText = "Name")]
        [Display(Name = "Ship Method")]
        public int? ShipMethodId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime? OrderDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime? ShipDate { get; set; }

        [ReadOnly(true)]
        public decimal? SubTotal { get; set; }

        public decimal? VAT { get; set; }

        public decimal? Freight { get; set; }

        [ReadOnly(true)]
        public decimal? TotalDue { get; set; }

        [StringLength(1000)]
        public string InvoiceNumber { get; set; }

        [StringLength(4000)]
        public string Notes { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string ModifiedByUser { get; set; }

        public static PurchaseOrderHeaderViewModel ConvertFromPurchaseOrderHeaderEntity(PurchaseOrderHeader pohEntity,
            PurchaseOrderHeaderViewModel pohViewModel)
        {
            pohViewModel.EmployeeId = pohEntity.EmployeeId;
            pohViewModel.Freight = pohEntity.Freight;
            pohViewModel.InvoiceNumber = pohEntity.InvoiceNumber;
            pohViewModel.ModifiedByUser = pohEntity.ModifiedByUser;
            pohViewModel.ModifiedDate = pohEntity.ModifiedDate;
            pohViewModel.Notes = pohEntity.Notes;
            pohViewModel.OrderDate = pohEntity.OrderDate;
            pohViewModel.PurchaseOrderHeaderId = pohEntity.PurchaseOrderId;
            pohViewModel.ShipMethodId = pohEntity.ShipMethodId;
            pohViewModel.ShipDate = pohEntity.ShipDate;
            pohViewModel.StatusId = pohEntity.StatusId;
            //pohViewModel.SubTotal = pohEntity.SubTotal;

            pohViewModel.SubTotal = (decimal)pohEntity.PurchaseOrderDetails.Sum(d => d.LineTotal);

          
            pohViewModel.VAT = pohEntity.VAT;
            pohViewModel.VendorId = pohEntity.VendorId; 
            
            //((isnull([SubTotal],(0))+isnull([VAT],(0)))+isnull([Freight],(0)))
            pohViewModel.TotalDue = pohViewModel.SubTotal + pohViewModel.VAT + pohViewModel.Freight;
            //pohViewModel.TotalDue = pohEntity.TotalDue;

            return pohViewModel;
        }

        public static PurchaseOrderHeader ConvertToPurchaseOrderHeaderEntity(PurchaseOrderHeaderViewModel pohViewModel,
            PurchaseOrderHeader pohEntity)
        {
            pohEntity.EmployeeId = pohViewModel.EmployeeId;
            pohEntity.Freight = pohViewModel.Freight;
            pohEntity.InvoiceNumber = pohViewModel.InvoiceNumber;
            pohEntity.ModifiedByUser = pohViewModel.ModifiedByUser;
            pohEntity.ModifiedDate = pohViewModel.ModifiedDate;
            pohEntity.Notes = pohViewModel.Notes;
            pohEntity.OrderDate = pohViewModel.OrderDate;
            if (pohViewModel.OrderDate.HasValue)
            {
                pohEntity.OrderDate = pohViewModel.OrderDate.Value.Date;
            }

            pohEntity.PurchaseOrderId = pohViewModel.PurchaseOrderHeaderId;
            pohEntity.ShipMethodId = pohViewModel.ShipMethodId;
            pohEntity.ShipDate = pohViewModel.ShipDate;
            if (pohViewModel.ShipDate.HasValue)
            {
                pohEntity.ShipDate = pohViewModel.ShipDate.Value.Date;
            }
            pohEntity.StatusId = pohViewModel.StatusId;
            //pohEntity.SubTotal = pohViewModel.SubTotal; // All fields that are read obly should not be set through model !!!
            //pohEntity.TotalDue = pohViewModel.TotalDue;
            pohEntity.VAT = pohViewModel.VAT;
            pohEntity.VendorId = pohViewModel.VendorId;

            return pohEntity;
        }
    }
}