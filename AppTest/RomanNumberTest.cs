using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTest
{
    public record RomanNumber(int Value)
    {
        private static readonly Dictionary<string, int> RomanMap = new()
        {
            { "N", 0 },
            { "I", 1 },
            { "V", 5 },
            { "X", 10 },
            { "L", 50 }
        };

        public static RomanNumber Parse(string input)
        {
            if (RomanMap.TryGetValue(input, out int value))
            {
                return new RomanNumber(value);
            }

            throw new ArgumentException($"Invalid Roman numeral: {input}");
        }
    }
}
