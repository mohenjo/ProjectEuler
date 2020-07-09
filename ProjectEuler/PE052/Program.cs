using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE052
{
    class Program
    {
        static void Main(string[] args)
        {
            int v = 1;
            while (!Globals.IsPermutation(v, 2*v, 3*v, 4*v, 5*v, 6*v))
            {
                Console.Write($"Processing {v}\r");
                v++;
            }
            Console.Clear();
            Console.WriteLine(v); // 142857
        }
    }

    static class Globals
    {
        // 인자들이 서로 순열인지 여부 반환
        public static bool IsPermutation(params int[] values)
        {
            bool IsEqual = true;

            string chkStr = IntegerToSortedString(values[0]);
            for (int idx = 1; idx < values.Length; idx++)
            {
                string cmpStr = IntegerToSortedString(values[idx]);
                if (chkStr != cmpStr) { IsEqual = false; }
            }

            return IsEqual;
        }

        // 입력 정수를 오름차순 정렬한 문자열 반환
        static string IntegerToSortedString(int value)
        {
            char[] valueChr = value.ToString().ToCharArray();
            Array.Sort(valueChr);
            return new string(valueChr);
        }
    }
}
