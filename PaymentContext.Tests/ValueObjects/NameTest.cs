using PaymentContext.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Tests.ValueObjects
{
    [TestClass]
    public class NameTest
    {
        [TestMethod]
        [DataTestMethod]
        [DataRow("j")]
        public void ShouldReturnErrorIfFirstNameIsLowerThanMinimalLength(string firstName)
        {
            var name = new Name(firstName, "Souza");
            Assert.IsFalse(name.IsValid);
        }
        [TestMethod]
        public void ShouldReturnErrorIfFirstNameIsGreaterThanMaximumLength()
        {
            var longName = LongStringGenerator(41);
            var name = new Name(longName, "ddd");
            Assert.IsFalse(name.IsValid);
        }
        [TestMethod]
        [DataTestMethod]
        [DataRow("j")]
        public void ShouldReturnErrorIfLastNameIsLowerThanMinimalLength(string lastName)
        {
            var name = new Name("Test", lastName);
            Assert.IsFalse(name.IsValid);
        }
        [TestMethod]
        public void ShouldReturnErrorIfLastNameIsGreaterThanMaximumLength()
        {
            var longName = LongStringGenerator(41);
            var name = new Name("Joao", longName);
            Assert.IsFalse(name.IsValid);
        }
        [TestMethod]
        public void ShouldReturnErrorIfFirstNameIsNull()
        {
            var name = new Name(null, "Souza");
            Assert.IsFalse(name.IsValid);
        }
        [TestMethod]
        public void ShouldReturnErrorIfLastNameIsNull()
        {
            var name = new Name("Diego", null);
            Assert.IsFalse(name.IsValid);
        }
        [TestMethod]
        public void ShouldReturnErrorIfFirstNameIsEmpty()
        {
            var name = new Name("", "Souza");
            Assert.IsFalse(name.IsValid);
        }
        [TestMethod]
        public void ShouldReturnErrorIfLastNameIsEmpty()
        {
            var name = new Name("Diego", "");
            Assert.IsFalse(name.IsValid);
        }

        private string LongStringGenerator(int size)
        {
            var text = new StringBuilder();
            for(var i = 0; i < size; i++)
            {
                text.Append('a');
            }
            return text.ToString();
        }
    }
}
