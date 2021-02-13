using System;
using System.Collections.Generic;
using System.Linq;
using KMeans.Core;
using KMeans.Core.Implementation;

namespace KMeans.Demo
{
    internal class Program
    {
        private const int CountTry = 300;
        private const int CountClusters = 3;

        private static void Main(string[] args)
        {
            var payload = new List<IEntitySpecification>
            {
                new EntitySpecification("Ivan", 65.0, 170.0),
                new EntitySpecification("Oleg", 73.0, 172.0),
                new EntitySpecification("Sergei",59.0, 168.0),
                new EntitySpecification("Kostya",61.0, 171.0),
                new EntitySpecification("Alexey",75.0, 150.0 ),
                new EntitySpecification("Victor",67.0, 174.0),
                new EntitySpecification("Dima",68.0, 175.0),
                new EntitySpecification("Anton",70.0, 180.0),
                new EntitySpecification("Valera",62.0, 169.0),
                new EntitySpecification("Danila",66.0, 168.0),
                new EntitySpecification("Sasha",77.0, 190.0),
                new EntitySpecification("Stas",75.0, 180.0),
                new EntitySpecification("Tamara",74.0, 184.0),
                new EntitySpecification("Olga",70.0, 170.0),
                new EntitySpecification("Nadya",61.0, 150.0),
                new EntitySpecification("Irina",58.0, 145.0),
                new EntitySpecification("Maksim",66.0, 160.0),
                new EntitySpecification("Katya",59.0, 148.0),
                new EntitySpecification("Pavel",68.0, 182.0),
                new EntitySpecification("Igor",61.0, 135.0)
            };

            var kMean = new KMean(new ClusterService(new MeanService(), new CentroidService(new Metric())), new Metric());
            var result = kMean.Calculate(payload, CountClusters, CountTry);

            ShowClustering(result, 3, kMean.GetClusters());
        }

        private static void ShowClustering(IReadOnlyCollection<IEntitySpecification> rawData, int numClusters, IEnumerable<ICluster> clusters)
        {
            for (var k = 0; k < numClusters; ++k)
            {
                Console.WriteLine($"Cluster {k + 1} centroid:\t\t\t{clusters.ToList()[k].Centroid.Weight:F1}\t\t{clusters.ToList()[k].Centroid.Height:F1}\t\t");
                Console.WriteLine($"Cluster {k + 1} mean:\t\t\t\t{clusters.ToList()[k].Mean.Weight:F1}\t\t{clusters.ToList()[k].Mean.Height:F1}\t\t");
                foreach (var info in rawData)
                {
                    if (info.ClusterId != k)
                        continue;
                    Console.Write($"{info.ClusterId + 1} cluster: \t\t");
                    Console.Write(info.Name + "\t\t");
                    Console.Write(info.Weight.ToString("F1") + "\t\t");
                    Console.Write(info.Height.ToString("F1") + "\t\t");
                    Console.WriteLine("");
                }
                Console.WriteLine("");
            }
        }
    }
}
