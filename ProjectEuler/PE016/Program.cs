using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace PE016
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Globals.PowerDigitSum(1000)); // 1366
        }
    }

    public static class Globals
    {
        /// <summary>
        /// 2^power 값의 각 자리수 합 반환
        /// </summary>
        /// <param name="power"></param>
        /// <returns></returns>
        public static int PowerDigitSum(int power)
        {
            BigInteger powerValue = BigInteger.Pow(2, power);
            return DigitSum(powerValue);
        }

        /// <summary>
        /// number : Biginteger의 각 자리 수의 합 반환
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private static int DigitSum(BigInteger number)
        {
            int sum = 0;
            foreach (var val in number.ToString())
            {
                sum += (int)Char.GetNumericValue(val);
            }
            return sum;
        }
    }
}
