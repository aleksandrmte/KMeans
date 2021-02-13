using System.Collections.Generic;

namespace KMeans.Core.Implementation
{
    public class Cluster: ICluster
    {
        public Cluster(int id, IMean mean, ICentroid centroid)
        {
            Id = id;
            Mean = mean;
            Centroid = centroid;
        }

        public int Id { get; }
        public IMean Mean { get; }
        public ICentroid Centroid { get; }

        public void Update(IEnumerable<IEntitySpecification> items)
        {
            Mean.Update(items);
            Centroid.Update(items, Mean);
        }
    }
}
