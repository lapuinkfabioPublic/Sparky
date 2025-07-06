using Moq;
using NUnit.Framework;
using Sparky;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using A2 = Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SparkNUnitTest
{
    [TestFixture]
    public class BankAccountNUnitTests
    {
        [SetUp]
        [Test]
        public void Setup() {
        }

        [Test]
        public void BankDepositLogFakker_Add100_ReturnTrue() {
            BankAccount bankAccount = new(new LogFakker()); //Pass a Faker 

            var result = bankAccount.Deposit(100);
            A2.Assert.IsTrue(result);
            Assert.That(bankAccount.GetBalance, Is.EqualTo(100));

        }

        [Test]
        public void BankDeposit_Add100_ReturnTrue()
        {
            var logMock = new Mock<ILogBook>();
            logMock.Setup(x => x.Message("")); 
            
            BankAccount bankAccount = new(logMock.Object); //Pass a Faker 
            var result = bankAccount.Deposit(100);
            A2.Assert.IsTrue(result);
            Assert.That(bankAccount.GetBalance, Is.EqualTo(100));

        }

        [Test]
        [TestCase(200,100)]
        [TestCase(200,150)]
        public void BankWithdraw_Withdraw100With200Balance_ReturnsTrue(int balance, int withdraw) {
            var logMock = new Mock<ILogBook>();
            logMock.Setup(u => u.LogToDB(It.IsAny<string>())).Returns(true);
            logMock.Setup(u => u.LogBalanceAfterWithdrawal(It.Is<int>(x=>x>0))).Returns(true);

            BankAccount bankAccount = new BankAccount(logMock.Object);
            bankAccount.Deposit(balance);

            var result = bankAccount.WithDraw(withdraw);
            A2.Assert.IsTrue(result);
        }

        [Test]
        [TestCase(200,300)]
        public void BankWithdraw_Withdraw100With200Balance_ReturnsFalse(int balance, int withdraw)
        {
            var logMock = new Mock<ILogBook>();
            logMock.Setup(u => u.LogToDB(It.IsAny<string>())).Returns(true);
            logMock.Setup(u => u.LogBalanceAfterWithdrawal(It.Is<int>(x => x > 0))).Returns(true);
            logMock.Setup(u => u.LogBalanceAfterWithdrawal(It.Is<int>(x => x < 0))).Returns(false);
            logMock.Setup(u => u.LogBalanceAfterWithdrawal(It.IsInRange<int>(int.MinValue,-1, Moq.Range.Inclusive ))).Returns(true);

            BankAccount bankAccount = new BankAccount(logMock.Object);
            bankAccount.Deposit(balance);

            var result = bankAccount.WithDraw(withdraw);
            A2.Assert.IsFalse(result);
        }

        [Test]
        public void BankLogDummy_LogMockStringOutputStr_ReturnTrue()
        {
            var logMock = new Mock<ILogBook>();
            string desireOutput = "";
            logMock.Setup(u => u.LogWithOutPutResult(It.IsAny<string>(), out desireOutput)).Returns(true);
            string result = "";
            A2.Assert.IsTrue(logMock.Object.LogWithOutPutResult("Ben",out result));
            Assert.That(result,  Is.EqualTo(desireOutput));
        }

        [Test]
        public void BankLogDummy_LogRegChecker_ReturnTrue()
        {
            var logMock = new Mock<ILogBook>();
            Customer customer = new();
            Customer customerNotUsed = new();

         
            logMock.Setup(u => u.LogWithRefObj(ref customer)).Returns(true);
            A2.Assert.IsFalse(logMock.Object.LogWithRefObj(ref customerNotUsed));
            A2.Assert.IsTrue(logMock.Object.LogWithRefObj(ref customer));

        }

        [Test]
        public void BankLogDummy_SetAndGetogType_MockTest()
        {
            var logMock = new Mock<ILogBook>();
            logMock.SetupAllProperties();
            logMock.Setup(u => u.LogSeverity).Returns(10);
            logMock.Setup(u => u.LogType).Returns("warning");
            

            logMock.Object.LogSeverity = 100;  //sera ignorado por causa do SetupAllProperties

            Assert.That(logMock.Object.LogSeverity, Is.EqualTo(10));
            Assert.That(logMock.Object.LogType, Is.EqualTo("warning"));

            //calbacks

            string logTemp = "Hello, ";
            logMock.Setup(u => u.LogToDB(It.IsAny<string>())).Returns(true)
                .Callback((string str)=> logTemp +=str );
            
            logMock.Object.LogToDB("Ben");
            Assert.That(logTemp, Is.EqualTo("Hello, Ben"));

            //calbacks

            int counter = 5;
            logMock.Setup(u => u.LogToDB(It.IsAny<string>())).Returns(true)
                .Callback( () => counter++);

            logMock.Object.LogToDB("Ben");
            Assert.That(counter, Is.EqualTo(6));



        }
    }
}
