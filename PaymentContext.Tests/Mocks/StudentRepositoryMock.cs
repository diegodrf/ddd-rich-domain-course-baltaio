using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Repositories;

namespace PaymentContext.Tests.Mocks
{
    public class StudentRepositoryMock : IStudentRepository
    {
        public void Create(Student student)
        {
            
        }

        public bool DocumentExists(string document)
        {
            if(document.StartsWith("00000000000"))
            {
                return true;
            }
            return false;
        }

        public bool EmailExists(string email)
        {
            return false;
        }
    }
}
