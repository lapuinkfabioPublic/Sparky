using Sparky;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;


namespace SparkNUnitTest
{

    
    public class CustomerXUnitTest
    {
        private Customer customer;
        
        public CustomerXUnitTest()
        {
            customer = new Customer();
        }

        [Fact]
        public void CombinaName_InputFirstANdLastName_ReturnFullName()
        {

            //Arrange

            //Act
            string fullName = customer.GreetAndCombinaName("Ben", "Spark");

            //Assert

            Assert.Equal("Hello, Ben Spark", fullName);
            Assert.Contains("ben Spark", fullName);
            Assert.Contains("Hello",fullName);
            Assert.StartsWith("Hello", fullName);
            Assert.EndsWith("Spark", fullName);
            Assert.Matches("Hello, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", fullName);
        }

        [Fact]
        public void GreetMessage_NotGreete_ReturnNull()
        {
            //arrange

            //act

            //assert

            Assert.Null(customer.GreetMessage);

        }

        [Fact]
        public void OddRager_InputMinandMaxRange_ReturnDiscountInRage()
        {
            int result = customer.Discount;
            Assert.InRange(result, 10, 25);
                   }

        [Fact]
        public void GreetMessag_GreetWithoutLastName_ReturnsNotNull()
        {
            customer.GreetAndCombinaName("ben", "");

            Assert.NotNull(customer.GreetMessage);
            Assert.False(string.IsNullOrEmpty(customer.GreetMessage));
        }
        [Fact]
        public void GreetMessag_GreetWithoutLastName_ThrowsException()
        {
            var exceptionDetails = Assert.Throws<ArgumentException>(() => customer.GreetAndCombinaName(string.Empty, "Spark"));
            Assert.Equal("Empty First Name", exceptionDetails.Message);
            Assert.Throws<ArgumentException>(() => customer.GreetAndCombinaName(string.Empty, "Spark"));


        }

        [Fact]
        public void CustomerType_CreateCustomerWithLessThan100Order_ReturnBasicCustomer()
        {
            customer.OrderTotal = 10;
            var result = customer.GetCustomerDetails();
            Assert.IsType<BasicCustomer>(result);
        }
        [Fact]
        public void CustomerType_CreateCustomerWithMoreThan100Order_ReturnBasicCustomer()
        {
            customer.OrderTotal = 110;
            var result = customer.GetCustomerDetails();
            Assert.IsType<PlaninumCustomer>(result);
        }


    }
}
