using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE009
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Global.Solve()); // 31875000
        }
    }

    static class Global
    {
        public static int Solve()
        {
            int result;
            for (int c = 3; c <= 1000; c++)
            {
                for (int b = 2; b < c; b++)
                {
                    for (int a = 1; a < b; a++)
                    {
                        if (a+b+c != 1000) { continue; }
                        if (a*a + b*b == c*c)
                        {
                            result = a * b * c;
                            return result;
                        }
                    }
                }
            }
            return 0;
        }
    }
}
