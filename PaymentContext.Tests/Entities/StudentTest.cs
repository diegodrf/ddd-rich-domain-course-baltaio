using Flunt.Notifications;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Tests.Entities
{
    [TestClass]
    public class StudentTest
    {
        [TestMethod]
        public void TestStudent()
        {
            var sb = new StringBuilder();
            var allNotifications = new List<Notification>();

            var name = new Name("Diego", "Faria");
            if (!name.IsValid)
                allNotifications.AddRange(name.Notifications);

            var document = new Document("12345678901", Domain.Enums.EDocumentType.CPF);
            var email = new Email(null);
            if (email.IsValid)
                allNotifications.AddRange(email.Notifications);

            foreach (var notification in allNotifications)
            {
                var messge = $"{notification.Key} -> {notification.Message}";
                sb.AppendLine(messge);
            }
            Console.WriteLine(sb.ToString());

            var student = new Student(name, document, email);

        }
    }
}
