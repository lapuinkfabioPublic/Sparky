﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    public class Customer
    {
        public string GreetMessage { get; set; }
        public string GreetAndCombinaName(string firstName, string LastName) {
            GreetMessage = $"Hello, {firstName} {LastName}";
            return GreetMessage;
        }
    }
}
