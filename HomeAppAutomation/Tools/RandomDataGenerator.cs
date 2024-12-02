using System;
using System.Collections.Generic;
using System.Drawing;

namespace HomeAppAutomations.Tools
{
    static class RandomDataGenerator
    {
        static string lowerCaseLetters = "abcdefghijklmnopqrstuvwxyz";
        static string upperCaseLetters = lowerCaseLetters.ToUpper();
        static string numericChars = "0123456789";
        static Random randomizer = new Random();

        private static string GenerateRandomString(int length, char[] possibleChars)
        {
            List<char> outputChars = new List<char> { };
            for (int i = 0; i < length; i++)
            {
                int index = randomizer.Next(possibleChars.Length);
                outputChars.Add(possibleChars[index]);
            }
            return string.Join("", outputChars.ToArray());
        }
        public static string GetLowercaseString(int length)
        {
            char[] lowerCaseChars = lowerCaseLetters.ToCharArray();
            return GenerateRandomString(length, lowerCaseChars);
        }
        public static string GetUpperCaseString(int length)
        {
            char[] upperCaseChars = upperCaseLetters.ToCharArray();
            return GenerateRandomString(length, upperCaseChars);
        }
        public static string GetMixCaseAlphabeticString(int length)
        {
            char[] inputChars = (lowerCaseLetters + upperCaseLetters).ToCharArray();
            return GenerateRandomString(length, inputChars);
        }

        public static string GetLettersDigitsString(int length)
        {
            char[] inputChars = (lowerCaseLetters + upperCaseLetters + numericChars).ToCharArray();
            return GenerateRandomString(length, inputChars);
        }

        public static string GetIntDigitString(int length)
        {
            char[] digitChars = numericChars.ToCharArray();
            char[] nonZeroDigits = "123456789".ToCharArray();
            string output = $"{nonZeroDigits[randomizer.Next(nonZeroDigits.Length)]}{GenerateRandomString(length - 1, digitChars)}";
            return output;
        }

        public static string GetDigitString(int length)
        {
            if(GetRandomBool())
            {
                int dotPosition = length / 2;
                return $"{GetIntDigitString(dotPosition)}.{GetIntDigitString(dotPosition-1)}";
            }

            return GetIntDigitString(length);
        }

        public static bool GetRandomBool()
        {
            bool[] choises = { false, true };
            return choises[randomizer.Next(2)];
        }

        public static Point GetPointInArea(Point upperLeftPoint, Size areaParams)
        {
            int x = randomizer.Next(upperLeftPoint.X, (upperLeftPoint.X + areaParams.Width));
            int y = randomizer.Next(upperLeftPoint.Y, (upperLeftPoint.Y + areaParams.Height));
            return new Point(x, y);
        }

        public static T GetRandomListItem<T>(List<T> itemsList)
        {
            int index = randomizer.Next(itemsList.Count);
            return itemsList[index];
        }
    }
}
