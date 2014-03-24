using System;
using System.ComponentModel.DataAnnotations;
using RecipiesModelNS;
using InventoryManagementMVC.DataAnnotations;
using System.ComponentModel;
using RecipiesWebFormApp.Helpers;

namespace InventoryManagementMVC.Models
{
    public class RecipeViewModel
    {
        [Key]
        public int RecipeId { get; set; }

        [Relation(EntityType = typeof (ProductCategory), DataFieldValue = "CategoryId", DataFieldText = "Name")]
        [Display(Name = "Category")]
        public int? CategoryId { get; set; }

        [Required(ErrorMessage = "Please enter a name for the recipie!")]
        public string Name { get; set; }

        public string Description { get; set; }

        [ReadOnly(true)]
        public decimal? ProductionValuePerPortion { get; set; }

        [Range(0.01, int.MaxValue, ErrorMessage = "{0} must be positive!")]
        [Display(Name = "Sell Value Per Portion")]
        public decimal? SellValuePerPortion { get; set; }

        [ReadOnly(true)]
        [DisplayFormat(DataFormatString = "{0:P2}")]
        public double? GrossProfit { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string ModifiedByUser { get; set; }

        public RecipeViewModel ConvertFromEntity(Recipe entity)
        {
            RecipeId = entity.RecipeId;
            CategoryId = entity.CategoryId;
            Name = entity.Name;
            Description = entity.Description;
            ProductionValuePerPortion = Recipe.GetRecipeValuePerPortion(RecipeId);

            

            SellValuePerPortion = entity.SellValuePerPortion;
            GrossProfit = ModelHelper.GetGp((double)ProductionValuePerPortion.GetValueOrDefault(), (double)SellValuePerPortion);
            //GrossProfit = entity.GrossProfit;
            ModifiedDate = entity.ModifiedDate;
            ModifiedByUser = entity.ModifiedByUser;

            return this;
        }

        public Recipe ConvertToEntity(Recipe entity)
        {
            entity.RecipeId = RecipeId;
            entity.CategoryId = CategoryId;
            entity.Name = Name;
            entity.Description = Description;
            //entity.ProductionValuePerPortion = ProductionValuePerPortion;
            entity.SellValuePerPortion = SellValuePerPortion;
            //entity.GrossProfit = GrossProfit;
            entity.ModifiedDate = ModifiedDate;
            entity.ModifiedByUser = ModifiedByUser;

            return entity;
        }
    }
}