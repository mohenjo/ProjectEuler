using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE046
{
    class Program
    {
        static void Main(string[] args)
        {
            PrimeNumber pn = new PrimeNumber(10000);
            bool check = pn.ShowNoGoldbach(out int thatNumber);
            if (check)
            {
                Console.WriteLine($"Found new mismatch at {thatNumber}");
            }
            else
            {
                Console.WriteLine("Cannot found any mismatches.");
            }
        }
    }

    public class PrimeNumber
    {
        private List<int> PrimeNumbers = new List<int>() { 2 };

        private SortedSet<int> CompositeNumbers = new SortedSet<int>();

        private int UpperLimit { get; }

        public PrimeNumber(int maxNumber)
        {
            UpperLimit = maxNumber;
            GeneratePrime();
            GenerateOddCompositeNumbers();
        }

        public void GeneratePrime()
        {
            int val = PrimeNumbers.Last() + 1;
            while (val <= UpperLimit)
            {
                if (PrimeNumbers.All(element => val % element != 0))
                {
                    PrimeNumbers.Add(val);
                }
                val++;
            }
        }

        private void GenerateOddCompositeNumbers()
        {
            foreach (int val1 in PrimeNumbers)
            {
                foreach (int val2 in PrimeNumbers)
                {
                    int newCompositeNumber = val1 * val2;
                    if (newCompositeNumber <= UpperLimit && newCompositeNumber % 2 != 0)
                    {
                        CompositeNumbers.Add(newCompositeNumber);
                    }
                }
            }

        }

        public bool ShowNoGoldbach(out int NotGlodbachInt)
        {
            NotGlodbachInt = 0;
            foreach (int cn in CompositeNumbers)
            {
                NotGlodbachInt = cn;
                bool IsGoldbach = false;
                foreach (int pn in PrimeNumbers)
                {
                    if (pn >= cn) { break; }
                    if (Math.Sqrt((cn - pn) / 2) % 1 == 0)
                    {
                        IsGoldbach = true;
                        break;
                    }
                }
                if (!IsGoldbach) { return true; }
            }
            return false;
        }
    }

}
