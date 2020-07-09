using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace PE025
{
    class Program
    {
        static void Main(string[] args)
        {
            Fibonacci fb = new Fibonacci(1, 1);
            BigInteger result = 0;
            int index = 0;
            while (NumDigits(result) < 1000 )
            {
                result = fb.NextValue(out index);
            }
            Console.WriteLine(index); // 4782
        }

        static int NumDigits(BigInteger aNumber)
        {
            return aNumber.ToString().Length;
        }
    }

    public class Fibonacci
    {
        private BigInteger FirstValue, SecondValue;
        private int Idx = 0;

        public Fibonacci(int firstValue, int secondValue)
        {
            FirstValue = firstValue;
            SecondValue = secondValue;
            Idx = 2;
        }

        public BigInteger NextValue(out int index)
        {
            BigInteger nextValue = FirstValue + SecondValue;
            BigInteger tmpValue = SecondValue;
            FirstValue = tmpValue;
            SecondValue = nextValue;
            index = ++Idx;
            return nextValue;
        }
    }
}
