using NUnit.Framework;
using Sparky;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkNUnitTest
{

    [TestFixture]
    public class CustomerNUnitTest
    {
        [Test]
        public void CombinaName_InputFirstANdLastName_ReturnFullName() {

            //Arrange
            var customer = new Customer();
            //Act
            string fullName = customer.GreetAndCombinaName("Ben", "Spark");

            //Assert

            Assert.That(fullName, Is.EqualTo("Hello, Ben Spark"));
            Assert.Equals(fullName, "Hello, Ben Spark");
            Assert.That(fullName , Does.ContainValue("ben Spark").IgnoreCase);
            Assert.That(fullName, Does.StartWith("Hello"));
            Assert.That(fullName, Does.EndWith("Spark"));
        }

    }
}
