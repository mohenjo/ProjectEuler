using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace PE043
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger result = 0;
            foreach (var list in Globals.Permutation(Globals.pdNum))
            {
                if (Globals.SliceCheck(list))
                {
                    BigInteger tmpInt = Globals.SliceToNum(list);
                    result += tmpInt;
                    Console.WriteLine($"{tmpInt} found.");
                }
            }
            Console.WriteLine($"The sum is {result}"); // 16695334890
        }
    }

    public static class Globals
    {
        public static List<int> pdNum = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

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
            for (int idx = 0; idx < aList.Count; idx++)
            {
                List<int> handoverList = aList.GetRange(0, aList.Count); handoverList.RemoveAt(idx);
                foreach (List<int> subList in Permutation(handoverList))
                {
                    List<int> tmpList = new List<int>(subList);
                    tmpList.Insert(0, aList[idx]);
                    result.Add(tmpList);
                }
            }
            return result;
        }

        public static bool SliceCheck(List<int> alist)
        {
            if (alist[0] == 0) { return false; }

            bool checkResult = true;
            List<int> chkPrime = new List<int>() { 1, 2, 3, 5, 7, 11, 13, 17 };
            for (int idx = 1; idx < chkPrime.Count; idx++)
            {
                string aString = string.Empty;
                for (int i = 0; i <= 2; i++)
                {
                    aString += alist[idx + i].ToString();
                }
                int chkNum = int.Parse(aString);
                if (chkNum % chkPrime[idx] != 0) { checkResult = false; }
            }
            return checkResult;
        }

        public static BigInteger SliceToNum(List<int> aList)
        {
            string aString = string.Empty;
            foreach (int val in aList)
            {
                aString += val.ToString();
            }
            return BigInteger.Parse(aString);
        }
    }
}
