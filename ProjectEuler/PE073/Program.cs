using System;
using System.Collections.Generic;
using System.Numerics;

namespace PE073
{
    internal class Program
    {
        private static void Main()
        {
            HashSet<string> fractions = new HashSet<string>();

            BigInteger dMax = 12_000;
            Fraction minValue = new Fraction(1, 3);
            Fraction maxValue = new Fraction(1, 2);

            for (BigInteger d = 2; d <= dMax; d++)
            {
                for (BigInteger n = 1; n < d; n++)
                {
                    Fraction checkFraction = new Fraction(n, d);
                    checkFraction.Irreducible();
                    if (checkFraction.Value > minValue.Value && checkFraction.Value < maxValue.Value)
                    {
                        fractions.Add(checkFraction.ToString());
                    }
                }
            }
            //string rstString = string.Join(", ", fractions);
            //Console.WriteLine(rstString);
            Console.WriteLine(fractions.Count); // 7295372

            Console.ReadKey();

        }
    }

    internal class Fraction
    {
        public BigInteger Numerator { get; private set; }
        public BigInteger Denominator { get; private set; }

        public double Value => (double)Numerator / (double)Denominator;

        public Fraction(BigInteger numerator, BigInteger denominator)
        {
            Numerator = numerator;
            Denominator = denominator;
        }

        public void Irreducible()
        {
            BigInteger gcd = GCD(Numerator, Denominator);
            (Numerator, Denominator) = (Numerator / gcd, Denominator / gcd);
        }

        public override string ToString()
        {
            return $"{Numerator}/{Denominator}";
        }

        public static BigInteger GCD(BigInteger numberA, BigInteger numberB)
        {
            while (numberB != 0)
            {
                BigInteger temp = numberA % numberB;
                numberA = numberB;
                numberB = temp;
            }
            return numberA;
        }

        public static BigInteger LCM(BigInteger numberA, BigInteger numberB)
        {
            return checked(numberA * numberB / GCD(numberA, numberB));
        }
    }
}
