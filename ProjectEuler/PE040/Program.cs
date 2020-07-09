using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE040
{
    class Program
    {
        static void Main(string[] args)
        {
            int result = Solution.Dn(1) * Solution.Dn(10) * Solution.Dn(100)
                * Solution.Dn(1000) * Solution.Dn(10000) * Solution.Dn(100000)
                * Solution.Dn(1000000);
            Console.WriteLine(result); // 210
        }
    }

    public static class Solution
    {
        private static string DecimalString = string.Empty;

        public static string DecimalFraction
        {
            get
            {
                return DecimalString[0] + "." + DecimalString.Substring(1);
            }
        } // 사용 안 함. 확인용.

        static Solution()
        {
            int maxLength = 1000000;
            int phase = 0;
            while (DecimalString.Length < maxLength)
            {
                Console.Write($"{DecimalString.Length} of {maxLength} is processcing...\r");
                for (int i = 0; i <= 9; i++)
                {
                    if (phase == 0)
                    {
                        DecimalString += i.ToString();
                    }
                    else
                    {
                        DecimalString += phase.ToString() + i.ToString();

                    }
                }
                phase++;
            }
            Console.Clear();
        }

        public static int Dn(int n)
        {
            return Convert.ToInt32(DecimalString.Substring(n, 1));
        }
    }
}
