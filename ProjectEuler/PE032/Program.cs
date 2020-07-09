using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE032
{
    /* 
     * A * B = C 자리수 설명 - 총 9자리가 되어야 함(pandigital)
     * C 6자리 -> A, B 3자리 = 불가
     * C 5자리 -> A, B 4자리 = (1, 3)[최대 4자리 이하: 불가], (2, 2)[최대 4자리 이하: 불가]
     * C 4자리 -> A, B 5자리 = (1, 4)[가능], (2, 3)[가능]
     * C 3자리 -> A, B 6자리 = (1, 5)[최소 5자리 이상: 불가], (2, 4)[최소 5자리 이상: 불가], (3, 3)[최소 6자리 이상: 불가]
     * 즉, C는 4자리, A, B는 합 5자리 (1, 4) 또는 (2, 3)
     */

    class Program
    {
        static void Main(string[] args)
        {

            HashSet<int> sumSet = new HashSet<int>();
            int sum = 0;
            // (1, 4) 구성일 경우
            for (int multiplicand = 1; multiplicand <= 9; multiplicand++)
            {
                for (int multiplier = 1234; multiplier <= 9876; multiplier++)
                {
                    if (IsPandigital(multiplicand, multiplier, out int calculation))
                    {
                        sumSet.Add(calculation);
                        Console.WriteLine($"{multiplicand} * {multiplier} = {calculation}");
                    }

                }
            }
            // (2, 3) 구성일 경우
            for (int multiplicand = 12; multiplicand <= 98; multiplicand++)
            {
                for (int multiplier = 123; multiplier <= 987; multiplier++)
                {

                    if (IsPandigital(multiplicand, multiplier, out int calculation))
                    {
                        sumSet.Add(calculation);
                        Console.WriteLine($"{multiplicand} * {multiplier} = {calculation}");
                    }

                }
            }

            Console.WriteLine($"Sum of product (remove duplicates) = {sumSet.Sum()}"); // 45228
        }

        static bool IsPandigital(int a, int b, out int c)
        {
            bool check = false;
            c = a * b;
            string toString = $"{a}{b}{c}";
            if (toString.Contains("0") || toString.Length != 9) { return false; }
            var toSet = new SortedSet<char>(toString.ToArray());
            string pandigitalSet = new string(toSet.ToArray());
            if (pandigitalSet == "123456789" ) { check = true; }

            return check;
        }
    }
}
