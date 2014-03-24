using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quartz;
using RecipiesWebFormApp.Shared;

namespace RecipiesWebFormApp.Quartz.Jobs
{
    public class JobBase : IJob
    {
        public virtual void Execute(IJobExecutionContext context)
        {
            if (context != null && context.JobDetail != null)
            {
                LogentriesHelper.QuartzJobLog.InfoFormat("Started job with key '{0}' and description '{1}'",
                    context.JobDetail.Key, context.JobDetail.Description);
            }
        }
    }
}