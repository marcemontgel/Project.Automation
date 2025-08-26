using OpenQA.Selenium;

namespace Automator.Project.Important.Domain.Page
{
    public class BookPage
    {
        /// <summary>
        /// IFrame Method CreditCard
        /// </summary>
        public By IFrameMethodCreditCard
            => By.XPath("//*[@id='payment-element']/div/iframe[1]");

        /// <summary>
        /// Input Credit Card
        /// </summary>
        public By InputCreditCard
           => By.Id("Field-numberInput");

        /// <summary>
        /// Input Expiry
        /// </summary>
        public By InputExpiry
           => By.Id("Field-expiryInput");

        /// <summary>
        /// Input Code Verification
        /// </summary>
        public By InputCodeVerification
           => By.Id("Field-cvcInput");

        /// <summary>
        /// Button Pay Now
        /// </summary>
        public By ButtonPayNow
            => By.Id("submit");
    }
}
