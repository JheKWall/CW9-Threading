using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW9Threading
{
    internal class FindPiThread
    {
        // Values that store Dart Values
        private ulong numDartsToThrow;    //also total number of darts
        private ulong numDartsInside;

        // Instantiating Random Num. Generator
        private Random rand;

        // Random Number 
        private double RandXCoordinate;
        private double RandYCoordinate;
        private double HypotenuseValue;

        public FindPiThread(ulong numDartsToThrow)
        {
            this.numDartsToThrow = numDartsToThrow;
            numDartsInside = 0;
            rand = new Random();
        }

        // 1. Loop that loops numDartsToThrow times
        // 2. Assigns a randomized double (0.0-0.99999999999999978) to RandXCoordinate and RandYCoordinate
        // 3. Calculates Hypotenuse from the two randomized coordinates
        // 4. Checks if Hypotenuse < 1.0, which would be "within" "the" "circle" "of" "the" "dart" "board."
        public void throwDarts()
        {
            for(ulong i = 0; i < numDartsToThrow; i++)
            {
                RandXCoordinate = rand.NextDouble();
                RandYCoordinate = rand.NextDouble();
                HypotenuseValue = (RandXCoordinate * RandXCoordinate) + (RandYCoordinate * RandYCoordinate);
                if (HypotenuseValue < 1.0)
                {
                    numDartsInside++;
                }
            }
        }

        public ulong GetNumDartsInside()
        {
            return numDartsInside;
        }
    }
}
