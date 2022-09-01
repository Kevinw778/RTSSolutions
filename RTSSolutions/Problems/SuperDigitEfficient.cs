using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTSSolutions.Problems
{
    public class SuperDigitEfficient
    {
        public static int Solve(string n, int k, bool showMath=false)
        {
            if (n.Length == 1 && k == 1)
                return int.Parse(n);
            else
            {
                var sum = SumDigits(n, k, showMath);
                return Solve(sum, 1, showMath);
            }
        }

        private static string SumDigits(string n, int k, bool showMath=false)
        {
            var sum = 0;

            var summedDigits = new StringBuilder();

            foreach (char c in n)
            {
                sum += int.Parse(c + "");
                summedDigits.Append(c);
                summedDigits.Append(" + ");
            }

            if (showMath)
                Console.WriteLine(summedDigits.ToString()[..(summedDigits.Length - 2)]);

            return (sum * k).ToString();
        }
    }
}