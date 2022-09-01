using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTSSolutions.Problems
{
    public class RunLengthEncoding
    {
        public static void Solve(String data)
        {
            var testData = data;

            var encodedData = RunLengthEncoding.Encode(testData);

            Console.WriteLine(encodedData);
        }

        /// <summary>
        /// Given a string of characters a-b,
        /// return an encoded version that looks like this:
        /// aaaabbccc
        /// would yield:
        /// 4a2b3c
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Encoded string of data</returns>
        public static string Encode(string data)
        {
            var chars = data.ToCharArray();

            var prevChar = '\0';

            var counter = 0;

            var encodedData = new StringBuilder();

            foreach (char c in chars)
            {
                if (c == prevChar)
                {
                    counter++;
                }
                else
                {
                    if (prevChar != '\0')
                        encodedData.Append(counter + prevChar.ToString());

                    prevChar = c;
                    counter = 1;
                }
            }

            encodedData.Append(counter + prevChar.ToString());
            return encodedData.ToString();
        }

        public static string Decode(string data)
        {
            var decodedData = new StringBuilder();

            var decodeInfo = GetAllInfo(data);

            foreach (var info in decodeInfo)
            {
                for (var i = 0; i < info.Count; i++)
                {
                    decodedData.Append(info.Character);
                }
            }

            return decodedData.ToString();
        }

        /// <summary>
        /// Gets the count of a character that occurs in an RLE-encoded string
        /// plus the character itself as an ad-hoc object
        /// 
        /// Count is returned as a string to enable retrieving the length of that
        /// string for the next substring fetched
        /// </summary>
        /// <param name="data"></param>
        /// <returns>(Count, Character) of the first count-character combo in the given data</returns>
        private static (string Count, char Character) GetInfo(string data)
        {
            var chars = data.ToCharArray();

            var num = new StringBuilder();
            var character = '\0';

            foreach (char c in chars)
            {
                if (char.IsDigit(c))
                    num.Append(c);
                else
                {
                    character = c;
                    break;
                }
            }

            return (num.ToString(), character);
        }

        private static List<(int Count, char Character)> GetAllInfo(string data)
        {
            var results = new List<(int Count, char Character)>();

            var countInfo = GetInfo(data);

            /**
             * Set the remaining string to be a substring based on the length of digits
             * found in the count, plus one for the letter encoded.
             */
            var remainingData = data.Substring(countInfo.Count.Length + 1);
            results.Add((int.Parse(countInfo.Count), countInfo.Character));

            while (remainingData.Length > 0)
            {
                countInfo = GetInfo(remainingData);

                /**
                * Same as before, but taking into account the potential for overflow
                * at the end of the string - might be a more elegant way to do this.
                */
                remainingData = countInfo.Count.Length + 1 == remainingData.Length
                    ? ""
                    : remainingData.Substring(countInfo.Count.Length + 1);

                results.Add((int.Parse(countInfo.Count), countInfo.Character));
            }

            return results;
        }
    }
}
