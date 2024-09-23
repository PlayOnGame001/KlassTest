using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace KlassTest
{
    public class RomanNumber
    {
        // Метод возвращает значение для римской цифры или выбрасывает исключение для недопустимого символа
        public static int DigitValue(char digit) => digit switch
        {
            'N' => 0,
            'I' => 1,
            'V' => 5,
            'X' => 10,
            'L' => 50,
            'C' => 100,
            'D' => 500,
            'M' => 1000,
            _ => throw new ArgumentException($"Невідома римська цифра: '{digit}'")
            {
                Source = "RomanNumber.DigitValue"
            }
        };

        // Метод для парсинга римской строки в число
        public static int Parse(string roman)
        {
            int result = 0;
            int prevValue = 0;
            for (int i = roman.Length - 1; i >= 0; i--)
            {
                char currentChar = roman[i];
                int currentValue = DigitValue(currentChar);

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

            return result;
        }

        // Дополнительный метод с условием
        public static int ParseWithCondition(string input)
        {
            return input == "IX" ? 9 : input.Length;
        }
    }

    [TestClass]
    public class RomanNumberTests
    {
        // Класс для тестовых кейсов
        public class TestCase
        {
            public string Source { get; set; }
            public int Value { get; set; }
        }

        [TestMethod]
        public void ParseTest()
        {
            String origin = "RomanNumber";
            String tpl = "Ilegal char";
            String tpl2 = "RomanNumberParce";

            TestCase[] testCases = [
            new ("I", [tpl.F("IW", "W", "1")]),
            new ("II", [tpl.F("IW", "W", "2")]),
            new ("III", [tpl.F("IW", "W", "3")]),
            new ("IV", [tpl.F("IW", "W", "14")]),
            new ("M", [tpl.F("IW", "W", "1000")]),

    ];

            foreach (var testCase in validCases)
            {
                int parsedValue = RomanNumber.Parse(testCase.Source);
                Assert.AreEqual(parsedValue.ToString(), testCase.Text, $"Ошибка при парсинге: {testCase.Source}");
            }
        }

        // Метод расширения для строки
        public static class StringExtension
        {
            public static String F(this String str, params String[] pars)
            {
                return String.Format(str, pars);
            }
        }

    }
}
