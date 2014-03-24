using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using InventoryManagementMVC.Models;
using Kendo.Mvc.UI;
using Kendo.Mvc.UI.Fluent;
using System.Web;
using System.Web.Mvc;
using System.Web.Security.AntiXss;
using System.Web.Util;
using System.Diagnostics;
using InventoryManagementMVC.DataAnnotations;
using RecipiesModelNS;
using System.Collections;
using System.Collections.Generic;

namespace InventoryManagementMVC.Extensions
{
    public static class GridBuilderExtension
    {
        public static IHtmlString ToMvcClientTemplate(this MvcHtmlString mvcString)
        {
            if (HttpEncoder.Current.GetType() == typeof (AntiXssEncoder))
            {
                var initial = mvcString.ToHtmlString();
                var corrected = initial.Replace("\\u0026", "&")
                    .Replace("%23", "#")
                    .Replace("%3D", "=")
                    .Replace("&#32;", " ");
                return new HtmlString(corrected);
            }

            return mvcString;
        }


        public static GridBuilder<T> AddReadOnlyOptions<T>(this GridBuilder<T> builder, bool isClient = false)
            where T : class
        {
            builder
                .AddBaseOptions()
                .Editable(editable => editable.Enabled(false))
                .AddToolbarOptions(false, false)
                .AddColumnOptions(isClient, false, false)
                .AddDataSourceOptions();

            return builder;
        }

        // It is EXTREMELY important NOT to set the name here. This is because of details grids. There name MUST be  .Name("ProductInventoryViewModelGrid_#=ProductInventoryHeaderId#")
        public static GridBuilder<T> AddBaseOptions<T>(this GridBuilder<T> builder) where T : class
        {
            Type modelEntityType = typeof (T);

            builder
                .Groupable(
                    gsb =>
                        gsb.Messages(mb => mb.Empty("Drag a column header and drop it here to group by that column"))
                            .Enabled(true))
                .Pageable(
                    pb =>
                        pb.PageSizes(new[] {5, 10, 100, 999})
                            .Refresh(true)
                            .Info(true)
                            .Enabled(true)
                            .Input(false)
                            .ButtonCount(10)
                )
                .Sortable(ssb => ssb.AllowUnsort(true).Enabled(true).SortMode(GridSortMode.SingleColumn))
                .Filterable(f => f.Extra(true)) // this is if And/Or is visible
                .Reorderable(r => r.Columns(true))
                .Resizable(resize => resize.Columns(true));
            //.Navigatable(n => n.Enabled(true))                
            //.Selectable(s => s.Enabled(true).Mode(GridSelectionMode.Single).Type(GridSelectionType.Row))
            //.ColumnMenu(gcmb => gcmb.Sortable(false).Columns(false).Filterable(false));
            return builder;
        }

        public static GridBuilder<T> AddToolbarOptions<T>(this GridBuilder<T> builder, bool isCreateVisible = true,
            bool isSaveVisible = true) where T : class
        {
            Type modelEntityType = typeof (T);
            PropertyInfo[] modelEntityProperties = modelEntityType.GetProperties();

            builder
                .ToolBar(toolbar =>
                {
                    if (isCreateVisible)
                    {
                        toolbar.Create();
                    }
                    if (isSaveVisible)
                    {
                        toolbar.Save();
                    }
                    var dic = new Dictionary<string, object>();
                    dic.Add("id", "exportToExcelLink");
                    dic.Add("onclick", "exportGridData(this)");
                    //string onclickHandler = "exportGridData(this)";


                    toolbar.Custom()
                        .Text("Export To Excel").HtmlAttributes(dic)
                        .Action("DownloadExport", "Download", new {typeName = modelEntityType.Name});
                });
            return builder;
        }

