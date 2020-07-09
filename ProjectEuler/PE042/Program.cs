using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PE042
{
    class Program
    {
        static void Main(string[] args)
        {
            // 입력 파일에서 문자열 읽음
            StreamReader txtFile =
                new StreamReader(@"C:\Users\haenn\source\repos\ProjectEuler\PE042\p042_words.txt");
            string inpString = txtFile.ReadToEnd();
            txtFile.Close();

            string[] words = inpString.Replace("\"", "").Split(new char[] { ',' });
            
            // triangle number 생성 [...ValueLimit];
            int maxLength = 0;
            foreach (string str in words)
            {
                maxLength = (str.Length > maxLength) ? str.Length : maxLength;
            }
            int valueLimit = ('Z' - 'A' + 1) * maxLength;
            List<int> triangleNumbers = new List<int>();
            int addNum = 0;
            int nth = 1;
            while (addNum < valueLimit)
            {
                addNum = Globals.TriangleNumber(nth++);
                triangleNumbers.Add(addNum);
            }

            // 문제 해결
            Console.WriteLine("Belows are words which value is triangle number: ");
            int count = 0;
            foreach(string str in words)
            {
                int wordvalue = Globals.WordValue(str);
                if (triangleNumbers.Contains(wordvalue))
                {
                    Console.WriteLine(str);
                    count++;
                }
            }
            Console.WriteLine($" -> {count} words have triangle number values."); // 162
        }
    }

    public static class Globals
    {
        // 알파벳 대문자로 구성된 aString에 대해 A = 1, B = 2, ...로 변환한 후,
        // 각 변환 값의 합을 반환
        public static int WordValue(string aString)
        {
            int wordValue = 0;
            foreach (char chr in aString) { wordValue += chr - (int)'A' + 1; }

            return wordValue;
        }

        public static int TriangleNumber(int n)
        {
            return n * (n + 1) / 2;
        }
    }
}
