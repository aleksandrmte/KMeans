namespace KMeans.Core.Implementation
{
    public class MeanService : IMeanService
    {
        public IMean Create(int clusterId) => new Mean();
    }
}
