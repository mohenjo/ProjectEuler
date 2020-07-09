using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Numerics;

namespace PE013
{
    class Program
    {
        static void Main(string[] args)
        {
            BigNumbers bigNumber = new BigNumbers(@"C:\Users\haenn\source\repos\ProjectEuler\PE013\input\PE013.txt");
            bigNumber.Display(10); // 5537376230
        }
    }

    public class BigNumbers
    {
        private List<string> StringNumbers = new List<string>();

        private BigInteger BigSum = new BigInteger(0);

        public BigNumbers(string path)
        {
            StreamReader File = new StreamReader(path);
            string line;
            while ((line = File.ReadLine()) != null)
            {
                StringNumbers.Add(line);
                BigSum = BigInteger.Add(BigSum, BigInteger.Parse(line));
            }
            File.Close();
        }

        public void Display(int numDigits) // 출력할 BigSum의 자리 수  
        {
            Console.WriteLine(BigSum.ToString().Substring(0, numDigits));
        }
    }
}
