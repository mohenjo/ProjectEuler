using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace PE053
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;

            for (int n = 1; n<=100; n++)
            {
                for (int r = 1; r <= n; r++)
                {
                    if (Globals.nCr(n, r) > 1000000) { count++; }
                }
            }
            Console.WriteLine(count); // 4075
        }
    }

    static class Globals
    {
        public static BigInteger Factorial(BigInteger aNumber)
        {
            if (aNumber == 0)
            {
                return 1;
            }
            else
            {
                return aNumber * Factorial(aNumber - 1);
            }
        }

        public static BigInteger nCr(int n, int r)
        {
            return Factorial(n) / (Factorial(r) * Factorial(n-r));
        }

    }
}
