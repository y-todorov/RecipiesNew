using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagementMVC.DataAnnotations
{
    [AttributeUsageAttribute(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false,
        Inherited = true)]
    public class RelationAttribute : Attribute
    {
        public Type EntityType { get; set; }

        public string DataFieldValue { get; set; }

        public string DataFieldText { get; set; }
    }
}