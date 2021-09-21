using System;
using System.IO;
using System.Text;
using Xunit;

namespace FindLineWithMaxSum.UnitTest
{
    public class StreamReaderExtension
    {
        [Fact]
        public void Test()
        {
            // Arrange
            StringBuilder test = new StringBuilder();
            //1
            test.Append("1,2,3,4,5,6");
            test.AppendLine();
            //2
            test.Append("q");
            test.AppendLine();
            //3
            test.Append("42");
            test.AppendLine();
            //4
            test.Append("1.0,");
            test.AppendLine();
            //5
            test.Append("1.1,2.2,3.3,4.4,5.5,6.5");
            test.AppendLine();
            //6
            test.Append("");
            test.AppendLine();
            //7
            test.Append("1.1,O.2,3.3,4.4,5.5,6.5");
            test.AppendLine();
            //8
            test.Append("0,42");
            test.AppendLine();
            //9
            test.AppendLine();

            using (MemoryStream memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(test.ToString())))
            {
                using (StreamReader streamReader = new StreamReader(memoryStream))
                {
                    // Act
                    (Int32 lineWithMaxSumOfNumbers, Int32[] linesWithWrongFormat) actual = streamReader.GetLineWithMaxSumOfNumbers();

                    // Assert
                    (Int32 lineWithMaxSumOfNumbers, Int32[] linesWithWrongFormat) expected = (lineWithMaxSumOfNumbers: 3, linesWithWrongFormat: new int[] { 2, 4, 6, 7, 9 });
                    Assert.Equal(expected.linesWithWrongFormat, actual.linesWithWrongFormat);
                    Assert.Equal(expected.lineWithMaxSumOfNumbers, actual.lineWithMaxSumOfNumbers);
                }
            }
        }
    }
}
