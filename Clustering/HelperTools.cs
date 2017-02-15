using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clustering {
    public class HelperTools {
        public static bool Equals(Vector[] v1, Vector[] v2) {
            if (v1.Length != v2.Length)
                return false;

            for (int i = 0; i < v1.Length; i++) {
                if (!v1[i].Equals(v2[i])) {
                    return false;
                }
            }

            return true;
        }

    }
}
