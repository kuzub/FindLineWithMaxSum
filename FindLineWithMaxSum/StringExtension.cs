using System;
using System.Globalization;

namespace FindLineWithMaxSum
{
    public static class StringExtension
    {
        public static readonly Char Separator = ',';

        public static Decimal SumOfNumbers(this String line)
        {
            String[] arrayOfNumbers = null;
            Decimal sumNumbers = 0;

            if (String.IsNullOrEmpty(line))
            {
                throw new WrongFormatLineException(message: "Input line is empty");
            }

            arrayOfNumbers = line.Split(Separator);

            for (Int32 i = 0; i < arrayOfNumbers.Length; i++)
            {
                if (Decimal.TryParse(arrayOfNumbers[i], NumberStyles.Any, CultureInfo.InvariantCulture, out Decimal result))
                {
                    sumNumbers += result;
                }
                else
                {
                    throw new WrongFormatLineException(message: "Input line has not Decimal value");
                }
            }

            return sumNumbers;
        }
    }
}
