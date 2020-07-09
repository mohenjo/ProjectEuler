using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace PE057
{
    class Program
    {
        static void Main(string[] args)
        {
            Conversion cv = new Conversion(1000);
            Console.WriteLine(cv.CheckDigit()); // 153
        }
    }

    class Conversion
    {
        /* 연분수의 형태는
         * a0 = 1 + 1 / 2
         * a1 = 1 + 1 / (2 + 1 / 2) = 1 + 1 / (1 + a0)
         * a2 = 1 + 1 / (1 + a1) 
         * ...
         */

        private List<BigInteger> Dividend = new List<BigInteger>();

        private List<BigInteger> Divisor = new List<BigInteger>();

        private int Expansions { get; }

        private void GenerateNextValue()
        {
            /* if currentValue cv = cv_c / cv_m
             * nextValue nv = 1 + 1 / (1 + cv) = (2 * cm_m + cv_c) / (cv_m + cv_c) 
             */
            BigInteger cv_m = Divisor.Last();
            BigInteger cv_c = Dividend.Last();
            Dividend.Add(2 * cv_m + cv_c);
            Divisor.Add(cv_m + cv_c);
        }

        public Conversion(int expansions)
        {
            Expansions = expansions;

            // a0 = 1 + 1 / 2 = 3 / 2
            Dividend.Add(3); Divisor.Add(2);

            for (int i = 1; i <= expansions; i++) { GenerateNextValue(); }
        }

        // 분자의 자리수가 분모의 자리수보다 큰 갯수 반환
        public int CheckDigit()
        {
            int count = 0;
            for (int idx = 0; idx < Expansions; idx++)
            {
                if (Dividend[idx].ToString().Length > Divisor[idx].ToString().Length)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
