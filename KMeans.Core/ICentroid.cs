using System.Collections.Generic;

namespace KMeans.Core
{
    public interface ICentroid: IMetricItem
    {
        void Update(IEnumerable<IEntitySpecification> items, IMean mean);
    }
}
