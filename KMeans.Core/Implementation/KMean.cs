using System;
using System.Collections.Generic;
using System.Linq;

namespace KMeans.Core.Implementation
{
    public class KMean : IKMean
    {
        private readonly IClusterService _clusterService;
        private readonly IMetric _metric;
        private List<ICluster> _clusters;
        private List<IEntitySpecification> _items;

        public KMean(IClusterService clusterService, IMetric metric)
        {
            _clusterService = clusterService;
            _metric = metric;
        }

        public List<IEntitySpecification> Calculate(IEnumerable<IEntitySpecification> entitySpecifications, int countClusters, int countTry)
        {
            var isChanged = true;
            var ct = 0;

            _items = entitySpecifications.ToList();

            _clusters = _clusterService.Init(countClusters).ToList();
            _items = InitClustering(countClusters, 0).ToList();

            Update();

            while (isChanged && ct < countTry)
            {
                ++ct;
                isChanged = Assign();
                Update();
            }

            return _items;
        }

        public IReadOnlyList<ICluster> GetClusters()
        {
            return _clusters;
        }

        private void Update()
        {
            _clusters.ForEach(cluster => cluster.Update(_items.Where(x => x.ClusterId == cluster.Id)));
        }

        private IEnumerable<IEntitySpecification> InitClustering(int numClusters, int randomSeed)
        {
            var data = _items;

            var random = new Random(randomSeed);

            for (var i = 0; i < numClusters; ++i)
                data[i].SetCluster(i);

            for (var i = numClusters; i < data.Count; ++i)
                data[i].SetCluster(random.Next(0, numClusters));

            return data;
        }

        private bool Assign()
        {
            var numClusters = _clusters.Count;
            var isChanged = false;
            var distances = new double[numClusters];
            foreach (var t in _items)
            {
                for (var k = 0; k < numClusters; k++)
                    distances[k] = _metric.Distance(t, _clusters[k].Centroid);

                var newClusterId = _metric.MinIndex(distances);
                if (newClusterId == t.ClusterId)
                    continue;

                isChanged = true;
                t.SetCluster(newClusterId);
            }
            return isChanged;
        }
    }
}
