using Moq;
using Sparky;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SparkNUnitTest
{
    
    public class ProductXUnitTests
    {
        [Fact]
        public void GetProductPrice_PlatiniumCustomer_ReturnPriceWith20iscont()
        {
            Product product = new Product() { Price = 50 };
            var result = product.GetPrice(new Customer() { IsPlatinum = true });
            Assert.Equal( 40, result);

        }
        [Fact]
        public void GetProductPriceMOQAbuse_PlatiniumCustomer_ReturnPriceWith20iscont()
        {
            var customer = new Mock<ICustomer>();
            customer.Setup(u => u.IsPlatinum).Returns(true);

            Product product = new Product() { Price = 50 };
            var result = product.GetPrice(customer.Object);
            Assert.Equal( 40 , result);

        }
    }
}
