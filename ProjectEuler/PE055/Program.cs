using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace PE055
{
    class Program
    {
        static void Main(string[] args)
        {
            // 숫자 자체가 palindrome 인 경우는 palindrome이라 간주하지 않음.
            // 뒤집힌 숫자를 더했을 때, palindrome인 경우만 고려.
            int count = 0;
            for (int i = 1; i <=10000; i++)
            {
                if (Globals.IsLychrel(i)) { count++; }
            }
            Console.WriteLine(count); // 249
        }
    }

    static class Globals
    {
        static BigInteger Palindrome(BigInteger aNumber)
        {
            char[] arr = aNumber.ToString().ToCharArray(); Array.Reverse(arr);
            return BigInteger.Parse(new string(arr));
        }

        static bool IsPalindrome(BigInteger aNumber)
        {
            return aNumber == Palindrome(aNumber);
        }

        public static bool IsLychrel(BigInteger aNumber)
        {
            BigInteger num = aNumber + Palindrome(aNumber);
            bool isLychrel = true;

            for (int repeat = 1; repeat < 50; repeat++)
            {
                if (IsPalindrome(num))
                {
                    isLychrel = false;
                    break;
                }
                else
                {
                    num += Palindrome(num);
                }
            }
            return isLychrel;
        }
    }
}
