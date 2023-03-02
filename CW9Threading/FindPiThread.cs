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
        private int numDartsToThrow;    //also total number of darts
        private int numDartsInside;

        // Instantiating Random Num. Generator
        private Random rand;

        // Random Number 
        private double RandXCoordinate;
        private double RandYCoordinate;
        private double HypotenuseValue;

        FindPiThread(int numDartsToThrow)
        {
            this.numDartsToThrow = numDartsToThrow;
            numDartsInside = 0;
            rand = new Random();
        }

        // When called, Assigns a randomized double (0.0-0.99999999999999978) to RandXCoordinate and RandYCoordinate
        public void ThrowDart()
        {
            for(int i = 0; i < numDartsToThrow; i++)
            {
                RandXCoordinate = rand.NextDouble();
                RandYCoordinate = rand.NextDouble();
                HypotenuseValue = (RandXCoordinate * RandXCoordinate) + (RandYCoordinate * RandYCoordinate);
            }
        }

        public int GetNumDartsInside()
        {
            return numDartsInside;
        }
    }
}
