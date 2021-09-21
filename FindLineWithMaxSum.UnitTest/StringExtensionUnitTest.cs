using System;
using Xunit;

namespace FindLineWithMaxSum.UnitTest
{
    public class StringExtensionUnitTest
    {
        [Theory]
        [InlineData("1,2,3,4,5,6", 21)]
        [InlineData("42", 42)]
        public void SumOfNumbers(String line, Decimal expected)
        {
            // Arrange

            // Act
            Decimal actual = line.SumOfNumbers();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(",")]
        [InlineData("q")]
        [InlineData("42,")]
        [InlineData("42,null")]
        [InlineData("42,1,1.o")]
        public void SumOfNumbers_ForWrongFormatLine_Should_WrongFormatLineException(String line)
        {
            // Arrange

            // Act
            Action act = () => line.SumOfNumbers();

            // Assert
            Assert.Throws<WrongFormatLineException>(act);
        }
    }
}
