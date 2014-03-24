using System.Data.SqlClient;
using System.Reflection;
using System.Web.Mvc;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RecipiesModelNS;
using RecipiesWebFormApp.Caching;

namespace RecipiesWebFormApp.Quartz.Jobs
{
    public class CheckDatabaseForChangesJob : JobBase
    {

        static CheckDatabaseForChangesJob()
        {
            sqlConn = new SqlConnection(ContextFactory.Current.Database.Connection.ConnectionString);
            command = new SqlCommand();
            command.Connection = sqlConn;
        }

        private static SqlConnection sqlConn;
        private static SqlCommand command;

        private static DateTime? lastProductChangeDate;
        public override void Execute(IJobExecutionContext context)
        {
            // Entire database 
            command.CommandText = @"SELECT  max(last_user_update) last_user_update
FROM sys.dm_db_index_usage_stats
WHERE database_id = DB_ID( 'recipies')";
            try
            {
                if (command.Connection.State != System.Data.ConnectionState.Open)
                {
                    sqlConn = new SqlConnection(ContextFactory.Current.Database.Connection.ConnectionString);
                    command.Connection = sqlConn;
                    command.Connection.Open();
                }

                if (command.Connection.State != System.Data.ConnectionState.Open)
                {
                    return;
                }

                object rowDate = command.ExecuteScalar();
                if (rowDate == DBNull.Value)
                {
                    return;
                }
            
                DateTime date = (DateTime)rowDate;
                if (!lastProductChangeDate.HasValue)
                {
                    lastProductChangeDate = date;
                }
                else
                {
                    if (lastProductChangeDate.GetValueOrDefault() != date)
                    {
                        lastProductChangeDate = date;
                        MyCacheManager.Instance.RemoveItems();
                        
                        // Yordan : caching of objects cannot be achieved this way !!!
                        //var controllersType = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.ReflectedType != null &&
                        //                                                                            t.ReflectedType.BaseType.Name ==
                        //                                                                            typeof(ControllerBase).Name)
                        //    .ToList();

                        //foreach (Type ct in controllersType)
                        //{
                        //    string controllerFullName = ct.ReflectedType.Name;
                        //    string controllerName = controllerFullName.Substring(0, controllerFullName.IndexOf("Controller"));

                        //    var instance = Activator.CreateInstance(ct.ReflectedType);
                        //    var method = ct.ReflectedType.GetMethod("Index");
                        //    if (method != null)
                        //    {
                        //        var res = method.Invoke(instance, null);
                        //    }
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
            }
            // do not call this for now
            //base.Execute(context);
        }

    }
}