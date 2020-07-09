using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE099
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string currentPath = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
            string filePath = currentPath + @"\p099_base_exp.txt";

            double[] values = (from line in File.ReadAllLines(filePath)
                               let data = line.Split(',')
                               select int.Parse(data[1]) * Math.Log(int.Parse(data[0]))).ToArray();

            var maxVal = values[0];
            var maxLine = 1;
            for (int idx = 1; idx < values.Length; idx++)
            {
                if (values[idx] > maxVal)
                {
                    maxVal = values[idx];
                    maxLine = idx + 1;
                }
            }
            Console.WriteLine(maxLine); // 709
        }
    }
}
