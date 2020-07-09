using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE028
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Solution(1001)); // 669171001
        }

        static int Solution(int size) // size by size 매트릭스. 단 size 는 홀수.
        {
            int result = 1; // 출발값 at depth = 0 (1 by 1 매트릭스)
            int depth = (size - 1) / 2; // 차원 수(사각형 매트릭스의 수) = (size - 1)/ 2
            for (int i = 1; i<=depth; i++)
            {
                result += 16 * i * i + 4 * i + 4; // 각 차원 수 꼭지점 값의 합
            }
            return result;
        }
    }
}
