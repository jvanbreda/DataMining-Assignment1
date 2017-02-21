using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clustering {
    public class Cluster {

        private List<Vector> members;
        private Vector centroid;

        public Cluster() {
            members = new List<Vector>();
            centroid = null;
        }

        public Vector GetCentroid() {
            return centroid;
        }

        public void SetCentroid(Vector v) {
            centroid = v;
        }

        public void CalculateNewCentroid() {
            SetCentroid(Vector.Average(members.ToArray()));
        }

        public Vector[] GetMembers() {
            return members.ToArray();
        }

        public void AddVector(Vector v) {
            members.Add(v);
        }

        public void RemoveVector(Vector v) {
            members.Remove(v);
        }

        public void ClearCluster() {
            members = new List<Vector>();
        }
    }
}
