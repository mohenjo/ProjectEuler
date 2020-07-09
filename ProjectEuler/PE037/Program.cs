using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE037
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            int sum = 0;
            while (count < 11) 
            {
                Globals.GenNextPrimeNumber();
                int newPrime = Globals.PrimeNumbers.Last();
                Console.Write($"Check Prime Value: {newPrime}\r");
                if (Globals.IsInterestingNumber(newPrime))
                {
                    count++;
                    sum += newPrime;
                    Console.WriteLine($"Found {count, 2} of 11 interesting prime number: {newPrime}");
                }
            } 
            Console.WriteLine($"Sum of interesting prime numbers is {sum}"); // 748317

        }
    }

    public static class Globals
    {
        public static List<int> PrimeNumbers = new List<int>() { 2, 3, 5, 7 };

        private static List<int> TruncateNumber(int aNumber)
        {
            HashSet<int> result = new HashSet<int>();

            string aNumStr = aNumber.ToString();
            // remove from left
            for (int i = 0; i < aNumStr.Length; i++)
            {
                result.Add(Convert.ToInt32(aNumStr.Substring(i)));
            }
            // remove from right
            for (int i = aNumStr.Length; i > 0; i--)
            {
                result.Add(Convert.ToInt32(aNumStr.Substring(0, i)));
            }

            return result.ToList();
        }

        public static void GenNextPrimeNumber()
        {
            int startNum = PrimeNumbers.Last() + 1;
            bool check = false;
            while (!check)
            {
                check = true;
                foreach (int primeNumber in PrimeNumbers)
                {
                    if (startNum % primeNumber == 0)
                    {
                        check = false;
                        break;
                    }
                }
                if (check)
                {
                    PrimeNumbers.Add(startNum);
                }
                else
                {
                    startNum++;
                }
            }
        }

        public static bool IsInterestingNumber(int aNumber)
        {
            int checkLast = (int)Char.GetNumericValue(aNumber.ToString().Last());
            if (checkLast != 3 && checkLast != 7) { return false; }

            bool result = true;

            foreach (int val in TruncateNumber(aNumber))
            {
                if (!PrimeNumbers.Contains(val)) { result = false; }
            }
            return result;
        }
    }

}
