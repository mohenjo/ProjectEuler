using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE038
{
    class Program
    {
        static void Main(string[] args)
        {
            // 문제접근:
            // 정수에 곱할 수가 (1, 2, ... n) where n > 1 이므로, n >= 2
            // 이 경우 5자리 이상의 정수에 대해서 정수 * 1 [5자리], 정수 * 2 [5자리]를 이어 붙이면
            // 10자리 이상이 된다. 즉 pandigital을 만족할 수가 없다.
            // 따라서, 정수는 4자리 이하, 그 범위는 [1..9999]
            int maxNum = 0;
            for (int i = 9999; i > 0; i--)
            {
                if (Globals.Concatenate(i, out int aPandigitalNum))
                {
                    maxNum = (aPandigitalNum > maxNum) ? aPandigitalNum : maxNum;
                }
            }
            Console.WriteLine(maxNum); // 932718654
        }
    }

    public static class Globals
    {
        // 입력된 문자열(숫자로 구성된)이 1 to 9 pandigital인지 여부 반환
        private static bool IsPandigital(string aStr)
        {
            if (aStr.Length != 9) { return false; }

            string checkStr = "123456789";

            Char[] tmpChr = aStr.ToCharArray(); Array.Sort(tmpChr);
            string inputStr = new string(tmpChr);

            return checkStr == inputStr;
        }

        // 입력된 정수 * [1, 2...]를 연결하여 9자리의 문자열 생성 후 pandigital 여부 반환
        // pandigital 일 경우, 해당 숫자 매개변수로 반환
        public static bool Concatenate(int aNum, out int aPandigitalNum)
        {
            // string concatenation
            string concatStr = String.Empty;
            int mulNum = 0;
            while (concatStr.Length < 9)
            {
                concatStr += (++mulNum * aNum).ToString();
            }

            if (concatStr.Length > 9) // 길이가 9보다 클 경우 != pandigital
            {
                aPandigitalNum = 0;
                return false;
            }
            else // concatenated string의 길이가 9인 경우
            {
                aPandigitalNum = Convert.ToInt32(concatStr);
                return IsPandigital(concatStr); // pandigital인가
            }
        }
    }
}
