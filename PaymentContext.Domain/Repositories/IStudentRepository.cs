using PaymentContext.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Domain.Repositories
{
    public interface IStudentRepository
    {
        void Create(Student student);
        bool EmailExists(string email);
        bool DocumentExists(string document);
    }
}
