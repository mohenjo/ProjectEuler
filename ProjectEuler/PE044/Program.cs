using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE044
{
    class Program
    {
        static void Main(string[] args)
        {

            PentagonalNumber pn = new PentagonalNumber();
            int minDiff;
            while (!pn.CheckPentagonality(out minDiff))
            {
                Console.Write($"Checking index {pn.Length}...\r");
                pn.MoveNext();
            }
            Console.Clear();
            Console.WriteLine(minDiff); // 5482660
        }
    }

    public class PentagonalNumber
    {
        private List<int> PentagonalNumbers = new List<int>();
        public int Length { get; private set; } = 0;

        public PentagonalNumber()
        {
            // initilize list: PentagonalNumbers = {1, 5}
            MoveNext(); MoveNext();
        }

        public void MoveNext()
        {
            Length++;
            PentagonalNumbers.Add(Length * (3 * Length - 1) / 2);
        }

        public bool CheckPentagonality(out int minDiff)
        {
            bool returnCheck = false;

            int Pj, Pk = PentagonalNumbers.Last();
            minDiff = Pk; // diff = | Pk - Pj | 비교를 위한 초기값 가정
            for (int i = 0; i < Length; i++)
            {
                Pj = PentagonalNumbers[i];
                int diff = Math.Abs(Pk - Pj);
                if (IsPentagonal(Pj + Pk) && IsPentagonal(diff))
                {
                    returnCheck = true;
                    minDiff = (diff < minDiff) ? diff : minDiff;
                }
            }

            return returnCheck;
        }

        private static bool IsPentagonal(int Pn)
        {
            // Pentagonal 식의 해(n)가 정수이면 Pentragonal Number임
            double calculated_n = (1 + Math.Sqrt(24 * Pn + 1)) / 6;
            if (calculated_n % 1 == 0) { return true; }
            else { return false; }
        }
    }
}
