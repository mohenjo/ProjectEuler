using System;
using System.Linq;

namespace PE092
{
    internal class Program
    {
        private static void Main()
        {
            int upto = 10_000_000;
            int count = Enumerable.Range(1, upto).Where(n => IsStuck89(n)).Count();
            Console.WriteLine(count); // 8581146
            Console.ReadKey();
        }

        private static bool IsStuck89(int aNumber)
        {
            while (aNumber != 89 && aNumber != 1)
            {
                aNumber = GetNextSeries(aNumber);
            }
            if (aNumber == 89) { return true; } else { return false; }
        }

        private static int GetNextSeries(int aNumber)
        {
            while (aNumber % 10 == 0)
            {
                aNumber /= 10;
            }
            int squareSum = 0;
            foreach (char c in aNumber.ToString())
            {
                squareSum += (int)Math.Pow(int.Parse(c.ToString()), 2);
            }
            return squareSum;
        }
    }
}
