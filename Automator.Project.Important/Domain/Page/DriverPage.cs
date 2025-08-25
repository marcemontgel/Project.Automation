using OpenQA.Selenium;

namespace Automator.Project.Important.Domain.Page
{
    public class DriverPage
    {
        public By InputNameCostumer
            => By.Id("client_name");

        public By InputTelephoneCostumer
            => By.XPath("//*[@id='phone_fold']//*[@class='form-field__form-input']");

        public By InputEmailCostumer
            => By.Id("client_email");

        public By ButtonReservationNow
            => By.XPath("//*[@class='transaction__inner']//button");
    }
}
