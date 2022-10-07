using PaymentContext.Domain.Entities;
using PaymentContext.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Tests
{
    [TestClass]
    public class StudentTest
    {
        [TestMethod]
        public void TestStudent()
        {
            var student = new Student(
                new Name("Diego", "Faria"), 
                new Document("12345678901", Domain.Enums.EDocumentType.CPF), 
                new Email("diego@email.com")
                );
        }
    }
}
