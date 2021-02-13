namespace KMeans.Core.Implementation
{
    public class CentroidService : ICentroidService
    {
        private readonly IMetric _metric;

        public CentroidService(IMetric metric)
        {
            _metric = metric;
        }

        public ICentroid Create(int clusterId) => new Centroid(_metric);
    }
}
