namespace KMeans.Core.Implementation
{
    public class EntitySpecification : IEntitySpecification
    {
        public EntitySpecification(string name, double weight, double height)
        {
            Name = name;
            Height = height;
            Weight = weight;
        }

        public string Name { get; }
        public int? ClusterId { get; private set; }
        public double Height { get; }
        public double Weight { get; }

        public void SetCluster(int clusterId) => ClusterId = clusterId;
    }
}
