using Flunt.Notifications;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Repositories;
using PaymentContext.Domain.Services;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Commands;
using PaymentContext.Shared.Handlers;

namespace PaymentContext.Domain.Handlers
{
    public class PaymentHandler : 
        Notifiable<Notification>, 
        IHandler<CommandPayPalPaymentSubscription>, 
        IHandler<CommandCredtiCardPaymentSubscription>, 
        IHandler<CommandBoletoPaymentSubscription>
    {
        private readonly ISudentRepository _studentRepository;
        private readonly IEmailService _emailService;

        public PaymentHandler(ISudentRepository studentRepository, IEmailService emailService)
        {
            _studentRepository = studentRepository;
            _emailService = emailService;
        }

        public ICommandResult Handle(CommandPayPalPaymentSubscription command)
        {
            // Fail fast
            command.Validate();
            if(!command.IsValid)
            {
                return new CommandResult(false, $"{nameof(command)} error.");
            }

            if (_studentRepository.EmailExists(command.StudentEmailAddress))
            {
                var key = nameof(Handle) + '.' + nameof(Handle) + '.' + nameof(command);
                AddNotification(key, "Email already exists.");
            }
            
            if (_studentRepository.DocumentExists(command.StudentDocumentNumber))
            {
                var key = nameof(Handle) + '.' + nameof(Handle) + '.' + nameof(command);
                AddNotification(key, "Document already exists.");
            }

            var address = new Address(command.Street, command.Number, command.Neighborhood, command.City, command.State, command.Country, command.ZipCode);
            var document = new Document(command.StudentDocumentNumber, command.StudentDocumentType);
            var email = new Email(command.StudentEmailAddress);
            var name = new Name(command.FirstName, command.LastName);

            var payerAddress = new Address(command.PayerStreet, command.PayerNumber, command.PayerNeighborhood, command.PayerCity, command.PayerState, command.PayerCountry, command.PayerZipCode);
            var payerDocument = new Document(command.PayerDocumentNumber, command.PayerDocumentType);
            var payerEmail = new Email(command.PayerEmailAddress);
            
            var payment = new PayPalPayment(
                command.TransactionCode,
                command.PaidDate,
                command.PaymentExpireDate,
                command.Total,
                command.TotalPaid,
                command.Payer,
                payerDocument,
                payerAddress,
                payerEmail
                );
            
            var subscription = new Subscription();
            subscription.AddPayment(payment);

            var student = new Student(name, document, email, address);
            student.AddSubscription(subscription);

            AddNotifications(address, document, email, name, payerAddress, payerDocument, payerEmail, payment, subscription, student);

            if (IsValid)
            {
                return new CommandResult(false, $"{nameof(command)} error.");
            }

            _studentRepository.Create(student);

            _emailService.SendEmail("xpto@email.com", "self@email.com", "New student", $"Welcome {student.Name}");

            return new CommandResult(true, "Student Created.");
        }

        public ICommandResult Handle(CommandBoletoPaymentSubscription command)
        {
            // Fail fast
            command.Validate();
            if (!command.IsValid)
            {
                return new CommandResult(false, $"{nameof(command)} error.");
            }

            if (_studentRepository.EmailExists(command.StudentEmailAddress))
            {
                var key = nameof(Handle) + '.' + nameof(Handle) + '.' + nameof(command);
                AddNotification(key, "Email already exists.");
            }

            if (_studentRepository.DocumentExists(command.StudentDocumentNumber))
            {
                var key = nameof(Handle) + '.' + nameof(Handle) + '.' + nameof(command);
                AddNotification(key, "Document already exists.");
            }

            var address = new Address(command.Street, command.Number, command.Neighborhood, command.City, command.State, command.Country, command.ZipCode);
            var document = new Document(command.StudentDocumentNumber, command.StudentDocumentType);
            var email = new Email(command.StudentEmailAddress);
            var name = new Name(command.FirstName, command.LastName);

            var payerAddress = new Address(command.PayerStreet, command.PayerNumber, command.PayerNeighborhood, command.PayerCity, command.PayerState, command.PayerCountry, command.PayerZipCode);
            var payerDocument = new Document(command.PayerDocumentNumber, command.PayerDocumentType);
            var payerEmail = new Email(command.PayerEmailAddress);

            var payment = new BoletoPayment(
                command.BarCode,
                command.BoletoNumber,
                command.PaidDate,
                command.PaymentExpireDate,
                command.Total,
                command.TotalPaid,
                command.Payer,
                payerDocument,
                payerAddress,
                payerEmail
                );

            var subscription = new Subscription();
            subscription.AddPayment(payment);

            var student = new Student(name, document, email, address);
            student.AddSubscription(subscription);

            AddNotifications(address, document, email, name, payerAddress, payerDocument, payerEmail, payment, subscription, student);

            if (IsValid)
            {
                return new CommandResult(false, $"{nameof(command)} error.");
            }

            _studentRepository.Create(student);

            _emailService.SendEmail("xpto@email.com", "self@email.com", "New student", $"Welcome {student.Name}");

            return new CommandResult(true, "Student Created.");
        }

        public ICommandResult Handle(CommandCredtiCardPaymentSubscription command)
        {
            // Fail fast
            command.Validate();
            if (!command.IsValid)
            {
                return new CommandResult(false, $"{nameof(command)} error.");
            }

            if (_studentRepository.EmailExists(command.StudentEmailAddress))
            {
                var key = nameof(Handle) + '.' + nameof(Handle) + '.' + nameof(command);
                AddNotification(key, "Email already exists.");
            }

            if (_studentRepository.DocumentExists(command.StudentDocumentNumber))
            {
                var key = nameof(Handle) + '.' + nameof(Handle) + '.' + nameof(command);
                AddNotification(key, "Document already exists.");
            }

            var address = new Address(command.Street, command.Number, command.Neighborhood, command.City, command.State, command.Country, command.ZipCode);
            var document = new Document(command.StudentDocumentNumber, command.StudentDocumentType);
            var email = new Email(command.StudentEmailAddress);
            var name = new Name(command.FirstName, command.LastName);

            var payerAddress = new Address(command.PayerStreet, command.PayerNumber, command.PayerNeighborhood, command.PayerCity, command.PayerState, command.PayerCountry, command.PayerZipCode);
            var payerDocument = new Document(command.PayerDocumentNumber, command.PayerDocumentType);
            var payerEmail = new Email(command.PayerEmailAddress);

            var payment = new CreditCardPayment(
                command.CardHolderName,
                command.CardNumber,
                command.LastTransactionNumber,
                command.PaidDate,
                command.PaymentExpireDate,
                command.Total,
                command.TotalPaid,
                command.Payer,
                payerDocument,
                payerAddress,
                payerEmail
                );

            var subscription = new Subscription();
            subscription.AddPayment(payment);

            var student = new Student(name, document, email, address);
            student.AddSubscription(subscription);

            AddNotifications(address, document, email, name, payerAddress, payerDocument, payerEmail, payment, subscription, student);

            if (IsValid)
            {
                return new CommandResult(false, $"{nameof(command)} error.");
            }

            _studentRepository.Create(student);

            _emailService.SendEmail("xpto@email.com", "self@email.com", "New student", $"Welcome {student.Name}");

            return new CommandResult(true, "Student Created.");
        }
    }
}
