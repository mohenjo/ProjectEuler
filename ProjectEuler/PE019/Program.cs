using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE019
{
    class Program
    {
        static void Main(string[] args)
        {
            int result = 0;
            for (int year = 1901; year <= 2000; year++)
            {
                result += CountIfFirstDayIsSunday(year);
            }
            Console.WriteLine(result); // 171
        
        }

        private static int CountIfFirstDayIsSunday(int year)
        {
            int count = 0;
            for (int month = 1; month <=12; month++)
            {
                DayOfWeek dw = (new DateTime(year, month, 1)).DayOfWeek;
                if (dw == DayOfWeek.Sunday) { count++; }
            }
            return count;
        }
    }

}
