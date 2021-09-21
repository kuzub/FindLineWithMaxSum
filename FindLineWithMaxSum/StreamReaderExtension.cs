using System;
using System.Collections.Generic;
using System.IO;

namespace FindLineWithMaxSum
{
    public static class StreamReaderExtension
    {
        public static (Int32 lineWithMaxSumOfNumbers, Int32[] linesWithWrongFormat) GetLineWithMaxSumOfNumbers(this StreamReader streamReader)
        {
            String line;
            Decimal currentSumOfNumbers;
            Decimal maxSumOfNumbers = Decimal.MinValue;
            Int32 currentLineNumber = 1;
            Int32 lineWithMaxSumOfNumbers = 0;
            List<Int32> linesWithWrongFormatList = new();

            while ((line = streamReader.ReadLine()) is not null)
            {
                try
                {
                    currentSumOfNumbers = line.SumOfNumbers();
                    //TODO if more then one line has same max value
                    if (currentSumOfNumbers > maxSumOfNumbers)
                    {
                        maxSumOfNumbers = currentSumOfNumbers;
                        lineWithMaxSumOfNumbers = currentLineNumber;
                    }
                }
                catch (WrongFormatLineException)
                {
                    linesWithWrongFormatList.Add(currentLineNumber);
                }
                currentLineNumber++;
            }

            return (lineWithMaxSumOfNumbers, linesWithWrongFormatList.ToArray());
        }
    }
}
