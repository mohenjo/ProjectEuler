using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE023
{
    class Program
    {
        static void Main(string[] args)
        {
            // 초과수 컬렉션 of [1..uperLimit]
            int upperLimit = 28123;
            List<int> abundantList = new List<int>();
            for (int i = 1; i <= upperLimit; i++)
            {
                if (i.IsAbundant())
                {
                    abundantList.Add(i);
                }
            }

            // 초과수의 합 컬렉션 of [1..uperLimit]
            HashSet<int> sumAbundantNumbers = new HashSet<int>();
            foreach (int i in abundantList)
            {
                foreach (int j in abundantList)
                {
                    int tmp = i + j;
                    if (tmp <= upperLimit) { sumAbundantNumbers.Add(tmp); }
                }
            }

            // 초과수가 아닌 수 컬렉션 of [1..uperLimit]
            List<int> nonSumAbundants = new List<int>();
            for (int val = 1; val <= upperLimit; val++)
            {
                if (!sumAbundantNumbers.Contains(val))
                {
                    nonSumAbundants.Add(val);
                }
            }
            Console.WriteLine(nonSumAbundants.Sum()); // 4179871
        }
    }

    public static class Globals
    {
        // 초과수(A의 진 약수 합이 A보다 큰 경우)인 경우 참 반환
        public static bool IsAbundant(this int aNumber)
        {
            bool check = false;
            SortedSet<int> divisors = new SortedSet<int>() { 1 };

            for (int i = 2; i <= Convert.ToInt32(Math.Sqrt(aNumber)); i++)
            {
                if (aNumber % i == 0)
                {
                    divisors.Add(i);
                    divisors.Add(aNumber / i);
                }
            }
            if (divisors.Sum() > aNumber) { check = true; }

            return check;
        }
    }
}
