using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace PE020
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger input = new BigInteger(100);
            Console.WriteLine(input.FactorialSum()); // 648
        }
    }

    public static class Globals
    {
        public static BigInteger Factorial(this BigInteger aNumber)
        {
            BigInteger result = 0;

            if (aNumber == 0) { return 1; }
            else
            {
                return aNumber * (aNumber - 1).Factorial();
            }
        }

        public static int FactorialSum(this BigInteger aNumber)
        {
            int result = 0;

            string tmpString = aNumber.Factorial().ToString();
            foreach (char chr in tmpString)
            {
                result += (int)Char.GetNumericValue(chr);
            }

            return result;
        }
    }
}
