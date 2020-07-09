using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE036
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            for (int i = 0; i < 1000000; i++)
            {
                if (Globals.IsDoublebasePalindrome(i)) { sum += i; }
            }
            Console.WriteLine(sum); // 872187
        }
    }

    public static class Globals
    {
        private static bool IsPalindrome(string aString)
        {
            char[] aChar = aString.ToCharArray();
            Array.Reverse(aChar);
            string bString = new string(aChar);

            bool result = false;
            if (aString == bString) { result = true; }

            return result;
        }

        public static bool IsDoublebasePalindrome(int aNumber)
        {
            bool result = IsPalindrome(aNumber.ToString()) && IsPalindrome(Convert.ToString(aNumber, 2));
            return result;
        }
    
    }
}
