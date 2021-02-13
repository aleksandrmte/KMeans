using System.Collections.Generic;

namespace KMeans.Core.Implementation
{
    public class Centroid : ICentroid
    {
        private readonly IMetric _metric;

        public Centroid(IMetric metric)
        {
            _metric = metric;
        }
        
        public double Height { get; private set; }
        public double Weight { get; private set; }
        
        public void Update(IEnumerable<IEntitySpecification> items, IMean mean) => ComputeCentroid(items, mean);
        
        private void ComputeCentroid(IEnumerable<IEntitySpecification> items, IMetricItem mean)
        {
            var minDist = double.MaxValue;
            foreach (var item in items)
            {
                var currentDistance = _metric.Distance(item, mean);
                if (!(currentDistance < minDist)) 
                    continue;
                minDist = currentDistance;
                Height = item.Height;
                Weight = item.Weight;
            }
        }
    }
}
