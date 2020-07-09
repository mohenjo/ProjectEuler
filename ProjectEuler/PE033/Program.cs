using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE033
{
    class Program
    {
        static void Main(string[] args)
        {
            // ab/bc < 1,
            // where, ab != bc
            int numerator, incorrectNumerator;
            int denominator, incorrectDenominator;
            int resultNumerator = 1, resultDenominator = 1;

            for (int b = 1; b <= 9; b++)
            {
                for (int a = 1; a <= 9; a++)
                {
                    for (int c = 1; c <= 9; c++)
                    {
                        numerator = 10 * a + b;
                        denominator = 10 * b + c;
                        if (numerator >= denominator) { continue; }
                        Reduction(ref numerator, ref denominator);

                        incorrectNumerator = a;
                        incorrectDenominator = c;
                        Reduction(ref incorrectNumerator, ref incorrectDenominator);

                        if (numerator == incorrectNumerator && denominator == incorrectDenominator)
                        {
                            Console.WriteLine($"{10 * a + b} / {b * 10 + c}");
                            resultNumerator *= numerator;
                            resultDenominator *= denominator;
                        }
                    }
                }
            }

            Reduction(ref resultNumerator, ref resultDenominator);
            Console.WriteLine(resultDenominator); // 100
        }

        public static void Reduction(ref int numerator, ref int denominator)
        {
            int divider = 2;
            while (divider <= numerator)
            {
                if (numerator % divider == 0 && denominator % divider == 0)
                {
                    numerator /= divider;
                    denominator /= divider;
                }
                else
                {
                    divider++;
                }
            }
        }
    }
}
