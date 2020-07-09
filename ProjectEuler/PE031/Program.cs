using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE031
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] coins = { 1, 2, 5, 10, 20, 50, 100, 200 };
            int target = 200;
            int[] cases = new int[target + 1];

            cases[0] = 1;
            foreach (int c in coins)
            {
                for (int i = c; i <= target; i++)
                {
                    cases[i] += cases[i - c];
                }
            }
            Console.WriteLine(cases[200]); // 73682
        }
    }
}
