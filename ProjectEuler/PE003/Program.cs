using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE003
{
    class Program
    {
        static void Main(string[] args)
        {
            long rst = Factor.MaxPrimeFactors(600851475143); // 6857
            Console.WriteLine(rst);
        }
    }

    static class Factor
    {
        public static long MaxPrimeFactors(long number)
        {
            List<long> primeFactors = new List<long> { };
            long target = number;
            long checkValue = 2;
            while (checkValue <= target)
            {
                if (target % checkValue == 0)
                {
                    primeFactors.Add(checkValue);
                    while (target % checkValue == 0) { target /= checkValue; }
                }
                else
                {
                    checkValue++;
                }
            }

            return primeFactors.Max();
        }
    }
}
