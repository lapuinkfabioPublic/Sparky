using Moq;
using Sparky;
using System.Diagnostics.Metrics;
using Xunit;

namespace SparkNUnitTest
{

    public class BankAccountXUnitTests
    {

        [Fact]
        public void BankDepositLogFakker_Add100_ReturnTrue()
        {
            BankAccount bankAccount = new(new LogFakker()); //Pass a Faker 

            var result = bankAccount.Deposit(100);
            Assert.True(result);
            Assert.Equal(100,bankAccount.GetBalance());

        }

        [Fact]
        public void BankDeposit_Add100_ReturnTrue()
        {
            var logMock = new Mock<ILogBook>();
            BankAccount bankAccount = new(logMock.Object); //Pass a Faker 
            var result = bankAccount.Deposit(100);
            Assert.True(result);
            Assert.Equal(100, bankAccount.GetBalance());

        }

        [Theory]
        [InlineData(200, 100)]
        [InlineData(200, 150)]
        public void BankWithdraw_Withdraw100With200Balance_ReturnsTrue(int balance, int withdraw)
        {
            var logMock = new Mock<ILogBook>();
            BankAccount bankAccount = new BankAccount(logMock.Object);
            bankAccount.Deposit(balance);

            var result = bankAccount.WithDraw(withdraw);
            Assert.True(result);
        }

        [Theory]
        [InlineData(200, 300)]
        public void BankWithdraw_Withdraw100With200Balance_ReturnsFalse(int balance, int withdraw)
        {
            var logMock = new Mock<ILogBook>();
            BankAccount bankAccount = new BankAccount(logMock.Object);
            bankAccount.Deposit(balance);

            var result = bankAccount.WithDraw(withdraw);
            Assert.False(result);
        }

        [Fact]
        public void BankLogDummy_LogMockStringOutputStr_ReturnTrue()
        {
            var logMock = new Mock<ILogBook>();
            string desireOutput = "";
            string result = "";
            Assert.True(logMock.Object.LogWithOutPutResult("Ben", out result));
            Assert.Equal(result, desireOutput);
        }

        [Fact]
        public void BankLogDummy_LogRegChecker_ReturnTrue()
        {
            var logMock = new Mock<ILogBook>();
            Customer customer = new();
            Customer customerNotUsed = new();


            Assert.False(logMock.Object.LogWithRefObj(ref customerNotUsed));
            Assert.True(logMock.Object.LogWithRefObj(ref customer));

        }

        [Fact]
        public void BankLogDummy_VerifyExample()
        {
            var logMock = new Mock<ILogBook>();
            BankAccount bankAccount = new(logMock.Object);
            bankAccount.Deposit(100);
            Assert.Equal(100, bankAccount.GetBalance());

            //verification

            logMock.Verify(u => u.Message(It.IsAny<string>()), Times.Exactly(2));
            logMock.Verify(u => u.Message("Test"), Times.AtLeastOnce);
            logMock.VerifySet(u => u.LogSeverity = 101, Times.Once);
            logMock.VerifyGet(u => u.LogSeverity, Times.Once);


        }
    }
}
