using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace PE029
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GenerateSequence(2, 100)); // 9183
        }

        static int GenerateSequence(int min, int max)
        {
            SortedSet<BigInteger> result = new SortedSet<BigInteger>();
            for (int a = min; a <= max; a++)
            {
                for (int b = min; b <=max; b++)
                {
                    result.Add((BigInteger)Math.Pow(a, b));
                }
            }
            return result.Count;
        }
    }

}
