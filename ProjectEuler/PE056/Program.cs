using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace PE056
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger maxDigitSum = 0;
            for (int a =1; a<100; a++)
            {
                for (int b=0; b <100; b++)
                {
                    BigInteger sum = DigitSum(a, b);
                    maxDigitSum = (sum > maxDigitSum) ? sum : maxDigitSum;
                }
            }
            Console.WriteLine(maxDigitSum); // 972
        }

        static BigInteger DigitSum(int a, int b)
        {
            BigInteger result = 0;
            foreach (char valChr in BigInteger.Pow(a, b).ToString())
            {
                result += BigInteger.Parse(valChr.ToString());
            }

            return result;
        }
    }


}
