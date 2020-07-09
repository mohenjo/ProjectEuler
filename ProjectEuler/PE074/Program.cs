using System;
using System.Collections.Generic;
using System.Linq;

namespace PE074
{
    internal class Program
    {
        private static void Main()
        {
            int result = Enumerable.Range(0, 1_000_001)
                .Where(num => (new Solver(num)).GetChainCount() == 60)
                .Count();
            Console.WriteLine(result); // 402
        }
    }

    internal class Solver
    {
        private readonly int StartNumber;

        public Solver(int number)
        {
            StartNumber = number;
        }

        public int GetChainCount()
        {
            List<int> history = new List<int>();
            int number = StartNumber;
            while (!history.Contains(number))
            {
                history.Add(number);
                number = FactorialSum(number);
            }
            return history.Count;
        }

        static Solver()
        {
            for (int i = 0; i < 10; i++)
            {
                Fact[i] = Factorial(i);
            }
        }

        public static int[] Fact = new int[10];

        private static int Factorial(int num)
        {
            if (num == 0)
            {
                return 1;
            }
            else
            {
                return num * Factorial(num - 1);
            }
        }

        public static int FactorialSum(int number)
        {
            int sum = 0;
            foreach (char c in number.ToString())
            {
                sum += Fact[(int)char.GetNumericValue(c)];
            }
            return sum;
        }
    }
}
