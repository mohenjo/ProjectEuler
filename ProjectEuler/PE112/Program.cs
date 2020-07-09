using System;

namespace PE112_Bouncy_numbers
{
    class Program
    {
        static void Main()
        {
            int criteria = 99;
            long total = 0;
            long currentNumber = 1;
            while (true)
            {
                if (IsBouncy(currentNumber))
                {
                    total++;
                }
                int percent = (int)(((double)total / (double)currentNumber) * 100);
                if (percent >= criteria)
                {
                    Console.WriteLine(currentNumber); // 1587000
                    break;
                }
                currentNumber++;
            }
            Console.ReadKey();
        }

        private static bool IsBouncy(long number)
        {
            bool inc = false;
            bool dec = false;
            int previousNum = (int)char.GetNumericValue(number.ToString()[0]);
            foreach (char c in number.ToString())
            {
                int compareNum = (int)char.GetNumericValue(c);
                if (compareNum > previousNum)
                {
                    inc = true;
                }
                else if (compareNum < previousNum)
                {
                    dec = true;
                }
                previousNum = compareNum;
            }
            return inc && dec == true;
        }
    }
}
