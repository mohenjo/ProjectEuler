using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE017
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            for (int i = 1; i <= 1000; i++)
            {
                NumberLetter val = new NumberLetter(i);
                Console.WriteLine("{0} -> {1} | {2}", i, val.CountMe(), val.ReadMe());
                count += val.CountMe();
            }
            Console.WriteLine(count); // 21124
        }
    }
}
