using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clustering {
    class Program {
        static Vector[] dataSet;

        static void Main(string[] args) {
            List<Tuple<Vector[], Vector[]>> clusteringResults = new List<Tuple<Vector[], Vector[]>>();
            int k = 4;
            dataSet = CsvParser.getVectorList();

            int counter = 0;
            int repetitions = 500;

            while (counter < repetitions) {
                Tuple<Vector[], Vector[]> clusteringResult = ClusterModule.Cluster(k, 10, dataSet);
                clusteringResults.Add(clusteringResult);
                counter++;
                Console.Write("\r{0}%", Math.Floor(((float)counter/repetitions) * 100));
            }

            Console.WriteLine();
            getClusterMembers(k, Calculator.getBestSSE(clusteringResults));
            //getClusterMembers(k, Calculator.getBestSilhouette(clusteringResults));



            Console.ReadLine();
        }

        private static void getClusterMembers(int k, Tuple<Vector[], Vector[]> clusterResult) {
            int currentClusterNumber;
            for (int i = 0; i < k; i++) {
                currentClusterNumber = 0;
                foreach (Vector v in clusterResult.Item1) {
                    if (i == v.clusterID) {
                        currentClusterNumber++;
                    }
                }

                Console.WriteLine(string.Format("Cluster {0}: {1} member(s)", i, currentClusterNumber));

            }

            Console.WriteLine(string.Format("SSE: {0}", Calculator.SSE(clusterResult)));
            Console.WriteLine(string.Format("Silhouette: {0}", Calculator.Silhouette(clusterResult)));
            Console.WriteLine("---------------------");
            Console.WriteLine();

        }
    }
}
