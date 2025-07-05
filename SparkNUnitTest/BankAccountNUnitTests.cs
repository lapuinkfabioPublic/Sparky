using Moq;
using NUnit.Framework;
using Sparky;
using System;
using System.Collections.Generic;
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


    }
}
