using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forecasting {
    public class DES {
        public static Tuple<Dictionary<int, float>, float, float, float> ComputeDES(Dictionary<int, float> dataSet) {
            Dictionary<int, float> optimalDesValues = new Dictionary<int, float>();
            Dictionary<int, float> optimalTrends = new Dictionary<int, float>();

            List<Tuple<Dictionary<int, float>, float, float, float>> iterationData = new List<Tuple<Dictionary<int, float>, float, float, float>>();

            float alpha = 0.1f;
            float beta = 0.1f;

            while (alpha < 1) {
                beta = 0.1f;
                while (beta < 1) {
                    Dictionary<int, float> desValues = new Dictionary<int, float>();
                    Dictionary<int, float> trends = new Dictionary<int, float>();
                    desValues.Add(2, dataSet[2]);
                    trends.Add(2, dataSet[2] - dataSet[1]);
                    for (int i = 3; i <= dataSet.Count; i++) {
                        Tuple<float, float> computed = ComputeSmoothedValue(alpha, beta, dataSet[i], desValues[i - 1], trends[i - 1]);
                        desValues.Add(i, computed.Item1);
                        trends.Add(i, computed.Item2);
                    }

                    Forecast(desValues, trends);

                    float error = ComputeError(dataSet, desValues);
                    iterationData.Add(new Tuple<Dictionary<int, float>, float, float, float>(desValues, error, alpha, beta));

                    beta += 0.01f;
                }

                alpha += 0.01f;
            }

            return GetMinimalError(iterationData);
        }


        private static Tuple<float, float> ComputeSmoothedValue(float alpha, float beta, float x, float s, float b) {
            float st = alpha * x + (1 - alpha) * (s + b);
            float bt = beta * (st - s) + (1 - beta) * b;

            return new Tuple<float, float>(st + bt, bt);
        }

        private static float ComputeError(Dictionary<int, float> dataSet, Dictionary<int, float> smoothedData) {
            float result = 0;
            for (int i = 2; i <= dataSet.Count; i++) {
                result += (float)Math.Pow((smoothedData[i] - dataSet[i]), 2);
            }

            result = result / (dataSet.Count - 2);
            return (float)Math.Sqrt(result);
        }

        private static Tuple<Dictionary<int, float>, float, float, float> GetMinimalError(List<Tuple<Dictionary<int, float>, float, float, float>> iterationData) {
            Tuple<Dictionary<int, float>, float, float, float> minimalErrorObservation = iterationData[0];
            foreach (Tuple<Dictionary<int, float>, float, float, float> t in iterationData) {
                if (t.Item2 < minimalErrorObservation.Item2) {
                    minimalErrorObservation = t;
                }
            }

            return minimalErrorObservation;
        }

        private static void Forecast(Dictionary<int, float> smoothedData, Dictionary<int, float> trends) {
            float lastKnownData = smoothedData[smoothedData.Count + 1];
            float lastKnownTrend = trends[trends.Count + 1];
            for (int i = smoothedData.Count + 2; i <= Program.MAX_FORECAST_WEEK; i++) {
                smoothedData.Add(i, lastKnownData + (lastKnownTrend * (i - trends.Count)));
            }
        }
    }
}
