using System;
using System.Collections.Generic;

namespace KMeans.Core.Implementation
{
    public class Metric: IMetric
    {
        public double Distance(IEntitySpecification item, IMetricItem centroid)
        {
            var sumSquaredDiffs = Math.Pow(item.Height - centroid.Height, 2) + Math.Pow(item.Weight - centroid.Weight, 2);
            return Math.Sqrt(sumSquaredDiffs);
        }

        public int MinIndex(IReadOnlyList<double> distances)
        {
            var indexOfMin = 0;
            var smallDist = distances[0];
            for (var k = 0; k < distances.Count; ++k)
            {
                if (!(distances[k] < smallDist)) 
                    continue;
                smallDist = distances[k]; 
                indexOfMin = k;
            }
            return indexOfMin;
        }
    }
}
