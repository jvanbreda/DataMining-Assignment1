using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm {
    public class Individual {

        public int[] genes{ get; private set;}

        public Individual(int[] genes) {
            this.genes = genes;
        }

        public int Length() {
            return genes.Length;
        }

        public int GenesToDigit() {
            int value = 0;
            for (int i = 0; i < genes.Length; i++) {
                value += genes[i] * (int) Math.Pow(2, (genes.Length - 1 - i));
            }

            return value;
        }

        public void ModifyGene(int index) {
            genes[index] = (genes[index] == 0 ? 1 : 0);
        }

        public override string ToString() {
            string genesString = "";
            for (int i = 0; i < genes.Length; i++) {
                genesString += genes[i] + "";
            }

            return string.Format("Individual({0})", genesString);
        }


    }
}
