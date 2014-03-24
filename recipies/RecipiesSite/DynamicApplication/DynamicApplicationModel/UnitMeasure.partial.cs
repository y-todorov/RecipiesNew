using System.Collections.Generic;
using System.Linq;

namespace RecipiesModelNS
{
    public partial class UnitMeasure : YordanBaseEntity
    {
        public List<UnitMeasure> GetRelatedUnitMeasures()
        {
            int baseUnitMeasureId = UnitMeasureId;
            List<UnitMeasure> result =
                ContextFactory.GetContextPerRequest()
                    .UnitMeasures.Where(
                        um => um.BaseUnitId == baseUnitMeasureId || um.UnitMeasureId == baseUnitMeasureId)
                    .ToList();

            return result;
        }
    }
}