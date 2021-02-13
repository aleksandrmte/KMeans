using System.Collections.Generic;

namespace KMeans.Core
{
    public interface IKMean
    {
        public List<IEntitySpecification> Calculate(IEnumerable<IEntitySpecification> entitySpecifications, int countClusters, int countTry);

        public IReadOnlyList<ICluster> GetClusters();
    }
}
