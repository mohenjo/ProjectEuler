using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace PE048
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Globals.SumSelfPowers(1000)); // 9110846700
        }
    }

    public static class Globals
    {
        private static BigInteger SelfPower(BigInteger aNumber)
        {
            // 아래와 같이 원리대로 계산할 경우, 1000^1000 계산 시 무한대 값 반환
            //BigInteger result = (BigInteger)Math.Pow((double)aNumber, (double)aNumber);

            // 따라서 아래와 같이 멱승을 직접 계산하면서 마지막 10자리만 반환함.
            BigInteger result = 1;
            for (int i = 1; i <= aNumber; i++)
            {
                result *= aNumber;
                // 마지막 n 자리 => 10^n 자리로 나눈 나머지 : 마지막 10자리
                result = BigInteger.Remainder(result, (BigInteger)Math.Pow(10, 10));
            }
            return result;
        }

        public static BigInteger SumSelfPowers(BigInteger untilNumber)
        {
            BigInteger sum = 0;
            for (BigInteger i = 1; i <= untilNumber; i++)
            {
                sum += SelfPower(i);
            }
            sum = BigInteger.Remainder(sum, (BigInteger)Math.Pow(10, 10));
            return sum;
        }
    }
}
