using DevTrends.MvcDonutCaching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecipiesWebFormApp.Caching
{
    public class MyCacheManager
    {
        static MyCacheManager()
        {
            Instance = new OutputCacheManager();
        }

        public static OutputCacheManager Instance;
    }
}