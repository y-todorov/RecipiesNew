using RecipiesModelNS;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Infrastructure;
using System.Data.Metadata.Edm;
using System.Data.SqlClient;
using System.Linq;
using System.Timers;
using System.Web;
using System.Web.Caching;

namespace RecipiesWebFormApp
{
    public static class DatabaseTableChangeWatcher
    {
        static DatabaseTableChangeWatcher()
        {
            sqlConn = new SqlConnection(ContextFactory.Current.Database.Connection.ConnectionString);
            command = new SqlCommand();
            command.Connection = sqlConn;
        }

        private static DateTime? lastProductChangeDate;
        public static event Action<object, EventArgs> DatabaseChange;

        public static CacheDependency ProductCacheDependencyObject;


        private static SqlConnection sqlConn;
        private static SqlCommand command;

        public static void StartWathching(int seconds)
        {
            Timer timer = new Timer(1000 * seconds);
            timer.Elapsed += timer_Elapsed;
            timer.Start();
        }

        private static void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            //using (SqlConnection sqlConn = new SqlConnection(ContextFactory.Current.Database.Connection.ConnectionString))
            {
                //using (DbCommand command = new SqlCommand())
                {
                    // ONLY FOR PRODDUCTS TABLE
                    //                    command.CommandText = @"SELECT last_user_update
                    //FROM sys.dm_db_index_usage_stats
                    //WHERE database_id = DB_ID( 'recipies')
                    //AND OBJECT_ID=OBJECT_ID('Production.Product')"; 


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

                        DateTime date = (DateTime)command.ExecuteScalar();
                        if (!lastProductChangeDate.HasValue)
                        {
                            lastProductChangeDate = date;
                        }
                        else
                        {
                            if (lastProductChangeDate.GetValueOrDefault() != date)
                            {
                                lastProductChangeDate = date;
                                if (DatabaseChange != null)
                                {
                                    DatabaseChange(null, new EventArgs());
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
        }
    }
}