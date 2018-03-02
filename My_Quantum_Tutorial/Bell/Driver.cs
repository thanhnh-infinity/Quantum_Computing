using Microsoft.Quantum.Simulation.Core;
using Microsoft.Quantum.Simulation.Simulators;

namespace Quantum.Bell
{
    class Driver
    {
        static void Main(string[] args)
        {
            //Construct a quantum simulator sim -- scope inside using statement only
            using (var sim = new QuantumSimulator())
            {
                Result[] initials = new Result[]{Result.Zero, Result.One};
                foreach (Result initial in initials)
                {
                    //Run method is used to call Quantum operation from C#-- it is asynchronously execution -- it means when fetch the Result property of Q# operation BellTest to variable res, this blocks execution until the task complets and return result synchronously
                    var res = BellTest.Run(sim,1000,initial).Result;
                    var (numZeros, numOnes) = res;
                    System.Console.WriteLine($"Init:{initial,-4} 0s={numZeros,-4} 1s={numOnes,-4}");

                }
            }

            using (var sim = new QuantumSimulator())
            {
                Result[] initials = new Result[]{Result.Zero, Result.One};
                foreach (Result initial in initials)
                {
                    //Run method is used to call Quantum operation from C#-- it is asynchronously execution -- it means when fetch the Result property of Q# operation BellTest2 to variable res, this blocks execution until the task complets and return result synchronously
                    var res = BellTest_2.Run(sim,1000,initial).Result;
                    var (numZeros, numOnes,agree) = res;
                    System.Console.WriteLine($"Init:{initial,-4} 0s={numZeros,-4} 1s={numOnes,-4} agree={agree,-4}");

                }
            }

            System.Console.WriteLine("Press any key to continue...");
            System.Console.ReadKey();
        }
    }
}