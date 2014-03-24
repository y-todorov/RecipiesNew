using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Data.Entity;

namespace RecipiesModelNS
{
    public partial class PurchaseOrderDetail : YordanBaseEntity
    {
        private static int? _purchaseOrderHeaderId;

        public override void Added(DbEntityEntry e = null)
        {
            //PurchaseOrderHeader.UpdatePurchaseOrderHeaderSubTotalFromPurchaseOrderDetails(PurchaseOrderId);
            // no need to update if all is 0-> no chane in products quantities
            //if (OrderQuantity.GetValueOrDefault() != 0 || ReceivedQuantity.GetValueOrDefault() != 0 || ReturnedQuantity.GetValueOrDefault() != 0)
            {
                //    PurchaseOrderHeader.UpdateProductsUnitsInStock(PurchaseOrderId);
            }
            base.Added(e);
        }

        public override void Changed(DbEntityEntry e = null)
        {
            //PurchaseOrderHeader.UpdatePurchaseOrderHeaderSubTotalFromPurchaseOrderDetails(PurchaseOrderId);
            //PurchaseOrderHeader.UpdateProductsUnitsInStock(PurchaseOrderId);
            base.Changed(e);
        }

        public override void Removing(DbEntityEntry e = null)
        {
            _purchaseOrderHeaderId = e.OriginalValues.GetValue<int?>("PurchaseOrderId");
            base.Removing(e);
        }

        public override void Removed(DbEntityEntry e = null)
        {
            //PurchaseOrderHeader.UpdatePurchaseOrderHeaderSubTotalFromPurchaseOrderDetails(_purchaseOrderHeaderId);
            //PurchaseOrderHeader.UpdateProductsUnitsInStock(_purchaseOrderHeaderId);
            base.Removed(e);
        }
    }
}