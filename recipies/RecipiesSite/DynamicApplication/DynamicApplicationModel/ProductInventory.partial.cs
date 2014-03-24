using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipiesModelNS
{
    public partial class ProductInventory
    {
        public override void Added(System.Data.Entity.Infrastructure.DbEntityEntry e = null)
        {
            Product.UpdateUnitsInStock(ProductId);
            base.Added(e);
        }

        public override void Changed(System.Data.Entity.Infrastructure.DbEntityEntry e = null)
        {
            Product.UpdateUnitsInStock(ProductId);
            base.Changed(e);
        }

        private static int? productId = 0;

        public override void Removing(System.Data.Entity.Infrastructure.DbEntityEntry e = null)
        {
            productId = ProductId;
            base.Removing(e);
        }

        public override void Removed(System.Data.Entity.Infrastructure.DbEntityEntry e = null)
        {
            Product.UpdateUnitsInStock(productId);
            base.Removed(e);
        }
    }
}