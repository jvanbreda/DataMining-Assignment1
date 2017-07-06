using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm {
    class GeneticModule {

        // Must be 2^n -1 (because the encoding works with binary strings)
        private static readonly int MAX_SEARCH_VALUE = 31;
        private static readonly Random r = new Random();

        public static Individual CreateIndividual() {
            int[] genes = new int[(int)Math.Log(MAX_SEARCH_VALUE + 1, 2)];
            for (int i = 0; i < (int)Math.Log(MAX_SEARCH_VALUE + 1, 2); i++) {
                genes[i] = r.Next(2);
            }

            return new Individual(genes);
        }

        public static double ComputeFitness(Individual ind) {
            int x = ind.GenesToDigit();
            return -Math.Pow(x, 2) + 7 * x;
        }

        public static Tuple<Individual, Individual> SelectTwoParents(Individual[] population, double[] fitness) {
            int counter = 0;
            Individual[] tournamentWinners = new Individual[2];

            int maxTournamentContestants = population.Length / 4;

            while(counter < 2) {
                List<int> randomIndeces = new List<int>();
                for (int i = 0; i < maxTournamentContestants; i++) {
                    randomIndeces.Add(r.Next(population.Length));
                }

                List<double> fitnesses = new List<double>();
                foreach (int randomIndex in randomIndeces) {
                    fitnesses.Add(fitness[randomIndex]);
                }

                int highestFitnessIndex = 0;
                for (int i = 0; i < fitnesses.Count; i++) {
                    if (fitnesses[i] > fitnesses[highestFitnessIndex])
                        highestFitnessIndex = i;
                }

                tournamentWinners[counter] = population[highestFitnessIndex];
                counter++;

            }
            return new Tuple<Individual, Individual>(tournamentWinners[0], tournamentWinners[1]);
        }

        public static Tuple<Individual, Individual> Crossover(Tuple<Individual, Individual> parents) {
            Individual parent1 = parents.Item1;
            Individual parent2 = parents.Item2;

            Individual[] childrenArray = new Individual[2];

            int counter = 0;

            while (counter < 2) {
                int[] childgenes = new int[parent1.Length()];
                int randomIndex = r.Next(parent1.Length());
                for (int i = 0; i < randomIndex; i++) {
                    childgenes[i] = parent1.genes[i];
                }
                for (int i = randomIndex; i < parent1.Length(); i++) {
                    childgenes[i] = parent2.genes[i];
                }

                childrenArray[counter] = new Individual(childgenes);
                counter++;
            }

            return new Tuple<Individual, Individual>(childrenArray[0], childrenArray[1]);
        }

        public static Individual Mutation(Individual ind, double mutationRate) {
            double random = r.NextDouble();
            if (random < mutationRate) {
                ind.ModifyGene(r.Next(ind.Length()));
            }

            return ind;
        }

    }
}
