using NUnit.Framework;
using NUnit.Framework.Legacy;
using Sparky;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkNUnitTest
{
    [TestFixture]
    public class CalculatorNUnitTests
    {
        [Test]
        public void AddNumbers_InputTwoInt_GetCorrectAddition()
        {
            //Arrange

            Calculator calc = new Calculator();

            //Act

            int result = calc.AddNumber(10, 20);

            //Assert
            ClassicAssert.AreEqual(30, result);
        }


        [Test]
        public void IsOddCheck_InputEventNumber_ReturnFalse()
        {
            Calculator calc = new Calculator();

            bool isOdd = calc.IsOddNumber(10);
            ClassicAssert.That(isOdd,  Is.EqualTo (false));
            ClassicAssert.IsTrue(isOdd);

        }

        [Test]
        [TestCase(11)]
        [TestCase(12)]
        [TestCase(13)]
        public void IsOddCheck_InputEventNumber_ReturnTrue(int a)
        {
            Calculator calc = new Calculator();

            bool isOdd = calc.IsOddNumber(a);
            ClassicAssert.That(isOdd, Is.EqualTo(true));
            ClassicAssert.IsTrue(isOdd);


        }

        [Test]
        [TestCase(10,ExpectedResult = false)]
        [TestCase(11, ExpectedResult = true)]
        public bool IsOddCheck_InputEventNumber_ReturnOdd(int a)
        {
            Calculator calc = new Calculator();
            return  calc.IsOddNumber(a);
        }


        [Test]
        [TestCase(5.4, 10.5)]
        [TestCase(5.43, 10.53)]
        [TestCase(5.49, 10.49)]
        public void IsOddCheck_InputTwo_GetCoorrectAddition(double a, double b)
        {
            double result = new Calculator().AddNumbersDouble(a, b);
           // ClassicAssert.AreEqual(15.9, result,  1); /*Valor do Delta, deve esar enre 14.9 e 16.9*/
            ClassicAssert.AreEqual(15.9, result, .2); /*Valor do Delta, deve esar enre 15.8 e 16*/
        }


    }
}
