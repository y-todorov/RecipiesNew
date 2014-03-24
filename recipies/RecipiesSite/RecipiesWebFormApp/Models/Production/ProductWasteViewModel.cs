using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using InventoryManagementMVC.DataAnnotations;
using RecipiesModelNS;

namespace InventoryManagementMVC.Models
{
    public class ProductWasteViewModel : WasteViewModel
    {
        [Relation(EntityType = typeof(Product), DataFieldValue = "ProductId", DataFieldText = "Name")]
        [Display(Name = "Product")]
        public int? ProductId { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int? ProductWasteHeaderId { get; set; }

        public ProductWasteViewModel ConvertFromEntity(ProductWaste entity)
        {
            base.ConvertFromEntity(entity);
            ProductId = entity.ProductId;
            ProductWasteHeaderId = entity.ProductWasteHeaderId;
            if (entity.Product != null && entity.Product.UnitMeasure != null)
            {
                UnitMeasureId = entity.Product.UnitMeasure.UnitMeasureId;
            }
            if (entity.Product != null)
            {
                UnitPrice = entity.Product.UnitPrice;
            }
            return this;
        }

        public ProductWaste ConvertToEntity(ProductWaste entity)
        {
            base.ConvertToEntity(entity);
            entity.ProductId = ProductId;
            entity.ProductWasteHeaderId = ProductWasteHeaderId;

            return entity;
        }
    }
}