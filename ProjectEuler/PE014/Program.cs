using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE014
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Globals.LongestCollatzSequenceNumber(1000000)); // 837799
        }
    }

    public static class Globals
    {
        public static long CollatzSequence(long number)
        {
            long nextNumber = number;
            long count = 1;
            while (nextNumber != 1)
            {
                if (nextNumber % 2 == 0)
                {
                    nextNumber /= 2;
                }
                else
                {
                    nextNumber = 3 * nextNumber + 1;
                }
                count++;
            }
            return count;
        }

        public static long LongestCollatzSequenceNumber(long uptoNumber)
        {
            long maxLength = 0, length;
            long numberWithMaxLength = 0;

            for (long val = 1; val <= uptoNumber; val++)
            {
                Console.Write("\r{0}", val);
                length = CollatzSequence(val);
                if (length >= maxLength)
                {
                    maxLength = length;
                    numberWithMaxLength = val;
                }
            }
            Console.WriteLine();
            return numberWithMaxLength;
        }
    }
} 
