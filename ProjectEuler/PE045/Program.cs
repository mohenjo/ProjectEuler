using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace PE045
{
    class Program
    {
        static void Main(string[] args)
        {
            bool check = false;
            int n_Hn = 143; // the last integer for hexagonal number as shown in the problem
            BigInteger Hn = 0;
            while (!check)
            {
                n_Hn++;
                Console.Write($"Checking integer {n_Hn}...\r");
                Hn = Globals.GenHexagonal(n_Hn);
                check = Globals.IsPentagonal(Hn);
            }
            Console.Clear();
            Console.WriteLine($"{Hn} is triagular, pentagonal, and hexagonal."); // 1533776805
        }
    }

    public static class Globals
    {
        // Generate Hexagonal number for an integer n
        // All hexagonal numbers are also triangular
        public static BigInteger GenHexagonal(int aNumber)
        {
            return aNumber * (2 * aNumber - 1);
        }

        // When a number Pn is a pentagonal number,
        // corresponding n = (-1 + Math.Sqrt(1 + 24*Pn)) / 6 and n must be an integer
        public static bool IsPentagonal(BigInteger Pn)
        {
            double eq = (1 + Math.Sqrt((double)(1 + 24 * Pn))) / 6;
            if (eq % 1 == 0) { return true; }
            else { return false; }
        }
    }
}
