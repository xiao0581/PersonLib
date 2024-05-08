using Microsoft.VisualStudio.TestTools.UnitTesting;
using PersonLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonLib.Tests
{
    [TestClass()]
    public class PersonTests
    {
        [TestMethod()]
        public void validateNameTest()
        {
           Person p = new Person { Name = null, Age = 19, Bpm = 68 };
           
            Assert.ThrowsException<ArgumentNullException>(() => p.validateName());
            Person p1 = new Person { Name = "", Age = 19, Bpm = 68 };
            Assert.ThrowsException<ArgumentException>(() => p1.validateName());

        }

        [TestMethod()]
        public void validateBirthYearTest()
        {
           Person p = new Person { Name = "xiao", Age = -1, Bpm = 68 };
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => p.validateBirthYear());
        }
    }
}