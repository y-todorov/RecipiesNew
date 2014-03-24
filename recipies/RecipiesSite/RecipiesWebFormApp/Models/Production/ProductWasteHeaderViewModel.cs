using RecipiesModelNS;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InventoryManagementMVC.Models
{
    public class ProductWasteHeaderViewModel
    {
        [Key]
        public int ProductWasteHeaderId { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ForDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string ModifiedByUser { get; set; }

        public ProductWasteHeaderViewModel ConvertFromEntity(ProductWasteHeader entity)
        {
            ProductWasteHeaderId = entity.ProductWasteHeaderId;
            ForDate = entity.ForDate;

            ModifiedDate = entity.ModifiedDate;
            ModifiedByUser = entity.ModifiedByUser;


            return this;
        }

        public ProductWasteHeader ConvertToEntity(ProductWasteHeader entity)
        {
            entity.ProductWasteHeaderId = ProductWasteHeaderId;
            entity.ForDate = ForDate;

            entity.ModifiedDate = ModifiedDate;
            entity.ModifiedByUser = ModifiedByUser;

            return entity;
        }
    }
}