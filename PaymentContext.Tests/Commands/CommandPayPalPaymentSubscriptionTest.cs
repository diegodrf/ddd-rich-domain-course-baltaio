using PaymentContext.Domain.Commands;

namespace PaymentContext.Tests.Commands
{
    [TestClass]
    public class CommandPayPalPaymentSubscriptionTest
    {
        [TestMethod]
        public void SouldReturnErroWhenCommandPayPalPaymentSubscriptionHasNotification()
        {
            var command = new CommandPayPalPaymentSubscription()
            {
                FirstName = "J",
                LastName = "Faria"
            };
            
            command.Validate();
            
            Assert.IsFalse(command.IsValid);

        }
    }
}
