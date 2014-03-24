using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;

namespace RecipiesWebFormApp.Caching
{
    public class ExplicitCacheDependency : CacheDependency
    {
        private string _uniqueId;

        public ExplicitCacheDependency(string uniqueId)
            : base(new string[0]) //no file system dependencies
        {
            _uniqueId = uniqueId;
        }

        public override string GetUniqueID()
        {
            return _uniqueId;
        }

        public void Invalidate()
        {
            base.NotifyDependencyChanged(this, EventArgs.Empty);
        }
    }
}