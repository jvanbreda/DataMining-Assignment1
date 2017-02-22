using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm {
    class Program {

        
        static void Main(string[] args) {

            GArunner ga = new GArunner(0.9, 0.05, true, 25, 10);
            Tuple<Individual[], double[]> result = ga.Run();

            Console.WriteLine();
            Console.WriteLine(string.Format("Average fitness of last population: {0}", Calculator.GetAverageFitness(result.Item2)));
            Console.WriteLine(string.Format("Best fitness of last population: {0}", Calculator.GetBestFitness(result.Item2)));
            Console.WriteLine(string.Format("Best individual: {0}", Calculator.GetFittestIndividual(result.Item1, result.Item2)));

            Console.Read();

        }
    }
}
