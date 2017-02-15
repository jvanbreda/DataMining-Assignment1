using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clustering {
    class Calculator {

        public static float SSE(Tuple<Vector[], Vector[]> clusteringResult) {
            Vector[] vectors = clusteringResult.Item1;
            Vector[] centroids = clusteringResult.Item2;

            float tempSum;
            float result = 0;

            for (int i = 0; i < centroids.Length; i++) {
                tempSum = 0;
                foreach (Vector v in vectors) {
                    if (i == v.clusterID) {
                        tempSum += v.Distance(centroids[i]);
                    }
                }
                result += tempSum;
            }
            return result;
        }

        public static float Silhouette(Tuple<Vector[], Vector[]> clusteringResult) {
            Vector[] vectors = clusteringResult.Item1;
            Vector[] centroids = clusteringResult.Item2;

            List<float> silhouetteValues = new List<float>();
            int numOfClusterMembers;

            float a, b;
            foreach(Vector v1 in vectors) {
                numOfClusterMembers = 0;
                a = 0;
                foreach(Vector v2 in vectors) {
                    if (v1.clusterID == v2.clusterID) {
                        a += v1.Distance(v2);
                        numOfClusterMembers++;
                    }
                }

                a = a / numOfClusterMembers;

                b = float.PositiveInfinity;

                for (int i = 0; i < centroids.Length; i++) {
                    if(i != v1.clusterID) {
                        if(v1.Distance(centroids[i]) < b) {
                            b = v1.Distance(centroids[i]);
                        } 
                    }
                }

                float vectorSilhouette = (b - a) / (Math.Max(a, b));
                silhouetteValues.Add(vectorSilhouette);
            }

            float silhouette = 0;
            foreach(float f in silhouetteValues) {
                silhouette += f;
            }

            return silhouette / silhouetteValues.Count;
        }

        public static Tuple<Vector[], Vector[]> getBestSSE(List<Tuple<Vector[], Vector[]>> listOfClusterResults) {
            Tuple<Vector[], Vector[]> bestSSE = listOfClusterResults[0];
            foreach (Tuple<Vector[], Vector[]> t in listOfClusterResults) {
                if (SSE(t) < SSE(bestSSE)) {
                    bestSSE = t;
                }
            }

            return bestSSE;
        }

        public static Tuple<Vector[], Vector[]> getBestSilhouette(List<Tuple<Vector[], Vector[]>> listOfClusterResults) {
            Tuple<Vector[], Vector[]> bestSilhouette = listOfClusterResults[0];
            foreach (Tuple<Vector[], Vector[]> t in listOfClusterResults) {
                if (Silhouette(t) > Silhouette(bestSilhouette)) {
                    bestSilhouette = t;
                }
            }

            return bestSilhouette;
        }
    }
}
