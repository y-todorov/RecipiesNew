using InventoryManagementMVC.DataAnnotations;
using RecipiesModelNS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagementMVC.Models
{
    public class ProductInventoryViewModel : InventoryViewModel
    {
        [Editable(false)]
        [HiddenInput(DisplayValue = false)]
        public int? ProductInventoryHeaderId { get; set; }

        [Relation(EntityType = typeof (Product), DataFieldValue = "ProductId", DataFieldText = "Name")]
        [Display(Name = "Product")]
        public int? ProductId { get; set; }

        [Editable(false)]
        public string UnitMeasure { get; set; }

        [Editable(false)]
        public string Category { get; set; }

        public ProductInventoryViewModel ConvertFromEntity(ProductInventory entity)
        {
            base.ConvertFromEntity(entity);
            ProductId = entity.ProductId;
            ProductInventoryHeaderId = entity.ProductInventoryHeaderId;
            if (entity.Product != null && entity.Product.ProductCategory != null)
            {
                Category = entity.Product.ProductCategory.Name;
            }
            else
            {
                Product product = ContextFactory.Current.Products.FirstOrDefault(p => p.ProductId == ProductId);
                if (product != null && product.ProductCategory != null)
                {
                    Category = product.ProductCategory.Name;
                }
            }

            if (entity.Product != null && entity.Product.UnitMeasure != null)
            {
                UnitMeasure = entity.Product.UnitMeasure.Name;
            }
            else
            {
                Product product = ContextFactory.Current.Products.FirstOrDefault(p => p.ProductId == ProductId);
                if (product != null && product.UnitMeasure != null)
                {
                    UnitMeasure = product.UnitMeasure.Name;
                }
            }

            if (entity.ProductInventoryHeader != null)
            {
                InventoryHeaderForDate = entity.ProductInventoryHeader.ForDate;
            }
            else
            {
                ProductInventoryHeader pih =
                    ContextFactory.Current.ProductInventoryHeaders.FirstOrDefault(
                        p => p.ProductInventoryHeaderId == ProductInventoryHeaderId);
                if (pih != null)
                {
                    InventoryHeaderForDate = pih.ForDate;
                }
            }
            return this;
        }

        public ProductInventory ConvertToEntity(ProductInventory entity)
        {
            base.ConvertToEntity(entity);
            entity.ProductId = ProductId;
            entity.ProductInventoryHeaderId = ProductInventoryHeaderId;

            return entity;
        }
    }
}