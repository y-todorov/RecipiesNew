using InventoryManagementMVC.DataAnnotations;
using RecipiesModelNS;
using System;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagementMVC.Models
{
    public class UnitMeasureViewModel
    {
        [Key]
        public int UnitMeasureId { get; set; }

        [Required]
        public string Name { get; set; }

        public bool IsBaseUnit { get; set; }

        [Relation(EntityType = typeof (UnitMeasure), DataFieldValue = "UnitMeasureId", DataFieldText = "Name")]
        [Display(Name = "Unit Measure")]
        public int? BaseUnitId { get; set; }

        [Range(0, int.MaxValue)]
        public double? BaseUnitFactor { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string ModifiedByUser { get; set; }

        public UnitMeasureViewModel ConvertFromEntity(UnitMeasure entity)
        {
            BaseUnitFactor = entity.BaseUnitFactor;
            BaseUnitId = entity.BaseUnitId;
            IsBaseUnit = entity.IsBaseUnit.GetValueOrDefault();
            UnitMeasureId = entity.UnitMeasureId;
            Name = entity.Name;
            ModifiedDate = entity.ModifiedDate;
            ModifiedByUser = entity.ModifiedByUser;

            return this;
        }

        public UnitMeasure ConvertToEntity(UnitMeasure entity)
        {
            entity.BaseUnitFactor = BaseUnitFactor;
            entity.BaseUnitId = BaseUnitId;
            entity.IsBaseUnit = IsBaseUnit;
            entity.UnitMeasureId = UnitMeasureId;
            entity.Name = Name;
            entity.ModifiedDate = ModifiedDate;
            entity.ModifiedByUser = ModifiedByUser;

            return entity;
        }
    }
}