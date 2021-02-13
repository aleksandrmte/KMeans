using System.Collections.Generic;

namespace KMeans.Core
{
    public interface IMetric
    {
        double Distance(IEntitySpecification item, IMetricItem centroid);
        int MinIndex(IReadOnlyList<double> distances);
    }
}
