using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clustering2 {
    public class Program {
        static Vector[] dataSet;
        public static int k = 4;
        static void Main(string[] args) {
            dataSet = CsvParser.GetVectorList();
            List<Cluster[]> clusteringResults = new List<Cluster[]>();
            int algorithmRuns = 100;

            int counter = 0;

            while (counter < algorithmRuns) {
                Cluster[] clusteringResult = ClusterModule.Cluster(k, 20, dataSet);
                clusteringResults.Add(clusteringResult);
                counter++;
                Console.Write("\r{0}%", Math.Floor(((float)counter / algorithmRuns) * 100));
            }
            Console.WriteLine();
            GetClusterMembers(Calculator.GetBestSSE(clusteringResults));

            Console.Read();
        }

        private static void GetClusterMembers(Cluster[] clusterResult) {
            foreach(Cluster c in clusterResult) {
                Console.WriteLine(string.Format("Cluster {0}: {1} member(s)", c.Id, c.Members.Count));
            }

            Console.WriteLine(string.Format("SSE: {0}", Calculator.SSE(clusterResult)));
            Console.WriteLine("---------------------");
            Console.WriteLine();

        }
    }
}
