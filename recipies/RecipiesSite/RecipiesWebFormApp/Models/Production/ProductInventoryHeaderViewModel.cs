using RecipiesModelNS;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InventoryManagementMVC.Models
{
    public class ProductInventoryHeaderViewModel
    {
        [Key]
        public int ProductInventoryHeaderId { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ForDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string ModifiedByUser { get; set; }

        public ProductInventoryHeaderViewModel ConvertFromEntity(ProductInventoryHeader entity)
        {
            ProductInventoryHeaderId = entity.ProductInventoryHeaderId;
            ForDate = entity.ForDate;

            ModifiedDate = entity.ModifiedDate;
            ModifiedByUser = entity.ModifiedByUser;


            return this;
        }

        public ProductInventoryHeader ConvertToEntity(ProductInventoryHeader entity)
        {
            entity.ProductInventoryHeaderId = ProductInventoryHeaderId;
            entity.ForDate = ForDate;

            entity.ModifiedDate = ModifiedDate;
            entity.ModifiedByUser = ModifiedByUser;

            return entity;
        }
    }
}