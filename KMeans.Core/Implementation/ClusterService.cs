using System.Collections.Generic;
using System.Linq;

namespace KMeans.Core.Implementation
{
    public class ClusterService : IClusterService
    {
        private readonly IMeanService _meanService;
        private readonly ICentroidService _centroidService;

        public ClusterService(IMeanService meanService, ICentroidService centroidService)
        {
            _meanService = meanService;
            _centroidService = centroidService;
        }

        public IReadOnlyList<ICluster> Init(int count)
        {
            return Enumerable.Range(0, count).Select(x => new Cluster(x, _meanService.Create(x), _centroidService.Create(x))).ToList();
        }
    }
}
