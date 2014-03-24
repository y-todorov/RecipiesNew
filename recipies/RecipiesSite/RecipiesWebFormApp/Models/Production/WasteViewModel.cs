using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using InventoryManagementMVC.DataAnnotations;
using RecipiesModelNS;

namespace InventoryManagementMVC.Models
{
    public class WasteViewModel
    {
        [Key]
        public int WasteId { get; set; }

        [Relation(EntityType = typeof(UnitMeasure), DataFieldValue = "UnitMeasureId", DataFieldText = "Name")]
        [Display(Name = "Unit Measure")]
        [ReadOnly(true)]
        public int? UnitMeasureId { get; set; } // Check this

        public double? Quantity { get; set; }

        [ReadOnly(true)]
        public decimal WasteValue { get; set; }

        public decimal? UnitPrice { get; set; }
        
        public DateTime? ModifiedDate { get; set; }

        public string ModifiedByUser { get; set; }

        public WasteViewModel ConvertFromEntity(Waste entity)
        {
            Quantity = entity.Quantity;
            UnitMeasureId = entity.UnitMeasureId;
            UnitPrice = entity.UnitPrice;
            WasteId = entity.WasteId;
            WasteValue = (decimal)entity.WasteValue;
            ModifiedDate = entity.ModifiedDate;
            ModifiedByUser = entity.ModifiedByUser;

            return this;
        }

        public Waste ConvertToEntity(Waste entity)
        {
            entity.Quantity = Quantity;
            entity.UnitMeasureId = UnitMeasureId;
            entity.UnitPrice = UnitPrice;
            entity.WasteId = WasteId;
            entity.WasteValue = (double)WasteValue;
            entity.ModifiedDate = ModifiedDate;
            entity.ModifiedByUser = ModifiedByUser;

            return entity;
        }
    }
}