        // Problems with aggregates in client mode !!!!!!!!!!!!
        // When model is empty collection there are problems with aggregates!!!!!!!!!!!
        public static GridBuilder<T> AddColumnOptions<T>(this GridBuilder<T> builder, bool isClient = false,
            bool isDeleteColumnVisible = true,
            bool isEditColumnVisible = true, bool isSelectColumnVisible = false, bool showHiddenColumns = false)
            where T : class
        {
            Type modelEntityType = typeof (T);
            PropertyInfo[] modelEntityProperties = modelEntityType.GetProperties();

            builder
                .Columns(columns =>
                {
                    foreach (PropertyInfo propertyInfo in modelEntityProperties)
                    {
                        RelationAttribute rellAttribute =
                            propertyInfo.GetCustomAttributes<RelationAttribute>().FirstOrDefault();
                        if (rellAttribute != null)
                        {
                            // DOES NOT WORK
                            //SelectList l = new SelectList(ContextFactory.Current.Set(rellAttribute.EntityType));

                            IEnumerator enumerator =
                                ContextFactory.Current.Set(rellAttribute.EntityType).AsQueryable().GetEnumerator();
                            List<object> objects = new List<object>();

                            // THIS FIXES THE MANY QUERIES PROBLEM :) :) :)
                            while (enumerator.MoveNext())
                            {
                                objects.Add(enumerator.Current);
                            }

                            // THIS MAKES LOTS OF QUERIES TO THE DB IF WE USE ContextFactory.Current.Set(rellAttribute.EntityType), DUNNO WHY
                            if (!isClient)
                            {
                                columns.ForeignKey(propertyInfo.Name,
                                    objects, rellAttribute.DataFieldValue, rellAttribute.DataFieldText)
                                    .ClientFooterTemplate("Count: #= kendo.format('{0}', count)#")
                                    .ClientGroupFooterTemplate("Count: #= kendo.format('{0}', count)#");
                            }
                            else
                            {
                                columns.ForeignKey(propertyInfo.Name,
                                    objects, rellAttribute.DataFieldValue, rellAttribute.DataFieldText)
                                    .ClientFooterTemplate("Count: #= kendo.format('{0}', count)#".Replace("#", "\\#"))
                                    .ClientGroupFooterTemplate("Count: #= kendo.format('{0}', count)#".Replace("#",
                                        "\\#"));
                            }
                        }

                        if (propertyInfo.GetCustomAttributes<KeyAttribute>().Any()) // The primary key
                        {
                            if (!isClient)
                            {
                                columns.Bound(propertyInfo.Name).Format("{0}").Title("Id")
                                    .ClientFooterTemplate("Count: #= kendo.format('{0}', count)#")
                                    .ClientGroupFooterTemplate("Count: #= kendo.format('{0}', count)#");
                            }
                            else
                            {
                                columns.Bound(propertyInfo.Name).Title("Id")
                                    .ClientFooterTemplate("Count: #= kendo.format('{0}', count)#".Replace("#", "\\#"))
                                    .ClientGroupFooterTemplate("Count: #= kendo.format('{0}', count)#".Replace("#",
                                        "\\#"));
                            }
                        }
                        // do not show foreign key columns
                        if (propertyInfo.GetCustomAttributes<RelationAttribute>().Any() ||
                            propertyInfo.GetCustomAttributes<KeyAttribute>().Any() || // Just show the PK
                            (propertyInfo.GetCustomAttributes<HiddenInputAttribute>().Any() && !showHiddenColumns))
                        {
                            continue;
                        }

                        string customFormat = string.Empty;
                        DisplayFormatAttribute dfa =
                            propertyInfo.GetCustomAttributes<DisplayFormatAttribute>().FirstOrDefault();
                        if (dfa != null && !string.IsNullOrEmpty(dfa.DataFormatString))
                        {
                            customFormat = dfa.DataFormatString;
                        }

                        if (propertyInfo.PropertyType == typeof (bool) ||
                            propertyInfo.PropertyType == typeof (bool?))
                        {
                            if (!isClient)
                            {
                                columns.Bound(propertyInfo.Name)
                                    .ClientFooterTemplate("Count: #= kendo.format('{0}', count)#")
                                    .ClientGroupFooterTemplate("Count: #= kendo.format('{0}', count)#");
                            }
                            else
                            {
                                columns.Bound(propertyInfo.Name)
                                    .ClientFooterTemplate("Count: #= kendo.format('{0}', count)#".Replace("#", "\\#"))
                                    .ClientGroupFooterTemplate("Count: #= kendo.format('{0}', count)#".Replace("#",
                                        "\\#"));
                            }
                        }
                        if (propertyInfo.PropertyType == typeof (string))
                        {
                            GridBoundColumnBuilder<T> bldr = columns.Bound(propertyInfo.Name);
                            if (propertyInfo.Name.Equals("ModifiedByUser", StringComparison.InvariantCultureIgnoreCase))
                            {
                                bldr = bldr.Title("Mdf. By User");
                            }

                            if (!isClient)
                            {
                                bldr
                                    .ClientFooterTemplate("Count: #= kendo.format('{0}', count)#")
                                    .ClientGroupFooterTemplate("Count: #= kendo.format('{0}', count)#");
                            }
                            else
                            {
                                bldr
                                    .ClientFooterTemplate("Count: #= kendo.format('{0}', count)#".Replace("#", "\\#"))
                                    .ClientGroupFooterTemplate("Count: #= kendo.format('{0}', count)#".Replace("#",
                                        "\\#"));
                            }
                        }
                        if (propertyInfo.PropertyType == typeof (double) ||
                            propertyInfo.PropertyType == typeof (double?))
                        {
                            if (!isClient)
                            {
                                columns.Bound(propertyInfo.Name)
                                    .Format(!string.IsNullOrEmpty(customFormat) ? customFormat : "{0:N3}")
                                    .ClientFooterTemplate("Sum: #= kendo.format('{0:N3}', sum)#")
                                    .ClientGroupFooterTemplate("Sum: #= kendo.format('{0:N3}', sum)#");
                            }
                            else
                            {
                                columns.Bound(propertyInfo.Name)
                                    .Format(!string.IsNullOrEmpty(customFormat) ? customFormat : "{0:N3}")
                                    .ClientFooterTemplate("Sum: #= kendo.format('{0:N3}', sum)#".Replace("#", "\\#"))
                                    .ClientGroupFooterTemplate("Sum: #= kendo.format('{0:N3}', sum)#".Replace("#", "\\#"));
                            }
                        }
                        if (propertyInfo.PropertyType == typeof (decimal) ||
                            propertyInfo.PropertyType == typeof (decimal?))
                        {
                            if (!isClient)
                            {
                                columns.Bound(propertyInfo.Name)
                                    .Format(!string.IsNullOrEmpty(customFormat) ? customFormat : "{0:C3}")
                                    .EditorTemplateName("Currency")
                                    .ClientFooterTemplate("Sum: #= kendo.format('{0:C3}', sum)#")
                                    .ClientGroupFooterTemplate("Sum: #= kendo.format('{0:C3}', sum)#");
                            }
                            else
                            {
                                columns.Bound(propertyInfo.Name)
                                    .Format(!string.IsNullOrEmpty(customFormat) ? customFormat : "{0:C3}")
                                    .EditorTemplateName("Currency")
                                    .ClientFooterTemplate("Sum: #= kendo.format('{0:C3}', sum)#".Replace("#", "\\#"))
                                    .ClientGroupFooterTemplate("Sum: #= kendo.format('{0:C3}', sum)#".Replace("#", "\\#"));
                            }
                        }
                        if (propertyInfo.PropertyType == typeof (int) ||
                            propertyInfo.PropertyType == typeof (int?))
                        {
                            if (!isClient)
                            {
                                columns.Bound(propertyInfo.Name)
                                    .Format(!string.IsNullOrEmpty(customFormat) ? customFormat : "{0:N}")
                                    .ClientFooterTemplate("Sum: #= kendo.format('{0:N}', sum)#")
                                    .ClientGroupFooterTemplate("Sum: #= kendo.format('{0:N}', sum)#");
                            }
                            else
                            {
                                columns.Bound(propertyInfo.Name)
                                    .Format(!string.IsNullOrEmpty(customFormat) ? customFormat : "{0:N}")
                                    .ClientFooterTemplate("Sum: #= kendo.format('{0:N}', sum)#".Replace("#", "\\#"))
                                    .ClientGroupFooterTemplate("Sum: #= kendo.format('{0:N}', sum)#".Replace("#", "\\#"));
                            }
                        }
                        if (propertyInfo.PropertyType == typeof (DateTime) ||
                            propertyInfo.PropertyType == typeof (DateTime?))
                        {
                            GridBoundColumnBuilder<T> bldr = columns.Bound(propertyInfo.Name);
                            if (propertyInfo.Name.Equals("ModifiedDate", StringComparison.InvariantCultureIgnoreCase))
                            {
                                bldr = bldr.Title("Mdf. Date");
                            }

                            if (!isClient)
                            {
                                if (propertyInfo.Name.Equals("ModifiedDate", StringComparison.InvariantCultureIgnoreCase))
                                {
                                    bldr
                                        .Format(!string.IsNullOrEmpty(customFormat)
                                            ? customFormat
                                            : "{0:dd/MM/yyyy HH:mm:ss}")
                                        .ClientFooterTemplate("Count: #= kendo.format('{0}', count)#")
                                        .ClientGroupFooterTemplate("Count: #= kendo.format('{0}', count)#");
                                }
                                else
                                {
                                    bldr
                                        .Format(!string.IsNullOrEmpty(customFormat) ? customFormat : "{0:dd/MM/yyyy}")
                                        .EditorTemplateName("Date")
                                        .ClientFooterTemplate("Count: #= kendo.format('{0}', count)#")
                                        .ClientGroupFooterTemplate("Count: #= kendo.format('{0}', count)#");
                                }
                            }
                            else
                            {
                                if (propertyInfo.Name.Equals("ModifiedDate", StringComparison.InvariantCultureIgnoreCase))
                                {
                                    bldr
                                        .Format(!string.IsNullOrEmpty(customFormat)
                                            ? customFormat
                                            : "{0:dd/MM/yyyy HH:mm:ss}")
                                        .ClientFooterTemplate("Count: #= kendo.format('{0}', count)#".Replace("#", "\\#"))
                                        .ClientGroupFooterTemplate("Count: #= kendo.format('{0}', count)#".Replace("#",
                                            "\\#"));
                                }
                                else
                                {
                                    bldr
                                        .Format(!string.IsNullOrEmpty(customFormat) ? customFormat : "{0:dd/MM/yyyy}")
                                        .EditorTemplateName("Date")
                                        .ClientFooterTemplate("Count: #= kendo.format('{0}', count)#".Replace("#", "\\#"))
                                        .ClientGroupFooterTemplate("Count: #= kendo.format('{0}', count)#".Replace("#",
                                            "\\#"));
                                }
                            }
                        }
                    }

                    if (isDeleteColumnVisible || isEditColumnVisible || isSelectColumnVisible)
                    {
                        columns.Command(command =>
                        {
                            if (isDeleteColumnVisible)
                            {
                                command.Destroy().Text("Delete");
                            }
                            if (isEditColumnVisible)
                            {
                                command.Edit().Text("Edit");
                            }
                            if (isSelectColumnVisible)
                            {
                                command.Select().Text("Select");
                            }
                        }); //.ClientFooterTemplate("Delete");
                    }
                });
            return builder;
        }

