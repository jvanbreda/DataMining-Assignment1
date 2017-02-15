using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clustering {
    class ClusterModule {

        public static void Cluster(int k, int maxInterations, params Vector[] dataSet) {
            Random r = new Random();
            int dimensions = dataSet[0].dimension;
            Vector[] centroids = new Vector[k];

            // Generate k random centroids
            for (int i = 0; i < k; i++) {
                float[] attributes = new float[dimensions];
                int randomIndex = r.Next(dataSet.Length);

                while (centroids.Contains(dataSet[randomIndex]))
                    randomIndex = r.Next(dataSet.Length);

                centroids[i] = dataSet[randomIndex];
            }

            bool centroidsChanged = true;
            int counter = 0;

            while (centroidsChanged && counter < maxInterations) {
                foreach (Vector v in dataSet) {
                    for (int i = 0; i < centroids.Length; i++) {
                        v.clusterID = v.Distance(centroids[i]) < v.Distance(centroids[v.clusterID]) ? i : v.clusterID;
                    }
                }

                Vector[] oldCentroids = centroids;

                for (int i = 0; i < k; i++) {
                    List<Vector> cluster = new List<Vector>();
                    foreach (Vector v in dataSet) {
                        if (v.clusterID == i)
                            cluster.Add(v);
                    }

                    if(cluster.Count > 0)
                        centroids[i] = Vector.Average(cluster.ToArray());
                }

                counter++;
                centroidsChanged = (oldCentroids == centroids);
            }

        }
    }
}
