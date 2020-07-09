using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE027
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxLength = 0;
            int productOfab = 0;

            for (int a = -999; a < 1000; a++)
            {
                for (int b = -1000; b <= 1000; b++)
                {
                    if (!b.IsPrime() || b <= 2) { continue; } // n = 0인 경우 고려, b는 소수여야 함.
                    int tmpValue = Globals.GetLengthOfConsecutivePrimeNumbers(a, b);
                    if (tmpValue > maxLength)
                    {
                        maxLength = tmpValue;
                        productOfab = a * b;
                    }
                }
            }
            Console.WriteLine(productOfab); // -59231

        }
    }

    public static class Globals
    {
        public static bool IsPrime(this int aNumber) // aNumber >= 2
        {
            if (aNumber < 2) { return false; }

            bool result = true;
            for (int i = 2; i <= (int)Math.Sqrt(aNumber) + 1; i++)
            {
                if (aNumber % i == 0 && aNumber != 2) { result = false; break; }
            }

            return result;
        }

        public static bool IsEqPrime(int n, int a, int b)
        {
            // Quadratic formula
            // where, Abs(a) < 1000, Abs(b) <= 1000
            int result = n * n + a * n + b;
            return result.IsPrime();
        }

        public static int GetLengthOfConsecutivePrimeNumbers(int a, int b)
        {
            int length = 0;
            int n = 0;
            while (IsEqPrime(n++, a, b))
            {
                length++;
            }
            return length;
        }
    }

}
