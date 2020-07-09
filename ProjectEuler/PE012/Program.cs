using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE012
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Globals.GenTriangleNumber(500)); // 76576500
        }
    }

    public static class Globals
    {
        public static SortedSet<int> Factors(int number)
        {
            SortedSet<int> factors = new SortedSet<int>();

            for (int i = 1; i <= (int)Math.Sqrt(number) + 1; i++)
            {
                if (number % i == 0)
                {
                    factors.Add(i); factors.Add(number / i);
                }
            }
            return factors;
        }

        public static int GenTriangleNumber(int numberOfFacotrs)
        {
            int sum = 0;
            int naturalNumber = 1;
            while (true)
            {
                sum += naturalNumber;
                if (Factors(sum).Count() > numberOfFacotrs)
                {
                    return sum;
                }
                naturalNumber++;
            }
        }
    }
}
