using System.Collections.Generic;

namespace KMeans.Core
{
    public interface ICluster
    {
        public int Id { get; }
        public IMean Mean { get; }
        public ICentroid Centroid { get; }

        public void Update(IEnumerable<IEntitySpecification> items);
    }
}
