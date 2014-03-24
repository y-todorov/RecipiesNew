namespace RecipiesModelNS
{
    public enum PurchaseOrderStatusEnum : int
    {
        Pending = 1,
        Approved = 2,
        Rejected = 3,
        Completed = 4
    }

    public enum SalesOrderStatusEnum
    {
        None = 0,
        Approved = 2,
        Canceled = 6
    }


    //public partial class RecipiesModel
    //{
    //    protected override void Init(string connectionString, BackendConfiguration backendConfiguration, MetadataContainer metadataContainer)
    //    {
    //        base.Init(connectionString, backendConfiguration, metadataContainer);

    //        Events.Adding += Events_Adding;
    //        Events.Added += Events_Added;
    //        Events.Changing += Events_Changing;
    //        Events.Changed += Events_Changed;
    //        Events.Removing += Events_Removing;
    //        Events.Removed += Events_Removed;            
    //    }

    //    void Events_Adding(object sender, AddEventArgs e)
    //    {
    //        Events.Adding -= Events_Adding;

    //        YordanBaseEntity yordanBaseEntity = e.PersistentObject as YordanBaseEntity;
    //        if (yordanBaseEntity != null)
    //        {
    //            yordanBaseEntity.Adding(this, e);
    //        }

    //        Events.Adding += Events_Adding;
    //    }

    //    void Events_Added(object sender, AddEventArgs e)
    //    {
    //        Events.Added -= Events_Added;

    //        YordanBaseEntity yordanBaseEntity = e.PersistentObject as YordanBaseEntity;
    //        if (yordanBaseEntity != null)
    //        {
    //            yordanBaseEntity.Added(this, e);
    //        }

    //        Events.Added += Events_Added;
    //    }
    //    void Events_Changing(object sender, ChangeEventArgs e)
    //    {
    //        Events.Changing -= Events_Changing;

    //         YordanBaseEntity yordanBaseEntity = e.PersistentObject as YordanBaseEntity;
    //         if (yordanBaseEntity != null)
    //         {
    //             yordanBaseEntity.Changing(this, e);
    //         }

    //        Events.Changing += Events_Changing;
    //    }

    //    void Events_Changed(object sender, ChangeEventArgs e)
    //    {
    //        Events.Changed -= Events_Changed;

    //        YordanBaseEntity yordanBaseEntity = e.PersistentObject as YordanBaseEntity;
    //        if (yordanBaseEntity != null)
    //        {
    //            yordanBaseEntity.Changed(this, e);
    //        }
    //        Events.Changed += Events_Changed;
    //    }

    //    void Events_Removing(object sender, RemoveEventArgs e)
    //    {
    //        Events.Removing -= Events_Removing;

    //        YordanBaseEntity yordanBaseEntity = e.PersistentObject as YordanBaseEntity;
    //        if (yordanBaseEntity != null)
    //        {
    //            yordanBaseEntity.Removing(this, e);
    //        }

    //        Events.Removing += Events_Removing;
    //    }

    //    void Events_Removed(object sender, RemoveEventArgs e)
    //    {
    //        Events.Removed -= Events_Removed;

    //        YordanBaseEntity yordanBaseEntity = e.PersistentObject as YordanBaseEntity;
    //        if (yordanBaseEntity != null)
    //        {
    //            yordanBaseEntity.Removed(this, e);
    //        }

    //        Events.Removed += Events_Removed;
    //    }

    //    protected override IQueryable<T> GetAllCore<T>()
    //    {
    //        Stopwatch stopwatch = new Stopwatch();
    //        stopwatch.Start();
    //        IQueryable<T> result = base.GetAllCore<T>();
    //        stopwatch.Stop();
    //        long mills = stopwatch.ElapsedMilliseconds;
    //        return result;
    //    }

    //    public override void SaveChanges(ConcurrencyConflictsProcessingMode failureMode)
    //    {
    //        PopulateHistoryTables();

    //        List<object> inserts = this.GetChanges().GetInserts<object>().ToList();
    //        List<object> updates = this.GetChanges().GetUpdates<object>().ToList();
    //        List<object> deletes = this.GetChanges().GetDeletes<object>().ToList();

    //        inserts.OfType<YordanBaseEntity>().ToList().ForEach(ybe => ybe.BeforeInsert(this));
    //        updates.OfType<YordanBaseEntity>().ToList().ForEach(ybe => ybe.BeforeUpdate(this));
    //        deletes.OfType<YordanBaseEntity>().ToList().ForEach(ybe => ybe.BeforeDelete(this));          

    //        base.SaveChanges(failureMode);


    //    }

    //    private void PopulateHistoryTables()
    //    {
    //        IList<object> listOfProductInserts = this.GetChanges().GetInserts<object>();
    //        IList<object> listOfProductUpdates = this.GetChanges().GetUpdates<object>();
    //        IList<object> listOfProductDeletes = this.GetChanges().GetDeletes<object>();

    //        IEnumerable<object> combinedListOfProducts = listOfProductInserts.Concat(listOfProductUpdates).Concat(listOfProductDeletes);
    //        if (combinedListOfProducts.Count() > 0)
    //        {
    //            //PubNubMessaging.Core.Pubnub.Instance.Publish("Products", "rebind", (t) => t.ToString(), (t) => t.ToString());
    //        }
    //        foreach (object obj in combinedListOfProducts)
    //        {
    //            object historyEntity = GetHistoryObjectForEntity(obj);
    //            if (historyEntity != null)
    //            {
    //                var productFields = obj.GetType().GetFields(BindingFlags.Instance |
    //                       BindingFlags.Static |
    //                       BindingFlags.NonPublic |
    //                       BindingFlags.Public);
    //                var productProperties = obj.GetType().GetProperties();

    //                var productHistoryFields = historyEntity.GetType().GetFields(BindingFlags.Instance |
    //                       BindingFlags.Static |
    //                       BindingFlags.NonPublic |
    //                       BindingFlags.Public);
    //                var productHistoryProperties = historyEntity.GetType().GetProperties();

    //                this.Add(historyEntity);

    //                foreach (FieldInfo field in productFields)
    //                {
    //                    // Check if this is actual property
    //                    if (productProperties.Any(p => ("_" + p.Name).Equals(field.Name, StringComparison.InvariantCultureIgnoreCase)))
    //                    {
    //                        //object theValue = prop.GetValue(product); This is property and we get exception when deleting products
    //                        var field2 = productHistoryFields.FirstOrDefault(f => f.Name.Equals(field.Name));
    //                        if (field2 != null)
    //                        {
    //                            try
    //                            {
    //                                object theValue = field.GetValue(obj);
    //                                historyEntity.SetFieldValue(field.Name, theValue);
    //                            }
    //                            catch (Exception)
    //                            {

    //                            }
    //                        }
    //                    }

    //                }
    //            }
    //        }
    //    }

    //    private object GetHistoryObjectForEntity(object obj)
    //    {
    //        if (obj is Product)
    //        {
    //            return new ProductHistory();
    //        }
    //        return null;
    //    }

    //}
}