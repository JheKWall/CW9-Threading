using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CW9Threading
{
    internal class Program
    {
        //Timer
        private static System.Timers.Timer stopWatch;

        static void Main(string[] args)
        {
            // Stopwatch
            int timer = 0;
            stopWatch = new System.Timers.Timer(interval: 1000);
            stopWatch.Elapsed += (sender, e) => timer++;

            ulong numDartsToThrow;
            int numThreadsToRun;
            ulong numDartsInside = 0; // Accumulator initialized to zero

            // Cool Lists involving threads
            List<Thread> listThread = new List<Thread>();
            List<FindPiThread> listFindPiThread = new List<FindPiThread>();

            Console.WriteLine("How many darts to throw? (Beware: choose carefully.)");
            numDartsToThrow = Convert.ToUInt64(Console.ReadLine());  // Workaround (or maybe intended way) to read in the number of darts to throw.

            Console.WriteLine("How many threads to run? (Not as serious as the last question, pick any large number.)");
            numThreadsToRun = Convert.ToInt32(Console.ReadLine());

            listThread.Capacity = numThreadsToRun;
            listFindPiThread.Capacity = numThreadsToRun;

            // Startup Loop
            stopWatch.Start();
            for (int i = 0; i < numThreadsToRun; i++)
            {
                //1. Creating a new FindPiThread object and assigning it to a position within the FindPiThread list.
                listFindPiThread.Add(new FindPiThread(numDartsToThrow));

                //2. Creating a new Thread with the FindPiThread object we just created, then throwing the new Thread into the Thread list.
                listThread.Add(new Thread(new ThreadStart(listFindPiThread[i].throwDarts)));

                //3. Starting thead and putting Main() to sleep (for 16 milliseconds)
                listThread[i].Start();
                Thread.Sleep(16);
            }

            // Waiting Loop
            for(int i = 0; i < numThreadsToRun; i++)
            {
                //Tells main to wait until every thead is done before continuing.
                listThread[i].Join();
            }

            // Collection Loop
            for(int i = 0; i < numThreadsToRun; i++)
            {
                numDartsInside += listFindPiThread[i].GetNumDartsInside();
            }

            // Drumroll Generator (Pi Evaluation)
            Console.WriteLine("The results are in... The evaluation of Pi using " + numThreadsToRun + " threads each throwing " + numDartsToThrow + " is: " + 4.0 * (Convert.ToDouble(numDartsInside)) / (Convert.ToDouble(numDartsToThrow) * numThreadsToRun) + "\n");
            stopWatch.Dispose();
            Console.WriteLine("The whole calculation took approximately " + timer + " seconds.\n");

            // Tactical Console Readkey to Pause (T.C.R.P)
            Console.ReadKey();
        }
    }
}
