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
    public class PaymentTypeViewModel
    {
        [Key]
        public int PaymentTypeId { get; set; }

        [Required()]
        public string Name { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string ModifiedByUser { get; set; }

        public PaymentTypeViewModel ConvertFromEntity(PaymentType entity)
        {
            PaymentTypeId = entity.PaymentTypeId;
            Name = entity.Name;
            ModifiedByUser = entity.ModifiedByUser;
            ModifiedDate = entity.ModifiedDate;

            return this;
        }
     
        public PaymentType ConvertToEntity(PaymentType entity)
        {
            entity.PaymentTypeId = PaymentTypeId;
            entity.Name = Name;
            entity.ModifiedByUser = ModifiedByUser;
            entity.ModifiedDate = ModifiedDate;

            return entity;
        }

        public override bool Equals(System.Object obj)
        {
            // If parameter cannot be cast to ThreeDPoint return false:
            PaymentTypeViewModel p = obj as PaymentTypeViewModel;
            if ((object)p == null)
            {
                return false;
            }

            // Return true if the fields match:
            return base.Equals(obj) && PaymentTypeId == p.PaymentTypeId;
        }

        public bool Equals(PaymentTypeViewModel p)
        {
            // Return true if the fields match:
            return base.Equals((PaymentTypeViewModel)p) && PaymentTypeId == p.PaymentTypeId;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() ^ PaymentTypeId;
        }

        //add this code to class ThreeDPoint as defined previously
        //
        public static bool operator ==(PaymentTypeViewModel a, PaymentTypeViewModel b)
        {
            // If both are null, or both are same instance, return true.
            if (System.Object.ReferenceEquals(a, b))
            {
                return true;
            }

            // If one is null, but not both, return false.
            if (((object)a == null) || ((object)b == null))
            {
                return false;
            }

            // Return true if the fields match:
            return a.PaymentTypeId == b.PaymentTypeId;
        }

        public static bool operator !=(PaymentTypeViewModel a, PaymentTypeViewModel b)
        {
            return !(a == b);
        }
    }
}