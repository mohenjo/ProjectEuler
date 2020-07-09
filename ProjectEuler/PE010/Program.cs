using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE010
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> result = Global.PrimeNumbersBelow(2000000);
            long sum = 0;
            foreach (int val in result)
            {
                sum += (long)val;
            }
            Console.WriteLine(sum); // 142913828922
        }
    }

    public static class Global
    {
        // 소수 생성: [2, 3, 5, 7, ...maxNNUmber) 
        public static List<int> PrimeNumbersBelow(int maxNumber)
        {
            if (maxNumber <= 2) { return new List<int> { }; }

            List<int> primeNumbers = new List<int> { 2 };

            for (int idx = 3; idx < maxNumber; idx++)
            {
                Console.Write("{0}\r", idx);
                bool check = true;
                foreach (int val in primeNumbers)
                {
                    if (idx % val == 0)
                    {
                        check = false;
                        break;
                    }
                }
                if (check) { primeNumbers.Add(idx); }
            }

            return primeNumbers;
        }
    }
}
