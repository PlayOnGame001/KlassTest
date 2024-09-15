//using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace AppTest
{
    public record RomanNumber(int Value)
    {
        private static readonly Dictionary<char, int> RomanMap = new()
        {
            { 'N', 0 },
            { 'I', 1 },
            { 'V', 5 },
            { 'X', 10 },
            { 'L', 50 },
            { 'C', 100 },
            { 'D', 500 },
            { 'M', 1000 }
        };

        public static RomanNumber Parse(string input)
        {
            int result = 0;
            int prevValue = 0;

            foreach (char c in input)
            {
                try
                {
                    int currentValue = DigitValue(c);

                    if (currentValue < prevValue)
                    {
                        result -= currentValue;
                    }
                    else
                    {
                        result += currentValue;
                    }

                    prevValue = currentValue;
                }
                catch (ArgumentException ex)
                {
                    ex.Source = "RomanNumber.Parse";
                    throw new FormatException($"Неверный символ '{c}' в строке '{input}'", ex);
                }
            }

            return new RomanNumber(result);
        }

        public static int DigitValue(char digit)
        {
            if (RomanMap.TryGetValue(digit, out int value))
            {
                return value;
            }

            throw new ArgumentException($"Невідома римська цифра: '{digit}'")
            {
                Source = "RomanNumber.DigitValue"
            };
        }
    }
}