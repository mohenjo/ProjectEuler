using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace PE050
{
    class Program
    {
        static void Main(string[] args)
        {
            /* 소수 리스트 P [2, 3, 5, ...], 이 리스트에 대한 누적리스트 PA [2, 5, 10, ...]가 주어졌을 떄, 
             * s 위치부터 e 위치까지 연속된 소수의 합은 diff = PA[e] - PA[s-1]과 같다(아래 참조).
             * 즉, diff 역시 소수인 경우 중에서 distance = e - s + 1이 최대인 값을 찾으면 됨
             * 
             * 참조: e = s라고 가정하면, s위치부터 s위치까지의 (연속된) 소수의 합은 P[s].
             * 즉. 연속된 소수의 합은 P[s] = PA[s] - PA[s] (= 0) 가 아니라 P[s] = PA[s] - PA[s-1]임. 
             * 따라서 P[0] = PA[0] - PA[0-1]를 계산하기 위해 PA는 [0, 2, 5, ...]로 작성돼야 하고,
             * P 리스트보다 인덱스 값이 1 크다.
             */

            PrimeNumber pn = new PrimeNumber(1000000);
            int maxLength = pn.GetMaxAddToPrimeLength(out BigInteger maxSumValue);
            Console.WriteLine($"{maxSumValue} by sum of cosecutive {maxLength} prime numbers.");
            // 997651, 543
        }
    }

    public class PrimeNumber
    {
        public List<int> List = new List<int>() { 2 };

        public List<BigInteger> AccumulatedList = new List<BigInteger>() { 0, 2 };

        private int UpperLimit { get; }

        public PrimeNumber(int upperLimit)
        {
            UpperLimit = upperLimit;
            InitializePrimeNumbers();
        }

        private void InitializePrimeNumbers()
        {
            int val = List.Last() + 1;
            BigInteger sum = List.Last();
            while (val <= UpperLimit)
            {
                if (List.All(element => val % element != 0))
                {
                    List.Add(val);
                    sum += val;
                    AccumulatedList.Add(sum);
                    // 화면출력
                    Console.Write($"Generating prime numbers class: {UpperLimit - val} to go.\r");
                }
                val++;
            }
            // 화면출력
            Console.Clear();
        }

        public int GetMaxAddToPrimeLength(out BigInteger maxSumValue)
        {
            int maxLength = 0;
            maxSumValue = 0;
            int maxPrimeNumber = List.Max();
            for (int start = 1; start < AccumulatedList.Count; start++)
            {
                Console.Write($"Solving: {AccumulatedList.Count - start} to go.\r");
                for (int end = start; end < AccumulatedList.Count; end++)
                {
                    int length = end - start + 1;
                    BigInteger diff = AccumulatedList[end] - AccumulatedList[start - 1];
                    if (BigInteger.Compare(diff, maxPrimeNumber) > 0)
                    {
                        // 소수 누적 리스트에서 차이값이 소수 리스트의 최대값보다 큰 경우가 발생할 수 있음
                        break;
                    }
                    if (length > maxLength && List.Contains((int)diff))
                    {
                        maxLength = length;
                        maxSumValue = diff;
                    }
                }
            }
            Console.Clear();
            return maxLength;
        }
    }
}
