using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE039
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxSolutionLength = 0;
            int maxPerimeter = 0;
            for (int p = 4; p <= 1000; p++)
            {
                Console.Write($"{p} out of 1000 is being estimated.\r");

                Triangles tr = new Triangles(p);
                if (tr.SolutionLength > maxSolutionLength)
                {
                    maxSolutionLength = tr.SolutionLength;
                    maxPerimeter = p;
                }
            }
            Console.Clear();
            Console.WriteLine($"Number of solution maximised at {maxPerimeter}");
            Triangles result = new Triangles(maxPerimeter);
            result.DisPlaySolution();
        }
    }

    public class Triangles
    {
        private int Perimeter { get; }

        private List<SortedSet<int>> Solutions = new List<SortedSet<int>>();

        public int SolutionLength
        {
            get 
            {
                return Solutions.Count;
            }
        }

        public Triangles(int perimeter)
        {
            if (perimeter < 4 || perimeter > 1000)
            {
                throw new Exception("세 변 길이의 합이 적절하지 않습니다.");
            }

            Perimeter = perimeter;
            GetSolutions();
        }

        private void GetSolutions()
        {
            int c;
            for (int a = 1; a < Perimeter; a++)
            {
                for (int b = 1; b < Perimeter; b++)
                {
                    c = Perimeter - (a + b);
                    // 각 변의 길이 (장변 c) 관계를 만족하지 않을 경우 다음 루프
                    if (c < a || c < b || c <= 0)
                    {
                        continue;
                    }
                    if (a * a + b * b == c * c) // 직각 삼각형일 경우
                    {
                        // 기존 해의 집합에 동일한 해가 존재하는 지 확인
                        bool isIn = true;
                        foreach (var set in Solutions)
                        {
                            if (set.Contains(a) && set.Contains(b) && set.Contains(c))
                            {
                                isIn = false;
                            }
                        }
                        // 새로운 해일 경우, 해 집합에 추가
                        if (isIn)
                        {
                            SortedSet<int> newSolution = new SortedSet<int>() { a, b, c };
                            Solutions.Add(newSolution);
                        }
                    }
                }
            }
        }

        public void DisPlaySolution()
        {
            foreach (var sets in Solutions)
            {
                Console.Write("{ ");
                foreach (int val in sets)
                {
                    Console.Write($"{val, 4} ");
                }
                Console.WriteLine("}");
            }
        }
    }
}
