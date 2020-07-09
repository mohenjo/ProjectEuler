using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PE067
{
    class Program
    {
        static void Main(string[] args)
        {
            TriangleNumbers tn = new TriangleNumbers(@"C:\Users\haenn\source\repos\ProjectEuler\PE067\input\p067_triangle.txt");
            Console.WriteLine(tn.GetMaxRouteValue()); // 7273
        }
    }

    public class TriangleNumbers
    {
        public List<string> TriangleStringList { get; } = new List<string>();

        public TriangleNumbers(string path)
        {
            List<string> stringList = new List<string>();
            string line;
            StreamReader file = new StreamReader(path);
            while ((line = file.ReadLine()) != null)
            {
                stringList.Add(line.Trim());
            }
            file.Close();
            TriangleStringList = stringList;
        }

        public void DisplayTriangle()
        {
            foreach (var line in TriangleStringList)
            {
                Console.WriteLine(line);
            }
        }

        public int GetMaxRouteValue()
        {
            List<string> tmpList = new List<string>(TriangleStringList); // copy list
            for (int idx = tmpList.Count - 2; idx >= 0; idx--)
            {
                List<int> currentIdx = StringToIntList(tmpList[idx]);
                List<int> nextIdx = ShortenByMaxValue(tmpList[idx + 1]);
                tmpList[idx] = IntListToString(AddLists(currentIdx, nextIdx));
            }
            return int.Parse(tmpList[0]);
        }

        private static string IntListToString(List<int> aList)
        {
            string result = String.Empty;
            result = string.Join(" ", aList);
            return result;
        }

        private static List<int> StringToIntList(string str)
        {
            List<int> result = new List<int>();
            foreach (string val in str.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries))
            {
                result.Add(int.Parse(val));
            }
            return result;
        }

        private static List<int> ShortenByMaxValue(string str)
        {
            List<int> tmpList = StringToIntList(str);
            List<int> result = new List<int>();
            for (int idx = 0; idx < tmpList.Count - 1; idx++)
            {
                int maxValue = (tmpList[idx] >= tmpList[idx + 1]) ? tmpList[idx] : tmpList[idx + 1];
                result.Add(maxValue);
            }
            return result;
        }

        private static List<int> AddLists(List<int> xList, List<int> yList)
        {
            List<int> result = new List<int>();
            for (int idx = 0; idx < xList.Count; idx++)
            {
                result.Add(xList[idx] + yList[idx]);
            }
            return result;
        }
    }
}
