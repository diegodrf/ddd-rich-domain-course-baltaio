using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handlers;
using PaymentContext.Tests.Mocks;

namespace PaymentContext.Tests.Handlers
{
    [TestClass]
    public class PaymentHandlerTest
    {
        [TestMethod]
        public void ShouldReturnErrorWhenDocumentNumberAlreadyExists()
        {
            var command = new CommandBoletoPaymentSubscription();
            command.BarCode= "111111";
            command.BoletoNumber= "111111";
            command.FirstName= "Diego";
            command.LastName= "Faria";
            command.StudentDocumentNumber= "00000000000";
            command.StudentDocumentType= EDocumentType.CPF;
            command.StudentEmailAddress= "d@d.com";
            command.Street= "Rua";
            command.Number= "123";
            command.Neighborhood= "Bairro";
            command.City= "Rio";
            command.State= "RJ";
            command.Country= "BR";
            command.ZipCode= "12221212";
            command.ExpireDate = null;
            command.PaymentNumber= "12312234";
            command.PaidDate= DateTime.Now;
            command.PaymentExpireDate= DateTime.Now.AddDays(5);
            command.Total= 100.00M;
            command.TotalPaid= 100.00M;
            command.Payer= "Diego Faria";
            command.PayerDocumentNumber= "00000000000";
            command.PayerDocumentType= EDocumentType.CPF;
            command.PayerStreet= "Rua";
            command.PayerNumber= "123";
            command.PayerNeighborhood= "Bairro";
            command.PayerCity= "Rio";
            command.PayerState= "RJ";
            command.PayerCountry= "BR";
            command.PayerZipCode= "122212221";
            command.PayerEmailAddress= "d@d.com";

            var handler = new PaymentHandler(new StudentRepositoryMock(), new EmailServiceMock());
            handler.Handle(command);

            Assert.IsFalse(handler.IsValid);
        }
    }
}
