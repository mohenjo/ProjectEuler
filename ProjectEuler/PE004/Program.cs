using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE004
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Palindrome.MaxPalindrome(100,999)); // 906609
        }
    }

    static class Palindrome
    {
        private static bool _isPalindrome(int aNumber)
        {
            string string1 = aNumber.ToString();
            char[] tmpCharArray = string1.ToCharArray();
            Array.Reverse(tmpCharArray);
            string string2 = new string(tmpCharArray);
            if (string1 == string2) { return true; }
            else { return false; }
        }

        public static int MaxPalindrome(int numMin, int numMax)
        {
            int maxPalindromeNum = 0;
            for (int num1 = numMin; num1 <= numMax; num1++)
            {
                for (int num2 = numMin; num2 <= numMax; num2++)
                {
                    int chkValue = num1 * num2;
                    if (Palindrome._isPalindrome(chkValue) && chkValue > maxPalindromeNum)
                    {
                        maxPalindromeNum = chkValue;
                    }
                }
            }
            return maxPalindromeNum;
        }
    }
}
