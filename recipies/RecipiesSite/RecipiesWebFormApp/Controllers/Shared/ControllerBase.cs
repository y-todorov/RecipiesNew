using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Reflection;
using System.Web.UI;
using Autofac;
using DevTrends.MvcDonutCaching;
using DevTrends.MvcDonutCaching.Annotations;
using InventoryManagementMVC.DataAnnotations;
using InventoryManagementMVC.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using RecipiesModelNS;
using RecipiesWebFormApp.Caching;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Collections;
using log4net;

namespace InventoryManagementMVC.Controllers
{
    //[DonutOutputCache(Duration = 24 * 3600,
    //    Options = OutputCacheOptions.IgnoreFormData | OutputCacheOptions.NoCacheLookupForPosts)]

    // when inserting new product it does not appear in product vendors becaouse of this cache


     //[DonutOutputCache(Duration = 24 * 3600)] // NEVER EVER CACHE POST REQUESTS !!! That is deletes, updates and inserts
    public class ControllerBase : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
        }

        protected override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            base.OnResultExecuting(filterContext);
        }


        protected override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            base.OnResultExecuted(filterContext);
        }
        protected override JsonResult Json(object data, string contentType, System.Text.Encoding contentEncoding,
            JsonRequestBehavior behavior)
        {
            JsonResult jr = base.Json(data, contentType, contentEncoding, behavior);
            jr.MaxJsonLength = int.MaxValue;
            return jr;
        }

        protected override JsonResult Json(object data, string contentType, System.Text.Encoding contentEncoding)
        {
            JsonResult jr = base.Json(data, contentType, contentEncoding);
            jr.MaxJsonLength = int.MaxValue;
            return jr;
        }

        public ActionResult ReadBase([DataSourceRequest] DataSourceRequest request, Type modelType, Type entityType, IEnumerable<object> entities)
        {
            DbSet dbset = ContextFactory.Current.Set(entityType);
            dbset.Load();
            var en = dbset.Local.GetEnumerator();

            List<object> result = new List<object>();

            foreach (object entity in entities)
            {
                dynamic newModel = Activator.CreateInstance(modelType);
                dynamic newEntity = Activator.CreateInstance(entityType);
                newEntity = entity;
                var modelToAdd = newModel.ConvertFromEntity(newEntity);
                result.Add(modelToAdd);
            }

            DataSourceResult dataSourceResult = result.ToDataSourceResult(request);
            return Json(dataSourceResult);
        }

        public ActionResult CreateBase([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")] IEnumerable<object> models, Type modelType, Type entityType)
        {
            if (models != null && ModelState.IsValid)
            {
                DbSet dbset = ContextFactory.Current.Set(entityType);

                Hashtable entitiesHash = new Hashtable();
                foreach (object model in models)
                {
                    dynamic newModel = model;
                    dynamic newEntity = Activator.CreateInstance(entityType);

                    newModel.ConvertToEntity(newEntity);

                    dbset.Add(newEntity);

                    entitiesHash.Add(newEntity, model);
                }

                ContextFactory.Current.SaveChanges();

                dynamic dummyEntity = Activator.CreateInstance(entityType);
                for (int i = 0; i < entitiesHash.Keys.Count; i++)
                {
                    dummyEntity = entitiesHash.Keys.Cast<object>().ElementAt(i);
                    dynamic model = entitiesHash[dummyEntity];
                    model.ConvertFromEntity(dummyEntity);
                }
            }
            DataSourceResult dataSourceResult = models.ToList().ToDataSourceResult(request, ModelState);

            return Json(dataSourceResult);
        }

        public ActionResult UpdateBase([DataSourceRequest] DataSourceRequest request,
            [Bind(Prefix = "models")] IEnumerable<object> models, Type modelType, Type entityType)
        {
            if (models != null && ModelState.IsValid)
            {
                List<object> entitiesToUpdate = GetEntitiesFromModels(models, modelType, entityType);

                DbSet dbset = ContextFactory.Current.Set(entityType);

                Hashtable entitiesHash = new Hashtable();

                foreach (object entity in entitiesToUpdate)
                {
                    if (entity != null)
                    {
                        dynamic newEntity = Activator.CreateInstance(entityType);
                        newEntity = entity;
                        dynamic model = models.FirstOrDefault(m => AreObjectsWithTheSameId(newEntity, m));
                        if (model != null)
                        {
                            model.ConvertToEntity(newEntity);
                            entitiesHash.Add(newEntity, model);
                        }
                    }
                }

                ContextFactory.Current.SaveChanges();

                foreach (dynamic entity in entitiesToUpdate)
                {
                    dynamic model = entitiesHash[entity];
                    model.ConvertFromEntity(entity); 
                }
            }
            DataSourceResult dataSourceResult = models.ToDataSourceResult(request, ModelState);
            return Json(dataSourceResult);

        }
        
        public ActionResult DestroyBase([DataSourceRequest] DataSourceRequest request,
            [Bind(Prefix = "models")] IEnumerable<object> models, Type modelType, Type entityType)
        {
            if (models.Any())
            {
                List<object> entitiesToDelete = GetEntitiesFromModels(models, modelType, entityType);
                DbSet dbset = ContextFactory.Current.Set(entityType);

                foreach (var entityToDelete in entitiesToDelete)
                {
                    if (entityToDelete != null)
                    {
                        dbset.Remove(entityToDelete);
                    }
                }
                ContextFactory.Current.SaveChanges();
            }

            DataSourceResult dataSourceResult = models.ToDataSourceResult(request, ModelState);
            return Json(dataSourceResult);
        }

        private List<object> GetEntitiesFromModels(IEnumerable<object> models, Type modelType, Type entityType)
        { 
            List<object> entities = new List<object>();
            if (models.Any())
            {
                var props = modelType.GetProperties();
                PropertyInfo keyProperty = null;
                foreach (var propertyInfo in props)
                {
                    KeyAttribute keyAttribute =
                        propertyInfo.GetCustomAttributes<KeyAttribute>().FirstOrDefault();
                    if (keyAttribute != null)
                    {
                        keyProperty = propertyInfo;
                        break;
                    }
                }

                DbSet dbset = ContextFactory.Current.Set(entityType);
                foreach (object model in models)
                {
                    object key = keyProperty.GetValue(model);

                    object entity = dbset.Find(new[] {key});
                    entities.Add(entity);
                }
            }

            return entities;
        }

        private bool AreObjectsWithTheSameId(object entity, object model)
        {
            Type modelType = model.GetType();
            var modelProps = modelType.GetProperties();
            PropertyInfo modelKeyProperty = null;
            foreach (var propertyInfo in modelProps)
            {
                KeyAttribute keyAttribute =
                    propertyInfo.GetCustomAttributes<KeyAttribute>().FirstOrDefault();
                if (keyAttribute != null)
                {
                    modelKeyProperty = propertyInfo;
                    break;
                }
            }

            Type entityType = entity.GetType();
            var entityProps = entityType.GetProperties();
            PropertyInfo entityKeyProperty = null;
            foreach (var propertyInfo in entityProps)
            {
                if (propertyInfo.Name.Equals(modelKeyProperty.Name, StringComparison.InvariantCultureIgnoreCase)) // this fixes CustomerId == CustomerID
                {
                    entityKeyProperty = propertyInfo;
                    break;
                }
            }

            object modelKey = modelKeyProperty.GetValue(model);
            object entityKey = entityKeyProperty.GetValue(entity);

            if (modelKey.ToString() == entityKey.ToString())
            {
                return true;
            }
            return false;

        }

    }
}