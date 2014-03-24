using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using InventoryManagementMVC.Models;

namespace RecipiesModelNS
{
    public class StoreViewModel
    {
        [Key]
        public int StoreId { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string ModifiedByUser { get; set; }

        public StoreViewModel ConvertFromEntity(Store entity)
        {
            StoreId = entity.StoreId;
            Name = entity.Name;
            ModifiedDate = entity.ModifiedDate;
            ModifiedByUser = entity.ModifiedByUser;

            return this;
        }

        public Store ConvertToEntity(Store entity)
        {
            entity.StoreId = StoreId;
            entity.Name = Name;
            entity.ModifiedDate = ModifiedDate;
            entity.ModifiedByUser = ModifiedByUser;

            return entity;
        }
    }
}