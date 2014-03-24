using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;

namespace RecipiesWebFormApp.Caching
{
    public class CacheDependencyManager
    {
        static CacheDependencyManager()
        {
            Instance = new CacheDependencyManager();
        }

        public static CacheDependencyManager Instance;


        private Dictionary<string, ExplicitCacheDependency> _dependencies
            = new Dictionary<string, ExplicitCacheDependency>();

        public CacheDependency GetCacheDependency(string key)
        {
            if (!_dependencies.ContainsKey(key))
                _dependencies.Add(key, new ExplicitCacheDependency(key));

            return _dependencies[key];
        }

        public void InvalidateDependency(string key)
        {
            if (_dependencies.ContainsKey(key))
            {
                var dependency = _dependencies[key];
                dependency.Invalidate();
                dependency.Dispose();
                _dependencies.Remove(key);
            }
        }
    }
}