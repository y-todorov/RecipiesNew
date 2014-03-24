using RecipiesModelNS;
using System;
using System.Web.UI.WebControls;

namespace YordanCustomControls
{
    public class YordanCustomOpenAccessLinqDataSource : EntityDataSource //OpenAccessLinqDataSource
    {
        public YordanCustomOpenAccessLinqDataSource()
        {
            //if (WhereParameters.Count > 0)
            //{
            //    AutoGenerateWhereClause = true; // MUST BE TESTED ????
            //    Where = null;
            //}

            if (string.IsNullOrEmpty(ConnectionString))
            {
                ConnectionString = "name=recipiesEntities";
            }
            if (string.IsNullOrEmpty(DefaultContainerName))
            {
                DefaultContainerName = "RecipiesEntities";
            }
            //ContextTypeName = typeof(RecipiesEntities).FullName; // string.Empty;
            EnableDelete = true;
            EnableInsert = true;
            EnableUpdate = true;


            // These events will fire first. Next will fire the events in custom pages that this control resides.
            Inserting += YordanCustomOpenAccessLinqDataSource_Inserting;
            Inserted += YordanCustomOpenAccessLinqDataSource_Inserted;

            Updating += YordanCustomOpenAccessLinqDataSource_Updating;
            Updated += YordanCustomOpenAccessLinqDataSource_Updated;

            Deleting += YordanCustomOpenAccessLinqDataSource_Deleting;
            Deleted += YordanCustomOpenAccessLinqDataSource_Deleted;

            ContextCreating += YordanCustomOpenAccessLinqDataSource_ContextCreating;
        }

        private void YordanCustomOpenAccessLinqDataSource_ContextCreating(object sender,
            EntityDataSourceContextCreatingEventArgs e)
        {
            //RecipiesEntities recipiesEntities = new RecipiesEntities();
            //e.Context = ((IObjectContextAdapter)recipiesEntities).ObjectContext;
        }

        private void YordanCustomOpenAccessLinqDataSource_Deleted(object sender, EntityDataSourceChangedEventArgs e)
        {
            YordanBaseEntity ybe = e.Entity as YordanBaseEntity;
            // object ob = ViewState["test"]; NO USE
            if (ybe != null)
            {
                ybe.Removed();
            }
        }

        private void YordanCustomOpenAccessLinqDataSource_Deleting(object sender, EntityDataSourceChangingEventArgs e)
        {
            YordanBaseEntity ybe = e.Entity as YordanBaseEntity;
            //ViewState.Add("test", ybe); NO use
            if (ybe != null)
            {
                ybe.Removing();
            }
        }

        private void YordanCustomOpenAccessLinqDataSource_Updated(object sender, EntityDataSourceChangedEventArgs e)
        {
            YordanBaseEntity ybe = e.Entity as YordanBaseEntity;
            if (ybe != null)
            {
                ybe.Changed();
            }
        }

        private void YordanCustomOpenAccessLinqDataSource_Updating(object sender, EntityDataSourceChangingEventArgs e)
        {
            YordanBaseEntity ybe = e.Entity as YordanBaseEntity;
            if (ybe != null)
            {
                ybe.Changing();
            }
        }

        private void YordanCustomOpenAccessLinqDataSource_Inserted(object sender, EntityDataSourceChangedEventArgs e)
        {
            YordanBaseEntity ybe = e.Entity as YordanBaseEntity;
            if (ybe != null)
            {
                ybe.Added();
            }
        }

        private void YordanCustomOpenAccessLinqDataSource_Inserting(object sender, EntityDataSourceChangingEventArgs e)
        {
            YordanBaseEntity ybe = e.Entity as YordanBaseEntity;
            if (ybe != null)
            {
                ybe.Adding();
            }
        }


        protected override void OnInit(EventArgs e)
        {
            if (WhereParameters.Count > 0)
            {
                AutoGenerateWhereClause = true; // MUST BE TESTED ????
                Where = null;
            }

            //if (string.IsNullOrEmpty(ConnectionString))
            //{
            //    ConnectionString = "name=recipiesEntities";
            //}
            //if (string.IsNullOrEmpty(DefaultContainerName))
            //{
            //    DefaultContainerName = "RecipiesEntities";
            //}
            //ContextTypeName = string.Empty;
            //EnableDelete = true;
            //EnableInsert = true;
            //EnableUpdate = true; 

            base.OnInit(e);
        }
    }
}