using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE005
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(SmallestMultiple.GetSmallestMultiple(20)); // 232792560
        }
    }

    static class SmallestMultiple
    {
        // dividend가 [1..maxDividor] 모두로 나누어 떨어지는 지 체크 (true for yes)
        private static bool _IsDivisible(int dividend, int maxDivisor)
        {
            bool answer = true;
            for (int i = maxDivisor; i >= 1; i--)
            {
                if (dividend % i != 0)
                {
                    answer = false;
                    break;
                }
            }
            return answer;
        }

        public static int GetSmallestMultiple(int maxDivisor)
        {
            int checkNum = maxDivisor;
            while (_IsDivisible(checkNum, maxDivisor) == false)
            {
                checkNum += maxDivisor;
            }
            return checkNum;
        }
    }
}
