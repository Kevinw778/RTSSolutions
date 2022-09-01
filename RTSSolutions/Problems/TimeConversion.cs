using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTSSolutions.Problems
{
    internal class TimeConversion
    {
        public static void Solve(string s)
        {
            var splitTime = s.Split(':');
            var amPm = splitTime[2][^2..]; // AM or PM

            var hour = int.Parse(splitTime[0]);
            var minute = splitTime[1];
            var second = splitTime[2][..^2];

            var hour24 = To24Hour(hour, amPm.Equals("PM"));

            Console.WriteLine($"{hour24}:{minute}:{second}");
        }

        private static string To24Hour(int hour, bool isPM)
        {
            var hour24 = isPM ? 12 : 0;

            if (hour != 12)
            {
                hour24 += hour;
            }

            var padding = hour24 < 10 ? "0" : "";

            return padding + hour24.ToString();
        }
    }
}
