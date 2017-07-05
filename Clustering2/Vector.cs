using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clustering2 {
    public class Vector {

        public float[] attributes { get; private set; }
        public int dimension;
        public int clusterID;

        private static readonly Random r = new Random();

        public Vector(params float[] attributes) {
            this.attributes = attributes;
            this.dimension = attributes.Length;
            this.clusterID = r.Next(Program.k);
        }

        public static Vector operator +(Vector v1, Vector v2) {
            float[] attributes = { };
            Vector mostDimVector = (v1.dimension >= v2.dimension ? v1 : v2);
            try {
                attributes = new float[mostDimVector.attributes.Length];
                for (int i = 0; i < mostDimVector.attributes.Length; i++) {
                    attributes[i] = v1.attributes[i] + v2.attributes[i];
                }

                return new Vector(attributes);
            }
            catch (IndexOutOfRangeException ex) {
                Console.WriteLine("Vectors must be of equal dimensions!");
            }

            return null;
        }

        public static Vector operator -(Vector v1, Vector v2) {
            float[] attributes = { };
            Vector mostDimVector = (v1.dimension >= v2.dimension ? v1 : v2);
            try {
                attributes = new float[mostDimVector.attributes.Length];
                for (int i = 0; i < mostDimVector.attributes.Length; i++) {
                    attributes[i] = v1.attributes[i] - v2.attributes[i];
                }
                return new Vector(attributes);
            }
            catch (IndexOutOfRangeException ex) {
                Console.WriteLine("Vectors must be of equal dimensions!");
            }

            return null;
        }

        public static Vector operator *(float scalar, Vector v) {
            float[] attributes = new float[v.attributes.Length];
            for (int i = 0; i < v.attributes.Length; i++) {
                attributes[i] = v.attributes[i] * scalar;
            }
            return new Vector(attributes);
        }

        public bool Equals(Vector other) {
            float[] attributes = { };
            Vector mostDimVector = (dimension >= other.dimension ? this : other);
            try {
                for (int i = 0; i < mostDimVector.attributes.Length; i++) {
                    if (this.attributes[i] != other.attributes[i]) {
                        return false;
                    }
                }

                return true;
            }
            catch (IndexOutOfRangeException ex) {
                Console.WriteLine("Vectors must be of equal dimensions!");
            }

            return false;
        }

        public float Length() {
            float squaredLength = 0;
            for (int i = 0; i < attributes.Length; i++) {
                squaredLength += (float)Math.Pow((attributes[i]), 2);
            }
            return (float)Math.Sqrt(squaredLength);
        }

        public float Distance(Vector other) {
            float squaredDistance = 0;
            Vector mostDimVector = (attributes.Length >= other.attributes.Length ? this : other);
            try {
                for (int i = 0; i < mostDimVector.attributes.Length; i++) {
                    squaredDistance += (float)Math.Pow((attributes[i] - other.attributes[i]), 2);
                }
                return (float)Math.Sqrt(squaredDistance);
            }
            catch (IndexOutOfRangeException ex) {
                Console.WriteLine("Vectors must be of equal dimensions!");
            }

            return -1;
        }

        public override string ToString() {
            string attributeString = "";
            foreach (float f in attributes) {
                attributeString += f + ",";
            }

            return string.Format("Vector({0})", attributeString.Substring(0, attributeString.Length - 1));
        }

        
    }
}
