using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Timers;

namespace RecipiesModelNS
{
    public partial class RecipiesEntities : DbContext
    {
        public RecipiesEntities(bool contextOwnsConnection)
            : base(new System.Data.EntityClient.EntityConnection("name=RecipiesEntities"), contextOwnsConnection)
        {
            this.Configuration.AutoDetectChangesEnabled = false;
        }

        protected override System.Data.Entity.Validation.DbEntityValidationResult ValidateEntity(
            System.Data.Entity.Infrastructure.DbEntityEntry entityEntry, IDictionary<object, object> items)
        {
            return base.ValidateEntity(entityEntry, items);
        }

        protected override bool ShouldValidateEntity(System.Data.Entity.Infrastructure.DbEntityEntry entityEntry)
        {
            return base.ShouldValidateEntity(entityEntry);
        }

        private int saveChangesHits = 0;

        public override int SaveChanges()
        {
            saveChangesHits++;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            ChangeTracker.DetectChanges();
            IEnumerable<DbEntityEntry> entries = ChangeTracker.Entries();
            sw.Stop();
            long mils = sw.ElapsedMilliseconds;

            List<YordanBaseEntity> addedEntities = new List<YordanBaseEntity>();
            List<YordanBaseEntity> modifiedEntities = new List<YordanBaseEntity>();
            List<YordanBaseEntity> deletedEntities = new List<YordanBaseEntity>();


            foreach (DbEntityEntry entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    YordanBaseEntity ybe = entry.Entity as YordanBaseEntity;
                    if (ybe != null)
                    {
                        ybe.Adding(entry);
                        addedEntities.Add(ybe);
                    }
                }
                else if (entry.State == EntityState.Deleted)
                {
                    YordanBaseEntity ybe = entry.Entity as YordanBaseEntity;
                    if (ybe != null)
                    {
                        ybe.Removing(entry);
                        deletedEntities.Add(ybe);
                    }
                }
                else if (entry.State == EntityState.Modified)
                {
                    YordanBaseEntity ybe = entry.Entity as YordanBaseEntity;
                    if (ybe != null)
                    {
                        ybe.Changing(entry);
                        modifiedEntities.Add(ybe);
                    }
                }
            }
            int result = base.SaveChanges();

            // THIS HERE IS REALLY PROBLEMATIC AND REALLY SLOW BECAUSE OF THE RECURSION -> SAVE CHANGES IS CALLED MANY MANY TIMES

            //foreach (YordanBaseEntity ybe in addedEntities)
            //{
            //    ybe.Added();
            //}
            //foreach (YordanBaseEntity ybe in modifiedEntities)
            //{
            //    ybe.Changed();
            //}
            foreach (YordanBaseEntity ybe in deletedEntities)
            {
                ybe.Removed();
            }

            // Mega test
            //ContextFactory.RemoveFromCache();

            return result;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}