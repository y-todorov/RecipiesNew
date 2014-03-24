using System;
using System.ComponentModel.DataAnnotations;
using RecipiesModelNS;
using InventoryManagementMVC.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;
using System.Linq;

namespace InventoryManagementMVC.Models
{
    public class ProductIngredientViewModel
    {
        [Key]
        public int ProductIngredientId { get; set; }

        [ReadOnly(true)]
        //[Relation(EntityType = typeof(Recipe), DataFieldValue = "RecipeId", DataFieldText = "Name")]
        [Display(Name = "Recipe")]
        [HiddenInput(DisplayValue = false)]
        public int? RecipeId { get; set; }


        [Relation(EntityType = typeof (Product), DataFieldValue = "ProductId", DataFieldText = "Name")]
        [Display(Name = "Product")]
        public int? ProductId { get; set; }

        public double? QuantityPerPortion { get; set; }

        // tova nqma kakvo da go pazim v baza izob6to. 6te go vzimame ot produkta!
        [ReadOnly(true)]
        public decimal? Cost { get; set; }
        
        [ReadOnly(true)]
        public decimal? TotalValue { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string ModifiedByUser { get; set; }

        public static ProductIngredientViewModel ConvertFromProductIngredientEntity(ProductIngredient entity,
            ProductIngredientViewModel model)
        {
            model.ProductIngredientId = entity.ProductIngredientId;
            model.RecipeId = entity.RecipeId;
            model.ProductId = entity.ProductId;
            model.QuantityPerPortion = entity.QuantityPerPortion;
            if (entity.ProductId.HasValue) // Problems if we use Entity.product
            {
                Product p =
                    ContextFactory.Current.Products.FirstOrDefault(prod => prod.ProductId == entity.ProductId.Value);
                if (p != null)
                {
                    model.Cost = entity.Product.UnitPrice;
                }
            }
            model.TotalValue = (decimal?) entity.TotalValue;

            model.ModifiedDate = entity.ModifiedDate;
            model.ModifiedByUser = entity.ModifiedByUser;

            return model;
        }

        public static ProductIngredient ConvertToProductIngredientEntity(ProductIngredientViewModel model,
            ProductIngredient entity)
        {
            entity.ProductIngredientId = model.ProductIngredientId;
            entity.RecipeId = model.RecipeId;
            entity.ProductId = model.ProductId;
            entity.QuantityPerPortion = model.QuantityPerPortion;
            if (model.ProductId.HasValue) // Problems if we use Entity.product
            {
                Product p =
                    ContextFactory.Current.Products.FirstOrDefault(prod => prod.ProductId == entity.ProductId.Value);
                if (p != null)
                {
                    entity.Cost = p.UnitPrice;
                }
            }


            entity.TotalValue = (double) model.TotalValue.GetValueOrDefault();

            entity.ModifiedDate = model.ModifiedDate;
            entity.ModifiedByUser = model.ModifiedByUser;

            return entity;
        }
    }
}