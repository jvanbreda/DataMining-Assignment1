using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clustering2 {
    class Calculator {

        public static float SSE(Cluster[] clusteringResult) {

            float tempSum;
            float result = 0;

            foreach(Cluster c in clusteringResult) {
                foreach(Vector v in c.Members) {
                    result += v.Distance(c.Centroid);
                }
            }

            return result;
        }

        

        public static Cluster[] GetBestSSE(List<Cluster[]> listOfClusterResults) {
            Cluster[] bestSSE = listOfClusterResults[0];
            foreach (Cluster[] clusters in listOfClusterResults) {
                if (SSE(clusters) < SSE(bestSSE)) {
                    bestSSE = clusters;
                }
            }

            return bestSSE;
        }
    }
}
