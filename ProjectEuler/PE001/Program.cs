using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE001
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(SumOfMultiples(1000)); // 233168
        }

        static int SumOfMultiples(int number)
        {
            int sum = 0;
            for (int i = 0; i < number; i++)
            {
                if (i % 3 == 0 || i % 5 == 0) { sum += i; }
            }
            return sum;
        }
    }
}
