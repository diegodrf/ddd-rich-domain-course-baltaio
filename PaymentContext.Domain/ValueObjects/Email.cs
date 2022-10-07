using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Email: ValueObject
    {
        public Email(string address)
        {
            Address = address;

            var key = $"{nameof(Email)}.{nameof(Address)}";
            AddNotifications(new Contract<Email>()
                .Requires()
                .IsEmail(Address, key)
                .IsNullOrEmpty(Address, key));
        }
        public string Address { get; set; }
    }
}
