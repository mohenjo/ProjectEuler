using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace PE015
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Globals.CountPaths(20, 20)); // 137846528820
        }
    }

    public static class Globals
    {
        public static BigInteger Factorial(BigInteger number)
        {
            if (number == 1)
            {
                return 1;
            }
            else
            {
                return BigInteger.Multiply(number, Factorial(number - 1));
            }
        }

        /// <summary>
        /// xSize * ySize 매트릭스에서 최원거리 모서리간 이동 경로의 수를 계산.
        /// 계산 식 = (xSize + ySize)! / ( xSize! * ySize! )
        /// </summary>
        /// <param name="xSize"></param>
        /// <param name="ySize"></param>
        public static BigInteger CountPaths(int xSize, int ySize)
        {
            return Factorial(xSize + ySize) / (Factorial(xSize) * Factorial(ySize));
        }
    }
}
