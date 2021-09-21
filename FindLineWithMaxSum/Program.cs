using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace FindLineWithMaxSum
{
    public class Program
    {
        static void Main(String[] args)
        {
            String path = String.Empty;
            if (args?.Length == 0)
            {
                Console.WriteLine("Enter file name");
                path = Console.ReadLine();
            }
            else
            {
                path = args[0];
            }

#if DEBUG
            path = Path.Combine(Directory.GetCurrentDirectory(), "test.txt");
#endif

            #region Validation
            if (String.IsNullOrEmpty(path))
            {
                Console.WriteLine("Error: file name is empty!");
                return;
            }

            path = path.Trim();
            if (File.Exists(path) == false)
            {
                Console.WriteLine($"Error: file '{path}' not found!");
                return;
            }
            #endregion

            (Int32 lineWithMaxSumOfNumbers, Int32[] linesWithWrongFormat) result;
            using (StreamReader streamReader = new(path))
            {
                result = streamReader.GetLineWithMaxSumOfNumbers();
                streamReader.Close();
            }

            if (result.lineWithMaxSumOfNumbers > 0)
            {
                Console.WriteLine($"Line with max sum of numbers: {result.lineWithMaxSumOfNumbers}");
            }

            if (result.linesWithWrongFormat.Length > 0)
            {
                Console.WriteLine($"Line{(result.linesWithWrongFormat.Length > 1 ? 's' : String.Empty)} with wrong format: {String.Join(StringExtension.Separator, result.linesWithWrongFormat)}");
            }
        }
    }
}
