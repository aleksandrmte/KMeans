using System.Collections.Generic;
using System.Linq;

namespace KMeans.Core.Implementation
{
    public class Mean : IMean
    {
        public double Height { get; private set; }
        public double Weight { get; private set; }
        public void Update(IEnumerable<IEntitySpecification> items)
        {
            if (!items.Any())
                return;

            Height = items.Sum(x => x.Height) / items.Count();
            Weight = items.Sum(x => x.Weight) / items.Count();
        }
    }
}
