using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clustering {
    class Program {
        static List<Vector> dataSet = new List<Vector>();

        static void Main(string[] args) {
            int k = 3;

            ClusterModule.Cluster(k, 200, dataSet.ToArray());
            getClusterMembers();
            
            Console.ReadLine();
        }

        private static void getClusterMembers() {
            foreach(Vector v in dataSet.OrderBy(o => o.clusterID)) {
                Console.WriteLine(v + " - " + v.clusterID);
            }
        }
    }
}
