using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using InventoryManagementMVC.DataAnnotations;

namespace RecipiesUnitTests
{
    public static class UnitTestHelper
    {
        private static readonly Random random = new Random((int) DateTime.Now.Ticks);


        public static string GetRandomString(int size = 10)
        {
            var builder = new StringBuilder();

            for (int i = 0; i < size; i++)
            {
                char ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26*random.NextDouble() + 65)));
                builder.Append(ch);
            }

            string randomString = builder.ToString();
            return randomString;
        }

        public static int GetRandomInt()
        {
            int randomInt = random.Next(int.MinValue, int.MaxValue);
            return randomInt;
        }

        public static double GetRandomDouble(double minimum = int.MinValue, double maximum = int.MaxValue)
        {
            double randomDouble = random.NextDouble()*(maximum - minimum) + minimum;
            return randomDouble;
        }

        public static decimal GetRandomDecimal()
        {
            double randomDouble = GetRandomDouble();
            var randomdecimal = (decimal) randomDouble;
            return randomdecimal;
        }

        public static DateTime GetRandomDateTime(DateTime? start = null)
        {
            if (!start.HasValue)
            {
                start = new DateTime(1900, 1, 1);
            }

            int range = (DateTime.Today - start.GetValueOrDefault()).Days;
            DateTime randomDate = start.GetValueOrDefault().AddDays(random.Next(range));
            return randomDate;
        }

        public static void InitializeModelWithRandomValues(object model)
        {
            Type modelType = model.GetType();
            PropertyInfo[] props = modelType.GetProperties();

            foreach (PropertyInfo propertyInfo in props)
            {
                ReadOnlyAttribute readOnlyAttribute =
                    propertyInfo.GetCustomAttributes<ReadOnlyAttribute>().FirstOrDefault();
                KeyAttribute keyAttribute =
                    propertyInfo.GetCustomAttributes<KeyAttribute>().FirstOrDefault();
                RelationAttribute relationAttribute =
                    propertyInfo.GetCustomAttributes<RelationAttribute>().FirstOrDefault();
                if (keyAttribute != null)
                {
                    continue;
                }
                if (relationAttribute != null)
                {
                    continue;
                }
                if (readOnlyAttribute != null)
                {
                    continue;
                }

                if (propertyInfo.PropertyType == typeof (string))
                {
                    propertyInfo.SetValue(model, GetRandomString());
                }
                else if (propertyInfo.PropertyType == typeof (int) || propertyInfo.PropertyType == typeof (int?))
                {
                    propertyInfo.SetValue(model, GetRandomInt());
                }
                else if (propertyInfo.PropertyType == typeof (double) || propertyInfo.PropertyType == typeof (double?))
                {
                    propertyInfo.SetValue(model, GetRandomDouble());
                }
                else if (propertyInfo.PropertyType == typeof (decimal) || propertyInfo.PropertyType == typeof (decimal?))
                {
                    propertyInfo.SetValue(model, GetRandomDecimal());
                }
                else if (propertyInfo.PropertyType == typeof (DateTime) ||
                         propertyInfo.PropertyType == typeof (DateTime?))
                {
                    propertyInfo.SetValue(model, GetRandomDateTime());
                }
            }
        }

        public static bool CheckIfTwoModelsAreEqual(object modelOne, object modelTwo)
        {
            Type modelTypeOne = modelOne.GetType();
            PropertyInfo[] props = modelTypeOne.GetProperties();

            Type modelTypeTwo = modelOne.GetType();

            if (modelTypeOne.FullName != modelTypeTwo.FullName)
            {
                return false;
            }

            object val1 = null;
            object val2 = null;

            bool arePropsEqual = true;

            foreach (PropertyInfo propertyInfo in props)
            {
                KeyAttribute keyAttribute =
                    propertyInfo.GetCustomAttributes<KeyAttribute>().FirstOrDefault();

                if (keyAttribute != null)
                {
                    continue; // this is because newly created models are with 0 key;
                }

                val1 = propertyInfo.GetValue(modelOne);
                val2 = propertyInfo.GetValue(modelTwo);
                if (val1 != null && val2 != null)
                {
                    arePropsEqual = val1.ToString() == val2.ToString();
                        // this is for double and decimal types, they are problematic
                }
                else
                {
                    arePropsEqual = val1 == val2;
                }
                if (!arePropsEqual)
                {
                    return false;
                }
            }
            return true;
        }
    }
}