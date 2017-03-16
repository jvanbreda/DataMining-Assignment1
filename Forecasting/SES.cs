using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forecasting {
    public class SES {

        public static Tuple<Dictionary<int, float>, float, float> ComputeSES(Dictionary<int, float> dataSet) {
            Dictionary<int, float> optimalSesValues = new Dictionary<int, float>();
            float minimalError = float.PositiveInfinity;
            float optimalAlpha = 1;            

            float alpha = 0.01f;
            while (alpha < 1) {
                Dictionary<int, float> sesValues = new Dictionary<int, float>();
                sesValues.Add(1, dataSet[1]);
                for (int i = 2; i <= dataSet.Count; i++) {
                    sesValues.Add(i, ComputeSmoothedValue(alpha, dataSet[i - 1], sesValues[i - 1]));
                }

                Forecast(sesValues);

                float error = ComputeError(dataSet, sesValues);
                if(error < minimalError) {
                    minimalError = error;
                    optimalSesValues = sesValues;
                    optimalAlpha = alpha;
                }

                alpha += 0.01f;
            }

            return new Tuple<Dictionary<int, float>, float, float>(optimalSesValues, minimalError, optimalAlpha);
        }

        private static float ComputeSmoothedValue(float alpha, float x, float s) {
            return alpha * x + (1 - alpha) * s;
        }

        private static float ComputeError(Dictionary<int, float> dataSet, Dictionary<int, float> smoothedData) {
            float result = 0;
            for (int i = 1; i <= dataSet.Count; i++) {
                result += (float) Math.Pow((smoothedData[i] - dataSet[i]), 2);
            }

            result = result / (dataSet.Count - 1);
            return (float) Math.Sqrt(result);
        }

        private static void Forecast(Dictionary<int, float> smoothedData) {
            float lastKnownData = smoothedData[smoothedData.Count];
            for (int i = smoothedData.Count + 1; i <= Program.MAX_FORECAST_WEEK; i++) {
                smoothedData.Add(i, lastKnownData);
            }
        }



    }
}
