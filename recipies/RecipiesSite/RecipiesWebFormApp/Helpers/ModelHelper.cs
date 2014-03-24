using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecipiesWebFormApp.Helpers
{
    public static class ModelHelper
    {
        ///
        public static double GetGp(double productionCost, double sellValue)
        {
            //((isnull(isnull([SellValuePerPortion],(0))/(1.09)-isnull([ProductionValuePerPortion],(0)),(0.00))/isnull([SellValuePerPortion],(1)))*(1.09))
            if (Math.Round(sellValue, 5) == 0)
            {
                return 0;
            }

            double result = ((sellValue/1.09 - productionCost)/sellValue) * 1.09;
            return result;
        }

        // ((isnull(isnull([SellValuePerPortion],(0))/(1.09)-isnull([ProductionValuePerPortion],(0)),(0.00))/isnull([SellValuePerPortion],(1)))*(1.09))
    }
}