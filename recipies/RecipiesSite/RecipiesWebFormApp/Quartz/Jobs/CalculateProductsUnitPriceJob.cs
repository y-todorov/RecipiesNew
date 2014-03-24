using Quartz;
using RecipiesModelNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecipiesWebFormApp.Quartz.Jobs
{
    public class CalculateProductsUnitPriceJob : JobBase
    {
        public override void Execute(IJobExecutionContext context)
        {
            Product.UpdateUnitPriceOfAllProducts();
            base.Execute(context);
        }
    }
}