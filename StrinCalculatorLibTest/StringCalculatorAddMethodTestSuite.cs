using StrinCalculatorLib;
namespace StringCalculatorLib.Tests
{
    public class StringCalculatorAddMethodTestSuite  // Test Suite
    {
        public class StringCalculatorTests
        {
            [Fact]
            public void GivenEmptyStringZeroIsExpected()
            {
                // Arrange
                string input = "";
                int expectedResult = 0;

                // Act
                var actualResult = StringCalculator.Add(input);

                // Assert
                Assert.Equal(expectedResult, actualResult);
            }

            [Fact]
            public void GivenSingleNumberSameNumberIsExpected()
            {
                // Arrange
                string input = "1";
                int expectedResult = 1;

                // Act
                var actualResult = StringCalculator.Add(input);

                // Assert
                Assert.Equal(expectedResult, actualResult);
            }

            [Fact]
            public void GivenCommaSeparatedNumbersSumIsExpected()
            {
                // Arrange
                string input = "1,2";
                int expectedResult = 3;

                // Act
                var actualResult = StringCalculator.Add(input);

                // Assert
                Assert.Equal(expectedResult, actualResult);
            }

            [Fact]
            public void GivenNewlineAndCommaSeparatedNumbersSumIsExpected()
            {
                // Arrange
                string input = "1\n2,3";
                int expectedResult = 6;

                // Act
                var actualResult = StringCalculator.Add(input);

                // Assert
                Assert.Equal(expectedResult, actualResult);
            }

            [Fact]
            public void GivenInvalidInputWithNewlineExceptionIsExpected()
            {
                // Arrange
                string input = "1,\n";

                // Act and Assert
                Assert.Throws<FormatException>(() => StringCalculator.Add(input));
            }

            [Fact]
            public void GivenCustomDelimiterSumIsExpected()
            {
                // Arrange
                string input = "//;\n1;2";
                int expectedResult = 3;

                // Act
                var actualResult = StringCalculator.Add(input);

                // Assert
                Assert.Equal(expectedResult, actualResult);
            }

            [Fact]
            public void GivenNegativeNumbersExceptionIsExpected()
            {
                // Arrange
                string input = "-1\n2";

                // Act and Assert
                Assert.Throws<ArgumentException>(() => StringCalculator.Add(input));
            }

            [Fact]
            public void GivenNumbersOver1000IgnoredSumIsExpected()
            {
                // Arrange
                string input = "2,1001";
                int expectedResult = 2;

                // Act
                var actualResult = StringCalculator.Add(input);

                // Assert
                Assert.Equal(expectedResult, actualResult);
            }

            [Fact]
            public void GivenCustomDelimiterWithMultipleCharactersSumIsExpected()
            {
                // Arrange
                string input = "//[***]\n1***2***3";
                int expectedResult = 6;

                // Act
                var actualResult = StringCalculator.Add(input);

                // Assert
                Assert.Equal(expectedResult, actualResult);
            }

            [Fact]
            public void GivenMultipleCustomDelimitersSumIsExpected()
            {
                // Arrange
                string input = "//[*][%]\n1*2%3";
                int expectedResult = 6;

                // Act
                var actualResult = StringCalculator.Add(input);

                // Assert
                Assert.Equal(expectedResult, actualResult);
            }

            [Fact]
            public void GivenMultipleDelimitersWithLengthMoreThanOneSumIsExpected()
            {
                // Arrange
                string input = "//[***][;;;]\n1***2;;;3";
                int expectedResult = 5;

                // Act
                var actualResult = StringCalculator.Add(input);

                // Assert
                Assert.Equal(expectedResult, actualResult);
            }
        }
    }
}