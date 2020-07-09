using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE034
{
    class Program
    {
        static void Main(string[] args)
        {
            //for (int i = 1; i <= 9; i++)
            //{
            //    Console.WriteLine($"{i}자리 => {9.Factorial() * i}");
            //}
            // 8자리 이상의 수부터는 모든 자리수가 9로 구성돼 있더라도
            // 각 자리수 팩토리얼 값의 합이 해당 자리수(보다 작음)를 만들 수 없음.
            // 따라서, 연산 범위는 [3..10^7]까지로 제한

            int sum = 0;
            double limit = Math.Pow(10, 7);
            for (int i = 3; i <= (int)limit; i++)
            {
                if (i % 5000 == 0)
                {
                    double process = (i - 3) / (limit - 3);
                    Console.Write("{0:F1}% processing...\r", process * 100);
                }
                if (IsCuriousNumber(i))
                {
                    sum += i;
                }
            }
            Console.Clear();
            Console.WriteLine(sum); // 40730

        }

        public static bool IsCuriousNumber(int aNumber)
        {
            bool result = false;
            int sumDigitFactorials = 0;
            foreach (char str in aNumber.ToString())
            {
                sumDigitFactorials += ((int)Char.GetNumericValue(str)).Factorial();
            }
            if (aNumber == sumDigitFactorials) { result = true; }
            return result;
        }
    }

    public static class Globals
    {
        public static int Factorial(this int aNumber)
        {
            // validation
            if (aNumber < 0)
            {
                throw new Exception($"{aNumber}의 Factorial을 계산할 수 없습니다.");
            }

            if (aNumber == 0)
            {
                return 1;
            }
            else
            {
                return aNumber * (aNumber - 1).Factorial();
            }
        }
    }

}
