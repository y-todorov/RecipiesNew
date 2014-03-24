using System;
using System.ComponentModel.DataAnnotations;
using RecipiesModelNS;

namespace InventoryManagementMVC.Models
{
    public class ShipMethodViewModel
    {
        [Key]
        public int ShipMethodId { get; set; }

        [Required(ErrorMessage = "Please enter a name for the ship method!")]
        public string Name { get; set; }

        public decimal? ShipBase { get; set; }

        public decimal? ShipRate { get; set; }
        
        public DateTime? ModifiedDate { get; set; }

        public string ModifiedByUser { get; set; }

        public ShipMethodViewModel ConvertFromEntity(ShipMethod entity)
        {
            ShipMethodId = entity.ShipMethodId;
            Name = entity.Name;
            ShipBase = entity.ShipBase;
            ShipRate = entity.ShipRate;
            ModifiedDate = entity.ModifiedDate;
            ModifiedByUser = entity.ModifiedByUser;

            return this;
        }

        public ShipMethod ConvertToEntity(ShipMethod entity)
        {
            entity.ShipMethodId = ShipMethodId;
            entity.Name = Name;
            entity.ShipBase = ShipBase;
            entity.ShipRate = ShipRate;
            entity.ModifiedDate = ModifiedDate;
            entity.ModifiedByUser = ModifiedByUser;

            return entity;
        }
    }
}