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
        private BankAccount bankAccount;
        [SetUp]
        [Test]
        public void Setup() {
            bankAccount = new(new LogFakker()); //Pass a Faker 
        }

        [Test]
        public void BankDeposit_Add100_ReturnTrue() {
            var result = bankAccount.Deposit(100);
            A2.Assert.IsTrue(result);
            Assert.That(bankAccount.GetBalance, Is.EqualTo(100));

        }


    }
}
