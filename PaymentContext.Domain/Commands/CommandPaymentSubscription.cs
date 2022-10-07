using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.Enums;
using PaymentContext.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Domain.Commands
{
    public abstract class CommandPaymentSubscription : Notifiable<Notification>, ICommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StudentDocumentNumber { get; set; }
        public EDocumentType StudentDocumentType { get; set; }
        public string StudentEmailAddress { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public DateTime? ExpireDate { get; set; }
        public string PaymentNumber { get; set; }
        public DateTime PaidDate { get; set; }
        public DateTime PaymentExpireDate { get; set; }
        public decimal Total { get; set; }
        public decimal TotalPaid { get; set; }
        public string Payer { get; set; }
        public string PayerDocumentNumber { get; set; }
        public EDocumentType PayerDocumentType { get; set; }
        public string PayerStreet { get; set; }
        public string PayerNumber { get; set; }
        public string PayerNeighborhood { get; set; }
        public string PayerCity { get; set; }
        public string PayerState { get; set; }
        public string PayerCountry { get; set; }
        public string PayerZipCode { get; set; }
        public string PayerEmailAddress { get; set; }
        public void Validate()
        {
            static string setKey(dynamic property) => new StringBuilder()
                .Append(nameof(CommandPaymentSubscription))
                .Append('.')
                .Append(nameof(property))
                .ToString();


            AddNotifications(new Contract<CommandPaymentSubscription>()
                .Requires()
                .IsGreaterOrEqualsThan(FirstName, 3, setKey(FirstName))
                .IsLowerOrEqualsThan(FirstName, 40, setKey(LastName))
                );
        }
    }
}
