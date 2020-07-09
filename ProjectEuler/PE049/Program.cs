using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE049
{
    class Program
    {
        static void Main(string[] args)
        {
            Solve.Process();
        }
    }

    public static class Solve
    {
        public static void Process()
        {
            for (int idx = 1; idx < PrimeNumber.List.Count - 1; idx++)
            {
                int currentValue = PrimeNumber.List[idx];
                for (int idxLess = 0; idxLess < idx; idxLess++)
                {
                    int leftValue = PrimeNumber.List[idxLess];
                    int diff = currentValue - leftValue;
                    int rightValue = currentValue + diff;
                    if (PrimeNumber.IsInList(rightValue) &&
                        Globals.IsPermutation(leftValue, currentValue, rightValue))
                    {
                        string result = $"{leftValue}{currentValue}{rightValue}";
                        Console.WriteLine(result); // 148748178147 & 296962999629
                    }
                }
            }
        }
    }

    public static class PrimeNumber
    {
        public static List<int> List = new List<int>();

        static PrimeNumber()
        {
            GeneratePrimeNumbers(1000, 9999);
        }

        public static bool IsInList(int aNumber)
        {
            return List.Contains(aNumber);
        }

        private static void GeneratePrimeNumbers(int lowerLimit, int upperLimit)
        {
            List<int> pn = new List<int>() { 2 };
            int val = pn.Last() + 1;
            while (val <= upperLimit)
            {
                if (pn.All(element => val % element != 0))
                {
                    pn.Add(val);
                }
                val++;
            }
            foreach (int v in pn)
            {
                if (v >= lowerLimit)
                {
                    List.Add(v);
                }
            }
        }

        public static void PrintPrimeNumbers()
        {
            Console.Write("[ ");
            foreach (int val in List)
            {
                Console.Write($"{val} ");
            }
            Console.WriteLine("]");
        }
    }

    public static class Globals
    {
        public static bool IsPermutation(int lVal, int mVal, int rVal)
        {
            char[] mValChr = mVal.ToString().ToCharArray(); Array.Sort(mValChr);
            string mValStr = new string(mValChr);

            char[] lValChr = lVal.ToString().ToCharArray(); Array.Sort(lValChr);
            string lValStr = new string(lValChr);

            char[] rValChr = rVal.ToString().ToCharArray(); Array.Sort(rValChr);
            string rValStr = new string(rValChr);

            return lValStr == mValStr && lValStr == rValStr;
        }
        
        /// <summary>
        /// 메소드 입력값(리스트)에 대해 해당 리스트 각 요소의 permutation 리스트를 반환
        /// </summary>
        /// <typeparam name="int">T형식의 리스트 요소</typeparam>
        /// <param name="aList">T형식으로 구성된 입력 리스트</param>
        /// <returns>T형식 리스트 요소에 대한 permutation 리스트</returns>
        public static List<List<int>> Permutation(List<int> aList)
        {
            List<List<int>> result = new List<List<int>>();

            if (aList.Count == 1)
            {
                result.Add(aList);
                return result;
            }
            // if aList.Count >= 2
            for (int idx = 0; idx < aList.Count; idx++) // 입력 리스트의 각 항목에 대해서
            {
                // 해당 항목을 제외한 부분(handoverList)을 재귀 메소드로 보냄
                List<int> handoverList = aList.GetRange(0, aList.Count); handoverList.RemoveAt(idx);
                foreach (List<int> subList in Permutation(handoverList))
                {
                    // 재귀 메소드의 리턴 값(리스트)에 현재 입력 리스트의 대상 항목을 삽입
                    List<int> tmpList = new List<int>(subList);
                    tmpList.Insert(0, aList[idx]);
                    result.Add(tmpList);
                }
            }
            return result;
        }
    }
}
