using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using RecipiesModelNS;
using System.ComponentModel;
using InventoryManagementMVC.DataAnnotations;
using System.Web.Mvc;
using RecipiesWebFormApp.Helpers;

namespace InventoryManagementMVC.Models
{
    public class SalesOrderDetailViewModel
    {
        [Key]
        public int SalesOrderDetailId { get; set; }

        [ReadOnly(true)]
        [Display(Name = "Sales Order")]
        [Editable(false)]
        [HiddenInput(DisplayValue = false)]
        public int? SalesOrderHeaderId { get; set; }

        [Relation(EntityType = typeof(Recipe), DataFieldValue = "RecipeId", DataFieldText = "Name")]
        [Display(Name = "Recipe")]
        public int? RecipeId { get; set; }

        [ReadOnly(true)]
        public string RecipeCategory { get; set; }

        [ReadOnly(true)]
        [Display(Name = "Production total value")]
        public decimal? ProductionTotalValue { get; set; }


        [Display(Name = "Order QTY")]
        public double? OrderQuantity { get; set; }

        public decimal? UnitPrice { get; set; }


        public double? UnitPriceDiscount { get; set; }

        [ReadOnly(true)]
        public decimal LineTotal { get; set; }

        [ReadOnly(true)]
        [DisplayFormat(DataFormatString = "{0:P2}")]
        public double? GrossProfit { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string ModifiedByUser { get; set; }

        public SalesOrderDetailViewModel ConvertFromEntity(SalesOrderDetail entity)
        {
            LineTotal = (decimal)entity.LineTotal;
            ModifiedByUser = entity.ModifiedByUser;
            ModifiedDate = entity.ModifiedDate;
            OrderQuantity = entity.OrderQuantity;
            RecipeId = entity.RecipeId;
            SalesOrderDetailId = entity.SalesOrderDetailId;
            SalesOrderHeaderId = entity.SalesOrderHeaderId;
            UnitPrice = entity.UnitPrice;
            UnitPriceDiscount = entity.UnitPriceDiscount;
            if (entity.Recipe != null && entity.Recipe.ProductCategory != null)
            {
                RecipeCategory = entity.Recipe.ProductCategory.Name;
            }
            else if (RecipeId.HasValue)
            {
                Recipe recipe = ContextFactory.Current.Recipes.FirstOrDefault(r => r.RecipeId == RecipeId);
                if (recipe != null && recipe.ProductCategory != null)
                {
                    RecipeCategory = recipe.ProductCategory.Name;
                }
            }

            if (entity.Recipe != null)
            {
                if (entity.OrderQuantity.GetValueOrDefault() != 0)
                {

                }

                // Recipe.ProductionValuePerPortion - this is not save to the database !!!
                ProductionTotalValue = Recipe.GetRecipeValuePerPortion(entity.RecipeId) * (decimal)entity.OrderQuantity.GetValueOrDefault();
            }
            else if (RecipeId.HasValue)
            {
                Recipe recipe = ContextFactory.Current.Recipes.FirstOrDefault(r => r.RecipeId == RecipeId);
                if (recipe != null)
                {
                    ProductionTotalValue = recipe.ProductionValuePerPortion * (decimal)entity.OrderQuantity.GetValueOrDefault();
                }
            }

            GrossProfit = ModelHelper.GetGp((double)ProductionTotalValue.GetValueOrDefault(), (double)LineTotal);


            return this;
        }

        public SalesOrderDetail ConvertToEntity(SalesOrderDetail entity)
        {
            entity.LineTotal = (double)LineTotal;
            entity.ModifiedByUser = ModifiedByUser;
            entity.ModifiedDate = ModifiedDate;
            entity.OrderQuantity = OrderQuantity;
            entity.RecipeId = RecipeId;
            entity.SalesOrderDetailId = SalesOrderDetailId;
            if (SalesOrderHeaderId != null) // ?
            {
                entity.SalesOrderHeaderId = SalesOrderHeaderId;
            }
            entity.UnitPrice = UnitPrice;
            entity.UnitPriceDiscount = UnitPriceDiscount;

            return entity;
        }
    }
}