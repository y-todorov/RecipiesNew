using System.Collections.Generic;
using System.Linq;

namespace RecipiesModelNS
{
    public partial class ProductCategory : YordanBaseEntity
    {
        public static List<ProductCategory> GetCategoriesToExcludeFromGP()
        {
            // Bar, Utilities and Pappers and Consumables

            List<ProductCategory> result = new List<ProductCategory>();

            ProductCategory barCategory =
                ContextFactory.Current.ProductCategories.FirstOrDefault(
                    pc => pc.Name.Equals("bar", System.StringComparison.InvariantCultureIgnoreCase));
            if (barCategory != null)
            {
                result.Add(barCategory);
            }

            ProductCategory utilitiesCategory =
                ContextFactory.Current.ProductCategories.FirstOrDefault(
                    pc => pc.Name.Equals("utilities", System.StringComparison.InvariantCultureIgnoreCase));
            if (utilitiesCategory != null)
            {
                result.Add(utilitiesCategory);
            }

            ProductCategory pappersAndConsumablesCategory =
                ContextFactory.Current.ProductCategories.FirstOrDefault(
                    pc => pc.Name.Equals("papers and consumables", System.StringComparison.InvariantCultureIgnoreCase));
            if (pappersAndConsumablesCategory != null)
            {
                result.Add(pappersAndConsumablesCategory);
            }

            return result;
        }
    }
}