using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clustering2 {
    class Cluster {
        public int Id { get; private set; }
        public Vector Centroid { get; private set; }
        public List<Vector> Members { get; private set; }

        public Cluster(int id) {
            Id = id;
            Centroid = null;
            Members = new List<Vector>();
        }

        public void AddMember(Vector member) {
            Members.Add(member);
        }

        public void ComputeCentroid() {
            Vector sumVector = new Vector(new float[Members[0].dimension]);
            foreach (Vector v in Members) {
                sumVector = sumVector + v;
            }

            Centroid = (1f / Members.Count) * sumVector;
        }

        public void Reset() {
            Members = new List<Vector>();
            Centroid = null;
        }
    }
}
