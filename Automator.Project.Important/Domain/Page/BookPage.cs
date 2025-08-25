using OpenQA.Selenium;

namespace Automator.Project.Important.Domain.Page
{
    public class BookPage
    {
        public By IFrameMethodCreditCard
            => By.XPath("//*[@id='payment-element']/div/iframe[1]");

        public By InputCreditCard
           => By.Id("Field-numberInput");

        public By InputExpiry
           => By.Id("Field-expiryInput");
        
        public By InputCodeVerification
           => By.Id("Field-cvcInput");

        public By ButtonPayNow
            => By.Id("submit");
    }
}
