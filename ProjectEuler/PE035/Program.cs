using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE035
{
    class Program
    {
        static void Main(string[] args)
        {
            CircularPrimes cp = new CircularPrimes(1000000);
            cp.DisplayCircularPrimeNumbers(); // 55
            Console.ReadKey();
        }
    }

    public class CircularPrimes
    {
        private List<int> PrimeNumbers { get; set; }
        private int PrimeNumberLimit { get; }

        public CircularPrimes(int primeNumberLimit)
        {
            PrimeNumberLimit = primeNumberLimit;
            GeneratePrimeNumbers();
        }

        private void GeneratePrimeNumbers()
        {
            PrimeNumbers = new List<int>() { 2, 3, 5 }; // 게산시간 단축을 위해 기본 소수 입력해둠
            List<int> Numbers = Enumerable.Range(2, PrimeNumberLimit - 1)
                .Where(n => (n % 2 != 0) && (n % 3 != 0) && (n % 5 != 0)).ToList();


            while (Numbers.Count != 0)
            {
                // display process
                Console.Write($"Initializing class: {Numbers.Count} calculation remains.\r");

                PrimeNumbers.Add(Numbers[0]);
                int cmpVal = Numbers[0];
                int idx = 0;
                while (idx < Numbers.Count)
                {
                    if (Numbers[idx] % cmpVal == 0)
                    {
                        Numbers.RemoveAt(idx);
                    }
                    else
                    {
                        idx++;
                    }
                }
            }
            Console.Clear();
        }

        private bool IsAllPrimeNumbers(List<int> aList)
        {
            bool check = true;
            foreach (int val in aList)
            {
                if (!PrimeNumbers.Contains(val))
                {
                    check = false;
                    break;
                }
            }
            return check;
        }

        public void DisplayCircularPrimeNumbers()
        {
            int result = 0;
            foreach (int val in PrimeNumbers)
            {
                if (IsAllPrimeNumbers(Globals.CircularNumbers(val)))
                {
                    Console.Write($"{val} ");
                    result++;
                }
            }
            Console.WriteLine();
            Console.WriteLine($"Found {result} circular prime numbers under {PrimeNumberLimit}");

        }
    }

    public static class Globals
    {
        public static List<int> CircularNumbers(int aNumber)
        {
            List<int> result = new List<int>();

            string tmpString = String.Empty;
            string aStrNum = aNumber.ToString();
            for (int idx = 0; idx < aStrNum.Length; idx++)
            {
                tmpString = aStrNum.Substring(idx);
                if (idx > 0)
                {
                    tmpString += aStrNum.Substring(0, idx);
                }
                result.Add(Convert.ToInt32(tmpString));
            }

            return result;
        }
    }
}
