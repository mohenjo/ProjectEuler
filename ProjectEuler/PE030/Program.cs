using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE030
{
    class Program
    {
        static void Main(string[] args)
        {
            // n자리 999.. 숫자 An 의 sum(각 자리 수^5)의 자리수를 B라고 하면
            // A5 -> B = 6, A6 -> 6, A7 -> 6, ...
            // 즉, 주어진 수 A의 자리 수가 7자리를 이상이면, 각 자리수^5의 합(각 자리 수가 9라고 하더라도)
            // 으로 해당 자리 수의 숫자 A를 만들 수 없다.
            // 따라서, 고려 가능한 숫자 A의 최대 범위를 6자리 숫자 999999까지로 가정.
            int sum = 0;
            for (int i = 2; i < 999999; i++)
            {
                if (IsEqualToSumOfFifthPowerOfDigits(i)) { sum += i; }
            }
            Console.WriteLine(sum); // 443839

        }

        private static int SumOfFifthPowerOfDigits(int aNumber)
        {
            int sum = 0;
            foreach (char val in aNumber.ToString())
            {
                sum += (int)Math.Pow(Char.GetNumericValue(val), 5);
            }
            return sum;
        }

        public static bool IsEqualToSumOfFifthPowerOfDigits(int aNumber)
        {
            bool result = false;
            if (aNumber == SumOfFifthPowerOfDigits(aNumber))
            {
                result = true;
            }
            return result;
        }
    }
}
