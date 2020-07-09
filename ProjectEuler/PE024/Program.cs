using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE024
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> inputList = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            List<List<int>> permutations = CombinationAndPermutation.Permutation(inputList);
            int index = 1000000 - 1;
            List<int> resultList = permutations[index];
            string result = string.Empty;
            foreach (int val in resultList)
            {
                result += val.ToString();
            }
            Console.WriteLine(result); // 2783915460

        }
    }

    public static class CombinationAndPermutation
    {
        /// <summary>
        /// <paramref name="inputList"/>의 내부 각 List의 첫 요소로 <paramref name="aValue"/>를 삽입합니다.
        /// ex> 0 -> {{1, 2}, {3, 4}} -> {{0, 1, 2}, {0, 3, 4}}
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="aValue"><paramref name="inputList"/>각 각 요소 index = 0에 삽입될 개체</param>
        /// <param name="inputList">입력 리스트</param>
        /// <returns></returns>
        private static List<List<T>> InsertToEachItemList<T>(T aValue, List<List<T>> inputList)
        {
            List<List<T>> resultList = new List<List<T>>();
            foreach (List<T> aList in inputList)
            {
                List<T> tmpList = new List<T>() { aValue };
                foreach (T val in aList)
                {
                    tmpList.Add(val);
                }
                resultList.Add(tmpList);
            }
            return resultList;
        }

        /// <summary>
        /// <paramref name="aList"/>에서 index = <paramref name="idx"/>를 제외한 새로운 리스트를 반환합니다.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="aList">입력 리스트</param>
        /// <param name="idx">입력 리스트에서 제외할 인덱스</param>
        /// <returns></returns>
        private static List<T> RemainAfterRemoveAt<T>(List<T> aList, int idx)
        {
            List<T> resultList = new List<T>();
            for (int i = 0; i < aList.Count; i++)
            {
                if (i != idx) { resultList.Add(aList[i]); }
            }
            return resultList;
        }

        /// <summary>
        /// <paramref name="inputList"/>의 각 요소의 순열 리스트를 반환합니다.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="inputList">순열 계산을 위한 입력 리스트</param>
        /// <returns>입력 리스트 각 요소의 순열 리스트를 포함한 리스트</returns>
        public static List<List<T>> Permutation<T>(List<T> inputList)
        {
            List<List<T>> result = new List<List<T>>();
            if (inputList.Count == 2)
            {
                result.Add(new List<T>() { inputList[0], inputList[1] });
                result.Add(new List<T>() { inputList[1], inputList[0] });
                return result;
            }
            else
            {
                for (int idx = 0; idx < inputList.Count; idx++)
                {
                    List<T> handoverList = RemainAfterRemoveAt(inputList, idx);
                    List<List<T>> tmpList = InsertToEachItemList(inputList[idx], Permutation(handoverList));
                    foreach (List<T> alist in tmpList)
                    {
                        result.Add(alist);
                    }
                }
                return result;
            }
        }

    }
}
