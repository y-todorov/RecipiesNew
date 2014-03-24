using System;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Reflection;
using System.Web;

namespace RecipiesModelNS
{
    public class YordanBaseEntity
    {
        public virtual void Adding(DbEntityEntry e = null)
        {
            //object att = ContextFactory.GetContextPerRequest().Set(this.GetType()).Attach(this);
            //DbEntityEntry dbEntry = ContextFactory.GetContextPerRequest().Entry(att);
            SetModifiedDateAndModifiedByUserFields();
        }

        public virtual void Added(DbEntityEntry e = null)
        {
        }

        public virtual void Changing(DbEntityEntry e = null)
        {
            SetModifiedDateAndModifiedByUserFields();
        }

        public virtual void Changed(DbEntityEntry e = null)
        {
        }

        public virtual void Removing(DbEntityEntry e = null)
        {
        }

        public virtual void Removed(DbEntityEntry e = null)
        {
        }

        private void SetModifiedDateAndModifiedByUserFields()
        {
            string userName = null;
            if (HttpContext.Current != null && HttpContext.Current.User != null &&
                HttpContext.Current.User.Identity != null)
            {
                userName = HttpContext.Current.User.Identity.Name;
            }
            Type type = this.GetType();
            PropertyInfo piModifiedDate = type.GetProperties().FirstOrDefault(p => p.Name.Equals("ModifiedDate"));
            if (piModifiedDate != null)
            {
                DateTime modifiedDate = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow,
                    TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time"));
                piModifiedDate.SetValue(this, modifiedDate);
            }
            PropertyInfo piModifiedByUser = type.GetProperties().FirstOrDefault(p => p.Name.Equals("ModifiedByUser"));
            if (piModifiedByUser != null)
            {
                if (!string.IsNullOrEmpty(userName))
                {
                    piModifiedByUser.SetValue(this, userName);
                }
            }
        }

        private void PopulateHistoryTables()
        {
            //object historyEntity = GetHistoryObjectForEntity(this);
            //if (historyEntity != null)
            //{
            //    var productFields = this.GetType().GetProperties(BindingFlags.Instance |
            //           BindingFlags.Static |
            //           BindingFlags.NonPublic |
            //           BindingFlags.Public);
            //    var productProperties = this.GetType().GetProperties();

            //    var productHistoryFields = historyEntity.GetType().GetFields(BindingFlags.Instance |
            //           BindingFlags.Static |
            //           BindingFlags.NonPublic |
            //           BindingFlags.Public);
            //    var productHistoryProperties = historyEntity.GetType().GetProperties();

            //    ContextFactory.GetContextPerRequest().ProductHistories.Add((ProductHistory)historyEntity);

            //    foreach (prop field in productFields)
            //    {
            //        // Check if this is actual property
            //        if (productProperties.Any(p => ("_" + p.Name).Equals(field.Name, StringComparison.InvariantCultureIgnoreCase)))
            //        {
            //            //object theValue = prop.GetValue(product); This is property and we get exception when deleting products
            //            var field2 = productHistoryFields.FirstOrDefault(f => f.Name.Equals(field.Name));
            //            if (field2 != null)
            //            {
            //                try
            //                {
            //                    object theValue = field.GetValue(this);
            //                    field2.setf .SetFieldValue(field.Name, theValue);
            //                }
            //                catch (Exception)
            //                {

            //                }
            //            }
            //        }

            //    }
            //}
        }


        private object GetHistoryObjectForEntity(object obj)
        {
            if (obj is Product)
            {
                return new ProductHistory();
            }
            return null;
        }
    }
}