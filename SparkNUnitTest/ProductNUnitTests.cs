﻿using NUnit.Framework;
using Sparky;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkNUnitTest
{
    [TestFixture]
    public class ProductNUnitTests
    {
        [Test]
        public void GetProductPrice_PlatiniumCustomer_ReturnPriceWith20iscont()
        { 
            Product product = new Product() { Price = 50 };
            var result = product.GetPrice( new Customer() { IsPlatinum = true});
            Assert.That(result, Is.EqualTo(40));
        
        }
    }
}
