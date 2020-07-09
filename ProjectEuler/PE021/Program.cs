using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE021
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedSet<int> result = new SortedSet<int>();
            int maxValue = 10000;
            for (int aNumber = 1; aNumber < maxValue; aNumber++)
            {
                if (aNumber.IsAmicable(out int otherNumber))
                {
                    if (aNumber == otherNumber) { continue; }
                    if (aNumber < maxValue && otherNumber < maxValue)
                    {
                        result.Add(aNumber);
                        result.Add(otherNumber);
                    }
                }
            }
            Console.WriteLine(result.Sum()); // 31626
        }
    }

    public static class Globals
    {
        private static int SumDivisors(int aNumber)
        {
            SortedSet<int> divisors = new SortedSet<int>() { 1 };

            for (int i = 2; i <= Convert.ToInt32(Math.Sqrt(aNumber)); i++)
            {
                if (aNumber % i == 0)
                {
                    divisors.Add(i);
                    divisors.Add(aNumber / i);
                }
            }

            return divisors.Sum();
        }

        public static bool IsAmicable(this int aNumber, out int otherNumber)
        {
            bool isAmicable = false;
            otherNumber = -1;

            // amicable check
            int f_aNumber = SumDivisors(aNumber);
            int bNumber = f_aNumber;
            int f_bNumber = SumDivisors(bNumber);
            if (f_bNumber == aNumber)
            {
                isAmicable = true;
                otherNumber = bNumber;
            }

            return isAmicable;
        }
    }

}
