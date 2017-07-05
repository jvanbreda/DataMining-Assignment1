using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clustering2 {
    class ClusterModule {

        public static Cluster[] Cluster(int k, int maxIterations, Vector[] dataSet) {

            Cluster[] clusters = new Cluster[k];
            for (int i = 0; i < clusters.Length; i++)
                clusters[i] = new Cluster(i);

            foreach(Vector v in dataSet)
                clusters[v.clusterID].AddMember(v);

            List<Vector> centroids = new List<Vector>();
            for (int i = 0; i < clusters.Length; i++) {
                clusters[i].ComputeCentroid();
                centroids.Add(clusters[i].Centroid);
            }

            bool centroidsChanged = true;
            int counter = 0;

            while(centroidsChanged && counter < maxIterations) {
                List<Vector> oldCentroids = Tools.Copy(centroids);
                foreach(Vector v in dataSet) {
                    for (int i = 0; i < clusters.Length; i++) {
                        v.clusterID = (v.Distance(clusters[i].Centroid) < v.Distance(clusters[v.clusterID].Centroid) ? i : v.clusterID);
                    }
                }

                foreach (Cluster c in clusters)
                    c.Reset();

                foreach (Vector v in dataSet)
                    clusters[v.clusterID].AddMember(v);

                centroids = new List<Vector>();
                for (int i = 0; i < clusters.Length; i++) {
                    clusters[i].ComputeCentroid();
                    centroids.Add(clusters[i].Centroid);
                }

                centroidsChanged = !Tools.Equals(oldCentroids, centroids);
                counter++;
            }

            return clusters;

        }
    }
}
