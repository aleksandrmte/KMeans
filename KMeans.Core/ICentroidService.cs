namespace KMeans.Core
{
    public interface ICentroidService
    {
        ICentroid Create(int clusterId);
    }
}
