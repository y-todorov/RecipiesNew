using System.Collections.Generic;
using System.Linq;

namespace RecipiesModelNS
{
    public partial class SalesOrderDetail : YordanBaseEntity
    {
        public override void Added(System.Data.Entity.Infrastructure.DbEntityEntry e = null)
        {
            SalesOrderHeader.UpdateSalesOrderHeaderTotalDueFromSalesOrderDetails(SalesOrderHeaderId);
            SalesOrderDetail.UpdateProductsUnitsInStock(SalesOrderDetailId);

            base.Added(e);
        }

        public override void Changed(System.Data.Entity.Infrastructure.DbEntityEntry e = null)
        {
            SalesOrderHeader.UpdateSalesOrderHeaderTotalDueFromSalesOrderDetails(SalesOrderHeaderId);
            SalesOrderDetail.UpdateProductsUnitsInStock(SalesOrderDetailId);
            base.Changed(e);
        }

        private static int? _salesOrderHeaderId = 0;

        public override void Removing(System.Data.Entity.Infrastructure.DbEntityEntry e = null)
        {
            _salesOrderHeaderId = e.OriginalValues.GetValue<int?>("SalesOrderHeaderId");
            base.Removing(e);
        }

        public override void Removed(System.Data.Entity.Infrastructure.DbEntityEntry e = null)
        {
            SalesOrderHeader.UpdateSalesOrderHeaderTotalDueFromSalesOrderDetails(_salesOrderHeaderId);
            SalesOrderDetail.UpdateProductsUnitsInStock(_salesOrderHeaderId);
            base.Removed(e);
        }

        public static void UpdateProductsUnitsInStock(int? salesOrderDetailId)
        {
            SalesOrderDetail salesOrderDetail =
                ContextFactory.Current.SalesOrderDetails.FirstOrDefault(
                    sod => sod.SalesOrderDetailId == salesOrderDetailId);
            if (salesOrderDetail != null && salesOrderDetail.Recipe != null)
            {
                Dictionary<int, double> productsWithQuantities = new Dictionary<int, double>();
                Recipe.GetProductsWithQuantities(salesOrderDetail.Recipe.RecipeId, productsWithQuantities);

                foreach (int productId in productsWithQuantities.Keys)
                {
                    Product.UpdateUnitsInStock(productId);
                }

                //foreach (ProductIngredient pi in salesOrderDetail.Recipe.ProductIngredients)
                //{
                //    Product.UpdateUnitsInStock(pi.ProductId);
                //}
                //foreach (RecipeIngredient ri in salesOrderDetail.Recipe.RecipeIngredients1)
                //{
                //    if (ri.IngredientRecipe != null)
                //    {
                //        foreach (ProductIngredient pi in ri.IngredientRecipe.ProductIngredients)
                //        {
                //            Product.UpdateUnitsInStock(pi.ProductId);
                //        }
                //    }
                //}
            }
        }
    }
}