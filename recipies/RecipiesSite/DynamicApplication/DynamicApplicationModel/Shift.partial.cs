using System;
using System.Data.Entity.Infrastructure;

namespace RecipiesModelNS
{
    public partial class Shift : YordanBaseEntity
    {
        public override void Adding(DbEntityEntry e)
        {
            Shift shift = this;
            if (shift.StartHour.HasValue)
            {
                shift.StartHour = new DateTime(2000, 1, 1).
                    AddHours(shift.StartHour.Value.Hour).
                    AddMinutes(shift.StartHour.Value.Minute);
            }
            if (shift.EndHour.HasValue)
            {
                shift.EndHour = new DateTime(2000, 1, 1).
                    AddHours(shift.EndHour.Value.Hour).
                    AddMinutes(shift.EndHour.Value.Minute);
            }
            base.Adding(e);
        }

        public override void Changing(DbEntityEntry e)
        {
            Shift shift = this;

            //if (e.FieldName.Equals("_StartHour", StringComparison.InvariantCultureIgnoreCase))
            //{
            //    DateTime? newStartHour = e.NewValue as DateTime?;
            //    if (newStartHour.HasValue)
            //    {
            //        shift.StartHour = new DateTime(2000, 1, 1).
            //            AddHours(newStartHour.Value.Hour).
            //            AddMinutes(newStartHour.Value.Minute);
            //    }
            //}
            //if (e.FieldName.Equals("_EndHour", StringComparison.InvariantCultureIgnoreCase))
            //{
            //    DateTime? newEndHour = e.NewValue as DateTime?;
            //    if (newEndHour.HasValue)
            //    {
            //        shift.EndHour = new DateTime(2000, 1, 1).
            //            AddHours(newEndHour.Value.Hour).
            //            AddMinutes(newEndHour.Value.Minute);
            //    }
            //}
            base.Changing(e);
        }

        public override void Changed(DbEntityEntry e)
        {
            base.Changed(e);
        }
    }
}