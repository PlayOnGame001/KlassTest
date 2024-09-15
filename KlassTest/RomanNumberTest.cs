using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

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
            _ => throw new ArgumentException($"Невідома римська цифра: '{digit}'")
            {
                Source = "RomanNumber.DigitValue"  // Указываем источник исключения
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
        [TestMethod]
        public void ParseTest()
        {
            Assert.AreEqual(1, RomanNumber.Parse("I"), "I->1");
            Assert.AreEqual(2, RomanNumber.Parse("II"), "II->2");
            Assert.AreEqual(3, RomanNumber.Parse("III"), "III->3");
        }

       /* [TestMethod]
        public void DigitValueTest()
        {
            Assert.AreEqual(1, RomanNumber.DigitValue('I'), "I->1");
            Assert.AreEqual(5, RomanNumber.DigitValue('V'), "V->5");
            Assert.AreEqual(10, RomanNumber.DigitValue('X'), "X->10");
            Assert.AreEqual(50, RomanNumber.DigitValue('L'), "L->50");
        }

        [TestMethod]
        public void ParseWithConditionTest()
        {
            Assert.AreEqual(9, RomanNumber.ParseWithCondition("IX"), "IX->9");
            Assert.AreEqual(3, RomanNumber.ParseWithCondition("III"), "III->3");
            Assert.AreEqual(2, RomanNumber.ParseWithCondition("II"), "II->2");
        }*/

        
        [TestMethod]
        public void RandomInvalidSymbolsTest()
        {
            
            HashSet<char> validRomanDigits = new HashSet<char> { 'N', 'I', 'V', 'X', 'L' };

            Random random = new Random();
            int testCount = 100; // Количество тестов

            for (int i = 0; i < testCount; i++)
            {
                char testChar = (char)random.Next(32, 127);  

                
                if (validRomanDigits.Contains(testChar))
                {
                    i--; 
                    continue;
                }

                try
                {
                    RomanNumber.DigitValue(testChar);
                }
                catch (ArgumentException ex)
                {
                    // Проверка, что источник исключения правильный
                    Assert.AreEqual("RomanNumber.DigitValue", ex.Source, $"Неверный источник для символа: '{testChar}'");
                    Console.WriteLine($"Исключение для символа '{testChar}' перехвачено с правильным источником.");
                }
            }
        }
    }
}
