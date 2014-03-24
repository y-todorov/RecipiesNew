using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RecipiesModelNS
{
    public partial class ProductWasteHeader : YordanBaseEntity
    {
        private static int? productWasteHeaderId = 0;

        public override void Removing(System.Data.Entity.Infrastructure.DbEntityEntry e = null)
        {
            productWasteHeaderId = ProductWasteHeaderId;
             
            base.Removing(e);
        }

        public override void Removed(System.Data.Entity.Infrastructure.DbEntityEntry e = null)
        {
            List<ProductWaste> pis = ContextFactory.Current.Wastes.OfType<ProductWaste>()
                .Where(pi => pi.ProductWasteHeaderId == null).ToList();
            //pi => pi.ProductInventoryHeaderId == productInventoryHeaderId ||
            foreach (ProductWaste pi in pis)
            {
                ContextFactory.Current.Wastes.Remove(pi);
            }
            ContextFactory.Current.SaveChanges();
            base.Removed(e);
        }

        public static void InsertMissingProductWastes(ProductWasteHeader pwhEntity)
        {
            List<ProductWaste> pws =
                ContextFactory.Current.Wastes.OfType<ProductWaste>()
                    .Where(pi => pi.ProductWasteHeaderId == pwhEntity.ProductWasteHeaderId)
                    .ToList();

            List<Product> allProducts = ContextFactory.Current.Products.ToList();
            // Move this to the database project in ProductInventoryHeader
            foreach (Product product in allProducts)
            {
                if (!pws.Any(pid => pid.ProductId == product.ProductId))
                {
                    ProductWaste pw = new ProductWaste();
                    pw.ProductId = product.ProductId;
                    pw.ProductWasteHeaderId = pwhEntity.ProductWasteHeaderId;

                    pw.UnitMeasure = product.UnitMeasure;
                    pw.UnitPrice = product.UnitPrice;
                   
                    ContextFactory.Current.Wastes.Add(pw);
                    ContextFactory.Current.SaveChanges();
                }
            } 
           
        }
    }
}