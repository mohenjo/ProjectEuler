using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE006
{
    class Program
    {
        static void Main(string[] args)
        {
            Difference difference = new Difference(100);
            Console.WriteLine(difference.GetDifference()); // 25164150
        }
    }

    class Difference
    {
        private int _naturalNumber;

        public Difference(int naturalNumber) => _naturalNumber = naturalNumber;

        private int _SumOfSquares()
        {
            int sum = 0;
            for (int i = 1; i <= _naturalNumber; i++)
            {
                sum += (i * i);
            }
            return sum;
        }

        private int _SquareOfSum()
        {
            int sum = 0;
            for (int i = 1; i <= _naturalNumber; i++)
            {
                sum += i;
            }
            return sum * sum;
        }

        public int GetDifference()
        {
            return Math.Abs(_SumOfSquares() - _SquareOfSum());
        }
    }
}
