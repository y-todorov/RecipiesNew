using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RecipiesModelNS
{
    public partial class Product : YordanBaseEntity
    {
        public static void UpdateUnitsInStock(int? productId)
        {
            if (productId.HasValue)
            {
                Product product =
                    ContextFactory.GetContextPerRequest().Products.FirstOrDefault(p => p.ProductId == productId);
                if (product != null)
                {
                    double quantityByDocumentsForDate = product.GetQuantityByDocumentsForDate(DateTime.Now);
                    if (product.UnitsInStock != quantityByDocumentsForDate)
                    {
                        product.UnitsInStock = quantityByDocumentsForDate;
                        ContextFactory.GetContextPerRequest().SaveChanges();
                    }
                }
            }
        }

        public double GetAveragePriceLastDays(int lastDays)
        {
            //return 0;
            string help;
            return GetAveragePriceLastDays(lastDays, out help);
        }

        public double GetAveragePriceLastDays(int lastDays, out string text)
        {
            RecipiesEntities context = ContextFactory.GetContextPerRequest();

            DateTime fromDate = DateTime.Now.AddDays(-lastDays).Date;
            DateTime toDate = DateTime.Now.Date;
            List<PurchaseOrderDetail> pods;
            pods = context.PurchaseOrderDetails.Where(
                pod => pod.ProductId == ProductId && pod.PurchaseOrderHeader.ShipDate.HasValue &&
                       pod.OrderQuantity != 0 && // this is important
                       pod.PurchaseOrderHeader.ShipDate >= fromDate && pod.PurchaseOrderHeader.ShipDate <= toDate &&
                       pod.PurchaseOrderHeader.StatusId == (int) PurchaseOrderStatusEnum.Completed).ToList();
            pods = pods.OrderByDescending(p => p.PurchaseOrderHeader.ShipDate).ToList();


            StringBuilder result = new StringBuilder();

            decimal totalPrice = 0;
            double totalQuantity = 0;
            double baseUnitsQuantity = 0;
            if (pods.Count > 0)
            {
                foreach (PurchaseOrderDetail pod in pods)
                {
                    double tempBaseUnitsQuantity = pod.Product.GetBaseUnitMeasureQuantityForProduct(
                        pod.StockedQuantity, pod.UnitMeasure, pod);
                    baseUnitsQuantity += tempBaseUnitsQuantity;
                    totalPrice += (decimal) pod.StockedQuantity*pod.UnitPrice.GetValueOrDefault();
                    totalQuantity += pod.StockedQuantity;

                    string productMeasureName = string.Empty;
                    if (pod.Product != null && pod.Product.UnitMeasure != null)
                    {
                        productMeasureName = pod.Product.UnitMeasure.Name;
                    }
                    string podUnitMeasureName = string.Empty;
                    if (pod.UnitMeasure != null)
                    {
                        podUnitMeasureName = pod.UnitMeasure.Name;
                    }
                    result.AppendLine(
                        string.Format(
                            "Purchase order id: {0}, ship date: {1:dd/MM/yyyy}, base unit quantity: {2} {5}, stocked quantity: {3} {6}, unitPrice of vendor measure: {4}",
                            pod.PurchaseOrderHeader.PurchaseOrderId, pod.PurchaseOrderHeader.ShipDate,
                            tempBaseUnitsQuantity, pod.StockedQuantity, pod.UnitPrice, productMeasureName,
                            podUnitMeasureName));
                }
            }
            else
            {
                DateTime nowDate = DateTime.Now.Date;
                PurchaseOrderDetail lastPod = context.PurchaseOrderDetails.Where(pod => pod.ProductId == ProductId &&
                                                                                        pod.OrderQuantity != 0 &&
                                                                                        // this is important
                                                                                        pod.PurchaseOrderHeader.ShipDate <=
                                                                                        nowDate &&
                                                                                        pod.PurchaseOrderHeader.StatusId ==
                                                                                        (int)
                                                                                            PurchaseOrderStatusEnum
                                                                                                .Completed)
                    .OrderByDescending(pod => pod.PurchaseOrderHeader.ShipDate)
                    .FirstOrDefault();
                if (lastPod != null)
                {
                    if (lastPod.UnitMeasure == null)
                    {
                        throw new ApplicationException(
                            string.Format("PurchaseOrder with id: {0} does not have a UnitMeasure! Please correct it!"));
                    }
                    double tempBaseUnitsQuantity =
                        lastPod.Product.GetBaseUnitMeasureQuantityForProduct(lastPod.StockedQuantity,
                            lastPod.UnitMeasure, lastPod);
                    baseUnitsQuantity += tempBaseUnitsQuantity;
                    totalPrice += (decimal) lastPod.StockedQuantity*lastPod.UnitPrice.GetValueOrDefault();

                    totalQuantity += lastPod.StockedQuantity;
                    string productMeasureName = string.Empty;
                    if (lastPod.Product != null && lastPod.Product.UnitMeasure != null)
                    {
                        productMeasureName = lastPod.Product.UnitMeasure.Name;
                    }
                    string podUnitMeasureName = string.Empty;
                    if (lastPod.UnitMeasure != null)
                    {
                        podUnitMeasureName = lastPod.UnitMeasure.Name;
                    }
                    result.AppendLine(
                        string.Format(
                            "Purchase order id: {0}, ship date: {1:dd/MM/yyyy}, base unit quantity: {2} {5}, stocked quantity: {3} {6}, unitPrice of vendor measure: {4}",
                            lastPod.PurchaseOrderHeader.PurchaseOrderId, lastPod.PurchaseOrderHeader.ShipDate,
                            tempBaseUnitsQuantity, lastPod.StockedQuantity, lastPod.UnitPrice,
                            productMeasureName, podUnitMeasureName));
                }
                else
                {
                    // няма никакви поръчки -> значи вземаме цената от последната инвентаризация;

                    ProductInventory productInventory =
                        ContextFactory.Current.Inventories.OfType<ProductInventory>()
                            .FirstOrDefault(
                                pi => pi.ProductId == ProductId && pi.ProductInventoryHeader.ForDate <= DateTime.Now);
                    if (productInventory != null && productInventory.StocktakeQuantity.HasValue)
                        // inventory.StocktakeQuantity.HasValue it is not auto generated
                    {
                        totalPrice = productInventory.AverageUnitPrice.GetValueOrDefault();
                        totalQuantity = 1;
                        baseUnitsQuantity = 1;
                        result.AppendLine(
                            string.Format(
                                "Total price from last inventory : {0}",
                                totalPrice));
                    }
                }
            }

            double averagePrice = Math.Round((double) totalPrice/baseUnitsQuantity, 3);

            if (double.IsNaN(averagePrice) || double.IsInfinity(averagePrice))
            {
                averagePrice = 0;
            }
            result.AppendLine(
                string.Format(
                    "Total price: {0}, Total quantity in vendor units: {1}, Total quantity in product base units: {2}",
                    totalPrice, totalQuantity, baseUnitsQuantity));
            result.AppendLine(string.Format("averagePrice: {0}", averagePrice));

            text = result.ToString();
            return averagePrice;
        }

        public ProductInventory GetLastInventoryForDate(DateTime forDate)
        {
            ProductInventory lastInventory =
                ContextFactory.GetContextPerRequest()
                    .Inventories.OfType<ProductInventory>()
                    .Where(
                        inv =>
                            inv.ProductId == ProductId && inv.StocktakeQuantity.HasValue &&
                            inv.ProductInventoryHeader.ForDate <= forDate.Date)
                    .OrderByDescending(inv => inv.ProductInventoryHeader.ForDate).FirstOrDefault();
            return lastInventory;
        }

        /// <summary>
        /// When the inventory is for a period for example my last 2. first one is on 22.01.2014 and the next one is on 29.01.2014. For this one from 29.01.2014 I want you to include all PO from 23.01.2014 incl till 29.01.2014 incl. And the same for the sales and waste.
        /// </summary>
        /// <param name="forDate"></param>
        /// <returns></returns>
        public double GetQuantityByDocumentsForDate(DateTime forDate)
        {
            ProductInventory inventory = GetLastInventoryForDate(forDate);

            double purchases = 0;
            double sales = 0;

            double wastes = 0;
            //DateTime wastesLastDate = forDate.AddDays(1).Date; // What will happen if inventory and waste are on the same date?
            
            double quantityByDocuments = 0;

            if (inventory != null)
            {
                DateTime day1AfterLastInventory =
                    inventory.ProductInventoryHeader.ForDate.GetValueOrDefault().AddDays(1).Date;

                purchases = GetPurchaseOrderStockedQuantity(
                    day1AfterLastInventory, forDate.Date);
                sales = GetSalesOrderQuantity(day1AfterLastInventory, forDate.Date);

                wastes = GetProductWastesValue(day1AfterLastInventory, forDate.Date);

                quantityByDocuments = inventory.StocktakeQuantity.GetValueOrDefault() + purchases - sales - wastes;
            }
            else
            {
                purchases = GetPurchaseOrderStockedQuantity(DateTime.Now.AddYears(-100), forDate.Date);
                sales = GetSalesOrderQuantity(DateTime.Now.AddYears(-100), forDate.Date);
                wastes = GetProductWastesValue(DateTime.Now.AddYears(-100), forDate.Date);

                quantityByDocuments = purchases - sales - wastes;
            }
            return quantityByDocuments;
        }

        public List<ProductWaste> GetProductWastes(DateTime fromDate, DateTime toDate)
        {
            List<ProductWaste> productWastes =
            ContextFactory.Current.Wastes.OfType<ProductWaste>()
                .Where(pw => pw.ProductWasteHeader.ForDate >= fromDate.Date && pw.ProductWasteHeader.ForDate <= toDate.Date && pw.ProductId == ProductId)
                .ToList();

            return productWastes;
        }

        public double GetProductWastesValue(DateTime fromDate, DateTime toDate)
        {
            double val;
            var wastes = GetProductWastes(fromDate, toDate);

            val  = wastes.Sum(pw => pw.Quantity.GetValueOrDefault());
            return val;
        }


        public double GetPurchaseOrderStockedQuantity(DateTime fromDate, DateTime toDate)
        {
           
            List<PurchaseOrderDetail> details = GetPurchaseOrderDetailsInPeriod(fromDate, toDate);
            double stockedQuantityForPeriod = 0;
            foreach (PurchaseOrderDetail purchaseOrderDetail in details)
            {
                if (purchaseOrderDetail.UnitMeasure != null && Math.Round(Math.Abs(purchaseOrderDetail.StockedQuantity), 4) > 0)
                {
                    stockedQuantityForPeriod +=
                        this.GetBaseUnitMeasureQuantityForProduct(purchaseOrderDetail.StockedQuantity,
                            purchaseOrderDetail.UnitMeasure);
                }

            }

            return stockedQuantityForPeriod;
        }

        public List<PurchaseOrderDetail> GetPurchaseOrderDetailsInPeriod(DateTime fromDate, DateTime toDate)
        {
            List<PurchaseOrderHeader> purchaseOrderHeaders =
                ContextFactory.GetContextPerRequest().PurchaseOrderHeaders.Where(pu => pu.ShipDate.HasValue &&
                                                                                       pu.ShipDate >= fromDate.Date &&
                                                                                       pu.ShipDate <= toDate.Date &&
                                                                                       pu.StatusId ==
                                                                                       (int)
                                                                                           PurchaseOrderStatusEnum
                                                                                               .Completed &&
                                                                                       pu.PurchaseOrderDetails.Any(
                                                                                           pod =>
                                                                                               pod.ProductId ==
                                                                                               ProductId)).ToList();
            List<PurchaseOrderDetail> details =
                purchaseOrderHeaders.SelectMany(
                    ph => ph.PurchaseOrderDetails.Where(pd => pd.ProductId == ProductId).ToList()).ToList();
            return details;
        }
        
        public double GetSalesOrderQuantity(DateTime fromDate, DateTime toDate)
        {
            List<SalesOrderDetail> salesOrderDetails = GetSalesOrderDetailsForPeriod(fromDate, toDate);
            double quantity = 0;
            foreach (SalesOrderDetail salesOrderDetail in salesOrderDetails)
            {
                List<ProductIngredient> pis =
                    salesOrderDetail.Recipe.ProductIngredients.Where(pi => pi.ProductId == ProductId).ToList();

                foreach (ProductIngredient pi in pis)
                {
                    quantity += pi.QuantityPerPortion.GetValueOrDefault()*
                                salesOrderDetail.OrderQuantity.GetValueOrDefault();
                }
            }

            return quantity;
        }

        public List<SalesOrderDetail> GetSalesOrderDetailsForPeriod(DateTime fromDate, DateTime toDate)
        {
            List<SalesOrderDetail> salesOrderDetails =
               ContextFactory.GetContextPerRequest()
                   .SalesOrderDetails.Where(sod => sod.SalesOrderHeader.ShippedDate.HasValue &&
                                                   sod.SalesOrderHeader.ShippedDate >= fromDate.Date &&
                                                   sod.SalesOrderHeader.ShippedDate <= toDate.Date &&
                                                   sod.OrderQuantity != 0 &&
                                                   (
                                                       sod.Recipe.ProductIngredients.Any(
                                                           ri =>
                                                               ri.ProductId ==
                                                               ProductId))
                   )
                   .ToList();
            return salesOrderDetails;
        }

        public double GetBaseUnitMeasureQuantityForProduct(double? quantity, UnitMeasure quantityUnitMeasure,
            PurchaseOrderDetail pod = null)
        {
            if (quantityUnitMeasure.BaseUnitId == this.UnitMeasureId)
            {
                UnitMeasure baseUnitMeasure = this.UnitMeasure;
                if (quantityUnitMeasure.BaseUnitFactor.HasValue)
                {
                    double result = quantity.GetValueOrDefault()*quantityUnitMeasure.BaseUnitFactor.GetValueOrDefault();
                    return Math.Round(result, 3);
                }
                else
                {
                    throw new ApplicationException(
                        "UnitMeasure mismatch in method GetBaseUnitMeasureQuantityForProduct! quantityUnitMeasure does no have");
                }
            }
            else if (quantityUnitMeasure.UnitMeasureId == this.UnitMeasureId)
            {
                double result = quantity.GetValueOrDefault();
                return Math.Round(result, 3);
            }
            else
            {
                string podMessage = "None.";
                if (pod != null)
                {
                    podMessage = string.Format("Purchase Order Id: {0}, purchase order detail Id: {1}",
                        pod.PurchaseOrderId, pod.PurchaseOrderDetailId);
                }
                throw new ApplicationException(
                    string.Format(
                        "UnitMeasure mismatch in method GetBaseUnitMeasureQuantityForProduct! Product id: {0}, Product name: {4}, Product unit measure: {1}, Quantity unit measure: {2}, More info: {3}",
                        ProductId, UnitMeasure.Name, quantityUnitMeasure.Name, podMessage, Name));
            }
        }

        public static void UpdateUnitPriceOfAllProducts()
        {
            List<Product> products = ContextFactory.GetContextPerRequest().Products.ToList();
            foreach (Product product in products)
            {
                //if (product.ProductId == 6983)
                {
                    decimal? averagePriceLastDays = (decimal?) product.GetAveragePriceLastDays(14);
                    if (averagePriceLastDays != product.UnitPrice)
                    {
                        product.UnitPrice = averagePriceLastDays;
                    }
                }
            }
            ContextFactory.GetContextPerRequest().SaveChanges();
        }

        public static void UpdateUnitsInStockOfAllProducts()
        {
            List<Product> allProducts = ContextFactory.GetContextPerRequest().Products.ToList();
            foreach (Product p in allProducts)
            {
                Product.UpdateUnitsInStock(p.ProductId);
            }
            ContextFactory.GetContextPerRequest().SaveChanges();
        }

        public static void UpdateUnitsOnOrderOfAllProducts()
        {
            List<Product> allProducts = ContextFactory.GetContextPerRequest().Products.ToList();
            List<PurchaseOrderDetail> allCompletedPurchaseOrderDetals =
                ContextFactory.GetContextPerRequest()
                    .PurchaseOrderDetails.Where(
                        pod => pod.PurchaseOrderHeader.StatusId == (int) PurchaseOrderStatusEnum.Approved ||
                               pod.PurchaseOrderHeader.StatusId == (int) PurchaseOrderStatusEnum.Pending
                    ).ToList();

            foreach (Product product in allProducts)
            {
                double unitsOnOrderk = 0;
                foreach (PurchaseOrderDetail pod in allCompletedPurchaseOrderDetals)
                {
                    if (pod.ProductId == product.ProductId)
                    {
                        unitsOnOrderk += product.GetBaseUnitMeasureQuantityForProduct(pod.OrderQuantity, pod.UnitMeasure);
                    }
                }
                if (product.UnitsOnOrder != unitsOnOrderk)
                {
                    product.UnitsOnOrder = unitsOnOrderk;
                }
            }
            ContextFactory.GetContextPerRequest().SaveChanges();
        }
    }
}