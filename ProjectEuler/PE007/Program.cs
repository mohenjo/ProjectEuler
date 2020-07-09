using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE007
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(PrimeNumber.GetNth(10001)); // 104743
        }
    }

    static class PrimeNumber
    {
        public static int GetNth(int nth)
        {
            List<int> primeNumber = new List<int> { 2 };
            while (primeNumber.Count < nth)
            {
                int checkNumber = primeNumber.Last() + 1;
                while (!_IsNewPrime(checkNumber, primeNumber))
                {
                    checkNumber++;
                }
                primeNumber.Add(checkNumber);
            }
            return primeNumber.Last();
        }

        // aNumber가 aList의 모든 요소 값으로 나누어지지 않을 경우(새로운 소수일 경우) 참 반환
        private static bool _IsNewPrime(int aNumber, List<int> aList)
        {
            bool result = true;
            foreach (var val in aList)
            {
                if (aNumber % val == 0) { result = false; }
            }
            return result;
        }
    }
}
