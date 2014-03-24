using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RecipiesModelNS
{
    public partial class ProductInventoryHeader : YordanBaseEntity
    {
        private static int? productInventoryHeaderId = 0;

        public override void Removing(System.Data.Entity.Infrastructure.DbEntityEntry e = null)
        {
            productInventoryHeaderId = ProductInventoryHeaderId;
            base.Removing(e);
        }

        public override void Removed(System.Data.Entity.Infrastructure.DbEntityEntry e = null)
        {
            List<ProductInventory> pis = ContextFactory.Current.Inventories.OfType<ProductInventory>()
                .Where(pi => pi.ProductInventoryHeaderId == null).ToList();
            //pi => pi.ProductInventoryHeaderId == productInventoryHeaderId ||
            foreach (ProductInventory pi in pis)
            {
                ContextFactory.Current.Inventories.Remove(pi);
            }
            ContextFactory.Current.SaveChanges();
            base.Removed(e);
        }

        public static void InsertMissingProductInventories(ProductInventoryHeader pihEntity)
        {
            //ContextFactory.Current.ProductInventoryHeaders.Add(pihEntity);
            //ContextFactory.Current.SaveChanges();

            List<ProductInventory> pis =
                ContextFactory.Current.Inventories.OfType<ProductInventory>()
                    .Where(pi => pi.ProductInventoryHeaderId == pihEntity.ProductInventoryHeaderId)
                    .ToList();

            List<Product> allProducts = ContextFactory.Current.Products.ToList();
            // Move this to the database project in ProductInventoryHeader
            foreach (Product product in allProducts)
            {
                if (!pis.Any(pid => pid.ProductId == product.ProductId))
                {
                    ProductInventory pi = new ProductInventory();
                    pi.ProductId = product.ProductId;
                    //pi.ForDate = pihEntity.ForDate;
                    pi.AverageUnitPrice = product.UnitPrice;
                    pi.QuantityByDocuments = product.GetQuantityByDocumentsForDate(pihEntity.ForDate.GetValueOrDefault());

                    pi.ProductInventoryHeaderId = pihEntity.ProductInventoryHeaderId;

                    ContextFactory.Current.Inventories.Add(pi);
                    ContextFactory.Current.SaveChanges();
                }
            }
        }
    }
}