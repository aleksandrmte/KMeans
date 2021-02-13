using System.Collections.Generic;

namespace KMeans.Core
{
    public interface IMean: IMetricItem
    {
        void Update(IEnumerable<IEntitySpecification> items);
    }
}
