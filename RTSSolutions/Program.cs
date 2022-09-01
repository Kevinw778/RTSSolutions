using System;
using System.Collections.Generic;
using RTSSolutions.Problems;

namespace RTSSolutions
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            //RunLengthEncoding.Solve("aaaabbccc");
            var testData = "aaaabbccc";
            var encodedString = RunLengthEncoding.Encode(testData);
            var decodedString = RunLengthEncoding.Decode(encodedString);

            Console.WriteLine(testData.Equals(decodedString));
            */

            //var nums = new List<int>()
            //{
            //    -4, 3, -9, 0, 4, 1
            //};

            //PlusMinus.Solve(nums);

            //TimeConversion.Solve("12:01:02AM");

            //FizzBuzz.Solve(15);

            //TestSuperDigit("12", 32);

            //Console.WriteLine(SuperDigit.Solve("123", 3));

            //Console.WriteLine(SuperDigitEfficient.Solve("148", 3, true));

            //TestStackQueue();

            //Console.WriteLine(GoodLookinBraces.IsBalanced("{{[[(())]]}}"));

            //RiceBags.solve();

            ServerPower.Solve(new List<int>() { 2, 3, 2, 1 });
        }

        static void TestStackQueue()
        {
            var q = new StackQueue<int>();

            q.Enqueue(42);
            q.DeQueue();
            q.Enqueue(14);
            q.Print();
            q.Enqueue(28);
            q.Print();
            q.Enqueue(60);
            q.Enqueue(78);
            q.DeQueue();
            q.Print(); // Should be 28
        }

        static void TestSuperDigit(string num, int repeat)
        {
            int count = 1;

            while (repeat > 0)
            {
                Console.WriteLine(SuperDigit.Solve(num, count));
                if (count % 4 == 0)
                    Console.WriteLine("----");

                if (count % 16 == 0)
                    Console.WriteLine("----------------");
                count++;
                repeat--;
            }
        }
    }
}
