using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTSSolutions.Problems
{
    public class ServerPower
    {
        public static int Solve(List<int> power)
        {
            ulong modulo = 1000000007;
            ulong finalSum = 0L;

            var groupCount = power.Count;

            for (int i = 0; i < groupCount; i++)
            {
                var takeNum = 1;

                while (takeNum <= power.Count - i)
                {
                    var powerList = power.GetRange(i, takeNum);
                    PrintList(powerList);

                    var min = (ulong)powerList.Min();
                    Console.WriteLine($"Min: {min}");

                    var sum = (ulong)powerList.Sum();
                    Console.WriteLine($"Sum: {sum}");

                    ulong product = min * sum;
                    Console.WriteLine($"Product: {product}");

                    finalSum += product;
                    Console.WriteLine($"Running Total: {finalSum}\n");

                    takeNum++;
                }
            }

            return Convert.ToInt32(finalSum % modulo);
        }

        private static void PrintList(List<int> nums)
        {
            int idx = 0;
            var space = " ";

            Console.Write('[');
            foreach (var num in nums)
            {
                idx++;
                Console.Write(num + (idx == nums.Count ? "" : space));
            }
            Console.WriteLine(']');
        }
    }
}
