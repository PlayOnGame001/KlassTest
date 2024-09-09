using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KlassTest
{
    public class RomanNumber
    {
        public static int DigitValue(char digit) => digit switch
        {
            'N' => 0,
            'I' => 1,
            'V' => 5,
            'X' => 10,
            'L' => 50,
            _ => throw new ArgumentException($"Невідома римська цифра: '{digit}'")
        };
       
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

        [TestMethod]
        public void DigitValueTest()
        {
            Assert.AreEqual(1, RomanNumber.DigitValue('I'), "I->1");
            Assert.AreEqual(5, RomanNumber.DigitValue('V'), "V->5");
            Assert.AreEqual(10, RomanNumber.DigitValue('X'), "X->10");
            Assert.AreEqual(50, RomanNumber.DigitValue('L'), "L->50");

        }
    }
}
