using PaymentContext.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Tests.Mocks
{
    public class EmailServiceMock : IEmailService
    {
        public void SendEmail(string to, string from, string subject, string body)
        {
            
        }
    }
}
