using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Domain.ValueObjects
{
    public class Name: ValueObject
    {
        public const int minimalFirstNameLength = 3;
        public const int MaximumFirstNameLength = 40;
        public const int minimalLastNameLength = 3;
        public const int MaximumLastNameLength = 40;
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications(new Contract<Name>()
                .Requires()
                .IsNotNullOrEmpty(FirstName, "Name.FirstName")
                .IsGreaterOrEqualsThan(FirstName, minimalFirstNameLength, "Name.FirstName")
                .IsLowerOrEqualsThan(FirstName, MaximumFirstNameLength, "Name.FirstName")
                .IsNotNullOrEmpty(LastName, "Name.LastName")
                .IsGreaterOrEqualsThan(LastName, minimalFirstNameLength, "Name.LastName")
                .IsLowerOrEqualsThan(LastName, MaximumFirstNameLength, "Name.LastName")
                );
           
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
    }
}