        public static GridBuilder<T> AddDataSourceOptions<T>(this GridBuilder<T> builder, bool isBatch = true)
            where T : class
        {
            Type modelEntityType = typeof (T);
            PropertyInfo[] modelEntityProperties = modelEntityType.GetProperties();

            PropertyInfo idPropertyInfo =
                modelEntityProperties.FirstOrDefault(pi => pi.GetCustomAttributes<KeyAttribute>().Any());
            if (idPropertyInfo == null)
            {
                throw new ApplicationException(string.Format(
                    "The entity {0} does not have a key. You should add a KeyAttribute to a property to denote it as a primary key!",
                    modelEntityType.FullName));
            }

            string idName = idPropertyInfo.Name;
            builder
                .DataSource(dataSource => dataSource
                    .Ajax()
                    .Batch(isBatch)
                    .PageSize(5)
                    .Model(
                        model =>
                        {
                            model.Id(idName);
                            model.Field(idName, typeof (int)).Editable(false);
                            model.Field("ModifiedDate", typeof (DateTime?)).Editable(false);
                            model.Field("ModifiedByUser", typeof (string)).Editable(false);
                            foreach (PropertyInfo propertyInfo in modelEntityProperties)
                            {
                                if (propertyInfo.Name != idName && propertyInfo.Name != "ModifiedDate" &&
                                    propertyInfo.Name != "ModifiedByUser")
                                {
                                    model.Field(propertyInfo.Name, propertyInfo.PropertyType)
                                        .DefaultValue(GetDefaultValueForType(propertyInfo.PropertyType));
                                }
                                RelationAttribute rellAttribute =
                                    propertyInfo.GetCustomAttributes<RelationAttribute>().FirstOrDefault();
                                if (rellAttribute != null)
                                {
                                    model.Field(propertyInfo.Name, propertyInfo.PropertyType).DefaultValue(-1);
                                    IEnumerator enumerator =
                                        ContextFactory.Current.Set(rellAttribute.EntityType)
                                            .AsQueryable()
                                            .GetEnumerator();
                                    if (enumerator.MoveNext())
                                    {
                                        var obj = enumerator.Current;
                                        if (obj != null)
                                        {
                                            Type objType = obj.GetType();
                                            PropertyInfo pi = objType.GetProperty(rellAttribute.DataFieldValue);
                                            if (pi != null)
                                            {
                                                object val = pi.GetValue(obj);
                                                model.Field(propertyInfo.Name, propertyInfo.PropertyType)
                                                    .DefaultValue(val);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    )
                    .Sort(sd =>
                    {
                        // Just show default dorting
                        //sd.Add(idName).Ascending(); 
                    })


                    // this is for editing and deleting
                    .Aggregates(a =>
                    {
                        Type[] numericTypes = new Type[]
                        {
                            typeof (int), typeof (int?), typeof (double), typeof (double?), typeof (float),
                            typeof (float?),
                            typeof (decimal), typeof (decimal?)
                        };
                        foreach (PropertyInfo pi in modelEntityProperties)
                        {
                            if (numericTypes.Contains(pi.PropertyType))
                            {
                                a.Add(pi.Name, pi.PropertyType).Average().Count().Max().Min().Sum();
                            }
                            else
                            {
                                a.Add(pi.Name, pi.PropertyType).Count();
                            }
                        }
                    })
                    .ServerOperation(false) // This must be false so aggregates can appear.
                    .Events(events => events.Error("error_handler")));
            return builder;
        }

        public static GridBuilder<T> AddDefaultOptions<T>(this GridBuilder<T> builder, bool isClient = false,
            bool showHiddenColumns = false, bool isCreateVisible = true)
            where T : class
        {
            Stopwatch s = new Stopwatch();
            s.Start();

            builder
                // THIS WILL BE FOR SIGNAL R
                //.Events(ev => ev.SaveChanges("saveChanges"))
                .AddBaseOptions()
                .Editable(editable => editable.Mode(GridEditMode.InCell))
                .AddToolbarOptions(isCreateVisible)
                .AddColumnOptions(isClient, true, false, false, showHiddenColumns)
                .AddDataSourceOptions();

            s.Stop();
            var mils = s.ElapsedMilliseconds;

            return builder;
        }

        public static GridBuilder<T> AddDefaultOptionsPopUpEdit<T>(this GridBuilder<T> builder) where T : class
        {
            builder
                // THIS WILL BE FOR SIGNAL R
                //.Events(ev => ev.SaveChanges("saveChanges"))
                .AddBaseOptions()
                .Editable(editable => editable.Mode(GridEditMode.PopUp))
                .AddToolbarOptions(true, true)
                .AddColumnOptions(true, false, false)
                .AddDataSourceOptions(false);

            return builder;
        }

        private static object GetDefaultValueForType(Type t)
        {
            if (t == typeof (DateTime) || t == typeof (DateTime?))
            {
                return DateTime.Now;
            }

            Type baseType = Nullable.GetUnderlyingType(t);
            if (baseType != null)
            {
                return Activator.CreateInstance(baseType);
            }
            if (t.IsValueType)
            {
                return Activator.CreateInstance(t);
            }
            return null;
        }
    }
}