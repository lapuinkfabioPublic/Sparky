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
    public class CustomerNUnitTest
    {
        private Customer customer;
        [SetUp]
        public void Setup()
        {
            customer = new Customer();
        }

        [Test]
        public void CombinaName_InputFirstANdLastName_ReturnFullName() {

            //Arrange
            
            //Act
            string fullName = customer.GreetAndCombinaName("Ben", "Spark");

            //Assert

            Assert.That(fullName, Is.EqualTo("Hello, Ben Spark"));
            Assert.Equals(fullName, "Hello, Ben Spark");
            Assert.That(fullName , Does.ContainValue("ben Spark").IgnoreCase);
            Assert.That(fullName, Does.StartWith("Hello"));
            Assert.That(fullName, Does.EndWith("Spark"));
            Assert.That(fullName, Does.Match("Hello, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+"));
        }

        [Test]
        public void GreetMessage_NotGreete_ReturnNull() {
            //arrange

            //act

            //assert

            A2.Assert.IsNull(customer.GreetMessage);

        }

        [Test]
        public void OddRager_InputMinandMaxRange_ReturnValidOddNumberRage() {
            Calculator calc = new();
            List<int> expectedOddRage = new List<int>() { 5, 7, 9 };
            //act
            List<int> result = calc.GetOddRange(5, 10);


            Assert.Multiple(() =>
            {
                Assert.That(result, Is.EquivalentTo(expectedOddRage));
                Assert.Equals(expectedOddRage, result);
                Assert.That(result, Does.Contain(7));
                Assert.That(result, Is.Not.Empty);

                Assert.That(result.Count, Has.No.Member(6));
                Assert.That(result, Is.Ordered.Descending);
                Assert.That(result, Is.Unique);
            });
            //Assert


        }

        [Test]
        public void OddRager_InputMinandMaxRange_ReturnDiscountInRage()
        {
            int result = customer.Discount;
            Assert.That(result, Is.InRange(10, 25));

        }

        [Test]
        public void GreetMessag_GreetWithoutLastName_ReturnsNotNull() {
            customer.GreetAndCombinaName("ben", "");
            
            A2.Assert.IsNotNull(customer.GreetMessage);
            A2.Assert.IsFalse(string.IsNullOrEmpty(customer.GreetMessage));
        }
        [Test]
        public void GreetMessag_GreetWithoutLastName_ThrowsException()
        {
            var exceptionDetails = Assert.Throws<ArgumentException>(() => customer.GreetAndCombinaName(string.Empty, "Spark"));
            Assert.Equals("Empty First Name",exceptionDetails.Message);
            Assert.That(() => customer.GreetAndCombinaName("", "spark"), Throws.ArgumentException.With.Message.EqualTo("Empty First Name"));


            Assert.Throws<ArgumentException>(() => customer.GreetAndCombinaName(string.Empty, "Spark"));
            Assert.That(() => customer.GreetAndCombinaName("", "spark"), Throws.ArgumentException.With.Message.EqualTo("Empty First Name"));


        }

        [Test]
        public void CustomerType_CreateCustomerWithLessThan100Order_ReturnBasicCustomer() {
            customer.OrderTotal = 10;
            var result = customer.GetCustomerDetails();
            Assert.That(result, Is.TypeOf<BasicCustomer>());
        }
        [Test]
        public void CustomerType_CreateCustomerWithMoreThan100Order_ReturnBasicCustomer()
        {
            customer.OrderTotal = 10;
            var result = customer.GetCustomerDetails();
            Assert.That(result, Is.TypeOf<PlaninumCustomer>());
        }


      }
    }
