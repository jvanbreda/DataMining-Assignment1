using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clustering {
    public class BetterClusterModule {

        private static readonly Random r = new Random();
        private static Cluster[] clusters;
        private static List<Vector> oldCentroids, centroids;

        public static Tuple<Vector[], Vector[]> Cluster(int k, int maxInterations, params Vector[] dataSet) {
            clusters = new Cluster[k];
            List<int> indeces = new List<int>();

            for (int i = 0; i < k; i++) {
                Cluster c = new Cluster();
                int randomIndex = r.Next(dataSet.Length);

                while (indeces.Contains(randomIndex))
                    randomIndex = r.Next(dataSet.Length);

                c.SetCentroid(new Vector(dataSet[randomIndex].attributes));
                clusters[i] = c;
                indeces.Add(randomIndex);
            }

            centroids = new List<Vector>();
            foreach (Cluster c in clusters) {
                centroids.Add(c.GetCentroid());
            }

            bool centroidsChanged = true;
            int counter = 0;

            while (centroidsChanged && counter < maxInterations) {
                ClearClusters();

                oldCentroids = centroids;

                FindClosestCentroid(dataSet, clusters.ToList());

                centroids = new List<Vector>();

                foreach (Cluster c in clusters) {
                    if (c.GetMembers().Length > 0) {
                        c.CalculateNewCentroid();
                        centroids.Add(c.GetCentroid());
                    }
                }

                counter++;
                centroidsChanged = (!HelperTools.Equals(oldCentroids.ToArray(), centroids.ToArray()));
            }

            
            return new Tuple<Vector[], Vector[]>(dataSet, centroids.ToArray());
        }

        private static void FindClosestCentroid(Vector[] vectors, List<Cluster> clusters) {
            float min = 0f;
            int cluster = 0;
            float distance = 0f;

            foreach(Vector v in vectors) {
                min = float.PositiveInfinity;
                for (int i = 0; i < clusters.Count; i++) {
                    Cluster c = clusters[i];
                    distance = v.Distance(c.GetCentroid());
                    if (distance < min) {
                        min = distance;
                        cluster = i;
                    }
                }
                v.clusterID = cluster;
                clusters[cluster].AddVector(v);
            }
        }

        private static void ClearClusters() {
            foreach (Cluster c in clusters) {
                c.ClearCluster();
            }
        }
    }
}
