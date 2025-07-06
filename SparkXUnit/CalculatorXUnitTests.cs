using Sparky;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SparkNUnitTest
{
    
    public class CalculatorXUnitTests
    {
        [Fact]
        public void AddNumbers_InputTwoInt_GetCorrectAddition()
        {
            //Arrange

            Calculator calc = new Calculator();

            //Act

            int result = calc.AddNumber(10, 20);

            //Assert
            Assert.Equal(30, result);
        }


        [Fact]
        public void IsOddCheck_InputEventNumber_ReturnFalse()
        {
            Calculator calc = new Calculator();

            bool isOdd = calc.IsOddNumber(10);
            Assert.True(isOdd);

        }

        [Theory]
        [InlineData(11)]
        [InlineData(12)]
        [InlineData(13)]
        public void IsOddCheck_InputEventNumber_ReturnTrue(int a)
        {
            Calculator calc = new Calculator();

            bool isOdd = calc.IsOddNumber(a);
            Assert.True(isOdd);


        }

        [Theory]
        [InlineData(10, false)]
        [InlineData(11, true)]
        public void IsOddCheck_InputEventNumber_ReturnOdd(int a, bool expectedResult)
        {
            Calculator calc = new Calculator();
            var result =   calc.IsOddNumber(a);
            Assert.Equal(expectedResult, result);
        }


        [Theory]
        [InlineData(5.4, 10.5)]
        [InlineData(5.43, 10.53)]
        [InlineData(5.49, 10.49)]
        public void IsOddCheck_InputTwo_GetCoorrectAddition(double a, double b)
        {
            double result = new Calculator().AddNumbersDouble(a, b);
            Assert.Equal(15.9, result, .2); /*Valor do Delta, deve esar enre 15.8 e 16*/
        }


    }
}
