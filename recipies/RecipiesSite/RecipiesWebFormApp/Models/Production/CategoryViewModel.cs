using System;
using System.ComponentModel.DataAnnotations;
using RecipiesModelNS;

namespace InventoryManagementMVC.Models
{
    public class CategoryViewModel
    {
        [Key]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Please enter a name for the category!")]
        public string Name { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string ModifiedByUser { get; set; }

        public CategoryViewModel ConvertFromEntity(ProductCategory entity)
        {
            CategoryId = entity.CategoryId;
            Name = entity.Name;
            ModifiedDate = entity.ModifiedDate;
            ModifiedByUser = entity.ModifiedByUser;

            return this;
        }

        public ProductCategory ConvertToEntity(ProductCategory entity)
        {
            entity.CategoryId = CategoryId;
            entity.Name = Name;
            entity.ModifiedDate = ModifiedDate;
            entity.ModifiedByUser = ModifiedByUser;

            return entity;
        }
    }
}