using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE026
{
    class Program
    {
        static void Main(string[] args)
        {
            int cyclicLength, maxCyclicLength = 0;
            int numberWithMaxCyclicLength =0;
            for (int i = 2; i < 1000; i++)
            {
                cyclicLength = GetCyclicLength(i);
                if (cyclicLength > maxCyclicLength)
                {
                    maxCyclicLength = cyclicLength;
                    numberWithMaxCyclicLength = i;
                }
                /* 각 숫자별 출력
                Console.Write("{0,3}: ", i);
                if (cyclicLength == 0)
                {
                    Console.WriteLine("just dividable.");
                }
                else
                {
                    Console.WriteLine("cyclic length {0}", cyclicLength);
                }
                */
            }
            Console.WriteLine("The maximum cyclic length is {0} with the number {1}",
                maxCyclicLength, numberWithMaxCyclicLength);
        }

        static int GetCyclicLength(int divisor)
        {
            List<int> quotientList = new List<int>();
            List<int> remainderList = new List<int>();
            int remainder;
            int repeatLength = 0;
            int dividend = 1;
            do
            {
                while (dividend < divisor)
                {
                    dividend *= 10;
                    quotientList.Add(0);
                }
                remainder = dividend % divisor;
                if (remainderList.Contains(remainder))
                {
                    repeatLength = remainderList.Count - remainderList.IndexOf(remainder);
                    break;
                }
                quotientList.Add(dividend / divisor);
                remainderList.Add(remainder);
                dividend = remainder * 10;
            } while (remainder != 0);

            return repeatLength;
        }
    }
}
