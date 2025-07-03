using Sparky;

namespace SparkMSTest;

[TestClass]
public class CalculatorMSTests
{
    [TestMethod]
    public void AddNumbers_InputTwoInt_GetCorrectAddition()
    {
        //Arrange

        Calculator calc = new Calculator();

        //Act

        int result = calc.AddNumber(10, 20);

        //Assert

        Assert.AreEqual(30,result); 
    }

    [TestMethod]
    public void AddNumbers_InputTwoInt_GetInCorrectAddition()
    {
        //Arrange

        Calculator calc = new Calculator();

        //Act

        int result = calc.AddNumber(10, 20);

        //Assert

        Assert.AreEqual(3, result);
    }
}
