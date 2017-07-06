using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forecasting {
    public class DES2 {

        public static Tuple<Dictionary<int, float>, float, float, float> ComputeDES(Dictionary<int, float> dataSet) {
            float alpha = 0.01f;
            float beta = 0.05f;

            List<Tuple<Dictionary<int, float>, float, float, float>> iterationData = new List<Tuple<Dictionary<int, float>, float, float, float>>();

            while (alpha < 1) {
                beta = 0.01f;
                while (beta < 1) {

                    Dictionary<int, float> s = new Dictionary<int, float>();
                    Dictionary<int, float> b = new Dictionary<int, float>();
                    Dictionary<int, float> smoothedValues = new Dictionary<int, float>();

                    s.Add(2, dataSet[2]);
                    b.Add(2, dataSet[2] - dataSet[1]);
                    smoothedValues.Add(3, s[2] + b[2]);

                    for(int i = 3; i <= dataSet.Keys.Max(); i++) {
                        Tuple<float, float> computed = ComputeSmoothedValue(alpha, beta, dataSet[i], s[i - 1], b[i - 1]);
                        s.Add(i, computed.Item1);
                        b.Add(i, computed.Item2);
                        smoothedValues.Add(i + 1, s[i] + b[i]);
                    }

                    Forecast(smoothedValues, b);

                    float error = ComputeError(dataSet, smoothedValues);
                    iterationData.Add(new Tuple<Dictionary<int, float>, float, float, float>(smoothedValues, error, alpha, beta));

                    beta += 0.01f;
                }

                alpha += 0.01f;
            }

            return GetMinimalError(iterationData);
        }

        private static Tuple<float, float> ComputeSmoothedValue(float alpha, float beta, float x, float s, float b) {
            float st = alpha * x + (1 - alpha) * (s + b);
            float bt = beta * (st - s) + (1 - beta) * b;

            return new Tuple<float, float>(st, bt);
        }

        private static float ComputeError(Dictionary<int, float> dataSet, Dictionary<int, float> smoothedData) {
            float squaredError = 0;
            for (int i = 3; i <= dataSet.Keys.Max(); i++) {
                squaredError += (float) Math.Pow(smoothedData[i] - dataSet[i], 2);
            }

            squaredError /= (dataSet.Count - 2);
            return (float)Math.Sqrt(squaredError);
        }

        private static void Forecast(Dictionary<int, float> smoothedData, Dictionary<int, float> trends) {
            for (int i = smoothedData.Keys.Max() + 1; i <= Program.MAX_FORECAST_WEEK; i++) {
                smoothedData.Add(i, smoothedData.Last().Value + trends.Last().Value * (i - smoothedData.Keys.Max()));
            }
        }

        private static Tuple<Dictionary<int, float>, float, float, float> GetMinimalError(List<Tuple<Dictionary<int, float>, float, float, float>> iterationData) {
            Tuple<Dictionary<int, float>, float, float, float> minimal = iterationData[0];
            foreach(Tuple<Dictionary<int, float>, float, float, float> t in iterationData) {
                if(t.Item2 < minimal.Item2) {
                    minimal = t;
                }
            }

            return minimal;
        }



    }
}
