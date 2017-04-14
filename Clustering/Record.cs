using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clustering {
    public class Record {
        public int offerNumber { get; private set; }
        public float timesBought { get; private set; }

        public Record(int offerNumber, float timesBought) {
            this.offerNumber = offerNumber;
            this.timesBought = timesBought;
        }
    }
}
