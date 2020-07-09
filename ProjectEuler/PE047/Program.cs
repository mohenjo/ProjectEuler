using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE047
{
    class Program
    {
        static void Main(string[] args)
        {
            bool found = false;
            int checkNumber = 0;
            while (!found)
            {
                checkNumber++;
                Console.Write($"Checking primes factors at {checkNumber}...\r");
                found = checkNumber.IsConsecutive(4);
            }
            Console.Clear();
            Console.WriteLine(checkNumber); // 134043
        }
    }

    public static class Globals
    {
        public static bool IsConsecutive(this int aNumber, int numberOfPrimes)
        {
            bool result = true;
            for (int i = 0; i < numberOfPrimes; i++)
            {
                Factor fc = new Factor(aNumber + i);
                if (fc.NumberOfFactors != numberOfPrimes)
                {
                    result = false;
                    break;
                }
            }
            return result;
        }
    }

    public class Factor
    {
        private List<int> PrimeFactors = new List<int>();
        public int NumberOfFactors => PrimeFactors.Count;

        public Factor(int aNumber)
        {
            PrimeFactors = GeneratePrimeFactors(aNumber);
        }

        private List<int> GeneratePrimeFactors(int aNumber)
        {
            List<int> primeFactors = new List<int>();
            int target = aNumber;
            int checkValue = 2;
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
            return primeFactors;
        }
    }
}
