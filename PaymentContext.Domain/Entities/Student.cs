using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities
{
    public class Student: Entity
    {
        private readonly ICollection<Subscription> _subscriptions;
        public Student(Name name, Document document, Email email, Address? address = null)
        {
            Name = name;
            Document = document;
            Email = email;
            Address = address;
            _subscriptions = new List<Subscription>();
        }

        public Name Name { get; set; }
        public Document Document { get; private set; }
        public Email Email { get; set; }
        public Address? Address { get; private set; }
        public IReadOnlyCollection<Subscription> Subscriptions
        {
            get
            {
                return _subscriptions.ToArray();
            }
        }

        public void AddSubscription(Subscription subscription)
        {
            foreach(var _ in _subscriptions.Where(s => s.Active == true))
            {
                _.Inactive();
            }

            _subscriptions.Add(subscription);
        }
    }
}
