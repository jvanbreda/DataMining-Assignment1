using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clustering2 {
    public class CsvParser {

        public static Vector[] GetVectorList() {
            List<Vector> vectorList = new List<Vector>();
            using (var fs = File.OpenRead("../../WinedataTransposed.csv")) {
                using (var streamReader = new StreamReader(fs)) {

                    while (!streamReader.EndOfStream) {
                        string line = streamReader.ReadLine();
                        string[] values = line.Split(',');

                        List<float> vectorAttributes = new List<float>();
                        foreach(string s in values) {
                            vectorAttributes.Add(float.Parse(s));
                        }

                        vectorList.Add(new Vector(vectorAttributes.ToArray()));
                    }

                }
            }

            return vectorList.ToArray();
        }
    }
}
