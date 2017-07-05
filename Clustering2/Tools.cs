using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clustering2 {
    public class Tools {
        
        public static List<Vector> Copy(List<Vector> list) {
            List<Vector> newList = new List<Vector>();
            foreach (Vector v in list)
                newList.Add(v);
            return newList;
        }

        public static bool Equals(List<Vector> list1, List<Vector> list2) {
            if (list1.Count != list2.Count)
                return false;
            else {
                return list1.All(list2.Contains);
            }
        }
        
    }
}
