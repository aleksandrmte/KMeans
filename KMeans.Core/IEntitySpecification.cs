namespace KMeans.Core
{
    public interface IEntitySpecification: IMetricItem
    {
        public string Name { get; }
        public int? ClusterId { get; }

        public void SetCluster(int clusterId);
    }
}
