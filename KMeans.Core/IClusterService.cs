using System.Collections.Generic;

namespace KMeans.Core
{
    public interface IClusterService
    {
        IReadOnlyList<ICluster> Init(int count);
    }
}
