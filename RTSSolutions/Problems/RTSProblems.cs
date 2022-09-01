using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTSSolutions.Problems
{
    public class RTSProblems
    {
        public static Dictionary<string, int> AboveBelow(List<int> nums, int compVal)
        {
            var result = new Dictionary<string, int>() { { "above", 0 }, { "below", 0 } };

            foreach (var num in nums)
            {
                // We know these keys will exist, don't bother checking for existence
                if (compVal < num)
                {
                    result["above"] += 1;
                }

                if (compVal > num)
                {
                    result["below"] += 1;
                }
            }

            return result;
        }

        public static string StringRotation(string str, int rotationAmount)
        {
            // Iterative solution using Shift helper

            //string newStr = str;
            //int rotations = 0;
            //while (rotations < rotationAmount)
            //{
            //    newStr = Shift(newStr);
            //    rotations++;
            //}

            //return newStr;

            // Recursive solution
            if (String.IsNullOrEmpty(str) || rotationAmount <= 0)
            {
                return str;
            }
            else
            {
                int strEnd = str.Length - 1;
                char newFront = str[strEnd];
                string newEnd = str.Substring(0, strEnd);

                return StringRotation(newFront + newEnd, rotationAmount - 1);
            }
        }

        private static string Shift(string str)
        {
            if (String.IsNullOrEmpty(str))
                return "";

            int strEnd = str.Length - 1;
            char newFront = str[strEnd];
            string newEnd = str.Substring(0, strEnd);

            return newFront + newEnd;
        }

        #region " Testing "
        public static void TestAboveBelow()
        {
            var nums = new List<int>() { 1, 2, 3, 4, 5, 6 };
            var compVal = 3;

            var result = AboveBelow(nums, compVal);

            foreach (var item in result)
            {
                Console.WriteLine($"{item.Key} : {item.Value}");
            }
        }

        public static void TestStringRotation()
        {
            var origStr = "MyString";
            var rotationCount = 2;

            var rotatedString = StringRotation(origStr, rotationCount);

            Console.WriteLine(origStr);

            Console.WriteLine(rotatedString);
        }
        #endregion

        public static void RotateString(string str, int rotationAmount)
        {
            Console.WriteLine((str.Substring(rotationAmount % str.Length) + str.Substring(0, rotationAmount % str.Length)));
        }
    }
}
