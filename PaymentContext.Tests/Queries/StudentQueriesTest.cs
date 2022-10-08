using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Queries;
using PaymentContext.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Tests.Queries
{
    [TestClass]
    public class StudentQueriesTest
    {
        private readonly ICollection<Student> _students;

        public StudentQueriesTest()
        {
            _students = new List<Student>();
            PopulateStudentList();
        }

        [TestMethod]
        public void ShouldReturnNullWhenDocumentNumberNotExists()
        {
            var expression = StudentQueries.GetStudentByDocument("10000000000");
            var student = _students.AsQueryable().Where(expression).FirstOrDefault();
            Assert.IsNull(student);
        }

        [TestMethod]
        public void ShouldReturnAStudentWhenDocumentNumberExists()
        {
            var expression = StudentQueries.GetStudentByDocument("00000000001");
            var student = _students.AsQueryable().Where(expression).FirstOrDefault();
            Assert.IsNotNull(student);
        }

        private void PopulateStudentList()
        {
            for(var i = 0; i < 10; i++)
            {
                var name = new Name("Joao", "Silva");
                var document = new Document($"0000000000{i}", Domain.Enums.EDocumentType.CPF);
                var email = new Email($"{name}@email.com");
                var student = new Student(name, document, email);
                _students.Add(student);
            }
        }
    }
}
