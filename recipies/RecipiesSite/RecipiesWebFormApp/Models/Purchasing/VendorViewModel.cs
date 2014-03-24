using System;
using System.ComponentModel.DataAnnotations;
using RecipiesModelNS;

namespace InventoryManagementMVC.Models
{
    public class VendorViewModel
    {
        [Key]
        public int VendorId { get; set; }

        public string AccountNumber { get; set; }

        public string ReportAccountNumber { get; set; }

        [Required(ErrorMessage = "Please enter a name for the vendor!")]
        public string Name { get; set; }

        public string Address { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        
        public string Fax { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Url)]
        public string HomePage { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string ModifiedByUser { get; set; }

        public VendorViewModel ConvertFromEntity(Vendor entity)
        {
            AccountNumber = entity.AccountNumber;
            Address = entity.Address;
            Email = entity.Email;
            Fax = entity.Fax;
            HomePage = entity.HomePage;
            Name = entity.Name;
            Phone = entity.Phone;
            ReportAccountNumber = entity.ReportAccountNumber;
            VendorId = entity.VendorId;

            return this;
        }

        public Vendor ConvertToEntity(Vendor entity)
        {
            entity.AccountNumber = AccountNumber;
            entity.Address = Address;
            entity.Email = Email;
            entity.Fax = Fax;
            entity.HomePage = HomePage;
            entity.Name = Name;
            entity.Phone = Phone;
            entity.ReportAccountNumber = ReportAccountNumber;
            entity.VendorId = VendorId;

            return entity;
        }
    }
}