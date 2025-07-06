//using Moq;
//using Sparky;
//using Xunit;
//using A2 = Microsoft.VisualStudio.TestTools.UnitTesting;

//namespace SparkNUnitTest
//{
    
//    public class BankAccountXUnitTests
//    {

//        [Fact]
//        public void BankDepositLogFakker_Add100_ReturnTrue() {
//            BankAccount bankAccount = new(new LogFakker()); //Pass a Faker 

//            var result = bankAccount.Deposit(100);
//            A2.Assert.IsTrue(result);
//            Assert.That(bankAccount.GetBalance, Is.EqualTo(100));

//        }

//        [Fact]
//        public void BankDeposit_Add100_ReturnTrue()
//        {
//            var logMock = new Mock<ILogBook>();
//            logMock.TestInitialize(x => x.Message("")); 
            
//            BankAccount bankAccount = new(logMock.Object); //Pass a Faker 
//            var result = bankAccount.Deposit(100);
//            A2.Assert.IsTrue(result);
//            Assert.That(bankAccount.GetBalance, Is.EqualTo(100));

//        }

//        [Fact]
//        [TestCase(200,100)]
//        [TestCase(200,150)]
//        public void BankWithdraw_Withdraw100With200Balance_ReturnsTrue(int balance, int withdraw) {
//            var logMock = new Mock<ILogBook>();
//            logMock.TestInitialize(u => u.LogToDB(It.IsAny<string>())).Returns(true);
//            logMock.TestInitialize(u => u.LogBalanceAfterWithdrawal(It.Is<int>(x=>x>0))).Returns(true);

//            BankAccount bankAccount = new BankAccount(logMock.Object);
//            bankAccount.Deposit(balance);

//            var result = bankAccount.WithDraw(withdraw);
//            A2.Assert.IsTrue(result);
//        }

//        [Fact]
//        [TestCase(200,300)]
//        public void BankWithdraw_Withdraw100With200Balance_ReturnsFalse(int balance, int withdraw)
//        {
//            var logMock = new Mock<ILogBook>();
//            logMock.TestInitialize(u => u.LogToDB(It.IsAny<string>())).Returns(true);
//            logMock.TestInitialize(u => u.LogBalanceAfterWithdrawal(It.Is<int>(x => x > 0))).Returns(true);
//            logMock.TestInitialize(u => u.LogBalanceAfterWithdrawal(It.Is<int>(x => x < 0))).Returns(false);
//            logMock.TestInitialize(u => u.LogBalanceAfterWithdrawal(It.IsInRange<int>(int.MinValue,-1, Moq.Range.Inclusive ))).Returns(true);

//            BankAccount bankAccount = new BankAccount(logMock.Object);
//            bankAccount.Deposit(balance);

//            var result = bankAccount.WithDraw(withdraw);
//            A2.Assert.IsFalse(result);
//        }

//        [Fact]
//        public void BankLogDummy_LogMockStringOutputStr_ReturnTrue()
//        {
//            var logMock = new Mock<ILogBook>();
//            string desireOutput = "";
//            logMock.TestInitialize(u => u.LogWithOutPutResult(It.IsAny<string>(), out desireOutput)).Returns(true);
//            string result = "";
//            A2.Assert.IsTrue(logMock.Object.LogWithOutPutResult("Ben",out result));
//            Assert.That(result,  Is.EqualTo(desireOutput));
//        }

//        [Fact]
//        public void BankLogDummy_LogRegChecker_ReturnTrue()
//        {
//            var logMock = new Mock<ILogBook>();
//            Customer customer = new();
//            Customer customerNotUsed = new();

         
//            logMock.TestInitialize(u => u.LogWithRefObj(ref customer)).Returns(true);
//            A2.Assert.IsFalse(logMock.Object.LogWithRefObj(ref customerNotUsed));
//            A2.Assert.IsTrue(logMock.Object.LogWithRefObj(ref customer));

//        }

//        [Fact]
//        public void BankLogDummy_SetAndGetogType_MockTest()
//        {
//            var logMock = new Mock<ILogBook>();
//            logMock.TestInitializeAllProperties();
//            logMock.TestInitialize(u => u.LogSeverity).Returns(10);
//            logMock.TestInitialize(u => u.LogType).Returns("warning");
            

//            logMock.Object.LogSeverity = 100;  //sera ignorado por causa do TestInitializeAllProperties

//            Assert.That(logMock.Object.LogSeverity, Is.EqualTo(10));
//            Assert.That(logMock.Object.LogType, Is.EqualTo("warning"));

//            //calbacks

//            string logTemp = "Hello, ";
//            logMock.TestInitialize(u => u.LogToDB(It.IsAny<string>())).Returns(true)
//                .Callback((string str)=> logTemp +=str );
            
//            logMock.Object.LogToDB("Ben");
//            Assert.That(logTemp, Is.EqualTo("Hello, Ben"));

//            //calbacks

//            int counter = 5;
//            logMock.TestInitialize(u => u.LogToDB(It.IsAny<string>()))
//                .Callback(() => counter++)
//                .Returns(true)
//                .Callback( () => counter++);

//            logMock.Object.LogToDB("Ben");
//            logMock.Object.LogToDB("Ben");
//            Assert.That(counter, Is.EqualTo(9));



//        }

//        [Fact]
//        public void BankLogDummy_VerifyExample() {
//            var logMock = new Mock<ILogBook>();
//            BankAccount bankAccount = new(logMock.Object);
//            bankAccount.Deposit(100);
//            Assert.That(bankAccount.GetBalance, Is.EqualTo(100));

//            //verification

//            logMock.Verify(u => u.Message(It.IsAny<string>()), Times.Exactly(2));
//            logMock.Verify(u => u.Message("Test"), Times.AtLeastOnce);
//            logMock.VerifySet(u => u.LogSeverity = 101, Times.Once);
//            logMock.VerifyGet(u => u.LogSeverity , Times.Once);


//        }
//    }
//}
