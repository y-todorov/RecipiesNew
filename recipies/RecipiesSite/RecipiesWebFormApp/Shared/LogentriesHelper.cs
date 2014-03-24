using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using log4net;
using Quartz;

namespace RecipiesWebFormApp.Shared
{
    public static class LogentriesHelper
    {
        public static ILog ApplicationLog;
        public static ILog QuartzJobLog;

        static LogentriesHelper()
        {
            ApplicationLog = LogManager.GetLogger(typeof(HttpApplication));
            QuartzJobLog = LogManager.GetLogger(typeof(IJob));
        }
    }
}