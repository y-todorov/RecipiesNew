using InventoryManagementMVC.DataAnnotations;
using RecipiesModelNS;
using RecipiesWebFormApp.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagementMVC.Models
{
    public class SalesOrderHeaderViewModel
    {
        [Key]
        public int SalesOrderHeaderId { get; set; }

        [Relation(EntityType = typeof(Customer), DataFieldValue = "CustomerID",
            DataFieldText = "ContactName")]
        [Display(Name = "Customer")]
        public int? CustomerId { get; set; }

        [Relation(EntityType = typeof(SalesOrderStatu), DataFieldValue = "SalesOrderStatusId",
            DataFieldText = "Name")]
        [Display(Name = "Status")]
        public int? StatusId { get; set; }

        [Relation(EntityType = typeof(Employee), DataFieldValue = "EmployeeId", DataFieldText = "FirstName")]
        [Display(Name = "Employee")]
        public int? EmployeeId { get; set; }

        [Relation(EntityType = typeof(PaymentType), DataFieldValue = "PaymentTypeId", DataFieldText = "Name")]
        [Display(Name = "Payment Type")]
        public int? PaymentTypeId { get; set; }

        public string AccountName { get; set; }

        [HiddenInput(DisplayValue = false)]
        public DateTime? OrderDate { get; set; }

        [HiddenInput(DisplayValue = false)]
        public DateTime? RequiredDate { get; set; }

        [Required]
        public DateTime? ShippedDate { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string ShipName { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string ShipAddress { get; set; }

        [ReadOnly(true)]
        [Display(Name = "Production total value")]
        public decimal? ProductionTotalValue { get; set; }

         [ReadOnly(true)]
        public decimal? SubTotal { get; set; }

        public decimal? TaxAmt { get; set; }

        public decimal? Freight { get; set; }

        [ReadOnly(true)]
        public decimal? TotalDue { get; set; }

        [ReadOnly(true)]
        [DisplayFormat(DataFormatString = "{0:P2}")]
        public double? GrossProfit { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string ModifiedByUser { get; set; }

        public List<PurchaseOrderDetailViewModel> PurchaseOrderDetailViewModels { get; set; }


        public SalesOrderHeaderViewModel ConvertFromEntity(SalesOrderHeader entity)
        {
            AccountName = entity.AccountName;
            CustomerId = entity.CustomerId;
            EmployeeId = entity.EmployeeId;
            ModifiedByUser = entity.ModifiedByUser;
            ModifiedDate = entity.ModifiedDate;
            OrderDate = entity.OrderDate;
            PaymentTypeId = entity.PaymentTypeId;
            RequiredDate = entity.RequiredDate;
            SalesOrderHeaderId = entity.SalesOrderHeaderId;
            ShipAddress = entity.ShipAddress;
            ShipName = entity.ShipName;
            ShippedDate = entity.ShippedDate;
            StatusId = entity.StatusId;
            //SubTotal = entity.SubTotal;
            SubTotal = (decimal)entity.SalesOrderDetails.Sum(d => d.LineTotal);

            TaxAmt = entity.TaxAmt;
            Freight = entity.Freight;
            // (isnull(([SubTotal]+[TaxAmt])+[Freight],(0)))
            TotalDue = SubTotal.GetValueOrDefault() + TaxAmt.GetValueOrDefault() + Freight.GetValueOrDefault();

            ProductionTotalValue = entity.SalesOrderDetails.Sum(d =>
            {
                SalesOrderDetailViewModel sodvm = new SalesOrderDetailViewModel();
                sodvm.ConvertFromEntity(d);
                return sodvm.ProductionTotalValue;
            });

            GrossProfit = ModelHelper.GetGp((double)ProductionTotalValue.GetValueOrDefault(), (double)SubTotal.GetValueOrDefault());

            return this;
        }

        public SalesOrderHeader ConvertToEntity(SalesOrderHeader entity)
        {
            entity.AccountName = AccountName;
            entity.CustomerId = CustomerId;
            entity.EmployeeId = EmployeeId;
            entity.ModifiedByUser = ModifiedByUser;
            entity.ModifiedDate = ModifiedDate;
            entity.OrderDate = OrderDate;
            entity.PaymentTypeId = PaymentTypeId;
            entity.RequiredDate = RequiredDate;
            entity.SalesOrderHeaderId = SalesOrderHeaderId;
            entity.ShipAddress = ShipAddress;
            entity.ShipName = ShipName;
            entity.ShippedDate = ShippedDate;
            entity.StatusId = StatusId;
            entity.SubTotal = SubTotal;
            entity.TaxAmt = TaxAmt;
            entity.Freight = Freight;


            return entity;
        }
    }
}