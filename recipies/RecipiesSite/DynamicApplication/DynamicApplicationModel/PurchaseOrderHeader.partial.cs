using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace RecipiesModelNS
{
    public partial class PurchaseOrderHeader : YordanBaseEntity
    {
        public static List<PurchaseOrderDetail> GetPurchaseOrderDetailsInPeriod(DateTime fromDate, DateTime toDate,
            PurchaseOrderStatusEnum status, List<ProductCategory> categoriesToExclude = null)
        {
            DateTime defaultDate = new DateTime(2000, 1, 1);
            DateTime endDateForLinq = toDate.Date.AddDays(1);
            List<PurchaseOrderHeader> purchaseOrderHeaders =
                ContextFactory.GetContextPerRequest().PurchaseOrderHeaders
                .Include(p => p.PurchaseOrderDetails.Select(pp => pp.Product))
                //.Include(p => p.PurchaseOrderDetails)
                .Where(pof => pof.ShipDate >= fromDate.Date &&
                                                                                        pof.ShipDate < endDateForLinq &&
                                                                                        pof.StatusId == (int) status)
                    .ToList();

            List<PurchaseOrderDetail> pods =
                purchaseOrderHeaders.SelectMany(
                    poh =>
                        poh.PurchaseOrderDetails.Where(
                            pod =>
                                categoriesToExclude != null &&
                                !categoriesToExclude.Any(
                                    pc => (pod.Product != null && pc.CategoryId == pod.Product.CategoryId)))).ToList();
            return pods;
            //return purchaseOrderHeaders;
        }

        public static void UpdateProductsUnitsInStock(int? purchaseOrderHeaderId)
        {
            if (purchaseOrderHeaderId.HasValue)
            {
                PurchaseOrderHeader poh =
                    ContextFactory.GetContextPerRequest()
                        .PurchaseOrderHeaders.FirstOrDefault(p => p.PurchaseOrderId == purchaseOrderHeaderId);

                if (poh != null)
                {
                    foreach (PurchaseOrderDetail pod in poh.PurchaseOrderDetails)
                    {
                        Product.UpdateUnitsInStock(pod.ProductId);
                    }
                }
            }
        }

        public static void UpdatePurchaseOrderHeaderSubTotalFromPurchaseOrderDetails(int? purchaseOrderHeaderId)
        {
            if (purchaseOrderHeaderId.HasValue)
            {
                PurchaseOrderHeader poh =
                    ContextFactory.GetContextPerRequest()
                        .PurchaseOrderHeaders.FirstOrDefault(po => po.PurchaseOrderId == purchaseOrderHeaderId.Value);
                if (poh != null)
                {
                    decimal? subTotal = 0;
                    foreach (PurchaseOrderDetail pod in poh.PurchaseOrderDetails)
                    {
                        subTotal += (decimal?) pod.LineTotal;
                    }
                    poh.SubTotal = subTotal;
                    ContextFactory.GetContextPerRequest().SaveChanges();
                }
            }
        }

        public override void Added(System.Data.Entity.Infrastructure.DbEntityEntry e = null)
        {
            //UpdateProductsUnitsInStock(PurchaseOrderId);
            base.Added(e);
        }

        public override void Changed(System.Data.Entity.Infrastructure.DbEntityEntry e = null)
        {
            //UpdateProductsUnitsInStock(PurchaseOrderId);
            base.Changed(e);
        }

        private static int? _purchaseOrderId = 0;

        public override void Removing(System.Data.Entity.Infrastructure.DbEntityEntry e = null)
        {
            _purchaseOrderId = PurchaseOrderId;
            base.Removing(e);
        }

        public override void Removed(System.Data.Entity.Infrastructure.DbEntityEntry e = null)
        {
            //UpdateProductsUnitsInStock(_purchaseOrderId);
            base.Removed(e);
        }
    }
}