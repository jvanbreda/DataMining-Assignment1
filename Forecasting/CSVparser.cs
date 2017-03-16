using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forecasting {
    public class CSVparser {
        public static Dictionary<int, float> GetData() {
            Dictionary<int, float> demandData = new Dictionary<int, float>();
            using (var fs = File.OpenRead("../../demand.csv")) {
                using (var streamReader = new StreamReader(fs)) {
                    while (!streamReader.EndOfStream) {
                        string line = streamReader.ReadLine();
                        string[] values = line.Split(',');
                        demandData.Add(int.Parse(values[0]), float.Parse(values[1]));
                    }
                }
            }
            return demandData;
        }
    }
}
