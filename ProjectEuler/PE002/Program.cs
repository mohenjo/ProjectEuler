using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE002
{
    class Program
    {
        static void Main(string[] args)
        {
            int result = Fibonacci.SumEvenFibonacci(4000000);
            Console.WriteLine(result); // 4613732
        }
    }

    static class Fibonacci
    {
        public static int SumEvenFibonacci(int maxValue)
        {
            int sum = 0;
            List<int> fibList = new List<int> { 1, 2 };
            int nextValue = fibList[0] + fibList[1];
            int lastIndex = 1;

            while (nextValue <= maxValue)
            {
                fibList.Add(nextValue);
                lastIndex++;
                nextValue = fibList[lastIndex - 1] + fibList[lastIndex];
            }

            foreach (int val in fibList)
            {
                if (val % 2 == 0)
                    sum += val;
            }

            return sum;
        }
    }
}
