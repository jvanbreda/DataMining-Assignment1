using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm {
    public class Calculator {

        public static Individual GetFittestIndividual(Individual[] population, double[] fitness) {
            int fittestIndex = 0;
            for (int i = 0; i < fitness.Length; i++) {
                if(fitness[i] > fitness[fittestIndex]) {
                    fittestIndex = i;
                }
            }
            return population[fittestIndex];
        }

        public static double GetAverageFitness(double[] fitness) {
            double sum = 0;
            for (int i = 0; i < fitness.Length; i++) {
                sum += fitness[i];
            }

            return (sum / fitness.Length);
        }

        public static double GetBestFitness(double[] fitness) {
            int fittestIndex = 0;
            for (int i = 0; i < fitness.Length; i++) {
                if (fitness[i] > fitness[fittestIndex]) {
                    fittestIndex = i;
                }
            }
            return fitness[fittestIndex];
        }
    }
}
