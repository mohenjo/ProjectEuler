using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;

namespace PE022
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\haenn\source\repos\ProjectEuler\PE022\input\p022_names.txt";
            List<string> inputArray = Globals.ParseToArray(path);
            Console.WriteLine(Globals.DisplayResult(inputArray)); // 871198282
        }
    }

    public static class Globals
    {
        public static List<string> ParseToArray(string path)
        {
            List<string> result = new List<string>();
            string text = string.Empty;
            text = File.ReadAllText(path);
            foreach (string str in text.Split(','))
            {
                result.Add(str.Replace("\"", string.Empty));
            }
            result.Sort();
            return result;
        }

        private static int AlphabeticalValue(string aString)
        {
            int result = 0;
            foreach (int chr in aString)
            {
                result += (int)chr - (int)'A' + 1;
            }
            return result;
        }

        public static BigInteger DisplayResult(List<string> aCollection)
        {
            BigInteger totalScore = 0;
            int idx = 1;
            foreach (string str in aCollection)
            {
                totalScore += idx++ * AlphabeticalValue(str);
            }
            return totalScore;
        }
    }
}
