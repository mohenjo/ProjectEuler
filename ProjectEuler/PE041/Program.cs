using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE041
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxNumber = 0;
            for (int i = 1; i <= 9; i++) // 자리 수
            {
                DigitPrime dp = new DigitPrime(i);
                if (dp.MaxPandigitalPrime > maxNumber)
                {
                    maxNumber = dp.MaxPandigitalPrime;
                }
            }
            Console.WriteLine(maxNumber); // 7652413
        }
    }


    public class DigitPrime
    {
        private int Digits { get; }

        private List<int> PandigitalList
        {
            get => GenNdigitsNumbers(Digits);
        }

        public DigitPrime(int nDigit)
        {
            Digits = nDigit;
        }

        // Digits 자리 pandigital number 중 가장 큰 소수 반환
        // 0을 반환할 경우, 해당 자리 수의 pandigital number 중에는 소수가 존재하지 않음을 의미
        public int MaxPandigitalPrime
        {
            get
            {
                int maxNum = 0;
                foreach (var val in PandigitalList)
                {
                    if (IsPrime(val) && val > maxNum)
                    {
                        maxNum = val;
                    }
                }
                return maxNum;
            }
        }

        /// <summary>
        /// 메소드 입력 값이 소수인지 여부 반환
        /// </summary>
        /// <param name="aNumber">메소드 입력 값</param>
        /// <returns>소수 여부의 판단 결과</returns>
        private bool IsPrime(int aNumber)
        {
            bool checkPrime = true;

            for (int i = 2; i <= (int)Math.Sqrt(aNumber); i++)
            {
                if (aNumber % i == 0)
                {
                    checkPrime = false;
                    break;
                }
            }

            return checkPrime;
        }

        // int 리스트 [int1, int2, int3...]를 int1int2int3 int로 반환
        private int IntListToInt(List<int> aList)
        {
            string numStr = String.Empty;
            foreach (int val in aList) { numStr += val.ToString(); }

            return int.Parse(numStr);
        }

        /// <summary>
        /// 입력 자리 수의 pandigital number의 리스트 생성
        /// </summary>
        /// <param name="nDigit">자리 수</param>
        /// <returns>입력 자리수의 pandigital number 리스트</returns>
        private List<int> GenNdigitsNumbers(int nDigit) // ndigit = [1..9]
        {
            List<int> pandiditalNumbers = new List<int>();

            List<int> originalList = Enumerable.Range(1, nDigit).ToList(); // [1..nDigit] 리스트 생성
            foreach (var list in Permutation(originalList))
            {
                pandiditalNumbers.Add(IntListToInt(list));
            }

            return pandiditalNumbers;
        }

        /// <summary>
        /// 메소드 입력값(리스트)에 대해 해당 리스트 각 요소의 permutation 리스트를 반환
        /// </summary>
        /// <typeparam name="T">T형식의 리스트 요소</typeparam>
        /// <param name="aList">T형식으로 구성된 입력 리스트</param>
        /// <returns>T형식 리스트 요소에 대한 permutation 리스트</returns>
        private List<List<T>> Permutation<T>(List<T> aList)
        {
            List<List<T>> result = new List<List<T>>();

            if (aList.Count == 1)
            {
                result.Add(aList);
                return result;
            }
            // if aList.Count >= 2
            for (int idx = 0; idx < aList.Count; idx++)
            {
                List<T> handoverList = aList.GetRange(0, aList.Count); handoverList.RemoveAt(idx);
                foreach (List<T> subList in Permutation(handoverList))
                {
                    List<T> tmpList = new List<T>(subList);
                    tmpList.Insert(0, aList[idx]);
                    result.Add(tmpList);
                }
            }
            return result;
        }
    }
}
