using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm {
    class GArunner {

        private double crossoverRate;
        private double mutationRate;
        private bool elitism;
        private int populationSize;
        private int iterations;

        private static readonly Random r = new Random();

        public GArunner(double crossoverRate, double mutationRate, bool elitism, int populationSize, int iterations) {
            this.crossoverRate = crossoverRate;
            this.mutationRate = mutationRate;
            this.elitism = elitism;
            this.populationSize = populationSize;
            this.iterations = iterations;
        }

        public Tuple<Individual[], double[]> Run() {

            // create initial population
            Individual[] initialPopulation = new Individual[populationSize];
            for (int i = 0; i < initialPopulation.Length; i++) {
                initialPopulation[i] = GeneticModule.CreateIndividual();
            }

            Individual[] currentPopulation = initialPopulation;

            // Looping to improve
            for (int generation = 0; generation < iterations; generation++) {
                double[] fitness = new double[populationSize];
                // calculate the fitness of each individual
                for (int i = 0; i < populationSize; i++) {
                    fitness[i] = GeneticModule.ComputeFitness(currentPopulation[i]);
                }

                Individual[] newPopulation = new Individual[populationSize];

                // if elitism is enabled, select the fittest individual and copy it to the new population
                // else, skip this step
                int startIndex;
                if (elitism) {
                    newPopulation[0] = Calculator.GetFittestIndividual(currentPopulation, fitness);
                    startIndex = 1;
                }
                else {
                    startIndex = 0;
                }

                // The rest of the population is filled with parents and offspring from parents of the current population
                for (int i = startIndex; i < populationSize; i++) {
                    Tuple<Individual, Individual> parents = GeneticModule.SelectTwoParents(currentPopulation, fitness);
                    Tuple<Individual, Individual> children;
                    if(crossoverRate > r.NextDouble()) {
                        children = GeneticModule.Crossover(parents);
                    }
                    else {
                        children = parents;
                    }

                    newPopulation[i] = GeneticModule.Mutation(children.Item1, mutationRate);
                    if(i + 1 < populationSize) {
                        newPopulation[i + 1] = GeneticModule.Mutation(children.Item2, mutationRate);
                    }
                }

                currentPopulation = newPopulation;
                Console.Write("\r{0}%", Math.Floor(((double)generation / iterations) * 100));
            }

            double[] lastPopulationFitness = new double[populationSize];
            for (int i = 0; i < populationSize; i++) {
                lastPopulationFitness[i] = GeneticModule.ComputeFitness(currentPopulation[i]);
            }
            
            return new Tuple<Individual[], double[]>(currentPopulation, lastPopulationFitness);
        }
    }
}
