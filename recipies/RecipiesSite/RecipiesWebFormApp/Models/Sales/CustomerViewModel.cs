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
    public class CustomerViewModel
    {
        [Key]
        public int CustomerId { get; set; }

        public string CompanyName { get; set; }

        [Required()]
        public string ContactName { get; set; }

        public string Address { get; set; }

        public string Country { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        
        public DateTime? ModifiedDate { get; set; }

        public string ModifiedByUser { get; set; }

        public CustomerViewModel ConvertFromEntity(Customer entity)
        {
            Address = entity.Address;
            CompanyName = entity.CompanyName;
            ContactName = entity.ContactName;
            Country = entity.Country;
            CustomerId = entity.CustomerID;
            Email = entity.Email;
            ModifiedByUser = entity.ModifiedByUser;
            ModifiedDate = entity.ModifiedDate;
            Phone = entity.Phone;

            return this;
        }

        public Customer ConvertToEntity(Customer entity)
        {
            entity.Address = Address;
            entity.CompanyName = CompanyName;
            entity.ContactName = ContactName;
            entity.Country = Country;
            entity.CustomerID = CustomerId;
            entity.Email = Email;
            entity.ModifiedByUser = ModifiedByUser;
            entity.ModifiedDate = ModifiedDate;
            entity.Phone = Phone;

            return entity;
        }

    }
}