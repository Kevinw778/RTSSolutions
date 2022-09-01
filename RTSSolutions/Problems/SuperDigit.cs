using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTSSolutions.Problems
{
    public class SuperDigit
    {
        public static int Solve(string n, int k)
        {
            string p = GenerateP(n, k);

            return int.Parse(FindSuperDigit(p));
        }

        private static string FindSuperDigit(string n)
        {
            var superDigit = SumDigits(n);

            while (superDigit.Length > 1)
            {
                superDigit = SumDigits(superDigit);
            }

            return superDigit;
        }

        private static string SumDigits(string n)
        {
            var sum = 0;

            var summedDigits = new StringBuilder();

            foreach (char c in n)
            {
                sum += int.Parse(c + "");
                summedDigits.Append(c);
                summedDigits.Append(" + ");
            }

            Console.WriteLine(summedDigits.ToString()[..(summedDigits.Length - 2)]);

            return sum.ToString();
        }

        private static string GenerateP(string n, int k)
        {
            var p = new StringBuilder();

            while (k > 0)
            {
                p.Append(n);
                k--;
            }

            return p.ToString();
        }
    }
}
